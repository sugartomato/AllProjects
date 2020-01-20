using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;

namespace KK.WordAddIn.Controls
{
    public partial class FormatImage : Form
    {
        private MSWord.Application m_App = (MSWord.Application)Globals.ThisAddIn.Application;
        private MSWord.Document m_ActiveDoc = (MSWord.Document)Globals.ThisAddIn.Application.ActiveDocument;
        public FormatImage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前活动图片
                //Msg.ShowInfo(m_App.Selection.Type.ToString());
                //Int32 _lineForColorRGB = 0;
                //float _lineWeight = 1;
                //Microsoft.Office.Core.MsoLineStyle _lineStyle = Microsoft.Office.Core.MsoLineStyle.msoLineSingle;
                //Microsoft.Office.Core.MsoLineDashStyle _lineDashStyle = Microsoft.Office.Core.MsoLineDashStyle.msoLineDash;
                // 获取设置参数
                MSWord.LineFormat line = null;
                if (m_App.Selection.Type == MSWord.WdSelectionType.wdSelectionInlineShape)
                {
                    MSWord.InlineShape shape = m_App.Selection.InlineShapes[1];
                    Msg.ShowInfo($"{shape.Range.Borders.OutsideColor},{shape.Range.Borders.OutsideLineStyle},{shape.Range.Borders.OutsideLineWidth}");
                    //_color = shape.Range.Borders.OutsideColor;
                    //_style = shape.Range.Borders.OutsideLineStyle;
                    //_width = shape.Range.Borders.OutsideLineWidth;
                    line = shape.Line;
                }
                if (m_App.Selection.Type == MSWord.WdSelectionType.wdSelectionShape)
                {
                    MSWord.Shape shape = m_App.Selection.ShapeRange[1];
                    line = shape.Line;
                }

                // 遍历所有图片
                if (m_ActiveDoc.InlineShapes.Count > 0)
                {
                    foreach (MSWord.InlineShape shape in m_ActiveDoc.InlineShapes)
                    {
                        if (shape.Type == MSWord.WdInlineShapeType.wdInlineShapePicture)
                        {
                            shape.Line.Weight = line.Weight;
                            shape.Line.DashStyle = line.DashStyle;
                            shape.Line.Style = line.Style;
                            shape.Line.ForeColor.RGB = line.ForeColor.RGB;
                        }
                    }
                }

                if (m_ActiveDoc.Shapes.Count > 0)
                {
                    foreach (MSWord.Shape shape in m_ActiveDoc.Shapes)
                    {
                        if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoPicture)
                        {
                            shape.Line.Weight = line.Weight;
                            shape.Line.DashStyle = line.DashStyle;
                            shape.Line.Style = line.Style;
                            shape.Line.ForeColor.RGB = line.ForeColor.RGB;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Msg.ShowError("设置图片边框异常：" + ex.Message + ex.StackTrace);
            }
        }
    }
}
