using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Net;
using Codeplex.Data;
using System.Media;

namespace SSLand
{
    public partial class MainForm : Form
    {
        WebClient webClient = new WebClient();
        private const int MAX_PANEL_NUM = 40;//タイムラインに表示する商品数
        List<SecondStreetListItem> bindlist = new List<SecondStreetListItem>();//タイムラインにバインドされている商品
        List<SecondStreetListItem> oldlist = new List<SecondStreetListItem>(); //1回前のリクエストで取得した商品リスト(重複を避ける)
        List<SecondStreetListItem> addlist = new List<SecondStreetListItem>(); //GUI更新時にタイムラインに追加すべき商品リスト
        //static List<string> boughtItemIDList = new List<string>(); //手動・自動購入した商品IDのリスト
        //static List<BoughtItemListForm.BoughtItem> boughtItemList = new List<BoughtItemListForm.BoughtItem>();
        int nowfocus = 0; //タイムラインの中の上から何個目を選択しているか
        bool soundOn = false;//新着商品時に音をならすか
        static BackgroundWorker bgWorker;
        static int dummy_report_progress = 0;
        public const string Key_LicenseKey = "LicenseKey";
        public const string Registry_Path = @"HKEY_CURRENT_USER\Software\SecondStreetWatcher";

        //SSLandのエージェント
        string agent = "reuse_store_release/3.0.2 CFNetwork/811.5.4 Darwin/16.7.0";

        public MainForm()
        {
            InitializeComponent();
        }
        static public SecondStreetAPI api;

