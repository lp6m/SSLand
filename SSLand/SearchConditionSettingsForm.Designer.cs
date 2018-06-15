namespace SSLand {
    partial class SearchConditionSettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryComboBox3 = new System.Windows.Forms.ComboBox();
            this.categoryComboBox2 = new System.Windows.Forms.ComboBox();
            this.brandComboBox = new System.Windows.Forms.ComboBox();
            this.useBrandCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.categoryComboBox1 = new System.Windows.Forms.ComboBox();
            this.useCategoryCheckBox = new System.Windows.Forms.CheckBox();
            this.conditionNameTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addSearchConditionButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteSearchConditionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(556, 184);
            this.listBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "検索条件一覧";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "検索条件の追加";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "カテゴリ";
            // 
            // categoryComboBox3
            // 
            this.categoryComboBox3.FormattingEnabled = true;
            this.categoryComboBox3.Location = new System.Drawing.Point(26, 341);
            this.categoryComboBox3.Name = "categoryComboBox3";
            this.categoryComboBox3.Size = new System.Drawing.Size(154, 20);
            this.categoryComboBox3.TabIndex = 37;
            this.categoryComboBox3.Text = "未指定";
            this.categoryComboBox3.Visible = false;
            this.categoryComboBox3.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.categoryComboBox3_Format);
            // 
            // categoryComboBox2
            // 
            this.categoryComboBox2.FormattingEnabled = true;
            this.categoryComboBox2.Location = new System.Drawing.Point(26, 315);
            this.categoryComboBox2.Name = "categoryComboBox2";
            this.categoryComboBox2.Size = new System.Drawing.Size(154, 20);
            this.categoryComboBox2.TabIndex = 36;
            this.categoryComboBox2.Text = "未指定";
            this.categoryComboBox2.Visible = false;
            this.categoryComboBox2.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox2_SelectedIndexChanged);
            this.categoryComboBox2.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.categoryComboBox2_Format);
            // 
            // brandComboBox
            // 
            this.brandComboBox.FormattingEnabled = true;
            this.brandComboBox.Location = new System.Drawing.Point(199, 289);
            this.brandComboBox.Name = "brandComboBox";
            this.brandComboBox.Size = new System.Drawing.Size(154, 20);
            this.brandComboBox.TabIndex = 40;
            this.brandComboBox.Text = "未指定";
            this.brandComboBox.Visible = false;
            this.brandComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.brandComboBox_Format);
            // 
            // useBrandCheckBox
            // 
            this.useBrandCheckBox.AutoSize = true;
            this.useBrandCheckBox.Location = new System.Drawing.Point(242, 267);
            this.useBrandCheckBox.Name = "useBrandCheckBox";
            this.useBrandCheckBox.Size = new System.Drawing.Size(111, 16);
            this.useBrandCheckBox.TabIndex = 39;
            this.useBrandCheckBox.Text = "ブランドを指定する";
            this.useBrandCheckBox.UseVisualStyleBackColor = true;
            this.useBrandCheckBox.CheckedChanged += new System.EventHandler(this.useBrandCheckBox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(197, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 12);
            this.label10.TabIndex = 38;
            this.label10.Text = "ブランド";
            // 
            // categoryComboBox1
            // 
            this.categoryComboBox1.FormattingEnabled = true;
            this.categoryComboBox1.Location = new System.Drawing.Point(26, 289);
            this.categoryComboBox1.Name = "categoryComboBox1";
            this.categoryComboBox1.Size = new System.Drawing.Size(154, 20);
            this.categoryComboBox1.TabIndex = 35;
            this.categoryComboBox1.Text = "未指定";
            this.categoryComboBox1.Visible = false;
            this.categoryComboBox1.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox1_SelectedIndexChanged);
            this.categoryComboBox1.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.categoryComboBox1_Format);
            // 
            // useCategoryCheckBox
            // 
            this.useCategoryCheckBox.AutoSize = true;
            this.useCategoryCheckBox.Location = new System.Drawing.Point(70, 267);
            this.useCategoryCheckBox.Name = "useCategoryCheckBox";
            this.useCategoryCheckBox.Size = new System.Drawing.Size(110, 16);
            this.useCategoryCheckBox.TabIndex = 34;
            this.useCategoryCheckBox.Text = "カテゴリを指定する";
            this.useCategoryCheckBox.UseVisualStyleBackColor = true;
            this.useCategoryCheckBox.CheckedChanged += new System.EventHandler(this.useCategoryCheckBox_CheckedChanged);
            // 
            // conditionNameTextBox
            // 
            this.conditionNameTextBox.Location = new System.Drawing.Point(86, 242);
            this.conditionNameTextBox.Name = "conditionNameTextBox";
            this.conditionNameTextBox.Size = new System.Drawing.Size(245, 19);
            this.conditionNameTextBox.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 43;
            this.label14.Text = "検索条件名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "※変更は設定画面を閉じると自動的に保存されます";
            // 
            // addSearchConditionButton
            // 
            this.addSearchConditionButton.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addSearchConditionButton.Location = new System.Drawing.Point(548, 324);
            this.addSearchConditionButton.Name = "addSearchConditionButton";
            this.addSearchConditionButton.Size = new System.Drawing.Size(118, 43);
            this.addSearchConditionButton.TabIndex = 45;
            this.addSearchConditionButton.Text = "追加";
            this.addSearchConditionButton.UseVisualStyleBackColor = true;
            this.addSearchConditionButton.Click += new System.EventHandler(this.addSearchConditionButton_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.editButton.Location = new System.Drawing.Point(569, 122);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(97, 39);
            this.editButton.TabIndex = 47;
            this.editButton.Text = "編集";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteSearchConditionButton
            // 
            this.deleteSearchConditionButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deleteSearchConditionButton.Location = new System.Drawing.Point(569, 167);
            this.deleteSearchConditionButton.Name = "deleteSearchConditionButton";
            this.deleteSearchConditionButton.Size = new System.Drawing.Size(97, 39);
            this.deleteSearchConditionButton.TabIndex = 48;
            this.deleteSearchConditionButton.Text = "削除";
            this.deleteSearchConditionButton.UseVisualStyleBackColor = true;
            // 
            // SearchConditionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 394);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteSearchConditionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addSearchConditionButton);
            this.Controls.Add(this.conditionNameTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryComboBox3);
            this.Controls.Add(this.categoryComboBox2);
            this.Controls.Add(this.brandComboBox);
            this.Controls.Add(this.useBrandCheckBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.categoryComboBox1);
            this.Controls.Add(this.useCategoryCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Name = "SearchConditionSettingsForm";
            this.Text = "検索条件の設定";
            this.Load += new System.EventHandler(this.SearchConditionSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categoryComboBox3;
        private System.Windows.Forms.ComboBox categoryComboBox2;
        private System.Windows.Forms.ComboBox brandComboBox;
        private System.Windows.Forms.CheckBox useBrandCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox categoryComboBox1;
        private System.Windows.Forms.CheckBox useCategoryCheckBox;
        private System.Windows.Forms.TextBox conditionNameTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addSearchConditionButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteSearchConditionButton;
    }
}