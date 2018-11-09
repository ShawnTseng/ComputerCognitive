namespace CognitiveService
{
    partial class ComputerVisionSpace
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtImageFielPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.comboSelectedFunction = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.comboSelectedLiteralMode = new System.Windows.Forms.ComboBox();
            this.lblLiteralMode = new System.Windows.Forms.Label();
            this.chkSmartCropping = new System.Windows.Forms.CheckBox();
            this.lblHeightRange = new System.Windows.Forms.Label();
            this.lblWidthRange = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.comboSelectedDomain = new System.Windows.Forms.ComboBox();
            this.lblSelectedDomain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "選擇影像";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtImageFielPath
            // 
            this.txtImageFielPath.Location = new System.Drawing.Point(93, 12);
            this.txtImageFielPath.Name = "txtImageFielPath";
            this.txtImageFielPath.Size = new System.Drawing.Size(319, 22);
            this.txtImageFielPath.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 392);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(760, 581);
            this.txtMessage.TabIndex = 4;
            // 
            // comboSelectedFunction
            // 
            this.comboSelectedFunction.FormattingEnabled = true;
            this.comboSelectedFunction.Location = new System.Drawing.Point(66, 21);
            this.comboSelectedFunction.Name = "comboSelectedFunction";
            this.comboSelectedFunction.Size = new System.Drawing.Size(282, 20);
            this.comboSelectedFunction.TabIndex = 5;
            this.comboSelectedFunction.SelectedIndexChanged += new System.EventHandler(this.comboChosenFunction_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(342, 54);
            this.button3.TabIndex = 7;
            this.button3.Text = "執行";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.comboSelectedLiteralMode);
            this.groupBox1.Controls.Add(this.lblLiteralMode);
            this.groupBox1.Controls.Add(this.chkSmartCropping);
            this.groupBox1.Controls.Add(this.lblHeightRange);
            this.groupBox1.Controls.Add(this.lblWidthRange);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.lblHeight);
            this.groupBox1.Controls.Add(this.lblWidth);
            this.groupBox1.Controls.Add(this.comboSelectedDomain);
            this.groupBox1.Controls.Add(this.lblSelectedDomain);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboSelectedFunction);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(418, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 300);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "影像處理";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(6, 174);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(342, 23);
            this.btnCheck.TabIndex = 20;
            this.btnCheck.Text = "文字處理狀態確認";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // comboSelectedLiteralMode
            // 
            this.comboSelectedLiteralMode.FormattingEnabled = true;
            this.comboSelectedLiteralMode.Items.AddRange(new object[] {
            "1:名人",
            "2.地標"});
            this.comboSelectedLiteralMode.Location = new System.Drawing.Point(66, 148);
            this.comboSelectedLiteralMode.Name = "comboSelectedLiteralMode";
            this.comboSelectedLiteralMode.Size = new System.Drawing.Size(282, 20);
            this.comboSelectedLiteralMode.TabIndex = 19;
            // 
            // lblLiteralMode
            // 
            this.lblLiteralMode.AutoSize = true;
            this.lblLiteralMode.Location = new System.Drawing.Point(7, 151);
            this.lblLiteralMode.Name = "lblLiteralMode";
            this.lblLiteralMode.Size = new System.Drawing.Size(53, 12);
            this.lblLiteralMode.TabIndex = 18;
            this.lblLiteralMode.Text = "文字類型";
            // 
            // chkSmartCropping
            // 
            this.chkSmartCropping.AutoSize = true;
            this.chkSmartCropping.Location = new System.Drawing.Point(108, 129);
            this.chkSmartCropping.Name = "chkSmartCropping";
            this.chkSmartCropping.Size = new System.Drawing.Size(72, 16);
            this.chkSmartCropping.TabIndex = 17;
            this.chkSmartCropping.Text = "智慧裁切";
            this.chkSmartCropping.UseVisualStyleBackColor = true;
            // 
            // lblHeightRange
            // 
            this.lblHeightRange.AutoSize = true;
            this.lblHeightRange.Location = new System.Drawing.Point(186, 104);
            this.lblHeightRange.Name = "lblHeightRange";
            this.lblHeightRange.Size = new System.Drawing.Size(55, 12);
            this.lblHeightRange.TabIndex = 16;
            this.lblHeightRange.Text = "(50~1024)";
            // 
            // lblWidthRange
            // 
            this.lblWidthRange.AutoSize = true;
            this.lblWidthRange.Location = new System.Drawing.Point(186, 76);
            this.lblWidthRange.Name = "lblWidthRange";
            this.lblWidthRange.Size = new System.Drawing.Size(55, 12);
            this.lblWidthRange.TabIndex = 15;
            this.lblWidthRange.Text = "(50~1024)";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(66, 101);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(114, 22);
            this.txtHeight.TabIndex = 14;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(66, 73);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(114, 22);
            this.txtWidth.TabIndex = 13;
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(31, 104);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(29, 12);
            this.lblHeight.TabIndex = 12;
            this.lblHeight.Text = "高度";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(31, 76);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(29, 12);
            this.lblWidth.TabIndex = 11;
            this.lblWidth.Text = "寬度";
            // 
            // comboSelectedDomain
            // 
            this.comboSelectedDomain.FormattingEnabled = true;
            this.comboSelectedDomain.Items.AddRange(new object[] {
            "1:名人",
            "2.地標"});
            this.comboSelectedDomain.Location = new System.Drawing.Point(66, 47);
            this.comboSelectedDomain.Name = "comboSelectedDomain";
            this.comboSelectedDomain.Size = new System.Drawing.Size(282, 20);
            this.comboSelectedDomain.TabIndex = 10;
            // 
            // lblSelectedDomain
            // 
            this.lblSelectedDomain.AutoSize = true;
            this.lblSelectedDomain.Location = new System.Drawing.Point(7, 50);
            this.lblSelectedDomain.Name = "lblSelectedDomain";
            this.lblSelectedDomain.Size = new System.Drawing.Size(53, 12);
            this.lblSelectedDomain.TabIndex = 9;
            this.lblSelectedDomain.Text = "選擇領域";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "選擇功能";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Response";
            // 
            // ComputerVisionSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 985);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtImageFielPath);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "ComputerVisionSpace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComputerVisionSpace";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtImageFielPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox comboSelectedFunction;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedDomain;
        private System.Windows.Forms.ComboBox comboSelectedDomain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeightRange;
        private System.Windows.Forms.Label lblWidthRange;
        private System.Windows.Forms.CheckBox chkSmartCropping;
        private System.Windows.Forms.ComboBox comboSelectedLiteralMode;
        private System.Windows.Forms.Label lblLiteralMode;
        private System.Windows.Forms.Button btnCheck;
    }
}

