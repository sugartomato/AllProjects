﻿namespace KK.WechatAuto
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSendTextMsg = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendImageMsg = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtReceivers = new System.Windows.Forms.TextBox();
            this.txtUseragent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtSubscribe = new System.Windows.Forms.RadioButton();
            this.rbtUser = new System.Windows.Forms.RadioButton();
            this.rbtGroup = new System.Windows.Forms.RadioButton();
            this.lblState = new System.Windows.Forms.Label();
            this.btnViewSession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "加载登陆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(950, 67);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(174, 469);
            this.txtConsole.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "加载联系人";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSendTextMsg
            // 
            this.btnSendTextMsg.Location = new System.Drawing.Point(2, 126);
            this.btnSendTextMsg.Name = "btnSendTextMsg";
            this.btnSendTextMsg.Size = new System.Drawing.Size(75, 35);
            this.btnSendTextMsg.TabIndex = 4;
            this.btnSendTextMsg.Text = "发送文本";
            this.btnSendTextMsg.UseVisualStyleBackColor = true;
            this.btnSendTextMsg.Click += new System.EventHandler(this.OnClick_Test_SendTextMsg);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(552, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(304, 469);
            this.dataGridView1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnViewSession);
            this.panel1.Controls.Add(this.btnSendImageMsg);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSendTextMsg);
            this.panel1.Location = new System.Drawing.Point(862, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 469);
            this.panel1.TabIndex = 7;
            // 
            // btnSendImageMsg
            // 
            this.btnSendImageMsg.Location = new System.Drawing.Point(2, 85);
            this.btnSendImageMsg.Name = "btnSendImageMsg";
            this.btnSendImageMsg.Size = new System.Drawing.Size(75, 35);
            this.btnSendImageMsg.TabIndex = 4;
            this.btnSendImageMsg.Text = "发送图片";
            this.btnSendImageMsg.UseVisualStyleBackColor = true;
            this.btnSendImageMsg.Click += new System.EventHandler(this.OnClick_Test_SendImageMsg);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(11, 261);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(363, 116);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.Text = "";
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 12;
            this.listFiles.Location = new System.Drawing.Point(11, 412);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(363, 124);
            this.listFiles.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(56, 381);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 13;
            this.button5.Text = "选择文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(245, 194);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(129, 46);
            this.btnSendMsg.TabIndex = 14;
            this.btnSendMsg.Text = "发送";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtReceivers
            // 
            this.txtReceivers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceivers.Location = new System.Drawing.Point(391, 67);
            this.txtReceivers.Multiline = true;
            this.txtReceivers.Name = "txtReceivers";
            this.txtReceivers.Size = new System.Drawing.Size(155, 469);
            this.txtReceivers.TabIndex = 15;
            // 
            // txtUseragent
            // 
            this.txtUseragent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUseragent.Location = new System.Drawing.Point(464, 7);
            this.txtUseragent.Name = "txtUseragent";
            this.txtUseragent.Size = new System.Drawing.Size(660, 21);
            this.txtUseragent.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(388, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "UserAgent";
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Location = new System.Drawing.Point(195, 6);
            this.txtState.Multiline = true;
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtState.Size = new System.Drawing.Size(179, 171);
            this.txtState.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(389, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "接收人(昵称或备注名)\r\n每行1个";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "文件：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "文本消息：";
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearConsole.Location = new System.Drawing.Point(1049, 38);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(75, 23);
            this.btnClearConsole.TabIndex = 22;
            this.btnClearConsole.Text = "清空";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.Location = new System.Drawing.Point(3, 7);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(47, 16);
            this.rbtAll.TabIndex = 23;
            this.rbtAll.TabStop = true;
            this.rbtAll.Tag = "all";
            this.rbtAll.Text = "所有";
            this.rbtAll.UseVisualStyleBackColor = true;
            this.rbtAll.CheckedChanged += new System.EventHandler(this.CheckedChanged_ContactType);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtSubscribe);
            this.panel2.Controls.Add(this.rbtUser);
            this.panel2.Controls.Add(this.rbtGroup);
            this.panel2.Controls.Add(this.rbtAll);
            this.panel2.Location = new System.Drawing.Point(552, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 32);
            this.panel2.TabIndex = 24;
            // 
            // rbtSubscribe
            // 
            this.rbtSubscribe.AutoSize = true;
            this.rbtSubscribe.Location = new System.Drawing.Point(168, 7);
            this.rbtSubscribe.Name = "rbtSubscribe";
            this.rbtSubscribe.Size = new System.Drawing.Size(59, 16);
            this.rbtSubscribe.TabIndex = 27;
            this.rbtSubscribe.Tag = "subscribe";
            this.rbtSubscribe.Text = "订阅号";
            this.rbtSubscribe.UseVisualStyleBackColor = true;
            this.rbtSubscribe.CheckedChanged += new System.EventHandler(this.CheckedChanged_ContactType);
            // 
            // rbtUser
            // 
            this.rbtUser.AutoSize = true;
            this.rbtUser.Location = new System.Drawing.Point(115, 7);
            this.rbtUser.Name = "rbtUser";
            this.rbtUser.Size = new System.Drawing.Size(47, 16);
            this.rbtUser.TabIndex = 26;
            this.rbtUser.Tag = "friend";
            this.rbtUser.Text = "好友";
            this.rbtUser.UseVisualStyleBackColor = true;
            this.rbtUser.CheckedChanged += new System.EventHandler(this.CheckedChanged_ContactType);
            // 
            // rbtGroup
            // 
            this.rbtGroup.AutoSize = true;
            this.rbtGroup.Location = new System.Drawing.Point(56, 7);
            this.rbtGroup.Name = "rbtGroup";
            this.rbtGroup.Size = new System.Drawing.Size(47, 16);
            this.rbtGroup.TabIndex = 25;
            this.rbtGroup.Tag = "group";
            this.rbtGroup.Text = "群组";
            this.rbtGroup.UseVisualStyleBackColor = true;
            this.rbtGroup.CheckedChanged += new System.EventHandler(this.CheckedChanged_ContactType);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Black;
            this.lblState.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.Lime;
            this.lblState.Location = new System.Drawing.Point(12, 180);
            this.lblState.Name = "lblState";
            this.lblState.Padding = new System.Windows.Forms.Padding(4);
            this.lblState.Size = new System.Drawing.Size(43, 22);
            this.lblState.TabIndex = 25;
            this.lblState.Text = "就绪";
            // 
            // btnViewSession
            // 
            this.btnViewSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewSession.Location = new System.Drawing.Point(3, 429);
            this.btnViewSession.Name = "btnViewSession";
            this.btnViewSession.Size = new System.Drawing.Size(75, 35);
            this.btnViewSession.TabIndex = 5;
            this.btnViewSession.Text = "Session";
            this.btnViewSession.UseVisualStyleBackColor = true;
            this.btnViewSession.Click += new System.EventHandler(this.btnViewSession_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 548);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClearConsole);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUseragent);
            this.Controls.Add(this.txtReceivers);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信自动群发";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSendTextMsg;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Button btnSendImageMsg;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtReceivers;
        private System.Windows.Forms.TextBox txtUseragent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtGroup;
        private System.Windows.Forms.RadioButton rbtUser;
        private System.Windows.Forms.RadioButton rbtSubscribe;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnViewSession;
    }
}

