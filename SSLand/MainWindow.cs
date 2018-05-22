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


namespace SSLand
{
    public partial class MainWindow : Form
    {
        WebClient webClient = new WebClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void アカウント管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form account_form = new Account();
            account_form.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button");
            string jsonstr = "";
            byte[] bytes = webClient.DownloadData("https://www.2ndstreet.jp/index.php/api_2_0/AppMain/getNewGoods");
            jsonstr = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(jsonstr);
            //DownloadAsync();

        }

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
