using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLand
{
    //ブランドリスト用
    public class SecondStreetListBrand
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

        public SecondStreetListBrand()
        {

        }
        public SecondStreetListBrand(dynamic json){
            try{
                this.id = int.Parse(json.id);
                this.maker_name = json.maker_name;
                this.maker_name_kana = json.maker_name_kana;
                this.name = json.name;
                this.name_kana = json.name_kana;
                this.sort_key = int.Parse(json.sort_key);
                this.section = int.Parse(json.section);
                this.section_name = json.section_name;
                this.maker_sort_key = int.Parse(json.maker_sort_key);
                this.maker_section = int.Parse(json.maker_section);
                this.maker_section_name = json.maker_section_name;
                this.is_valid = int.Parse(json.is_valid);
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                Log.Logger.Error("FrilListItem json parse error:" + ex.Message);
            }
        }
    }
}
