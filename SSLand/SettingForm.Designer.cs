namespace SSLand
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.photosizeNumericDown = new System.Windows.Forms.NumericUpDown();
            this.autoscrollCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useBrandCheckBox = new System.Windows.Forms.CheckBox();
            this.brandComboBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.brandAddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photosizeNumericDown)).BeginInit();
            this.SuspendLayout();
            // 
            // photosizeNumericDown
            // 
            this.photosizeNumericDown.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.photosizeNumericDown.Location = new System.Drawing.Point(202, 353);
            this.photosizeNumericDown.Margin = new System.Windows.Forms.Padding(4);
            this.photosizeNumericDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.photosizeNumericDown.Minimum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.photosizeNumericDown.Name = "photosizeNumericDown";
            this.photosizeNumericDown.Size = new System.Drawing.Size(105, 30);
            this.photosizeNumericDown.TabIndex = 16;
            this.photosizeNumericDown.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // autoscrollCheckBox
            // 
            this.autoscrollCheckBox.AutoSize = true;
            this.autoscrollCheckBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoscrollCheckBox.Location = new System.Drawing.Point(102, 8);
            this.autoscrollCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.autoscrollCheckBox.Name = "autoscrollCheckBox";
            this.autoscrollCheckBox.Size = new System.Drawing.Size(374, 29);
            this.autoscrollCheckBox.TabIndex = 15;
            this.autoscrollCheckBox.Text = "新しい商品があれば自動でスクロールを移動";
            this.autoscrollCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(97, 354);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "写真サイズ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(97, 418);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "※設定は閉じると自動保存されます";
            // 
            // useBrandCheckBox
            // 
            this.useBrandCheckBox.AutoSize = true;
            this.useBrandCheckBox.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.useBrandCheckBox.Location = new System.Drawing.Point(102, 45);
            this.useBrandCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.useBrandCheckBox.Name = "useBrandCheckBox";
            this.useBrandCheckBox.Size = new System.Drawing.Size(187, 29);
            this.useBrandCheckBox.TabIndex = 25;
            this.useBrandCheckBox.Text = "ブランドを指定する";
            this.useBrandCheckBox.UseVisualStyleBackColor = true;
            this.useBrandCheckBox.CheckedChanged += new System.EventHandler(this.useBrandCheckBox_CheckedChanged);
            // 
            // brandComboBox
            // 
            this.brandComboBox.FormattingEnabled = true;
            this.brandComboBox.Location = new System.Drawing.Point(102, 82);
            this.brandComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.brandComboBox.Name = "brandComboBox";
            this.brandComboBox.Size = new System.Drawing.Size(557, 23);
            this.brandComboBox.TabIndex = 26;
            this.brandComboBox.Text = "未指定";
            this.brandComboBox.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(102, 171);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(676, 169);
            this.listBox1.TabIndex = 27;
            // 
            // brandAddButton
            // 
            this.brandAddButton.Location = new System.Drawing.Point(666, 81);
            this.brandAddButton.Name = "brandAddButton";
            this.brandAddButton.Size = new System.Drawing.Size(112, 24);
            this.brandAddButton.TabIndex = 28;
            this.brandAddButton.Text = "指定する";
            this.brandAddButton.UseVisualStyleBackColor = true;
            this.brandAddButton.Visible = false;
            this.brandAddButton.Click += new System.EventHandler(this.brandAddButton_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.brandAddButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.brandComboBox);
            this.Controls.Add(this.useBrandCheckBox);
            this.Controls.Add(this.photosizeNumericDown);
            this.Controls.Add(this.autoscrollCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photosizeNumericDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown photosizeNumericDown;
        private System.Windows.Forms.CheckBox autoscrollCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox useBrandCheckBox;
        private System.Windows.Forms.ComboBox brandComboBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button brandAddButton;
    }
}