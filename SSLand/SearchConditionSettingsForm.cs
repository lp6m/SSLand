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

namespace SSLand {
    public partial class SearchConditionSettingsForm : Form {
        public SearchConditionSettingsForm() {
            InitializeComponent();
        }
        bool isEditMode = false;//新規追加中:false 編集中;true
        int nowedit_index;//現在編集中の検索条件のDB内リストのインデックス
        SecondStreetMaster.Category selected_category;//現在選択中のカテゴリ
        public class SearchConditionClass {
            public bool usecategory;
            public bool usebrand;
            public int category_level1 = -1;
            public int category_level2 = -1;
            public int category_level3 = -1;
            public string category_level1_name;
            public string category_level2_name;
            public string category_level3_name;
            public string category_type;//リクエストに必要
            public int brand_id;
            public string brand_name;
            public string condition_name;
            public override string ToString() {
                string rst = "";
                try {
                    rst += this.condition_name + " ";
                    if (usecategory) {
                        rst += " カテゴリ:";
                        if (category_level1 > 0) rst += category_level1_name;
                        if (category_level2 > 0) rst += category_level2_name;
                        if (category_level3 > 0) rst += category_level3_name;
                    }
                    if (usebrand) {
                        rst += " ブランド:";
                        if (brand_id > 0) rst += brand_name;
                    }
                } catch (Exception ex) {

                }
                return rst;
            }
        }

        public const string brandenable = "brandenable";

        private void SearchConditionSettingsForm_Load(object sender, EventArgs e) {
            RefreshListBox();
            foreach (var pair in SecondStreetMaster.brandDictionary) {
                this.brandComboBox.Items.Add(pair.Value);
            }
            foreach (var c in SecondStreetMaster.categoryChildDictionary["1"]) {
                this.categoryComboBox1.Items.Add(c);
            }
        }

        private void categoryComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (categoryComboBox1.SelectedIndex < 0) return;
            this.selected_category = (SecondStreetMaster.Category)categoryComboBox1.SelectedItem;
            if (SecondStreetMaster.categoryChildDictionary.ContainsKey(selected_category.id)) {
                //レベル2を表示
                categoryComboBox2.Visible = true;
                categoryComboBox3.Visible = false;
                categoryComboBox2.Items.Clear();
                foreach (var c in SecondStreetMaster.categoryChildDictionary[selected_category.id]) {
                    categoryComboBox2.Items.Add(c);
                }
                //レベル2,3,4のindex-1に
                categoryComboBox2.SelectedIndex = -1;
                categoryComboBox3.SelectedIndex = -1;
                categoryComboBox2.Text = "未選択";
            } else {
                //レベル1までしかない
            }
        }

