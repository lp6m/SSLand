using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Codeplex.Data;

namespace SSLand
{
    class SecondStreetMaster
    {

        ////親ID->子IDリスト
        //public static Dictionary<int, List<Category>> categoryChildrenDictionary = new Dictionary<int, List<Category>>();
        ////カテゴリID->カテゴリ
        //public static Dictionary<int, Category> categoryDictionary = new Dictionary<int, Category>();
        ////内容->ID(文字列)
        //public static Dictionary<string, string> conditionTypeFril = new Dictionary<string, string>();
        //public static Dictionary<string, string> shippingPayersFril = new Dictionary<string, string>();
        ////ID->内容
        //public static Dictionary<int, string> conditionTypeFrilDic = new Dictionary<int, string>();
        //public static Dictionary<int, string> shippingPayersFrilDic = new Dictionary<int, string>();
        public static bool init()
        {
            //マスタデータ読み込み
            try
            {
                makeBrandDictionary();//getBrands();
                //getCategories();
                //getSizeGroup();
                //conditionTypeFril = new Dictionary<string, string>();
                //conditionTypeFril.Add("新品、未使用", "5");
                //conditionTypeFril.Add("未使用に近い", "4");
                //conditionTypeFril.Add("目立った傷や汚れなし", "6");
                //conditionTypeFril.Add("やや傷や汚れあり", "3");
                //conditionTypeFril.Add("傷や汚れあり", "2");
                //conditionTypeFril.Add("全体的に状態が悪い", "1");
                //foreach (KeyValuePair<string, string> pair in conditionTypeFril)
                //{
                //    conditionTypeFrilDic[int.Parse(pair.Value)] = pair.Key;
                //}
                //shippingPayersFril = new Dictionary<string, string>();
                //shippingPayersFril.Add("送料込み(あなたが負担)", "1");
                //shippingPayersFril.Add("着払い(購入者が負担)", "2");
                //foreach (KeyValuePair<string, string> pair in shippingPayersFril)
                //{
                //    shippingPayersFrilDic[int.Parse(pair.Value)] = pair.Key;
                //}
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("マスタデータ読み込み失敗:" + ex.Message);
                return false;
            }
        }
        //public struct Category
        //{
        //    public int id;
        //    public int parent_id;//0なら根カテゴリ
        //    public string name;
        //    public int grand_parent_id;//0なら根カテゴリ
        //    public int size_group_id;//jsonではnull, プログラム上では-1でグループ無し
        //    public List<int> child_ids;
        //}
        //public static List<Category> categories = new List<Category>();
        //public static List<SizeGroup> sizegroups = new List<SizeGroup>();
        public static List<Brand> brands = new List<Brand>();
        public static Dictionary<int, Brand> brandDictionary = new Dictionary<int, Brand>();
        //static void getCategories()
        //{
        //    categoryChildrenDictionary = new Dictionary<int, List<Category>>();
        //    string jsonstr = "";
        //    using (WebClient webClient = new WebClient())
        //    {
        //        byte[] bytes = webClient.DownloadData("https://api.fril.jp/api/v3/initial_data");
        //        jsonstr = Encoding.UTF8.GetString(bytes);
        //    }
        //    dynamic json = DynamicJson.Parse(jsonstr);
        //    foreach (var data in json.categories)
        //    {
        //        Category c = new Category();
        //        c.id = (int)data.id;
        //        c.parent_id = (int)data.parent_id;
        //        c.name = data.name;
        //        c.grand_parent_id = (int)data.grand_parent_id;
        //        c.child_ids = new List<int>();
        //        foreach (var child in data.child_ids)
        //        {
        //            c.child_ids.Add((int)child);
        //        }
        //        c.size_group_id = (data.size_group_id == null) ? -1 : (int)data.size_group_id;
        //        //dictionary作成
        //        if (categoryChildrenDictionary.ContainsKey(c.parent_id) == false) categoryChildrenDictionary[c.parent_id] = new List<Category>();
        //        categoryChildrenDictionary[c.parent_id].Add(c);
        //        categoryDictionary[c.id] = c;
        //    }
        //    Log.Logger.Info("フリルカテゴリリスト読み込み完了");
        //}

