using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