        private void アカウント管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form account_form = new Account();
            account_form.Show();
        }
        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form setting_form = new SettingForm();
            setting_form.Show();

        }


        private async void MainWindow_Load(object sender, EventArgs e)
        {   
            new SettingsDBHelper().onCreate();
            string stringValue = (string)Microsoft.Win32.Registry.GetValue(MainForm.Registry_Path, "Expire", "");
            string datestr = DateTime.Now.AddDays(7).ToString();
            if (string.IsNullOrEmpty(stringValue)) Microsoft.Win32.Registry.SetValue(Registry_Path, "Expire", datestr);
            string licensekey = (string)Microsoft.Win32.Registry.GetValue(MainForm.Registry_Path, "LicenseKey", "");
            if (string.IsNullOrEmpty(licensekey)) new LicenseForm().Show();
            if (await Task.Run(() => SecondStreetMaster.init()) == false)
            {
                MessageBox.Show("フリルからデータの読み込みに失敗しました.プログラムを終了します.\nインターネット環境を確認してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //GUI更新
            //リストに存在していないものだけをリストにいれる
            //まだリストに存在していないものだけをリストにいれる
            foreach (var item in addlist)
            {
                this.flowLayoutPanel1.SuspendLayout();
                bool isexist = false;
                foreach (var binditem in bindlist) if (item.goods_id == binditem.goods_id) isexist = true;
                if (isexist == false)
                {
                    bindlist.Add(item);
                    AddSecondStreetItemPanel(item);
                }
                this.flowLayoutPanel1.ResumeLayout();
            }
            //if (addlist.Count > 0 && soundOn)
            //{
            //    SoundPlayer simpleSound = new SoundPlayer(@".\notification.wav");
            //    simpleSound.Play();
            //}
            //追加が終わったあとにmax_timelineを超えていれば超えた分だけ削除する
            //max_sizeを超えている場合は一番上のデータを削除する
            if (bindlist.Count > MAX_PANEL_NUM)
            {
                int deletenum = bindlist.Count - MAX_PANEL_NUM;
                for (int i = 0; i < deletenum; i++)
                {
                    bindlist.RemoveAt(0);
                    flowLayoutPanel1.Controls[0].Dispose();
                }
            }
        }


        private void AddSecondStreetItemPanel(SecondStreetListItem item)
        {
            SecondStreetItemPanel panel = new SecondStreetItemPanel(item);
            panel.Tag = item;
            panel.TabStop = false;
            this.flowLayoutPanel1.Controls.Add(panel);
            this.flowLayoutPanel1.AutoScrollPosition = new Point(0, 0);
            if (SettingForm.getAutoScroll()) 
            {
                panel.SetFocusBuyButton();
                this.flowLayoutPanel1.AutoScrollPosition = new Point(0, 0);
                nowfocus = 0;
            }
            else
            {
                nowfocus++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.backgroundWorker1.IsBusy) return;
            else this.backgroundWorker1.RunWorkerAsync();
        }


        private void startProcessButton_Click(object sender, EventArgs e)
        {
            ToggleMonitoring();
        }
        private void ToggleMonitoring()
        {
            //監視の開始・停止を行う
            //api = Common.getFrilAPIFromDB();
            //if (api == null)
            //{
            //    MessageBox.Show("アカウントを確認してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (this.startProcessButton.BackColor != Color.Red)
            {
                if (this.backgroundWorker1.IsBusy)
                {
                    MessageBox.Show("しばらくたってから再実行してください");
                    return;
                }
                //OFF -> ON
                this.startProcessButton.BackColor = Color.Red;
                this.startProcessButton.Text = "監視停止(z)";
                this.timer1.Enabled = true;
                addlist.Clear();
                bindlist.Clear();
                ClearSecondStreetItemPanel();
                oldlist.Clear();
                //boughtItemIDList.Clear();
                SecondStreetItemPanel.ReloadPhotoSize();
            }
            else
            {
                //ON -> OFF
                this.startProcessButton.BackColor = Color.Transparent;
                this.startProcessButton.Text = "監視開始(z)";
                this.timer1.Enabled = false;
                this.backgroundWorker1.CancelAsync();
            }
        }
        private void ClearSecondStreetItemPanel()
        {
            this.flowLayoutPanel1.Controls.Clear();
        }

        //こちらは動かなかった
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'z') ToggleMonitoring();
        }
        
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Home)
            {
                this.flowLayoutPanel1.AutoScrollPosition = new Point(0, 0);
                int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                if (panel_cnt <= 0) return;
                try
                {
                    SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 1];
                    //panel.SetFocusBuyButton();
                    nowfocus = 0;
                }
                catch (Exception ex)
                {

                }
            }
            if (e.KeyCode == System.Windows.Forms.Keys.PageUp)
            {
                this.flowLayoutPanel1.AutoScrollPosition = new Point(-this.flowLayoutPanel1.AutoScrollPosition.X, -this.flowLayoutPanel1.AutoScrollPosition.Y - 120);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.PageDown)
            {
                this.flowLayoutPanel1.AutoScrollPosition = new Point(-this.flowLayoutPanel1.AutoScrollPosition.X, -this.flowLayoutPanel1.AutoScrollPosition.Y + 120);
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Tab && e.Shift != true)
            {
                int old = nowfocus;
                nowfocus++;
                if (nowfocus >= bindlist.Count) nowfocus = 0;
                try
                {
                    //フォーカスする
                    int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                    SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 1 - nowfocus];
                    //panel.SetFocusBuyButton();
                }
                catch (Exception ex)
                {
                    //失敗したので戻す
                    nowfocus = old;
                }
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Tab && e.Shift == true)
            {
                int old = nowfocus;
                nowfocus--;
                if (nowfocus < 0) nowfocus = 0;
                if (nowfocus >= bindlist.Count) nowfocus = 0;
                try
                {
                    //フォーカスする
                    int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                    SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 1 - nowfocus];
                    //panel.SetFocusBuyButton();
                }
                catch (Exception ex)
                {
                    //失敗したので戻す
                    nowfocus = old;
                }
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F1)
            {
                //bool execute = SettingForm.getf1f4Enable();
                //if (execute)
                //{
                    //int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                    //if (panel_cnt >= 1)
                    //{
                    //    SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 1];
                    //    SecondStreetItem item = (SecondStreetItem)panel.Tag;
                    //    ExecuteBuyItem(item, true);
                    //}
                //}
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F2)
            {
                //bool execute = SettingForm.getf1f4Enable();
                //if (execute)
                //{
                //    int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                //    if (panel_cnt >= 2)
                //    {
                //        SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 2];
                //        SecondStreetItem item = (SecondStreetItem)panel.Tag;
                //        ExecuteBuyItem(item, true);
                //    }
                //}
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F3)
            {
                //bool execute = SettingForm.getf1f4Enable();
                //if (execute)
                //{
                //    int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                //    if (panel_cnt >= 3)
                //    {
                //        SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 3];
                //        SecondStreetItem item = (SecondStreetItem)panel.Tag;
                //        ExecuteBuyItem(item, true);
                //    }
                //}
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F4)
            {
                //bool execute = SettingForm.getf1f4Enable();
                //if (execute)
                //{
                //    int panel_cnt = this.flowLayoutPanel1.Controls.Count;
                //    if (panel_cnt >= 4)
                //    {
                //        SecondStreetItemPanel panel = (SecondStreetItemPanel)this.flowLayoutPanel1.Controls[panel_cnt - 4];
                //        SecondStreetItem item = (SecondStreetItem)panel.Tag;
                //        ExecuteBuyItem(item, true);
                //    }
                //}
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //api = Common.checkFrilAPI(api);
            try
            {
                bgWorker = (BackgroundWorker)sender;
                //停止リクエストがあれば終了
                if (bgWorker.CancellationPending) return;
                addlist.Clear();
                List<SecondStreetListItem> rst = new List<SecondStreetListItem>();
                //新着商品を取得
                rst = GetItemProcess.getNewMatchingItems();
                foreach (var newitem in rst)
                {
                    bool isnew = true;
                    foreach (var olditem in oldlist)
                    {
                        if (newitem.goods_id == olditem.goods_id)
                        {
                            isnew = false;
                            break;
                        }
                    }
                    if (isnew)
                    {
                        addlist.Add(newitem);
                    }
                }
                oldlist = new List<SecondStreetListItem>(rst);
                if (addlist.Count != 0)
                {
                    //GUI更新リクエスト
                    dummy_report_progress += 1;
                    if (dummy_report_progress > 100) dummy_report_progress = 0;
                    bgWorker.ReportProgress(dummy_report_progress);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e) {
            this.flowLayoutPanel1.Width = this.Width - this.flowLayoutPanel1.Left - 60;
            this.flowLayoutPanel1.Height = this.Height - this.flowLayoutPanel1.Top - 60;
        }

        private void button5_Click(object sender, EventArgs e) {
            var rst = SecondStreetAPI.postNewItem();
            foreach (var item in rst) AddSecondStreetItemPanel(item);
        }

        private void ライセンスToolStripMenuItem_Click(object sender, EventArgs e) {
            new LicenseForm().Show();
        }
    }
}