        //public struct SizeGroup
        //{
        //    public int id;
        //    public string name;
        //    public bool hidden;
        //    public List<SizeType> size_types;
        //}
        //public struct SizeType
        //{
        //    public string name;
        //    public List<SizeInfo> sizes;
        //}
        //public struct SizeInfo
        //{
        //    public int id;
        //    public string name;
        //}
        //public static void getSizeGroup()
        //{
        //    sizegroups = new List<SizeGroup>();
        //    string jsonstr = "";
        //    using (WebClient webClient = new WebClient())
        //    {
        //        byte[] bytes = webClient.DownloadData("https://api.fril.jp/api/v3/initial_data");
        //        jsonstr = Encoding.UTF8.GetString(bytes);
        //    }
        //    dynamic json = DynamicJson.Parse(jsonstr);
        //    foreach (var sizegroup in json.size_groups)
        //    {
        //        SizeGroup sg = new SizeGroup();
        //        sg.id = (int)sizegroup.id;
        //        sg.name = sizegroup.name;
        //        sg.hidden = (bool)sizegroup.hidden;
        //        sg.size_types = new List<SizeType>();
        //        foreach (var sz in sizegroup.size_types)
        //        {
        //            SizeType size_type = new SizeType();
        //            size_type.name = sz.name;
        //            size_type.sizes = new List<SizeInfo>();
        //            foreach (var si in sz.sizes)
        //            {
        //                SizeInfo size_info = new SizeInfo();
        //                size_info.id = (int)si.id;
        //                size_info.name = si.name;
        //                size_type.sizes.Add(size_info);
        //            }
        //            sg.size_types.Add(size_type);
        //        }
        //        sizegroups.Add(sg);
        //    }
        //    Log.Logger.Info("サイズデータ読み込み完了");
        //}
        public struct Brand
        {
            public int id;
            public string maker_name;
            public string maker_name_kana;
            public string name;
            public string name_kana;
            public int sort_key;
            public int section;
            public string section_name;
            public int maker_sort_key;
            public int maker_section;
            public string maker_section_name;
            public int is_valid;
        }




        //public static void getBrands()
        //{
        //    brands = new List<Brand>();
        //    string jsonstr = "";
        //    using (WebClient webClient = new WebClient())
        //    {
        //        byte[] bytes = webClient.DownloadData("https://api.fril.jp/api/v3/brands");
        //        jsonstr = Encoding.UTF8.GetString(bytes);
        //    }
        //    dynamic json = DynamicJson.Parse(jsonstr);
        //    foreach (var bd in json.brands)
        //    {
        //        var brand = new Brand();
        //        brand.id = (int)bd.id;
        //        brand.name = bd.name;
        //        brand.kana_name = bd.kana_name;
        //        brand.confirm_flag = (int)bd.confirm_flag;
        //        brands.Add(brand);
        //        brandDictionary[brand.id] = brand;
        //    }
        //    Log.Logger.Info("ブランドデータ読み込み完了");
        //}


        //ブランド情報の取得
        public static void makeBrandDictionary()
        {
            //リクエスト部
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.2ndstreet.jp/index.php/api_2_0/AppMaster/getBrands");
            req.Method = "POST";
            req.UserAgent = SecondStreetAPI.LOGIN_USER_AGENT;
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
                    var brand = new Brand();
                    brand.id = int.Parse(itemjson.id);
                    brand.maker_name = itemjson.maker_name;
                    brand.maker_name_kana = itemjson.maker_name_kana;
                    brand.name = itemjson.name;
                    brand.name_kana = itemjson.name_kana;
                    brand.sort_key = int.Parse(itemjson.sort_key);
                    brand.section = int.Parse(itemjson.section);
                    brand.section_name = itemjson.section_name;
                    brand.maker_sort_key = int.Parse(itemjson.maker_sort_key);
                    brand.maker_section = int.Parse(itemjson.maker_section);
                    brand.maker_section_name = itemjson.maker_section_name;
                    brand.is_valid = int.Parse(itemjson.is_valid);
                    brands.Add(brand);
                    brandDictionary[brand.id] = brand;
                }
                Log.Logger.Info("ブランドデータ読み込み完了");
            }
            catch (Exception ex)
            {
                Log.Logger.Info(ex);
            }

        }
    }
}
