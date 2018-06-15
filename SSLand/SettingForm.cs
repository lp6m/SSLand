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
        static public bool getShowPrompt() {
            var settingsDBHelper = new SettingsDBHelper();
            string rst = settingsDBHelper.getSettingValue("showprompt");
            if (String.IsNullOrEmpty(rst)) return true;//default
            if (rst == "False") return false;
            else return true;
        }
        static public bool getUseCard() {
            var settingsDBHelper = new SettingsDBHelper();
            string rst = settingsDBHelper.getSettingValue("usecard");
            if (String.IsNullOrEmpty(rst)) return false;//default
            if (rst == "False") return false;
            else return true;
        }
        static public string getCardNumber() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("cardnumber");
        }
        static public string getCardMonth() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("cardmonth");
        }
        static public string getCardYear() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("cardyear");
        }
        static public string getCardSecurityCode() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("securitycode");
        }
        static public string getCardFirstName() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("cardfirstname");
        }
        static public string getCardLastName() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("cardlastname");
        }
        static public string getVpassPassword() {
            var settingsDBHelper = new SettingsDBHelper();
            return settingsDBHelper.getSettingValue("vpasspassword");
        }
        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.showPromptBeforeBuyCheckbox.Checked = getShowPrompt();
            this.autoscrollCheckBox.Checked = getAutoScroll();
            this.photosizeNumericDown.Value = getPhotoSize();
            this.cardNumberTextBox.Text = getCardNumber();
            this.expireMonthTextBox.Text = getCardMonth();
            this.expireYearTextBox.Text = getCardYear();
            this.securityCodeTextBox.Text = getCardSecurityCode();
            this.cardFirstNameTextBox.Text = getCardFirstName();
            this.cardLastNameTextBox.Text = getCardLastName();
            this.vpassPasswordTextbox.Text = getVpassPassword();
            this.radioButton1.Checked = getUseCard();
            this.radioButton2.Checked = !getUseCard();
        }



        static private string getSettingStr(string key)
        {
            var settingsDBHelper = new SettingsDBHelper();
            string rst = settingsDBHelper.getSettingValue(key);
            if (String.IsNullOrEmpty(rst)) return "";
            return rst;
        }
        private void SaveSettings()
        {
            var settingsDBHelper = new SettingsDBHelper();
            settingsDBHelper.updateSettings(autoscroll, this.autoscrollCheckBox.Checked.ToString());
            settingsDBHelper.updateSettings(photosize, ((int)this.photosizeNumericDown.Value).ToString());

            settingsDBHelper.updateSettings("showprompt", showPromptBeforeBuyCheckbox.Checked.ToString());

            settingsDBHelper.updateSettings("cardnumber", cardNumberTextBox.Text.Trim());
            settingsDBHelper.updateSettings("cardmonth", expireMonthTextBox.Text.Trim());
            settingsDBHelper.updateSettings("cardyear", expireYearTextBox.Text.Trim());
            settingsDBHelper.updateSettings("securitycode", securityCodeTextBox.Text.Trim());
            settingsDBHelper.updateSettings("cardfirstname", cardFirstNameTextBox.Text.Trim());
            settingsDBHelper.updateSettings("cardlastname", cardLastNameTextBox.Text.Trim());
            settingsDBHelper.updateSettings("vpasspassword", vpassPasswordTextbox.Text.Trim());
            settingsDBHelper.updateSettings("usecard", radioButton1.Checked.ToString());
        }
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
