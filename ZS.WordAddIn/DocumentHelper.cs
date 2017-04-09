using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;


namespace ZS.WordAddIn
{
    //internal class WordHelper
    //{

    //    /// <summary>
    //    /// 移除文档里面所有备注
    //    /// </summary>
    //    public static void RemoveAllComments(Word.Document doc)
    //    {
    //        if (doc == null) return;

    //        doc.DeleteAllComments();
    //    }

    //    public static void RemoveAllVisibleComments(Word.Document doc)
    //    {
    //        if (doc == null) return;

    //        doc.DeleteAllCommentsShown();
    //    }


    //    public static Int32 GetParagraphsCount(Word.Document doc)
    //    {
    //        return doc.Paragraphs.Count;

    //    }




    //    public class Section
    //    {

    //        public Word.Range Rang { get; set; }
    //        public string Text { get; set; }
    //        public string KeyText { get; set; }


    //        public override string ToString()
    //        {
    //            if (KeyText != null)
    //            {
    //                return KeyText.ToString();
    //            }
    //            else
    //            {
    //                return base.ToString();
    //            }
    //        }

    //        public static List<Section> GetAll(Word.Document doc)
    //        {
    //            if (doc == null) return null;

    //            List<Section> list = new List<Section>();

    //            if (doc.Sections != null && doc.Sections.Count > 0)
    //            {
    //                foreach (Word.Section sec in doc.Sections)
    //                {
    //                    Section s = new Section();

    //                    s.Rang = sec.Range;   // 区域对象
    //                    s.Text = sec.Range.Text;  // 区域文本内容
    //                    if (s.Text.Length > 5)  // 区域关键字（前五个）
    //                    {
    //                        s.KeyText = s.Text.Substring(0, 5);
    //                    }
    //                    else
    //                    {
    //                        s.KeyText = s.Text;
    //                    }


    //                    list.Add(s);
    //                }
    //                return list;
    //            }
    //            else
    //            {
    //                return null;
    //            }
    //        }
    //    }


    //    public class Paragraph
    //    {
    //        public Word.Range Rang { get; set; }
    //        public string Text { get; set; }
    //        public string KeyText { get; set; }

    //        public override string ToString()
    //        {
    //            if (KeyText != null)
    //            {
    //                return KeyText.ToString();
    //            }
    //            else
    //            {
    //                return base.ToString();
    //            }
    //        }

    //        public static List<Paragraph> GetAll(Word.Document doc)
    //        {
    //            if (doc == null) return null;

    //            List<Paragraph> list = new List<Paragraph>();

    //            if (doc.Paragraphs != null && doc.Paragraphs.Count > 0)
    //            {
    //                foreach (Word.Paragraph p in doc.Paragraphs)
    //                {
    //                    Paragraph s = new Paragraph();

    //                    s.Rang = p.Range;   // 区域对象
    //                    s.Text = p.Range.Text;  // 区域文本内容
    //                    if (s.Text.Length > 5)  // 区域关键字（前五个）
    //                    {
    //                        s.KeyText = s.Text.Substring(0, 5);
    //                    }
    //                    else
    //                    {
    //                        s.KeyText = s.Text;
    //                    }

    //                    list.Add(s);
    //                }
    //                return list;
    //            }
    //            else
    //            {
    //                return null;
    //            }
    //        }
    //    }


    //}


    /// <summary>
    /// 文档处理帮助
    /// </summary>
    internal class DocumentHelper
    {
        // Word文档对象
        Word.Document m_Doc = null;

        public DocumentHelper(Word.Document doc)
        {
            if (doc == null) throw new ApplicationException("未指定文档对象！");
            m_Doc = doc;
        }



        #region 段落


