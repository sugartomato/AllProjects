namespace KK.ImageCompress
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRecurse = new System.Windows.Forms.CheckBox();
            this.rbtnReplaceOrignal = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelChkFileExt = new System.Windows.Forms.Panel();
            this.chkExGIF = new System.Windows.Forms.CheckBox();
            this.chkExBMP = new System.Windows.Forms.CheckBox();
            this.chkExPNG = new System.Windows.Forms.CheckBox();
            this.chkExJPG = new System.Windows.Forms.CheckBox();
            this.chkExJPEG = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompressLevel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnClearMsg = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelChkFileExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFolder.Location = new System.Drawing.Point(118, 12);
            this.txtFolder.Multiline = true;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(796, 35);
            this.txtFolder.TabIndex = 0;
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(100, 35);
            this.btnSelFolder.TabIndex = 2;
            this.btnSelFolder.Text = "选择目录";
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.Cornsilk;
            this.txtConsole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtConsole.Location = new System.Drawing.Point(437, 121);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(477, 344);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.Text = "";
            this.txtConsole.Click += new System.EventHandler(this.txtConsole_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRecurse);
            this.groupBox1.Location = new System.Drawing.Point(210, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 134);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // chkRecurse
            // 
            this.chkRecurse.AutoSize = true;
            this.chkRecurse.Location = new System.Drawing.Point(19, 29);
            this.chkRecurse.Name = "chkRecurse";
            this.chkRecurse.Size = new System.Drawing.Size(84, 16);
            this.chkRecurse.TabIndex = 0;
            this.chkRecurse.Text = "递归子目录";
            this.chkRecurse.UseVisualStyleBackColor = true;
            // 
            // rbtnReplaceOrignal
            // 
            this.rbtnReplaceOrignal.AutoSize = true;
            this.rbtnReplaceOrignal.Location = new System.Drawing.Point(14, 136);
            this.rbtnReplaceOrignal.Name = "rbtnReplaceOrignal";
            this.rbtnReplaceOrignal.Size = new System.Drawing.Size(83, 16);
            this.rbtnReplaceOrignal.TabIndex = 5;
            this.rbtnReplaceOrignal.TabStop = true;
            this.rbtnReplaceOrignal.Text = "替换原文件";
            this.rbtnReplaceOrignal.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 158);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(179, 16);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "保存原图所在目录并添加后缀";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 180);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(107, 16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "保存到指定目录";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(31, 202);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("黑体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(437, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 62);
            this.button1.TabIndex = 9;
            this.button1.Text = "处理";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelChkFileExt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCompressLevel);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Location = new System.Drawing.Point(14, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 202);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "压缩选项";
            // 
            // panelChkFileExt
            // 
            this.panelChkFileExt.Controls.Add(this.chkExGIF);
            this.panelChkFileExt.Controls.Add(this.chkExBMP);
            this.panelChkFileExt.Controls.Add(this.chkExPNG);
            this.panelChkFileExt.Controls.Add(this.chkExJPG);
            this.panelChkFileExt.Controls.Add(this.chkExJPEG);
            this.panelChkFileExt.Location = new System.Drawing.Point(17, 83);
            this.panelChkFileExt.Name = "panelChkFileExt";
            this.panelChkFileExt.Size = new System.Drawing.Size(387, 100);
            this.panelChkFileExt.TabIndex = 5;
            // 
            // chkExGIF
            // 
            this.chkExGIF.AutoSize = true;
            this.chkExGIF.Location = new System.Drawing.Point(231, 13);
            this.chkExGIF.Name = "chkExGIF";
            this.chkExGIF.Size = new System.Drawing.Size(48, 16);
            this.chkExGIF.TabIndex = 7;
            this.chkExGIF.Tag = ".gif";
            this.chkExGIF.Text = ".GIF";
            this.chkExGIF.UseVisualStyleBackColor = true;
            this.chkExGIF.CheckedChanged += new System.EventHandler(this.chkEx_CheckedChanged);
            // 
            // chkExBMP
            // 
            this.chkExBMP.AutoSize = true;
            this.chkExBMP.Location = new System.Drawing.Point(177, 13);
            this.chkExBMP.Name = "chkExBMP";
            this.chkExBMP.Size = new System.Drawing.Size(48, 16);
            this.chkExBMP.TabIndex = 6;
            this.chkExBMP.Tag = ".bmp";
            this.chkExBMP.Text = ".BMP";
            this.chkExBMP.UseVisualStyleBackColor = true;
            this.chkExBMP.CheckedChanged += new System.EventHandler(this.chkEx_CheckedChanged);
            // 
            // chkExPNG
            // 
            this.chkExPNG.AutoSize = true;
            this.chkExPNG.Location = new System.Drawing.Point(123, 13);
            this.chkExPNG.Name = "chkExPNG";
            this.chkExPNG.Size = new System.Drawing.Size(48, 16);
            this.chkExPNG.TabIndex = 5;
            this.chkExPNG.Tag = ".png";
            this.chkExPNG.Text = ".PNG";
            this.chkExPNG.UseVisualStyleBackColor = true;
            this.chkExPNG.CheckedChanged += new System.EventHandler(this.chkEx_CheckedChanged);
            // 
            // chkExJPG
            // 
            this.chkExJPG.AutoSize = true;
            this.chkExJPG.Checked = true;
            this.chkExJPG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExJPG.Location = new System.Drawing.Point(9, 13);
            this.chkExJPG.Name = "chkExJPG";
            this.chkExJPG.Size = new System.Drawing.Size(48, 16);
            this.chkExJPG.TabIndex = 3;
            this.chkExJPG.Tag = ".jpg";
            this.chkExJPG.Text = ".JPG";
            this.chkExJPG.UseVisualStyleBackColor = true;
            this.chkExJPG.CheckedChanged += new System.EventHandler(this.chkEx_CheckedChanged);
            // 
            // chkExJPEG
            // 
            this.chkExJPEG.AutoSize = true;
            this.chkExJPEG.Checked = true;
            this.chkExJPEG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExJPEG.Location = new System.Drawing.Point(63, 13);
            this.chkExJPEG.Name = "chkExJPEG";
            this.chkExJPEG.Size = new System.Drawing.Size(54, 16);
            this.chkExJPEG.TabIndex = 4;
            this.chkExJPEG.Tag = ".jpeg";
            this.chkExJPEG.Text = ".JPEG";
            this.chkExJPEG.UseVisualStyleBackColor = true;
            this.chkExJPEG.CheckedChanged += new System.EventHandler(this.chkEx_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(87, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "压缩比例从1到100，数值越大质量越高，数值越小文件越小";
            // 
            // lblCompressLevel
            // 
            this.lblCompressLevel.AutoSize = true;
            this.lblCompressLevel.Location = new System.Drawing.Point(15, 37);
            this.lblCompressLevel.Name = "lblCompressLevel";
            this.lblCompressLevel.Size = new System.Drawing.Size(71, 12);
            this.lblCompressLevel.TabIndex = 1;
            this.lblCompressLevel.Text = "压缩比例:80";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(89, 20);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(322, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 80;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnClearMsg
            // 
            this.btnClearMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearMsg.Location = new System.Drawing.Point(758, 80);
            this.btnClearMsg.Name = "btnClearMsg";
            this.btnClearMsg.Size = new System.Drawing.Size(75, 35);
            this.btnClearMsg.TabIndex = 11;
            this.btnClearMsg.Text = "清空消息";
            this.btnClearMsg.UseVisualStyleBackColor = true;
            this.btnClearMsg.Click += new System.EventHandler(this.btnClearMsg_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(839, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "消息另存为";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 477);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnClearMsg);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rbtnReplaceOrignal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnSelFolder);
            this.Controls.Add(this.txtFolder);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelChkFileExt.ResumeLayout(false);
            this.panelChkFileExt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRecurse;
        private System.Windows.Forms.RadioButton rbtnReplaceOrignal;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearMsg;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompressLevel;
        private System.Windows.Forms.CheckBox chkExJPG;
        private System.Windows.Forms.Panel panelChkFileExt;
        private System.Windows.Forms.CheckBox chkExBMP;
        private System.Windows.Forms.CheckBox chkExPNG;
        private System.Windows.Forms.CheckBox chkExJPEG;
        private System.Windows.Forms.CheckBox chkExGIF;
    }
}

