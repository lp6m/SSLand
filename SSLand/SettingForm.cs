using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLand
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }



        bool isEditMode = false;//新規追加中:false 編集中;true
        int nowedit_index;//現在編集中の検索条件のDB内リストのインデックス
        //SecondStreetMaster.Category selected_category;//現在選択中のカテゴリ
        public class SearchConditionClass
        {
            public int minprice;
            public int maxprice;
            public string keyword_text;
            public string ngkeyword_text;
            public bool usecategory;
            public bool usebrand;
            public bool usecondition;
            public int category_level1;//-1だと使用しない
            public int category_level2;
            public int category_level3;
            public string category_level1_name;
            public string category_level2_name;
            public string category_level3_name;
            public bool autobuyoption = false;
            public int brand_id;
            public string brand_name;
            public string ngseller_text;
            public string seller_text;
            public string condition_name;
            public bool ischeckdetail_for_ng;
            public List<int> item_condition_list;
            public override string ToString()
            {
                string rst = "";
                try
                {
                    rst += this.condition_name + " ";
                    if (this.autobuyoption) rst += "自動購入ON";
                    rst += minprice.ToString() + "円～" + maxprice.ToString() + "円";
                    if (!String.IsNullOrEmpty(keyword_text)) rst += "キーワード: " + keyword_text;
                    if (!String.IsNullOrEmpty(ngkeyword_text)) rst += "NGキーワード: " + ngkeyword_text;
                    if (!String.IsNullOrEmpty(seller_text)) rst += "出品者指定: " + seller_text;
                    if (!String.IsNullOrEmpty(ngseller_text)) rst += "NG出品者: " + ngseller_text;
                    if (usecategory)
                    {
                        rst += " カテゴリ:";
                        if (category_level1 > 0) rst += category_level1_name;
                        if (category_level2 > 0) rst += category_level2_name;
                        if (category_level3 > 0) rst += category_level3_name;
                    }
                    if (usebrand)
                    {
                        rst += " ブランド:";
                        if (brand_id > 0) rst += brand_name;
                    }
                    if (usecondition)
                    {
                        rst += "商品の状態 ";
                        if (item_condition_list != null) foreach (int id in item_condition_list) rst += id.ToString();
                    }
                    if (ischeckdetail_for_ng)
                    {
                        rst += "NG商品説明チェック";
                    }


                }
                catch (Exception ex)
                {

                }
                return rst;
            }
        }


        public const string autoscroll = "autoscroll";
        //public const string f1f4enable = "f1f4enable";
        public const string photosize = "photosize";

        static public bool getAutoScroll()
        {
            var settingsDBHelper = new SettingsDBHelper();
            string rst = settingsDBHelper.getSettingValue(autoscroll);
            if (String.IsNullOrEmpty(rst)) return false;//default
            if (rst == "False") return false;
            else return true;
        }
        static public int getPhotoSize()
        {
            var settingsDBHelper = new SettingsDBHelper();
            string rst = settingsDBHelper.getSettingValue(photosize);
            if (String.IsNullOrEmpty(rst)) return 160;//default;
            try
            {
                int photos = int.Parse(rst);
                return photos;
            }
            catch (Exception ex)
            {
                return 160;
            }
        }
        //static public bool getf1f4Enable()
        //{
        //    var settingsDBHelper = new SettingsDBHelper();
        //    string rst = settingsDBHelper.getSettingValue(f1f4enable);
        //    if (String.IsNullOrEmpty(rst)) return false;//default
        //    if (rst == "False") return false;
        //    else return true;
        //}

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.photosizeNumericDown.Value = getPhotoSize();
            this.autoscrollCheckBox.Checked = getAutoScroll();

            //ブランドデータ
            foreach (var pair in SecondStreetMaster.brandDictionary)
            {
                
                this.brandComboBox.Items.Add(pair.Value.name+"("+pair.Value.name_kana+")");
            }
            RefreshListBox();
        }

        private void RefreshListBox(string keyword = "")
        {
            if (string.IsNullOrEmpty(keyword))
            {
                this.listBox1.Items.Clear();
                var conditions = LoadSearchConditions();
                foreach (var sc in conditions) this.listBox1.Items.Add(sc);
            }
            else
            {
                this.listBox1.Items.Clear();
                var conditions = LoadSearchConditions();
                foreach (var sc in conditions)
                {
                    if (sc.ToString().IndexOf(keyword) >= 0) this.listBox1.Items.Add(sc);
                }
            }
        }
        public static List<SearchConditionClass> LoadSearchConditions()
        {
            List<SearchConditionClass> rst = new List<SearchConditionClass>();
            try
            {
                var settingsDBHelper = new SettingsDBHelper();
                string base64xml = settingsDBHelper.getSettingValue("search_conditions");
                if (string.IsNullOrEmpty(base64xml)) throw new Exception("no search conditions");
                string xml = Common.Base64Decode(base64xml);
                if (string.IsNullOrEmpty(xml)) throw new Exception("base64 decode fail");
                try
                {
                    SearchConditionClass[] array;
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SearchConditionClass[]));
                    using (TextReader reader = new StringReader(xml))
                    {
                        array = (SearchConditionClass[])serializer.Deserialize(reader);
                    }
                    foreach (var sc in array) rst.Add(sc);
                    return rst;
                }
                catch (Exception ex)
                {
                    return rst;
                }
            }
            catch (Exception ex)
            {
                return rst;
            }
        }

        private void SaveSettings()
        {
            var settingsDBHelper = new SettingsDBHelper();
            settingsDBHelper.updateSettings(autoscroll, this.autoscrollCheckBox.Checked.ToString());
            settingsDBHelper.updateSettings(photosize, ((int)this.photosizeNumericDown.Value).ToString());
            //settingsDBHelper.updateSettings(f1f4enable, f1f4EnableCheckBox.Checked.ToString());
            //if (this.radioButton1.Checked)
            //{
            //    settingsDBHelper.updateSettings(paycreditcard, "True");
            //}
            //else
            //{
            //    settingsDBHelper.updateSettings(paycreditcard, "False");
            //}
            //settingsDBHelper.updateSettings(cardnumber, cardNumberTextBox.Text.Trim());
            //settingsDBHelper.updateSettings(expireMonth, expireMonthTextBox.Text.Trim());
            //settingsDBHelper.updateSettings(expireYear, expireYearTextBox.Text.Trim());
            //settingsDBHelper.updateSettings(securitycode, securityCodeTextBox.Text.Trim());
        }
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void useBrandCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.useBrandCheckBox.Checked) this.brandComboBox.Visible = true;
            else this.brandComboBox.Visible = false;
        }
    }
}
