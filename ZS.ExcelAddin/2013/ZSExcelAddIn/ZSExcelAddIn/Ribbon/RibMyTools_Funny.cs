using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using ZS.Common;
using Excel = Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn
{
    public partial class RibMyTools : Office.IRibbonExtensibility
    {
        // ========================================
        // 分部类：一些有趣的方法
        // ========================================

        public void OnClick_Funny(Office.IRibbonControl ctrl)
        {
            try
            {
                if (ctrl == null)
                {
                    MessageBox.Show("ctrl控件为null，无法处理！");
                    return;
                }

                switch (ctrl.Id)
                {
                    case "ZS_BTN_Funny_PicToRange":
                        Funny_ImageToPixel();
                        break;
                    default:
                        MessageBox.Show("没有对应的处理分支：" + ctrl.Id);
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OnClick_Funny方法执行异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 读取图片，转换为像素填充到单元格
        /// </summary>
        private void Funny_ImageToPixel()
        {
            String _imgFile = String.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _imgFile = ofd.FileName;
                }
                else
                {
                    return;
                }

                if (!System.IO.File.Exists(_imgFile))
                {
                    ShowError("文件不存在：" + _imgFile);
                    return;
                }

                // 尝试转换，看是否为图片
                System.Drawing.Image _img = null;
                Boolean isImage = false;
                try
                {
                    _img = System.Drawing.Image.FromFile(_imgFile);
                    isImage = true;
                }
                catch (Exception ex)
                {
                    ShowError("文件不是有效的图片：" + _imgFile);
                    return;
                }

                Excel.Worksheet sheet = (Excel.Worksheet)_ActiveBook.Worksheets.Add();

                if (!isImage) return;
                System.Drawing.Bitmap bitMpa = new System.Drawing.Bitmap(_img);

                // 生成一个小图


                Int32 widh = 200;
                Int32 height = bitMpa.Height * widh / bitMpa.Width;

                System.Drawing.Bitmap thumImage = new System.Drawing.Bitmap(widh, height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(thumImage);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Clear(System.Drawing.Color.Transparent);
                g.DrawImage(bitMpa, new System.Drawing.Rectangle(0, 0, widh, height), new System.Drawing.Rectangle(0, 0, bitMpa.Width, bitMpa.Height), System.Drawing.GraphicsUnit.Pixel);


                // 设置行高列宽
                sheet.Rows.RowHeight = 7;
                sheet.Columns.ColumnWidth = 1;
                

                for (Int32 i = 0; i < widh; i++)
                {
                    for (Int32 k = 0; k < height; k++)
                    {
                        System.Drawing.Color color = thumImage.GetPixel(i, k);
                        Excel.Range rng = (Excel.Range)sheet.Cells[k + 1, i + 1];
                        rng.Interior.Color = color;
                    }
                }

                

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void FileStream_Read()
        {

        }


    }
}