        private void categoryComboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            if (categoryComboBox2.SelectedIndex < 0) return;
            this.selected_category = (SecondStreetMaster.Category)categoryComboBox2.SelectedItem;
            if (SecondStreetMaster.categoryChildDictionary.ContainsKey(selected_category.id)) {
                //レベル3を表示
                categoryComboBox3.Visible = true;
                categoryComboBox3.Items.Clear();
                foreach (var c in SecondStreetMaster.categoryChildDictionary[selected_category.id]) {
                    categoryComboBox3.Items.Add(c);
                }
                //レベル3,4のindex-1に
                categoryComboBox3.SelectedIndex = -1;
                categoryComboBox3.Text = "未選択";
            } else {
                //レベル2までしかない
            }
        }

        private void categoryComboBox1_Format(object sender, ListControlConvertEventArgs e) {
            e.Value = ((SecondStreetMaster.Category)e.ListItem).name;
        }

        private void categoryComboBox2_Format(object sender, ListControlConvertEventArgs e) {
            e.Value = ((SecondStreetMaster.Category)e.ListItem).name;
        }

        private void categoryComboBox3_Format(object sender, ListControlConvertEventArgs e) {
            e.Value = ((SecondStreetMaster.Category)e.ListItem).name;
        }

        private void useCategoryCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (useCategoryCheckBox.Checked) this.categoryComboBox1.Visible = true;
            else this.categoryComboBox1.Visible = false;
        }

        private void useBrandCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (useBrandCheckBox.Checked) this.brandComboBox.Visible = true;
            else this.brandComboBox.Visible = false;
        }
        SearchConditionClass getSearchConditionFromGUI() {
            SearchConditionClass rst = new SearchConditionClass();
            try {
                rst.condition_name = this.conditionNameTextBox.Text.Trim();
                rst.usecategory = this.useCategoryCheckBox.Checked;
                rst.usebrand = this.useBrandCheckBox.Checked;
                if (rst.usecategory) {
                    //カテゴリタイプは設定されているもので一番深いカテゴリのカテゴリタイプを取得
                    if (this.categoryComboBox1.SelectedItem != null) {
                        rst.category_level1 = int.Parse(((SecondStreetMaster.Category)this.categoryComboBox1.SelectedItem).id);
                        rst.category_level1_name = ((SecondStreetMaster.Category)this.categoryComboBox1.SelectedItem).name;
                        rst.category_type = ((SecondStreetMaster.Category)this.categoryComboBox1.SelectedItem).category_type;
                    }
                    if (this.categoryComboBox2.SelectedItem != null) {
                        rst.category_level2 = int.Parse(((SecondStreetMaster.Category)this.categoryComboBox2.SelectedItem).id);
                        rst.category_level2_name = ((SecondStreetMaster.Category)this.categoryComboBox2.SelectedItem).name;
                        rst.category_type = ((SecondStreetMaster.Category)this.categoryComboBox1.SelectedItem).category_type;
                    }
                    if (this.categoryComboBox3.SelectedItem != null) {
                        rst.category_level3 = int.Parse(((SecondStreetMaster.Category)this.categoryComboBox3.SelectedItem).id);
                        rst.category_level3_name = ((SecondStreetMaster.Category)this.categoryComboBox3.SelectedItem).name;
                        rst.category_type = ((SecondStreetMaster.Category)this.categoryComboBox1.SelectedItem).category_type;
                    }
                }
                if (rst.usebrand) {
                    rst.brand_id = ((SecondStreetMaster.Brand)this.brandComboBox.SelectedItem).id;
                    rst.brand_name = ((SecondStreetMaster.Brand)this.brandComboBox.SelectedItem).name;
                }
                return rst;
            } catch (Exception) {
                return null;
            }
        }
        private void addSearchConditionButton_Click(object sender, EventArgs e) {
            SearchConditionClass newsc = getSearchConditionFromGUI();
            if (newsc == null) {
                MessageBox.Show("正しく入力してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isEditMode == false) {
                var nowsclist = LoadSearchConditions();
                nowsclist.Add(newsc);
                SaveSearchConditions(nowsclist);
                RefreshListBox();
                ResetGUIComponent();
            } else {
                isEditMode = false;
                var nowsclist = LoadSearchConditions();
                nowsclist[nowedit_index] = newsc;
                SaveSearchConditions(nowsclist);
                RefreshListBox();
                ResetGUIComponent();
                this.addSearchConditionButton.Text = "追加";
            }
        }
        private void ResetGUIComponent() {
            selected_category = new SecondStreetMaster.Category();
            this.conditionNameTextBox.Text = "";
            this.useBrandCheckBox.Checked = false;
            this.useCategoryCheckBox.Checked = false;
            this.categoryComboBox1.SelectedIndex = this.categoryComboBox2.SelectedIndex = this.categoryComboBox3.SelectedIndex = -1;
            this.categoryComboBox1.Visible = this.categoryComboBox2.Visible = this.categoryComboBox3.Visible = false;
            this.brandComboBox.SelectedIndex = -1;
        }
        private void RefreshListBox(string keyword = "") {
            if (string.IsNullOrEmpty(keyword)) {
                this.listBox1.Items.Clear();
                var conditions = LoadSearchConditions();
                foreach (var sc in conditions) this.listBox1.Items.Add(sc);
            } else {
                this.listBox1.Items.Clear();
                var conditions = LoadSearchConditions();
                foreach (var sc in conditions) {
                    if (sc.ToString().IndexOf(keyword) >= 0) this.listBox1.Items.Add(sc);
                }
            }
        }
        public static List<SearchConditionClass> LoadSearchConditions() {
            List<SearchConditionClass> rst = new List<SearchConditionClass>();
            try {
                var settingsDBHelper = new SettingsDBHelper();
                string base64xml = settingsDBHelper.getSettingValue("search_conditions");
                if (string.IsNullOrEmpty(base64xml)) throw new Exception("no search conditions");
                string xml = Common.Base64Decode(base64xml);
                if (string.IsNullOrEmpty(xml)) throw new Exception("base64 decode fail");
                try {
                    SearchConditionClass[] array;
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SearchConditionClass[]));
                    using (TextReader reader = new StringReader(xml)) {
                        array = (SearchConditionClass[])serializer.Deserialize(reader);
                    }
                    foreach (var sc in array) rst.Add(sc);
                    return rst;
                } catch (Exception ex) {
                    return rst;
                }
            } catch (Exception ex) {
                return rst;
            }
        }
        private void SaveSearchConditions(List<SearchConditionClass> newsclist) {
            string xml = SearchConditionsToXml(newsclist);
            new SettingsDBHelper().updateSettings("search_conditions", Common.Base64Encode(xml));
        }
        private string SearchConditionsToXml(List<SearchConditionClass> newsclist) {
            try {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SearchConditionClass[]));
                using (StringWriter textWriter = new StringWriter()) {
                    serializer.Serialize(textWriter, newsclist.ToArray());
                    return textWriter.ToString();
                }
            } catch (Exception ex) {
                return "";
            }
        }

        private void brandComboBox_Format(object sender, ListControlConvertEventArgs e) {
            e.Value = ((SecondStreetMaster.Brand)e.ListItem).name;
        }

        private void deleteSearchConditionButton_Click(object sender, EventArgs e) {
            if (isEditMode) {
                MessageBox.Show("先に編集中の検索条件を保存してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.listBox1.SelectedIndex < 0) {
                MessageBox.Show("削除する条件を選択してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (MessageBox.Show("選択した検索条件を削除しますか?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            List<SearchConditionClass> cons = LoadSearchConditions();
            int deleteconindex = this.listBox1.SelectedIndex;
            cons.RemoveAt(deleteconindex);
            SaveSearchConditions(cons);
            RefreshListBox();
        }

        private void editButton_Click(object sender, EventArgs e) {
            SearchConditionClass selectsc = (SearchConditionClass)listBox1.SelectedItem;
            int selectconDBindex = this.listBox1.SelectedIndex;
            if (isEditMode) {
                MessageBox.Show("現在編集中の設定を保存してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBox1.SelectedIndex < 0 || selectsc == null || selectconDBindex < 0) {
                MessageBox.Show("編集する設定を選択してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetGUIFromSearchCondition(selectsc);
            nowedit_index = selectconDBindex;
            isEditMode = true;
            this.addSearchConditionButton.Text = "変更を保存";
        }
        private void SetGUIFromSearchCondition(SearchConditionClass con) {
            ResetGUIComponent();
            this.conditionNameTextBox.Text = con.condition_name;
            this.useCategoryCheckBox.Checked = con.usecategory;
            this.useBrandCheckBox.Checked = con.usebrand;
            if (con.usecategory) {
                if(con.category_level1 > 0) {
                    int category_level1_selected_index = 0;
                    foreach (var c in SecondStreetMaster.categoryChildDictionary["1"]){
                        if (c.id == con.category_level1.ToString()) {
                            selected_category = c;
                            break;
                        }
                        category_level1_selected_index++;
                    }
                    this.categoryComboBox1.SelectedIndex = category_level1_selected_index;
                    this.categoryComboBox1.Visible = true;
                }
                if (con.category_level2 > 0) {
                    int category_level2_selected_index = 0;
                    foreach (var c in SecondStreetMaster.categoryChildDictionary[con.category_level1.ToString()]) {
                        if (c.id == con.category_level2.ToString()) {
                            selected_category = c;
                            break;
                        }
                        category_level2_selected_index++;
                    }
                    this.categoryComboBox2.SelectedIndex = category_level2_selected_index;
                    this.categoryComboBox2.Visible = true;
                }
                if (con.category_level3 > 0) {
                    int category_level3_selected_index = 0;
                    foreach (var c in SecondStreetMaster.categoryChildDictionary[con.category_level2.ToString()]) {
                        if (c.id == con.category_level3.ToString()) {
                            selected_category = c;
                            break;
                        }
                        category_level3_selected_index++;
                    }
                    this.categoryComboBox3.SelectedIndex = category_level3_selected_index;
                    this.categoryComboBox3.Visible = true;
                }
            }
            if (con.usebrand) {
                int brandcombo_index = 0;
                foreach (var pair in SecondStreetMaster.brandDictionary) {
                    if (pair.Value.id == con.brand_id) break;
                    brandcombo_index++;
                }
                this.brandComboBox.SelectedIndex = brandcombo_index;
                this.brandComboBox.Visible = true;
            }
        }
    }
}
