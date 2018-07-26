using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SSLand {

    public class SecondStreetAPI{

        public const string USER_AGENT = "Mozilla/5.0 (iPad; COU OS 10_3_2 like Mac OS X) AppleWebKit/603.2.4 (KHTML, like Gecko) Mobile/14F89 Fril/6.7.1";
        public const string LOGIN_USER_AGENT = "reuse_store_release/3.0.5 CFNetwork/897.15 Darwin/17.5.0";

        public SecondStreetAPI()
        {
        }

        private class SecondStreetRawResponse
        {
            public bool error = true;
            public string response = "";
        }

        public Common.Account account;
        public SecondStreetAPI(string email, string password)
        {
            this.account = new Common.Account();
            this.account.email = email;
            this.account.password = password;
        }

        public SecondStreetAPI(Common.Account account){
            this.account = account;
        }

        //ログイン処理
        //ログインしても実はaccess_tokenとかは使用しない
        //ログイン後のクッキーだけが必要になる
        //購入前にログインを行う
        public bool trySecondStreetLogin(string email, string password) {
            string url = "https://auth.geonet.jp/authorize";
            string client_id = "f92a4aeb4d2d07e4b8471177246e7eac3f7bf287ff984c2f3219c18c71b9c302";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("response_type", "code");
            param.Add("redirect_uri", "https://www.2ndstreet.jp/index.php/api_2_0/appuserauth/login");
            param.Add("state", "state");
            param.Add("scope", "openid profile delivery geoinfo geomasterid");
            param.Add("client_id", client_id);
            //csrf取り出し
            var rawres = getSecondStreetAPI(url, param, SecondStreetAPI.LOGIN_USER_AGENT);
            var resjson = DynamicJson.Parse(rawres.response);
            string csrf_token = resjson.csrf_token;

            Dictionary<string, string> param2 = new Dictionary<string, string>();
            param2.Add("response_type", "code");
            param2.Add("redirect_uri", "https://www.2ndstreet.jp/index.php/api_2_0/appuserauth/login");
            param2.Add("client_id", client_id);
            param2.Add("csrf_token", csrf_token);
            param2.Add("user_action", "accept");
            param2.Add("state", "state");
            param2.Add("scope", "openid profile delivery geoinfo geomasterid");
            param2.Add("login_id", email);
            param2.Add("password", password);
            //302で自動的にリダイレクトする
            var rawres2 = postSecondStreetAPI(url, param2, SecondStreetAPI.LOGIN_USER_AGENT);
            try {
                var resjson2 = DynamicJson.Parse(rawres2.response);
                string access_token = resjson2.access_token;
                string refresh_token = resjson2.refresh_token;
                /*string token_type = resjson.token_type;
                int expires_in = (int)resjson.expires_in;
                string geo_id = resjson.geo_id;
                string nickname = resjson.nickname;
                string geo_master_id = resjson.geo_master_id;*/
                Log.Logger.Info("セカンドストリートログイン成功");
                return true;
            } catch (Exception ex) {
                Log.Logger.Error("セカンドストリートログイン失敗");
                return false;
            }
        }
        public void addItemToCartWeb(string shops_id, string goods_id) {
            string url2 = "https://www.2ndstreet.jp/cart/updateForApp";
            Dictionary<string, string> param2 = new Dictionary<string, string>();
            param2.Add("releaseurl", "1");
            param2.Add("shopsId", shops_id);
            param2.Add("goodsId", goods_id);
            param2.Add("num", "1");
            param2.Add("sp", "on");
            param2.Add("ver", "3.0.5");
            var rawres2 = getSecondStreetAPI(url2, param2, SecondStreetAPI.USER_AGENT);
        }

        public bool buyItemByDaibiki(string shops_id, string goods_id) {
            try {
                //カートに追加
                addItemToCartWeb(shops_id, goods_id);
                //ポイント消費確認ページへ
                string url = "https://www.2ndstreet.jp/reduce";
                var rawres = getSecondStreetAPI(url, new Dictionary<string, string>(), SecondStreetAPI.USER_AGENT);
                //ポイント消費確定・支払い方法ページへ
                string url2 = "https://www.2ndstreet.jp/reduce/next";
                var param2 = new Dictionary<string, string>();
                param2.Add("point", "");
                param2.Add("pointUsageType", "0");
                param2.Add("couponsId", "");
                param2.Add("isAgree", "1");
                var rawres2 = postSecondStreetAPI(url2, param2, SecondStreetAPI.USER_AGENT);
                //支払い方法確定・最終確認ページへ
                //HTMLから住所情報およびトークンを取り出す
                string html = System.Web.HttpUtility.HtmlDecode(rawres2.response);//HTML特殊文字列をデコード
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                string url3 = "https://www.2ndstreet.jp/delivery/check";
                var param3 = new Dictionary<string, string>();
                param3.Add("token_api_key", doc.DocumentNode.SelectSingleNode("//input[@name=\"token_api_key\"]").GetAttributeValue("value", ""));
                param3.Add("token_url", "https://api.veritrans.co.jp/4gtoken");
                param3.Add("paymentType", "2"); //代引き
                param3.Add("myCard", "0");
                param3.Add("cardKind", "1");
                param3.Add("luecaSelect", "on");
                param3.Add("luecaNewNo", "");
                param3.Add("luecaPinCode", "");
                param3.Add("luecaNewNo01", "");
                param3.Add("luecaNewNo02", "");
                param3.Add("luecaNewNo03", "");
                param3.Add("luecaNewNo04", "");
                param3.Add("myAddress", "0");
                var node = doc.DocumentNode.SelectSingleNode("//div[@class=\"flow_input my_ad_input my_ad_form1\"]");
                param3.Add("delvLastName_0", node.SelectSingleNode("//input[@name=\"delvLastName_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvFirstName_0", node.SelectSingleNode("//input[@name=\"delvFirstName_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvFirstKana_0", node.SelectSingleNode("//input[@name=\"delvFirstKana_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvLastKana_0", node.SelectSingleNode("//input[@name=\"delvLastKana_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvZipCode_0", node.SelectSingleNode("//input[@name=\"delvZipCode_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvPrefectural_0", node.SelectSingleNode("//option[@selected]").GetAttributeValue("value", ""));
                param3.Add("delvAddress1_0", node.SelectSingleNode("//input[@name=\"delvAddress1_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvTelNo1_0", node.SelectSingleNode("//input[@name=\"delvTelNo1_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvTelNo2_0", node.SelectSingleNode("//input[@name=\"delvTelNo2_0\"]").GetAttributeValue("value", ""));
                param3.Add("delvTelNo3_0", node.SelectSingleNode("//input[@name=\"delvTelNo3_0\"]").GetAttributeValue("value", ""));
                var node2 = doc.DocumentNode.SelectSingleNode("//div[@class=\"ordermail_input\"]");
                param3.Add("delvMail", node2.SelectSingleNode("//input[@name=\"delvMail\"]").GetAttributeValue("value", ""));
                param3.Add("delvMailConf", node2.SelectSingleNode("//input[@name=\"delvMailConf\"]").GetAttributeValue("value", ""));
                param3.Add("delvMgznReceiveType", "1");
                param3.Add("delvMgznOnline", "0");
                param3.Add("delvMgznShop", "0");
                param3.Add("deliveryType", "1");
                param3.Add("deliveryDate", "0");
                param3.Add("deliveryTimeZone", "0");
                param3.Add("isAgree", "1");
                var rawres3 = postSecondStreetAPI(url3, param3, SecondStreetAPI.USER_AGENT);
                //注文確定へ
                //HTMLからトークン取り出す
                HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
                doc2.LoadHtml(rawres3.response);
                var param4 = new Dictionary<string, string>();
                param4.Add("token", doc2.DocumentNode.SelectSingleNode("//input[@name=\"token\"]").GetAttributeValue("value", ""));
                string url4 = "https://www.2ndstreet.jp/finish/index/ios_app";
                var rawres4 = postSecondStreetAPI(url4, param4, SecondStreetAPI.USER_AGENT);
                Console.WriteLine(rawres4.response);
                Log.Logger.Info("代引き購入成功");
                return true;
            } catch (Exception ex) {
                Log.Logger.Error("代引き購入失敗");
                return false;
            }
        }
        public void getGoodsDetail(string goods_id, string shops_id) {
            /*string url = "https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getGoodsDetail";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("goods_id", goods_id);
            param.Add("shops_id", shops_id);
            var rawres = postSecondStreetAPI(url, param, SecondStreetAPI.LOGIN_USER_AGENT);
            Console.WriteLine(rawres.response);*/
        }
        //新着アイテムの取得
        //リクエストになげるbrand_idは0埋めの6桁でなければならないので注意
        public List<SecondStreetListItem> postNewItem(int brand_id, int category_id = -1, string category_type = "") {
            List<SecondStreetListItem> rst = new List<SecondStreetListItem>();
            string url = "https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getGoodsByParams";
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (category_id > 0) param.Add("category_id", category_id.ToString("000000"));
            if (!string.IsNullOrEmpty(category_type)) param.Add("category_type", category_type.ToString());
            param.Add("brand_id", string.Join(",", brand_id.ToString("000000")));
            param.Add("count", "30");
            param.Add("offset", "0");
            param.Add("is_small_result", "0");//1だと詳細情報得られない
            param.Add("order", "1");//新着順
            var rawres = postSecondStreetAPI(url, param, SecondStreetAPI.LOGIN_USER_AGENT);
            try {
                dynamic resjson = DynamicJson.Parse(rawres.response);
                foreach (var itemjson in resjson.value){
                    rst.Add(new SecondStreetListItem(itemjson));
                }
                return rst;
            }catch (Exception ex){
                Log.Logger.Error("セカンドストリートタイムラインjsonパース失敗");
                return rst;
            }
        }

        private SecondStreetRawResponse postSecondStreetAPI(string url, Dictionary<string, string> param, string UserAgent) {
            SecondStreetRawResponse res = new SecondStreetRawResponse();
            try {
                string text = "";
                List<string> paramstr = new List<string>();
                int num = 0;
                foreach (KeyValuePair<string, string> p in param) {
                    string k = Uri.EscapeDataString(p.Key);
                    string v = Uri.EscapeDataString(p.Value);
                    if (num != 0) text += "&";
                    text = text + (k + "=" + v);
                    num++;
                }
                byte[] bytes = Encoding.ASCII.GetBytes(text);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.UserAgent = UserAgent;
                req.Method = "POST";
                //リクエストヘッダを付加
                req.ContentType = "application/x-www-form-urlencoded;";
                req.Accept = "gzip, deflate";
                req.ContentLength = (long)bytes.Length;
                //クッキーコンテナの追加
                req.CookieContainer = this.cc;
                //タイムアウト設定
                req.Timeout = 5000;
                //POST
                string content = "";
                var task = Task.Factory.StartNew(() => executePostRequest(ref req, bytes));
                task.Wait(10000);
                if (task.IsCompleted)
                    content = task.Result;
                else
                    throw new Exception("Timed out");
                if (string.IsNullOrEmpty(content)) throw new Exception("webrequest error");
                res.error = false;
                res.response = content;
                Log.Logger.Info("SecondStreetPOSTリクエスト成功");
                req.Abort();
                return res;
            } catch (Exception e) {
                return res;
                Log.Logger.Error("SecondStreetPOSTリクエスト失敗");
            }
        }

        //FrilAPIをGETでたたく
        private SecondStreetRawResponse getSecondStreetAPI(string url, Dictionary<string, string> param, string UserAgent)
        {
            SecondStreetRawResponse res = new SecondStreetRawResponse();
            try
            {
                //url = Uri.EscapeUriString(url);//日本語などを％エンコードする
                //パラメータをURLに付加 ?param1=val1&param2=val2...
                url += "?";
                List<string> paramstr = new List<string>();
                foreach (KeyValuePair<string, string> p in param)
                {
                    string k = Uri.EscapeDataString(p.Key);
                    string v = Uri.EscapeDataString(p.Value);
                    paramstr.Add(k + "=" + v);
                }
                url += string.Join("&", paramstr);
                //HttpWebRequestの作成
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.CookieContainer = this.cc;
                req.UserAgent = UserAgent;
                req.Method = "GET";
                //結果取得
                string content = "";
                var task = Task.Factory.StartNew(() => executeGetRequest(req));
                task.Wait(10000);
                if (task.IsCompleted)
                    content = task.Result;
                else
                    throw new Exception("Timed out");
                if (string.IsNullOrEmpty(content)) throw new Exception("webrequest error");
                res.error = false;
                res.response = content;
                Log.Logger.Info("SecondStreetGETリクエスト成功");
                return res;
            }
            catch (Exception e)
            {
                Log.Logger.Error("SecondStreetGETリクエスト失敗");
                return res;
            }
        }
        private string executeGetRequest(HttpWebRequest req)
        {
            try
            {
                HttpWebResponse webres = (HttpWebResponse)req.GetResponse();
                Stream s = webres.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string content = sr.ReadToEnd();
                return content;
            }
            catch
            {
                return "";
            }
        }
        private string executePostRequest(ref HttpWebRequest req, byte[] bytes)
        {
            try
            {
                using (Stream requestStream = req.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
                //結果取得
                string result = "";
                using (Stream responseStream = req.GetResponse().GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch(WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream)) {
                    Console.WriteLine(reader.ReadToEnd());
                }
                return "";
            }
        }
        public CookieContainer cc = new CookieContainer();

        }
    }
