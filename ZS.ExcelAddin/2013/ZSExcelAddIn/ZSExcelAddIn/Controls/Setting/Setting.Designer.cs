namespace ZSExcelAddIn.Controls.Setting
{
    partial class Setting
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabItemGeneral = new System.Windows.Forms.TabPage();
            this.panelSpotlightColor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPinnedFiles = new System.Windows.Forms.TabPage();
            this.ucPinnedFiles1 = new ZSExcelAddIn.Controls.Setting.ucPinnedFiles();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabItemGeneral.SuspendLayout();
            this.tabPinnedFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabItemGeneral);
            this.tabMain.Controls.Add(this.tabPinnedFiles);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(694, 409);
            this.tabMain.TabIndex = 0;
            // 
            // tabItemGeneral
            // 
            this.tabItemGeneral.Controls.Add(this.panelSpotlightColor);
            this.tabItemGeneral.Controls.Add(this.label1);
            this.tabItemGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabItemGeneral.Name = "tabItemGeneral";
            this.tabItemGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabItemGeneral.Size = new System.Drawing.Size(686, 383);
            this.tabItemGeneral.TabIndex = 0;
            this.tabItemGeneral.Text = "通用";
            this.tabItemGeneral.UseVisualStyleBackColor = true;
            // 
            // panelSpotlightColor
            // 
            this.panelSpotlightColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpotlightColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelSpotlightColor.Location = new System.Drawing.Point(96, 9);
            this.panelSpotlightColor.Name = "panelSpotlightColor";
            this.panelSpotlightColor.Size = new System.Drawing.Size(84, 23);
            this.panelSpotlightColor.TabIndex = 1;
            this.panelSpotlightColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelSpotlightColor_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "聚光灯颜色";
            // 
            // tabPinnedFiles
            // 
            this.tabPinnedFiles.Controls.Add(this.ucPinnedFiles1);
            this.tabPinnedFiles.Location = new System.Drawing.Point(4, 22);
            this.tabPinnedFiles.Name = "tabPinnedFiles";
            this.tabPinnedFiles.Size = new System.Drawing.Size(686, 383);
            this.tabPinnedFiles.TabIndex = 1;
            this.tabPinnedFiles.Text = "固定文件";
            this.tabPinnedFiles.UseVisualStyleBackColor = true;
            // 
            // ucPinnedFiles1
            // 
            this.ucPinnedFiles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPinnedFiles1.Location = new System.Drawing.Point(0, 0);
            this.ucPinnedFiles1.Name = "ucPinnedFiles1";
            this.ucPinnedFiles1.Size = new System.Drawing.Size(686, 383);
            this.ucPinnedFiles1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(602, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "关闭(&C)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(516, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 457);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabMain);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.tabMain.ResumeLayout(false);
            this.tabItemGeneral.ResumeLayout(false);
            this.tabItemGeneral.PerformLayout();
            this.tabPinnedFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabItemGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSpotlightColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabPinnedFiles;
        private ucPinnedFiles ucPinnedFiles1;
    }
}