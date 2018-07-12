using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

#region Office
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
#endregion

namespace ZSExcelAddIn
{
    public partial class RibMyTools : Office.IRibbonExtensibility
    {

        #region 测试/调试

        public void OnClick_Test(Office.IRibbonControl ctrl)
        {
            Excel.Worksheet _thisSheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;

            switch (ctrl.Id)
            {
                case "btn_Test_UnDo":
                    //Globals.ThisAddIn.Application.Undo();
                    Globals.ThisAddIn.Application.OnUndo("撤销这个", "ToUnDo");

                    break;
                case "btn_Test_QueryTable":


                    System.Data.SqlClient.SqlConnectionStringBuilder ssb = new System.Data.SqlClient.SqlConnectionStringBuilder();
                    ssb.UserID = "oasa";
                    ssb.Password = "lixinyue112233";
                    ssb.InitialCatalog = "oa";
                    ssb.DataSource = "10.90.0.2";



                    string sqlString = "OLEDB;Provider=SQLOLEDB.1;Persist Security Info=True;User ID=oasa;Initial Catalog=OA;Data Source=10.90.0.2;Use Procedure for Prepare=1;Auto Translate=Tru";

                    Excel.ListObjects listObjects = _thisSheet.ListObjects;
                    Excel.ListObject listObject = listObjects.AddEx(Excel.XlListObjectSourceType.xlSrcExternal,
                        sqlString,
                        Type.Missing,
                        Excel.XlYesNoGuess.xlYes,
                        _thisSheet.Range["$A$2"],
                        Type.Missing);
                    Excel.QueryTable queryTable = listObject.QueryTable;
                    queryTable.CommandType = Excel.XlCmdType.xlCmdSql;
                    queryTable.CommandText = _thisSheet.Range["A1"].Value;
                    queryTable.AdjustColumnWidth = true;
                    queryTable.Refresh();
                    break;

                case "btn_TextResize":
                    Excel.Range oldRng = _thisSheet.Range["A3:F3"];
                    ShowInfo("旧区域地址：" + oldRng.Address);
                    Excel.Range newRng = oldRng.Resize[oldRng.Rows.Count + 2, oldRng.Columns.Count];
                    ShowInfo("新区域地址：" + newRng.Address);

                    break;
                case "btn_InputCheck":

                    object f = _thisSheet.Application.InputBox("输入一个，测试bool");

                    ShowInfo(f.ToString() == "1" ? "有效" : "都是无效");


                    break;
            }
        }

        /// <summary>
        /// 调试组按钮点击事件
        /// </summary>
        /// <param name="ctrl"></param>
        public void OnClick_Debug(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "ZS_BTN_ListAllCommand":
                    ListAllCommands();
                    break;
                case "ZS_BTN_ListResource":
                    ListAllResources();
                    break;
                case "ZS_BTN_LoadExcelInResource":
                    LoadExelInResource();
                    break;
                case "ZS_BTN_Test_ListDllPath":
                    Debug_ListDllPath();
                    break;
                default:
                    ShowError("未指定处理分支：" + ctrl.Id);
                    break;
            }
        }

        /// <summary>
        /// 枚举所有命令，写到一个新的工作表里
        /// </summary>
        private void ListAllCommands()
        {
            try
            {
                List<String> result = new List<string>();
                // 
                Office.CommandBars cmds = Globals.ThisAddIn.Application.CommandBars;
                if (cmds.Count > 0)
                {
                    foreach (Office.CommandBar cmd in cmds)
                    {
                        result.Add(cmd.Name + "|" + cmd.Id);
                        if (cmd.Controls.Count > 0)
                        {
                            foreach (Office.CommandBarControl ctrl in cmd.Controls)
                            {
                                GetCommandBarControls(ctrl, "", result);
                            }
                        }
                    }
                }

                Excel.Worksheet sheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add();
                for (Int32 i = 0; i < result.Count; i++)
                {
                    sheet.Range["A" + (i + 1)].Value = result[i];
                }
                //sheet.Range["A1:A" + result.Count].Value = result.ToArray();

            }
            catch (Exception ex)
            {
                ShowError("列举命令异常：" + ex.Message + ex.StackTrace);
            }
        }

        private void ListAllResources()
        {
            String[] resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            if (resources != null && resources.Length > 0)
            {
                Excel.Worksheet sheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add();
                sheet.Name = "资源列表";
                for (Int32 i = 0; i < resources.Length; i++)
                {
                    sheet.Range["A" + (i + 1)].Value = resources[i];
                }
            }
        }

        private void LoadExelInResource()
        {
            try
            {
                String fileName = @"d:\AA.xlsx";
                String reName = "ZSExcelAddIn.Images.用印记录_20180529143455.xlsx";
                using (System.IO.Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream(reName))
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // 保存到临时文件
                    sm.CopyTo(writer.BaseStream);
                    writer.Flush();
                    writer.Close();
                    // 打开
                    Excel.Workbook xlBook = Globals.ThisAddIn.Application.Workbooks.Open(fileName);
                    System.Windows.Forms.MessageBox.Show(xlBook.Name);
                    xlBook.Close(false);
                    System.IO.File.Delete(fileName);

                }
            }
            catch (Exception ex)
            {

                ShowError(ex.Message + ex.StackTrace);
            }
        }

        private void GetCommandBarControls(Office.CommandBarControl ctrl, String tab, List<String> result)
        {
            tab += "\t";
            result.Add(ctrl.Id + "|" + ctrl.Caption + "|" + ctrl.Parent.Name + "|" + ctrl.Control);
        }

        private void Debug_ListDllPath()
        {
            try
            {
                if (_ActiveBook == null) return;
                Excel.Worksheet _sheet = (Excel.Worksheet)_ActiveBook.Sheets.Add();
                _sheet.Name = "DLL路径获取";
                Dictionary<String, String> result = new Dictionary<string, string>();

                result.Add("Assembly.GetExecutingAssembly().Location", Assembly.GetExecutingAssembly().Location);
                result.Add("Environment.CurrentDirectory", Environment.CurrentDirectory);
                result.Add("Environment.CommandLine", Environment.CommandLine);
                result.Add("System.Windows.Forms.Application.StartupPath", System.Windows.Forms.Application.StartupPath);
                result.Add("Assembly.GetEntryAssembly().CodeBase", Assembly.GetExecutingAssembly().CodeBase);

                Int32 rowIndex = 1;
                foreach (var k in result)
                {
                    _sheet.Range["A" + rowIndex].Value = k.Key;
                    _sheet.Range["B" + rowIndex].Value = k.Value;
                    rowIndex += 1;
                }
            }
            catch (Exception ex)
            {
                ShowError("列举DLL路径失败：" + ex.Message);
            }
        }

        public void ToUnDo()
        {
            ShowInfo("1");
        }

        #endregion



    }
}
