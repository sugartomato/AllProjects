using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;


namespace ZSExcelAddIn
{
	[Guid("293c0d68-1272-46e1-bc41-ca07eecc37cf")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	[ComVisible(true)]
	public class MyFunctions:UDFBase
	{

		public MyFunctions() { }


		public String AddWithValue(object range,  String val)
		{
			String bookName = String.Empty;
			try
			{
				bookName = Globals.ThisAddIn.Application.ActiveWorkbook.Name;
				if (String.IsNullOrEmpty(bookName))
				{
					bookName = "未知的工作簿名称";
				}
			}
			catch (Exception ex)
			{
				bookName = "获取活动工作簿名称异常：" + ex.Message;
			}
			return "123" + bookName;
			Range r = range as Range;
			return r.Value + val + Globals.ThisAddIn.Application.ActiveWorkbook.Name;
		}
	}

	public abstract class UDFBase
	{
		/// <summary>
		/// 解决在某些机器的Excel提示找不到mscoree.dll的问题
		/// 这里在注册表中将该dll的路径注册进去，当使用regasm注册该类库为com组件
		/// 时会调用该方法
		/// </summary>
		/// <param name="type"></param>
		[ComRegisterFunctionAttribute]
		public static void RegisterFunction(Type type)
		{
			Registry.ClassesRoot.CreateSubKey(
				GetSubKeyName(type, "Programmable"));
			RegistryKey key = Registry.ClassesRoot.OpenSubKey(
				GetSubKeyName(type, "InprocServer32"), true);
			key.SetValue("", System.Environment.SystemDirectory + @"\mscoree.dll",
				RegistryValueKind.String);
		}

		[ComUnregisterFunctionAttribute]
		public static void UnregisterFunction(Type type)
		{
			Registry.ClassesRoot.DeleteSubKey(
				GetSubKeyName(type, "Programmable"), false);
		}

		private static string GetSubKeyName(Type type, string subKeyName)
		{
			return string.Format("CLSID\\{{{0}}}\\{1}", type.GUID.ToString().ToUpper(), subKeyName);
		}
	}
}
