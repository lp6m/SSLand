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
        private const int MAX_PANEL_NUM = 20;//タイムラインに表示する商品数
        List<SecondStreetListItem> bindlist = new List<SecondStreetListItem>();//タイムラインにバインドされている商品
        List<SecondStreetListItem> oldlist = new List<SecondStreetListItem>(); //1回前のリクエストで取得した商品リスト(重複を避ける)
        List<SecondStreetListItem> addlist = new List<SecondStreetListItem>(); //GUI更新時にタイムラインに追加すべき商品リスト
        //static List<string> boughtItemIDList = new List<string>(); //手動・自動購入した商品IDのリスト
        //static List<BoughtItemListForm.BoughtItem> boughtItemList = new List<BoughtItemListForm.BoughtItem>();
        int nowfocus = 0; //タイムラインの中の上から何個目を選択しているか
        bool soundOn = false;//新着商品時に音をならすか
        static BackgroundWorker bgWorker;
        static int dummy_report_progress = 0;
        //public const string Key_LicenseKey = "LicenseKey";
        //public const string Registry_Path = @"HKEY_CURRENT_USER\Software\FriWatcher";

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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            new SettingsDBHelper().onCreate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "ブランド名取得中";
            //string jsonstr = "";
            //byte[] bytes = webClient.DownloadData("https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods");
            //jsonstr = Encoding.UTF8.GetString(bytes);
            //Console.WriteLine(jsonstr);
            //DownloadAsync();
            postNewBrand();
            label1.Text ="待機中";
        }
        //ブランド情報の取得
        private List<SecondStreetListBrand> postNewBrand() {

            //リクエスト部
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.2ndstreet.jp/index.php/api_2_0/AppMaster/getBrands");
            req.Method = "POST";
            req.UserAgent = agent;
            HttpWebResponse rawres = (HttpWebResponse)req.GetResponse();
            Stream s = rawres.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            //パース部
            dynamic resjson = DynamicJson.Parse(content);
            List<SecondStreetListBrand> rst = new List<SecondStreetListBrand>();
            try
            {
                foreach (var itemjson in resjson.value)
                {
                    rst.Add(new SecondStreetListBrand(itemjson));
                    Console.WriteLine(itemjson);
                }
                label1.Text = "待機";
                return rst;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("セカンドストリートタイムラインjsonパース失敗");
                label1.Text = "ブランド名取得エラー";
                return rst;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "新着商品取得中";
            postNewItem();
        }

        //新着アイテムの取得
        private List<SecondStreetListItem> postNewItem()
        {
            //リクエスト部
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods");
            req.Method = "POST";
            req.UserAgent = agent;
            HttpWebResponse rawres = (HttpWebResponse)req.GetResponse();
            Stream s = rawres.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string content = sr.ReadToEnd();
            //パース部
            dynamic resjson = DynamicJson.Parse(content);
            List<SecondStreetListItem> rst = new List<SecondStreetListItem>();
            try
            {
                foreach (var itemjson in resjson.value)
                {
                    rst.Add(new SecondStreetListItem(itemjson));
                    Console.WriteLine(itemjson);
                }
                label1.Text = "待機状態";
                return rst;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("セカンドストリートタイムラインjsonパース失敗");
                label1.Text = "新着アイテム取得エラー";
                return rst;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        //更新ボタン
        private void button4_Click(object sender, EventArgs e)
        {

        }
       

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //GUI更新
            //リストに存在していないものだけをリストにいれる
            //まだリストに存在していないものだけをリストにいれる
            foreach (var item in addlist)
            {
                bool isexist = false;
                foreach (var binditem in bindlist) if (item.goods_id == binditem.goods_id) isexist = true;
                if (isexist == false)
                {
                    bindlist.Add(item);
                    AddSecondStreetItemPanel(item);
                }
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
            if (SettingForm.getAutoScroll()) 
            {
                //panel.SetFocusBuyButton();
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
                //GetItemProcess.resetMaxID();
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
                //rst = GetItemProcess.getNewMatchingItems();
                rst = SecondStreetAPI.postNewItem();
                //出品者指定の新着商品を取得
                //rst.AddRange(GetItemProcess.getNewSpecificSellerItems());
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





        //////////////////////////////このへんは開発中のもの///////////////////////////////////////////
        // Step5: メソッド内でawaitキーワードを使ったら、メソッドの先頭でasyncを加えなければならない。
        // Step6: メソッド内でawaitキーワードを使ったら、戻り値の型はTask<T>型で返さなければならない。
        //        T型は本来返すべき戻り値の型。。
        //public static async Task<string> ReadFromUrlAsync(Uri url)
        //{
        //    using (WebClient webClient = new WebClient())
        //    {
        //        // Step1: OpenReadから非同期対応のOpenReadTaskAsyncに変更する。
        //        // Step2: OpenReadTaskAsyncがTask<Stream>を返すので、awaitする。
        //        //        awaitすると、Streamが得られる。

        //        try
        //        {
        //            using (Stream stream = await webClient.OpenReadTaskAsync(url))
        //            {
        //                TextReader tr = new StreamReader(stream, Encoding.UTF8, true);
        //                // Step3: ReadToEndから非同期対応のReadToEndAsyncに変更する。
        //                // Step4: ReadToEndAsyncがTask<string>を返すので、awaitする。
        //                //        awaitすると、stringが得られる。
        //                string body = await tr.ReadToEndAsync();
        //                return body;
        //            }

        //        }catch (WebException e)
        //        {
        //            Console.Write(e);
        //            Console.WriteLine("ぼけ");
        //        }
        //        //using (Stream stream = await webClient.OpenReadTaskAsync(url))
        //        //{
        //        //    TextReader tr = new StreamReader(stream, Encoding.UTF8, true);
        //        //    // Step3: ReadToEndから非同期対応のReadToEndAsyncに変更する。
        //        //    // Step4: ReadToEndAsyncがTask<string>を返すので、awaitする。
        //        //    //        awaitすると、stringが得られる。
        //        //    string body = await tr.ReadToEndAsync();
        //        //    return body;
        //        //}
        //    }
        //}


        //public static async Task DownloadAsync()
        //{//https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods
        //    Uri url = new Uri("https://google.co.jp");
        //    string body = await ReadFromUrlAsync(url);
        //    Console.WriteLine(body);
        //}


    }
}
