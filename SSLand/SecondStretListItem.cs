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
        public long goods_id;
        public int shops_id;
        public string goods_name;
        public string brand_name;
        public string shop_name;
        public int price;
        public int price_org;
        public string sale_label;
        public int is_favorite_goods;
        public int is_favorite_shop;
        public string size_detail;
        public string color_name;
        public string pattern_name;
        public string image_url;
        

        public SecondStreetListItem()
        {

        }
        public SecondStreetListItem(dynamic json)
        {
            try
            {
                this.goods_id = Int64.Parse(json.goods_id);
                this.shops_id = int.Parse(json.shops_id);
                this.goods_name = json.goods_name;
                this.brand_name = json.brand_name;
                this.shop_name = json.shop_name;
                this.price = (int)json.price;//なぜかdouble
                this.price_org = (int)json.price_org;//なぜかdouble
                this.sale_label = json.sale_label;
                this.is_favorite_goods = int.Parse(json.is_favorite_goods);
                this.is_favorite_shop = int.Parse(json.is_favorite_shop);
                this.size_detail = json.size_detail;
                this.color_name = json.color_name;
                this.pattern_name = json.pattern_name;
                this.image_url = json.image_url;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Log.Logger.Error("SecondStreetListItem json parse error:" + ex.Message);
            }
        }
    }
}
