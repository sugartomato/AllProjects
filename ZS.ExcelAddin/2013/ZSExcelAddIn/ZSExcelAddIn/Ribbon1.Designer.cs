namespace ZSExcelAddIn
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.TabZS = this.Factory.CreateRibbonTab();
            this.group_Display = this.Factory.CreateRibbonGroup();
            this.chkHighLightRowAndCloumn = this.Factory.CreateRibbonCheckBox();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnInsertDate = this.Factory.CreateRibbonButton();
            this.btnInsertTime = this.Factory.CreateRibbonButton();
            this.btnInsertDateTime = this.Factory.CreateRibbonButton();
            this.btnCalendar = this.Factory.CreateRibbonButton();
            this.splitButton1 = this.Factory.CreateRibbonSplitButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.TabZS.SuspendLayout();
            this.group_Display.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabInsert";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabInsert";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnInsertDate);
            this.group1.Items.Add(this.btnInsertTime);
            this.group1.Items.Add(this.btnInsertDateTime);
            this.group1.Items.Add(this.btnCalendar);
            this.group1.Label = "日期与时间";
            this.group1.Name = "group1";
            // 
            // TabZS
            // 
            this.TabZS.Groups.Add(this.group_Display);
            this.TabZS.Groups.Add(this.group2);
            this.TabZS.Label = "我的Excel工具";
            this.TabZS.Name = "TabZS";
            // 
            // group_Display
            // 
            this.group_Display.Items.Add(this.chkHighLightRowAndCloumn);
            this.group_Display.Label = "显示";
            this.group_Display.Name = "group_Display";
            // 
            // chkHighLightRowAndCloumn
            // 
            this.chkHighLightRowAndCloumn.Label = "高亮显示行和列";
            this.chkHighLightRowAndCloumn.Name = "chkHighLightRowAndCloumn";
            this.chkHighLightRowAndCloumn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chkHighLightRowAndCloumn_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.splitButton1);
            this.group2.Label = "group2";
            this.group2.Name = "group2";
            // 
            // btnInsertDate
            // 
            this.btnInsertDate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnInsertDate.Image = global::ZSExcelAddIn.Properties.Resources.Today_32x32;
            this.btnInsertDate.Label = "插入日期";
            this.btnInsertDate.Name = "btnInsertDate";
            this.btnInsertDate.ScreenTip = "插入当前日期";
            this.btnInsertDate.ShowImage = true;
            this.btnInsertDate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertDate_Click);
            // 
            // btnInsertTime
            // 
            this.btnInsertTime.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnInsertTime.Image = global::ZSExcelAddIn.Properties.Resources.Time_32x32;
            this.btnInsertTime.Label = "插入时间";
            this.btnInsertTime.Name = "btnInsertTime";
            this.btnInsertTime.ShowImage = true;
            this.btnInsertTime.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertTime_Click);
            // 
            // btnInsertDateTime
            // 
            this.btnInsertDateTime.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnInsertDateTime.Image = global::ZSExcelAddIn.Properties.Resources.SwitchTimeScalesTo_32x32;
            this.btnInsertDateTime.Label = "插入日期与时间";
            this.btnInsertDateTime.Name = "btnInsertDateTime";
            this.btnInsertDateTime.ShowImage = true;
            this.btnInsertDateTime.SuperTip = "sdfsadfasdfadfasdf";
            this.btnInsertDateTime.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnInsertDateTime_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCalendar.Label = "日历";
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.ShowImage = true;
            this.btnCalendar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCalendar_Click);
            // 
            // splitButton1
            // 
            this.splitButton1.Label = "splitButton1";
            this.splitButton1.Name = "splitButton1";
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.TabZS);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.TabZS.ResumeLayout(false);
            this.TabZS.PerformLayout();
            this.group_Display.ResumeLayout(false);
            this.group_Display.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertDate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertTime;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertDateTime;
        private Microsoft.Office.Tools.Ribbon.RibbonTab TabZS;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCalendar;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_Display;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkHighLightRowAndCloumn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSplitButton splitButton1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
