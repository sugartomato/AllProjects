using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSExcelAddIn
{
    public class Msg
    {

        public static void ShowError(String msg)
        {
            MsgboxForm.MsgContent = msg;
            MsgboxForm.MsgType = ZS.DotNetForms.MessageBoxEx.MessageType.Error;
            MsgboxForm.ShowDialog();
        }

        public static void ShowError(String msg, Exception ex)
        {
            MsgboxForm.MsgContent = msg;
            MsgboxForm.MsgType = ZS.DotNetForms.MessageBoxEx.MessageType.Error;
            MsgboxForm.Ex = ex;
            MsgboxForm.ShowDialog();
        }


        public static void ShowInfo(String msg)
        {
            MsgboxForm.MsgContent = msg;
            MsgboxForm.MsgType = ZS.DotNetForms.MessageBoxEx.MessageType.Info;
            MsgboxForm.ShowDialog();
        }
        public static void ShowSuccess(String msg)
        {
            MsgboxForm.MsgContent = msg;
            MsgboxForm.MsgType = ZS.DotNetForms.MessageBoxEx.MessageType.Success;
            MsgboxForm.ShowDialog();
        }
        public static void ShowWarning(String msg)
        {
            MsgboxForm.MsgContent = msg;
            MsgboxForm.MsgType = ZS.DotNetForms.MessageBoxEx.MessageType.Warning;
            MsgboxForm.ShowDialog();
        }

        private static ZS.DotNetForms.MessageBoxEx _propMsgboxForm = null;
        private static ZS.DotNetForms.MessageBoxEx MsgboxForm
        {
            get
            {
                if (_propMsgboxForm == null)
                {
                    _propMsgboxForm = new ZS.DotNetForms.MessageBoxEx();
                    _propMsgboxForm.Title = "KK工具箱！";
                }
                return _propMsgboxForm;
            }
        }
    }
}
