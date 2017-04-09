using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// win32 Class特性绑定
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class)]
    public class Win32ClassBindAttribute : System.Attribute
    {

        /// <summary>
        /// 构造一个新的特性
        /// </summary>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="className">类名称</param>
        public Win32ClassBindAttribute(string nameSpace = @"Root\CIMV2", string className = "")
        {
            this.Namespace = nameSpace;
            this.ClassName = ClassName;
        }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

    }

    /// <summary>
    /// win32字段特性绑定
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property)]
    public class Win32FieldsBindAttribute : System.Attribute
    {

        /// <summary>
        /// 构造一个新的特性
        /// </summary>
        /// <param name="name">字段名称</param>
        public Win32FieldsBindAttribute(string name = "")
        {
            this.Name = name;
        }

        /// <summary>
        /// 字段名
        /// </summary>
        public string Name { get; set; }

    }

}
