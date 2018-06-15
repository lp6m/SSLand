using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Codeplex.Data;

namespace SSLand{
    class SecondStreetMaster{
        public static bool init(){
            //マスタデータ読み込み
            try{
                makeBrandDictionary();
                makeCategoryDictionary();
                SecondStreetMaster.loaded = true;
                return true;
            }catch (Exception ex){
                Log.Logger.Error("マスタデータ読み込み失敗:" + ex.Message);
                return false;
            }
        }
        public static bool loaded = false;
        public static List<Brand> brands = new List<Brand>();
        public static Dictionary<int, Brand> brandDictionary = new Dictionary<int, Brand>();
        public static Dictionary<string, List<Category>> categoryChildDictionary = new Dictionary<string, List<Category>>();//Key:親のカテゴリID Value:それに属してる子のカテゴリリスト, ルートは"1"
        public struct Brand{
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
        public struct Category {
            public string id;
            public string name;
            public string parent_id;//1つ上の親カテゴリID
            public string category_type;//カテゴリタイプ（リクエスト時に必要）
        }

        //カテゴリ情報の取得
        public static void makeCategoryDictionary() {
            //リクエスト部
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.2ndstreet.jp/index.php/api_2_0/AppMaster/getCategories");
            req.Method = "POST";
            req.UserAgent = SecondStreetAPI.LOGIN_USER_AGENT;
            HttpWebResponse rawres = (HttpWebResponse)req.GetResponse();
            Stream s = rawres.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            //パース部
            dynamic resjson = DynamicJson.Parse(content);
            foreach (var cdata in resjson.value) {
                var category = new Category();
                category.id = cdata.id;
                category.name = cdata.name;
                category.parent_id = ((int)cdata.parent_id).ToString();
                category.category_type = cdata.category_type;
                if (!SecondStreetMaster.categoryChildDictionary.ContainsKey(category.parent_id)) SecondStreetMaster.categoryChildDictionary[category.parent_id] = new List<Category>();
                SecondStreetMaster.categoryChildDictionary[category.parent_id].Add(category);
            }
            Log.Logger.Info("カテゴリ読み込み完了");
        }
        //ブランド情報の取得
        public static void makeBrandDictionary(){
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
            foreach (var itemjson in resjson.value) {
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
    }
}
