namespace SSLand
{
    partial class SecondStreetItemPanel
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shopNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenBrowserButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.brandNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemNameLabel.Location = new System.Drawing.Point(6, 254);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(113, 30);
            this.itemNameLabel.TabIndex = 0;
            this.itemNameLabel.Text = "アイテム名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "店舗名：";
            // 
            // shopNameLabel
            // 
            this.shopNameLabel.AutoSize = true;
            this.shopNameLabel.Location = new System.Drawing.Point(64, 356);
            this.shopNameLabel.Name = "shopNameLabel";
            this.shopNameLabel.Size = new System.Drawing.Size(76, 15);
            this.shopNameLabel.TabIndex = 3;
            this.shopNameLabel.Text = "shop_name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 306);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 41);
            this.label1.TabIndex = 37;
            this.label1.Text = "価格 :";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PriceLabel.ForeColor = System.Drawing.Color.Red;
            this.PriceLabel.Location = new System.Drawing.Point(89, 306);
            this.PriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(63, 41);
            this.PriceLabel.TabIndex = 38;
            this.PriceLabel.Text = "0円";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OpenBrowserButton);
            this.panel1.Location = new System.Drawing.Point(152, 352);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 66);
            this.panel1.TabIndex = 44;
            // 
            // OpenBrowserButton
            // 
            this.OpenBrowserButton.BackColor = System.Drawing.Color.Teal;
            this.OpenBrowserButton.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OpenBrowserButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OpenBrowserButton.Location = new System.Drawing.Point(4, 4);
            this.OpenBrowserButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenBrowserButton.Name = "OpenBrowserButton";
            this.OpenBrowserButton.Size = new System.Drawing.Size(133, 58);
            this.OpenBrowserButton.TabIndex = 25;
            this.OpenBrowserButton.TabStop = false;
            this.OpenBrowserButton.Text = "開く";
            this.OpenBrowserButton.UseVisualStyleBackColor = false;
            this.OpenBrowserButton.Click += new System.EventHandler(this.OpenBrowserButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(8, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 46;
            this.label3.Text = "サイズ：";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(64, 383);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(32, 15);
            this.sizeLabel.TabIndex = 47;
            this.sizeLabel.Text = "size";
            // 
            // brandNameLabel
            // 
            this.brandNameLabel.AutoSize = true;
            this.brandNameLabel.Location = new System.Drawing.Point(8, 284);
            this.brandNameLabel.Name = "brandNameLabel";
            this.brandNameLabel.Size = new System.Drawing.Size(80, 15);
            this.brandNameLabel.TabIndex = 48;
            this.brandNameLabel.Text = "brand_name";
            // 
            // SecondStreetItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.brandNameLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.shopNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemNameLabel);
            this.Name = "SecondStreetItemPanel";
            this.Size = new System.Drawing.Size(297, 422);
            this.Load += new System.EventHandler(this.SecondStreetItemPanel_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label shopNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OpenBrowserButton;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label brandNameLabel;
    }
}
