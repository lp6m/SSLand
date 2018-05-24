using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Net;
using Codeplex.Data;
using System.Media;

namespace SSLand
{
    public partial class MainForm : Form
    {
        WebClient webClient = new WebClient();
        private const int MAX_PANEL_NUM = 20;//タイムラインに表示する商品数
        List<SecondStreetListItem> bindlist = new List<SecondStreetListItem>();//タイムラインにバインドされている商品
        List<SecondStreetListItem> oldlist = new List<SecondStreetListItem>(); //1回前のリクエストで取得した商品リスト(重複を避ける)
        List<SecondStreetListItem> addlist = new List<SecondStreetListItem>(); //GUI更新時にタイムラインに追加すべき商品リスト

        string agent = "reuse_store_release/3.0.2 CFNetwork/811.5.4 Darwin/16.7.0";
        public MainForm()
        {
            InitializeComponent();
        }
        static public SecondStreetAPI api;

        private void アカウント管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form account_form = new Account();
            account_form.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            new SettingsDBHelper().onCreate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "ブランド名取得中";
            //string jsonstr = "";
            //byte[] bytes = webClient.DownloadData("https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods");
            //jsonstr = Encoding.UTF8.GetString(bytes);
            //Console.WriteLine(jsonstr);
            //DownloadAsync();
            postNewBrand();
            label1.Text ="待機中";
        }
        //ブランド情報の取得
        private List<SecondStreetListBrand> postNewBrand() {

            //リクエスト部
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.2ndstreet.jp/index.php/api_2_0/AppMaster/getBrands");
            req.Method = "POST";
            req.UserAgent = agent;
            HttpWebResponse rawres = (HttpWebResponse)req.GetResponse();
            Stream s = rawres.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            //パース部
            dynamic resjson = DynamicJson.Parse(content);
            List<SecondStreetListBrand> rst = new List<SecondStreetListBrand>();
            try
            {
                foreach (var itemjson in resjson.value)
                {
                    rst.Add(new SecondStreetListBrand(itemjson));
                    Console.WriteLine(itemjson);
                }
                label1.Text = "待機";
                return rst;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("セカンドストリートタイムラインjsonパース失敗");
                label1.Text = "ブランド名取得エラー";
                return rst;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "新着商品取得中";
            postNewItem();
        }

        //新着アイテムの取得
        private List<SecondStreetListItem> postNewItem()
        {
            //リクエスト部
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods");
            req.Method = "POST";
            req.UserAgent = agent;
            HttpWebResponse rawres = (HttpWebResponse)req.GetResponse();
            Stream s = rawres.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            //パース部
            dynamic resjson = DynamicJson.Parse(content);
            List<SecondStreetListItem> rst = new List<SecondStreetListItem>();
            try
            {
                foreach (var itemjson in resjson.value)
                {
                    rst.Add(new SecondStreetListItem(itemjson));
                    Console.WriteLine(itemjson);
                }
                label1.Text = "待機状態";
                return rst;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("セカンドストリートタイムラインjsonパース失敗");
                label1.Text = "新着アイテム取得エラー";
                return rst;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        //更新ボタン
        private void button4_Click(object sender, EventArgs e)
        {

        }
       

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //GUI更新
            //リストに存在していないものだけをリストンにいれる
            //まだリストに存在していないものだけをリストにいれる
            foreach (var item in addlist)
            {
                bool isexist = false;
                foreach (var binditem in bindlist) if (item.goods_id == binditem.goods_id) isexist = true;
                if (isexist == false)
                {
                    bindlist.Add(item);
                    AddFrilItemPanel(item);
                }
            }
            if (addlist.Count > 0 && soundOn)
            {
                SoundPlayer simpleSound = new SoundPlayer(@".\notification.wav");
                simpleSound.Play();
            }
            //追加が終わったあとにmax_timelineを超えていれば超えた分だけ削除する
            //max_sizeを超えている場合は一番上のデータを削除する
            if (bindlist.Count > MAX_PANEL_NUM)
            {
                int deletenum = bindlist.Count - MAX_PANEL_NUM;
                for (int i = 0; i < deletenum; i++)
                {
                    bindlist.RemoveAt(0);
                    flowLayoutPanel1.Controls[0].Dispose();
                }
            }
        }


        private void AddSecondStreetItemPanel(SecondStreetListItem item)
        {
            SecondStreetItemPanel panel = new SecondStreetItemPanel(item);
            panel.Tag = item;
            panel.TabStop = false;
            this.flowLayoutPanel1.Controls.Add(panel);
            if (SettingForm.getAutoScroll()) 
            {
                panel.SetFocusBuyButton();
                this.flowLayoutPanel1.AutoScrollPosition = new Point(0, 0);
                nowfocus = 0;
            }
            else
            {
                nowfocus++;
            }
        }



        // Step5: メソッド内でawaitキーワードを使ったら、メソッドの先頭でasyncを加えなければならない。
        // Step6: メソッド内でawaitキーワードを使ったら、戻り値の型はTask<T>型で返さなければならない。
        //        T型は本来返すべき戻り値の型。。
        //public static async Task<string> ReadFromUrlAsync(Uri url)
        //{
        //    using (WebClient webClient = new WebClient())
        //    {
        //        // Step1: OpenReadから非同期対応のOpenReadTaskAsyncに変更する。
        //        // Step2: OpenReadTaskAsyncがTask<Stream>を返すので、awaitする。
        //        //        awaitすると、Streamが得られる。

        //        try
        //        {
        //            using (Stream stream = await webClient.OpenReadTaskAsync(url))
        //            {
        //                TextReader tr = new StreamReader(stream, Encoding.UTF8, true);
        //                // Step3: ReadToEndから非同期対応のReadToEndAsyncに変更する。
        //                // Step4: ReadToEndAsyncがTask<string>を返すので、awaitする。
        //                //        awaitすると、stringが得られる。
        //                string body = await tr.ReadToEndAsync();
        //                return body;
        //            }

        //        }catch (WebException e)
        //        {
        //            Console.Write(e);
        //            Console.WriteLine("ぼけ");
        //        }
        //        //using (Stream stream = await webClient.OpenReadTaskAsync(url))
        //        //{
        //        //    TextReader tr = new StreamReader(stream, Encoding.UTF8, true);
        //        //    // Step3: ReadToEndから非同期対応のReadToEndAsyncに変更する。
        //        //    // Step4: ReadToEndAsyncがTask<string>を返すので、awaitする。
        //        //    //        awaitすると、stringが得られる。
        //        //    string body = await tr.ReadToEndAsync();
        //        //    return body;
        //        //}
        //    }
        //}


        //public static async Task DownloadAsync()
        //{//https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods
        //    Uri url = new Uri("https://google.co.jp");
        //    string body = await ReadFromUrlAsync(url);
        //    Console.WriteLine(body);
        //}


    }
}
