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
    public partial class MainWindow : Form
    {
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
    }
}