        /// <summary>
        /// 获取所有段落信息
        /// </summary>
        /// <returns></returns>
        public List<Paragraph> Paragraph_GetAll()
        {

            List<Paragraph> list = new List<Paragraph>();

            if (m_Doc.Paragraphs != null && m_Doc.Paragraphs.Count > 0)
            {
                foreach (Word.Paragraph p in m_Doc.Paragraphs)
                {
                    Paragraph s = new Paragraph(p.Range);

                    list.Add(s);
                }
                return list;
            }
            else
            {
                return null;
            }
        }


        public class Paragraph
        {

            public Paragraph() { }
            public Paragraph(Word.Range rng)
            {
                if (rng == null)
                {
                    throw new ApplicationException("未指定的Range对象！");
                }

                this.Rang = rng;
                this.Text = rng.Text;
                if (this.Text.Length > KeyTextLength)
                {
                    this.KeyText = this.Text.Substring(0, this.KeyTextLength);
                }
                else
                {
                    this.KeyText = this.Text;
                }

                if (_propTrimKeyText)
                {
                    this.KeyText = this.KeyText.Trim();
                }
            }

            /// <summary>
            /// 段落的Range对象
            /// </summary>
            public Word.Range Rang { get; set; }
            /// <summary>
            /// 获取或者设置段落的全部文本
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// 获取或者设置段落的关键文字
            /// </summary>
            public string KeyText { get; set; }


            private Int32 _propKeyTextLength = 10;
            /// <summary>
            /// 获取或者设置段落关键文字表示的长度
            /// </summary>
            public Int32 KeyTextLength
            {

                get { return _propKeyTextLength; }
                set { _propKeyTextLength = value; }
            }

            private Boolean _propTrimKeyText = true;
            /// <summary>
            /// 是否移除关键字前后的空格
            /// </summary>
            public Boolean TrimKeyText
            {
                get { return _propTrimKeyText; }
                set
                {
                    _propTrimKeyText = value;
                    if (_propTrimKeyText)
                    {
                        if (KeyText != null) KeyText.Trim();
                    }
                }
            }

            public override string ToString()
            {
                if (KeyText != null)
                {
                    return KeyText.ToString();
                }
                else
                {
                    return base.ToString();
                }
            }

        }

        #endregion



        #region 小节

        #endregion


        #region Shapes


        /// <summary>
        /// 获取文档中的所有图片
        /// </summary>
        /// <returns>返回图片对象集合</returns>
        public List<System.Drawing.Image> Shape_GetAllPicture()
        {

            List<System.Drawing.Image> listR = new List<System.Drawing.Image>();
            // 读取Shape中的图片
            if (m_Doc.Shapes != null && m_Doc.Shapes.Count > 0)
            {
                foreach (Word.Shape p in m_Doc.Shapes)
                {
                    if (p.Type == Microsoft.Office.Core.MsoShapeType.msoPicture)
                    {
                        var img = ConvertToImage(p);
                        if (img != null)
                        {
                            listR.Add(img);
                        }

                    }
                }
            }

            // 读取InLineShape中的图片
            if (m_Doc.InlineShapes != null && m_Doc.InlineShapes.Count > 0)
            {
                foreach (Word.InlineShape p in m_Doc.InlineShapes)
                {
                    if (p.Type == Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        var img = ConvertToImage(p);
                        if (img != null)
                        {
                            listR.Add(img);
                        }

                    }
                }
            }

            if (listR.Count > 0)
            {
                return listR;
            }
            else
            {
                return null;
            }
        }


