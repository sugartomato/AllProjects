using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace KK.WordAddIn.Controls
{
    public partial class MainTaskPan : UserControl
    {
        public MainTaskPan()
        {
            InitializeComponent();
        }

        #region 即时消息

        public void WriteConsole(String text)
        {
            this.WriteConsole(text, MsgType.Information);
        }

        public void WriteConsole(String text, MsgType msgType)
        {
            Int32 selStart = txtConsole.Text.Length;
            String msgContent = "[$]" + text;
            txtConsole.AppendText(msgContent + "\r\n");
            if (msgType == MsgType.Error)
            {
                txtConsole.Select(selStart, msgContent.Length);
                txtConsole.SelectionColor = Color.Red;
            }

            if (msgType == MsgType.Warning)
            {
                txtConsole.Select(selStart, msgContent.Length);
                txtConsole.SelectionColor = Color.Orange;
            }

            txtConsole.Select(txtConsole.Text.Length, 0);
        }

        public enum MsgType
        {
            Information,
            Error,
            Warning
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }

        public void WriteStartMark(String action)
        {
            WriteConsole("**[开始 " + action + "]**", MsgType.Warning);
        }
        public void WriteEndMark(String action)
        {
            WriteConsole("**[结束 " + action + "]**", MsgType.Warning);
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WriteStartMark("获取所有句子");
                Sentences sens = Globals.ThisAddIn.Application.ActiveDocument.Sentences;
                if (sens != null && sens.Count > 0)
                {
                    for (Int32 i = 1; i <= sens.Count; i++)
                    {
                        WriteConsole(String.Format("[{0}]{1}", i, sens[i].Text));
                        var sen = sens[i] as Range;
                    }
                }
                WriteEndMark("获取所有句子");
            }
            catch (Exception ex)
            {
                WriteConsole("获取所有句子出错：" + ex.Message, MsgType.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WriteConsole("**********[开始 扩展选择范围]**********", MsgType.Warning);

                // 从当前选择的区域，扩展三个字
                Range currentRng = Globals.ThisAddIn.Application.Selection.Range;
                if (currentRng != null)
                {
                    WriteConsole(String.Format("当前选择区域起始值：{0}，终止值：{1}", currentRng.Start, currentRng.End));

                    // 扩展选择范围
                    currentRng.MoveStart(WdUnits.wdCharacter, -5);
                    currentRng.MoveEnd(WdUnits.wdCharacter, 10);
                    currentRng.Select();
                }
                else
                {
                    WriteConsole("当前Selection.Range对象为null", MsgType.Warning);
                }


                WriteConsole("**********[完成 扩展选择范围]**********", MsgType.Warning);
            }
            catch (Exception ex)
            {
                WriteConsole("扩展选择范围出错：" + ex.Message, MsgType.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                WriteConsole("*[开始 逐句扩展选择]*", MsgType.Warning);

                Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
                if (currentRange != null)
                {
                    // 这里测试，如果不把第二个参数转换城object，使用句子扩展Range的时候，会报类型错误
                    currentRange.MoveEnd(WdUnits.wdSentence,(object)1);
                    currentRange.Select();
                }
                else
                {
                    WriteConsole("当前Selection.Range对象为null", MsgType.Warning);
                }

                

                WriteConsole("*[完成 逐句扩展选择]*", MsgType.Warning);
            }
            catch (Exception ex)
            {
                WriteConsole("扩展选择范围出错：" + ex.Message, MsgType.Error);
            }
        }

        #region 表格

        /// <summary>
        /// 列举所有表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Tables tables = Globals.ThisAddIn.Application.ActiveDocument.Tables;
                if (tables != null && tables.Count > 0)
                {
                    for (Int32 i = 1; i <= tables.Count; i++)
                    {
                        WriteConsole(tables[i].ID);
                        WriteConsole(tables[i].Range.Text);
                        WriteConsole(tables[i].Rows.Count.ToString());
                        WriteConsole(tables[i].Columns.Count.ToString());
                        WriteConsole(tables[i].Title);

                    }
                }
                else
                {
                    WriteConsole("文档中没有表格！", MsgType.Warning);
                }
            }
            catch (Exception ex)
            {
                WriteConsole("获取所有表格异常：" + ex.Message, MsgType.Error);
            }
        }


        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            WriteStartMark("获取图片");
            Document doc = (Document)Globals.ThisAddIn.Application.ActiveDocument;
            if (doc.Shapes.Count > 0)
            {
                foreach (Shape shape in doc.Shapes)
                {
                    if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoPicture)
                    {
                        WriteConsole($"获得Shapes图片,位置：{shape.Anchor.Start},ID:{shape.ID},Title:{shape.Title}");
                        
                    }
                }
            }
            if (doc.InlineShapes.Count > 0)
            {
                foreach (InlineShape shape in doc.InlineShapes)
                {
                    if (shape.Type == WdInlineShapeType.wdInlineShapePicture)
                    {
                        WriteConsole($"获得InlineShapes图片,位置：{shape.Range.Start},Title:{shape.Title}");
                    }
                }
            }

            WriteEndMark("获取图片");
        }

    }

}
