using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX
{
    /// <summary>
    /// 调试信息记录与输出
    /// </summary>
    public class AppDebugError :WXBase
    {
        /// <summary>错误类名</summary>
        public String ClassName { get; set; }
        /// <summary>错误方法名</summary>
        public String MethodName { get; set; }
        /// <summary>错误内容</summary>
        public String ErrContent { get; set; }
        /// <summary>发生时间</summary>
        public DateTime ExTime { get; set; }

        public AppDebugError():base() { }
        public AppDebugError(String className,String methodName,String errContent) : base() {
            this.ClassName = className;
            this.MethodName = methodName;
            this.ErrContent = errContent;
            this.ExTime = DateTime.Now;
        }

        private static Queue<AppDebugError> m_Errors = new Queue<AppDebugError>();
        public static void Append(AppDebugError err)
        {
            m_Errors.Enqueue(err);
        }
        public static AppDebugError ReadOne()
        {
            if (m_Errors.Count > 0)
            {
                return m_Errors.Dequeue();
            }

            return null;
        }

    }
}