        #region Shape转图像
        /// <summary>
        /// 将Shape对象转换为Image
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        private System.Drawing.Image ConvertToImage(Word.Shape shape)
        {
            if (shape == null) return null;
            shape.Select();
            m_Doc.Application.Selection.Copy();
            //Globals.ThisAddIn.Application.Selection.Copy();

            if (System.Windows.Forms.Clipboard.GetDataObject() != null)
            {
                var data = System.Windows.Forms.Clipboard.GetDataObject();
                if (data != null && data.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
                {
                    System.Drawing.Image img = (System.Drawing.Image)data.GetData(System.Windows.Forms.DataFormats.Bitmap, true);
                    return img;
                }
            }
            return null;
        }

        /// <summary>
        /// 将InlineShape转换为Image
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        private System.Drawing.Image ConvertToImage(Word.InlineShape shape)
        {
            if (shape == null) return null;
            shape.Select();
            m_Doc.Application.Selection.Copy();
            //Globals.ThisAddIn.Application.Selection.Copy();

            if (System.Windows.Forms.Clipboard.GetDataObject() != null)
            {
                var data = System.Windows.Forms.Clipboard.GetDataObject();
                if (data != null && data.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
                {
                    System.Drawing.Image img = (System.Drawing.Image)data.GetData(System.Windows.Forms.DataFormats.Bitmap, true);
                    return img;
                }
            }
            return null;
        }

        #endregion


        public class ShapePicture
        {
            public Word.Shape ShapeOrg { get; set; }
        }

        #endregion

        #region 文档保存与另存

        /// <summary>
        /// 将文档以PDF格式另存到指定目录。
        /// </summary>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public Boolean SaveAsPDF(string savePath)
        {
            throw new ApplicationException("方法未做处理！");
        }

        /// <summary>
        /// 将文档以PDF格式保存到文档所在的目录，以文档名称命名。如果文档的路径不存在，则保存到桌面
        /// </summary>
        /// <returns></returns>
        public Boolean SaveAsPDF()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (m_Doc.Path != null && m_Doc.Path != string.Empty)
            {
                folder = m_Doc.Path;
            }

            if (!folder.EndsWith(@"\"))
            {
                folder = folder + @"\";
            }

            string fileName = m_Doc.Name + ".pdf";
            if (fileName == null && fileName == string.Empty)
            {
                fileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            }


            return this.SaveAsPDF(folder + fileName, false);
        }

        private Boolean SaveAsPDF(string path, bool open)
        {
            try
            {
                object fileName = path;
                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                m_Doc.SaveAs2(ref fileName, ref fileFormat);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Boolean SaveAsPDF(Word.Document doc)
        {
            // 文档验证
            if (doc == null) return false;
            string fullPath = "";
            return SaveAsPDF(doc, doc.Path, false, ref fullPath);
        }

        public static Boolean SaveAsPDF(Word.Document pDoc, String pFolder, Boolean pOpen,ref string pFullPath)
        {
            object fileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
            object fileFullPath = string.Empty;

            // 文档验证
            if (pDoc == null) return false;

            // 目录不正确则指定到桌面
            if (pFolder == null || pFolder == string.Empty || !System.IO.Directory.Exists(pFolder))
            {
                pFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            if (!pFolder.EndsWith(@"\"))
            {
                pFolder = pFolder + @"\";
            }

            // 文档名称
            if (pDoc.Name != null && pDoc.Name != string.Empty)
            {
                if (pDoc.Name.Contains("."))
                {
                    fileName = pDoc.Name.Substring(0, pDoc.Name.LastIndexOf(".")) + ".pdf";
                }
                else
                {
                    fileName = pDoc.Name + ".pdf";
                }
            }

            pFullPath = pFolder + fileName;
            fileFullPath = pFullPath;
            try
            {
                pDoc.SaveAs2(ref fileFullPath, ref fileFormat);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion



        #region 静态方法

        public static void SaveShapeToFile(Word.Shape shape )
        {
            if (shape == null) return;
            shape.Select();
            Globals.ThisAddIn.Application.Selection.Copy();

            if (System.Windows.Forms.Clipboard.GetDataObject() != null)
            {
                var data = System.Windows.Forms.Clipboard.GetDataObject();
                if (data != null && data.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
                {
                    System.Drawing.Image img = (System.Drawing.Image)data.GetData(System.Windows.Forms.DataFormats.Bitmap, true);
                    img.Save(@"d:\TT.jpg");
                }
                
            }
        }



        #endregion


    }
}
