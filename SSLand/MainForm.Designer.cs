namespace SSLand
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.購入者管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.検索条件の設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ライセンスToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.startProcessButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.soundToggleButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.goodsIDTextBox = new System.Windows.Forms.TextBox();
            this.shopIDTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1076, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.購入者管理ToolStripMenuItem,
            this.設定ToolStripMenuItem,
            this.検索条件の設定ToolStripMenuItem,
            this.ライセンスToolStripMenuItem});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // 購入者管理ToolStripMenuItem
            // 
            this.購入者管理ToolStripMenuItem.Name = "購入者管理ToolStripMenuItem";
            this.購入者管理ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.購入者管理ToolStripMenuItem.Text = "アカウント管理";
            this.購入者管理ToolStripMenuItem.Click += new System.EventHandler(this.アカウント管理ToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.設定ToolStripMenuItem.Text = "設定";
            this.設定ToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // 検索条件の設定ToolStripMenuItem
            // 
            this.検索条件の設定ToolStripMenuItem.Name = "検索条件の設定ToolStripMenuItem";
            this.検索条件の設定ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.検索条件の設定ToolStripMenuItem.Text = "検索条件の設定";
            this.検索条件の設定ToolStripMenuItem.Click += new System.EventHandler(this.検索条件の設定ToolStripMenuItem_Click);
            // 
            // ライセンスToolStripMenuItem
            // 
            this.ライセンスToolStripMenuItem.Name = "ライセンスToolStripMenuItem";
            this.ライセンスToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ライセンスToolStripMenuItem.Text = "ライセンス";
            this.ライセンスToolStripMenuItem.Click += new System.EventHandler(this.ライセンスToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // startProcessButton
            // 
            this.startProcessButton.Location = new System.Drawing.Point(11, 25);
            this.startProcessButton.Name = "startProcessButton";
            this.startProcessButton.Size = new System.Drawing.Size(84, 33);
            this.startProcessButton.TabIndex = 16;
            this.startProcessButton.Text = "監視開始(z)";
            this.startProcessButton.UseVisualStyleBackColor = true;
            this.startProcessButton.Click += new System.EventHandler(this.startProcessButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 81);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(933, 288);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(248, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 21);
            this.button5.TabIndex = 19;
            this.button5.Text = "代引き購入テスト";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1076, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // soundToggleButton
            // 
            this.soundToggleButton.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.soundToggleButton.Location = new System.Drawing.Point(101, 27);
            this.soundToggleButton.Name = "soundToggleButton";
            this.soundToggleButton.Size = new System.Drawing.Size(62, 33);
            this.soundToggleButton.TabIndex = 21;
            this.soundToggleButton.TabStop = false;
            this.soundToggleButton.Text = "📢";
            this.soundToggleButton.UseVisualStyleBackColor = true;
            this.soundToggleButton.Click += new System.EventHandler(this.soundToggleButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.goodsIDTextBox);
            this.groupBox1.Controls.Add(this.shopIDTextBox);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(397, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(365, 49);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "購入テスト";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "goodsID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "shopID";
            // 
            // goodsIDTextBox
            // 
            this.goodsIDTextBox.Location = new System.Drawing.Point(97, 29);
            this.goodsIDTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.goodsIDTextBox.Name = "goodsIDTextBox";
            this.goodsIDTextBox.Size = new System.Drawing.Size(147, 19);
            this.goodsIDTextBox.TabIndex = 24;
            // 
            // shopIDTextBox
            // 
            this.shopIDTextBox.Location = new System.Drawing.Point(97, 9);
            this.shopIDTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shopIDTextBox.Name = "shopIDTextBox";
            this.shopIDTextBox.Size = new System.Drawing.Size(147, 19);
            this.shopIDTextBox.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 527);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.soundToggleButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startProcessButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MainForm";
            this.Text = "SSLand";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 購入者管理ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button startProcessButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem ライセンスToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button soundToggleButton;
        private System.Windows.Forms.ToolStripMenuItem 検索条件の設定ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox goodsIDTextBox;
        private System.Windows.Forms.TextBox shopIDTextBox;
    }
}

