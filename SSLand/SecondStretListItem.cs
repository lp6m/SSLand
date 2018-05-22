using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLand
{
    //一括取得した場合の商品概要クラス
    public class SecondStreetListItem
    {
        public string tl_id;
        public string item_id;
        public string item_name;
        public string item_detail;
        public int price;
        public int t_status;
        public string user_id;
        public int brand_id;
        public string brand_name;
        public int i_brand_id;
        public string i_brand_name;
        public DateTime created_at;

        public SecondStreetListItem()
        {

        }
        public SecondStreetListItem(dynamic json)
        {
            try
            {
                this.tl_id = ((long)json.tl_id).ToString();
                this.item_id = ((long)json.item_id).ToString();
                this.item_name = json.item_name;
                this.item_detail = json.item_detail;
                this.price = (int)json.price;
                this.t_status = (int)json.t_status;
                this.user_id = ((long)json.user_id).ToString();
                this.brand_id = (json.brand_id == null) ? -1 : (int)json.brand_id;
                this.i_brand_id = (json.i_brand_id == null) ? -1 : (int)json.i_brand_id;
                this.created_at = DateTime.Parse((string)json.created_at);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("SecondStreetListItem json parse error:" + ex.Message);
            }
        }
    }
}
