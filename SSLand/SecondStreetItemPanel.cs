using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SSLand
{
    public partial class SecondStreetItemPanel : UserControl
    {
        public SecondStreetItemPanel()
        {
            InitializeComponent();
        }
        const int default_photo_size = 160;
        static int photosize = 160;
        static private MainForm mainform;
        static public void setMainFormInstance(MainForm mainForm) {
            SecondStreetItemPanel.mainform = mainForm;
        }
        private SecondStreetListItem item;
        public SecondStreetItemPanel(SecondStreetListItem item)
        {
            try
            {
                InitializeComponent();
                ChangeComponentSize();
                this.item = item;
                this.itemNameLabel.Text = item.goods_name;
                this.shopNameLabel.Text = item.shop_name;
                this.brandNameLabel.Text = item.brand_name;
                this.sizeLabel.Text = item.size_detail;
                if (!string.IsNullOrEmpty(item.image_url)) this.pictureBox1.ImageLocation = item.image_url;
                this.PriceLabel.Text = String.Format("{0:#,0} 円", item.price);
                ChangeComponentSize();
            }
            catch (Exception ex)
            {
                Log.Logger.Error("FrilItemPanel error");
            }
        }

        private void SecondStreetItemPanel_Load(object sender, EventArgs e)
        {
        }
        private void ChangeComponentSize()
        {
            SecondStreetItemPanel.photosize = SettingForm.getPhotoSize();
            int plussize = photosize - default_photo_size;
            this.pictureBox1.Height += plussize;
            this.pictureBox1.Width += plussize;
            this.Width += plussize;
            this.Height += plussize;
            this.pictureBox1.Location = new Point((this.Width - this.pictureBox1.Width) / 2, this.pictureBox1.Location.Y);
            this.panel1.Location = new Point((this.Width - this.pictureBox1.Width) / 2, this.panel1.Location.Y + plussize);
        }

        private void OpenBrowserButton_Click(object sender, EventArgs e)
        {
            string pc_url = "https://www.2ndstreet.jp/goods/detail/goodsId/" + item.goods_id.ToString() + "/shopsId/"+item.shops_id.ToString();
            //商品ページをブラウザで開く
            Process.Start(pc_url);
        }

        public void SetFocusBuyButton()
        {
            this.BuyButton.Focus();
        }

        private void BuyButton_Enter(object sender, EventArgs e)
        {
            this.BuyButton.BackColor = Color.Purple;
        }

        private void BuyButton_Leave(object sender, EventArgs e)
        {
            this.BuyButton.BackColor = Color.Red;
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            mainform.BuyItem(item);
        }

        //private void OpenSellerButton_Click(object sender, EventArgs e)
        //{
        //    //出品者ページをブラウザで開く
        //    string shop_url = MainForm.api.getShopURL(item.user_id);
        //    if (string.IsNullOrEmpty(shop_url) == false) Process.Start(shop_url);
        //}


    }
}
