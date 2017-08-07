using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK.CodeLineCounter
{
    public class CodeLineCounter
    {

        public delegate void FileChangeHandler(String file,Int32 lineCount);
        public static event FileChangeHandler OnFileChanged;
        public delegate void DirectoryChangedHandler(DirectoryChangedEventArgs args);
        public static event DirectoryChangedHandler OnDirectoryChanged;
        public static Int64 CountLine(String dir, String fileExt)
        {
            DirectoryChangedEventArgs args = new DirectoryChangedEventArgs();
            args.DirectoryPath = dir;

            Int64 lineCount = 0;

            // 先遍历所有文件
            string[] files;
            try
            {
                files = System.IO.Directory.GetFiles(dir);
            }
            catch (Exception ex)
            {
                args.IsOpenSuccess = false;
                args.ErrMessage = ex.Message;
                OnDirectoryChanged?.Invoke(args);
                return 0;
            }

            args.IsOpenSuccess = true;
            OnDirectoryChanged?.Invoke(args);

            if (files != null && files.Length > 0)
            {
                foreach (string file in files)
                {

                    if (file.EndsWith(fileExt))
                    {

                        Int32 tmpCount = CountFileLine(file);
                        lineCount += tmpCount;

                        OnFileChanged?.Invoke(file, tmpCount);
                    }
                }
            }

            string[] dirs = System.IO.Directory.GetDirectories(dir);

            if (dirs != null && dir.Length > 0)
            {
                foreach (string d in dirs)
                {
                    lineCount += CountLine(d, fileExt);
                }
            }

            return lineCount;
            
        }

        /// <summary>
        /// 统计文件里的代码行数
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static Int32 CountFileLine(string path)
        {
            //using (System.IO.StreamReader rd = new System.IO.StreamReader(path))
            //{
            //    System.IO.File.ReadAllLines
            //}

            if (!System.IO.File.Exists(path))
            {
                return 0;
            }

            try
            {
                string[] allText = System.IO.File.ReadAllLines(path);
                return allText.Length;
            }
            catch
            {
                return 0;
            }

        }
    }


    #region 事件参数

    public class DirectoryChangedEventArgs:EventArgs
    {
        public String DirectoryPath { get; set; }
        public Boolean IsOpenSuccess { get; set; }
        public String ErrMessage { get; set; }
    }

#endregion

}
