using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace KK.SARIcon
{
    public partial class frmMain : Form
    {
        private Desktop m_Desktop = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                lblState.Text = String.Empty;
                toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right;

                WriteConsole("xml文件路径：" + Common.XMLPath);
                //WriteConsole("桌面句柄：" + Desktop.GetDefaultIntptr());
                if (!System.IO.File.Exists(Common.XMLPath))
                {
                    WriteConsole("记录文件不存在。点击保存按钮生成新的文件");
                    btnRestoreIcon.Enabled = false;
                }
                m_Desktop = new Desktop();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.Dispose();
            }
        }

        private void btnSaveIcon_Click(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.friendly_icons;
                List<IconItem> icons = GetIcons();


                WriteConsole("获取到【" + icons.Count + "】个图标数据！");

                // 保存图标数据到xml文件
                Boolean result = WriteItemsToXML(icons);
                if (result)
                {
                    lblState.Text = "保存完成！";
                }
                else
                {
                    lblState.Text = "保存失败！";
                }
            }
            catch (Exception ex)
            {
                WriteConsole("保存失败：" + ex.Message);
            }
            finally
            {
                btnRestoreIcon.Enabled = true;
            }
        }

        private void btnRestoreIcon_Click(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.hello_;

                List<IconItem> icons = GetIcons();

                if (!System.IO.File.Exists(Common.XMLPath))
                {
                    MessageBox.Show("配置文件[" + Common.XMLPath + "]不存在！先保存图标设置！");
                    return;
                }

                // 读取XML文件，转化为集合
                XElement root = XElement.Load(Common.XMLPath);
                IEnumerable<XElement> nodes = root.Elements();
                if (nodes != null && nodes.Count() > 0)
                {
                    foreach (var node in nodes)
                    {
                        String iconText = node.Attribute("text").Value;
                        Int32 locationX = Int32.Parse(node.Attribute("x").Value);
                        Int32 locationY = Int32.Parse(node.Attribute("y").Value);

                        // 检查图标是否存在，存在则设置位置，不存在就跳过
                        IconItem tmpIcon = icons.FirstOrDefault(x => x.Text == iconText);
                        if (tmpIcon != null)
                        {
                            m_Desktop.SetItemLocation(tmpIcon.Index, new Point(locationX, locationY));
                        }
                    }
                }

                lblState.Text = "恢复完成!";

            }
            catch (Exception ex)
            {
                MessageBox.Show("恢复失败：" + ex.Message);
            }
        }

        private void btnListIcons_Click(object sender, EventArgs e)
        {
            try
            {
                List<IconItem> icons = GetIcons();
                WriteConsole("获取到【" + icons.Count + "】个图标数据！");
                foreach (IconItem icon in icons)
                {
                    WriteConsole(icon.Index + ":" + icon.Text);
                }

            }
            catch (Exception ex)
            {
                WriteConsole("列举图标失败：" + ex.Message);
            }
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }


        #region 公共处理
        private List<IconItem> GetIcons()
        {
            List<IconItem> icons = new List<IconItem>();
            this.Icon = Properties.Resources.friendly_icons;

            // 获取图标数量，遍历获取文本与坐标
            WriteConsole("桌面ListView句柄：" + m_Desktop.DesktopListViewPtr.ToString());
            WriteConsole("桌面进程ID：" + m_Desktop.DesktopProcessID);
            WriteConsole("侦测到桌面图标数：" + m_Desktop.GetItemsCount());
            Int32 iconsCount = m_Desktop.GetItemsCount();
            for (Int32 i = 0; i < iconsCount; i++)
            {
                IconItem tmpIcon = new IconItem();
                tmpIcon.Text = m_Desktop.GetItemText(i);
                tmpIcon.Location = m_Desktop.GetItemLocation(i);
                tmpIcon.Index = i;
                icons.Add(tmpIcon);
            }
            return icons;
        }

        private void WriteConsole(String msg)
        {
            txtConsole.AppendText(msg + "\r\n");
        }
        #endregion

        #region XML处理

        /// <summary>
        /// 保存列表到xml文件
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private Boolean WriteItemsToXML(List<IconItem> items)
        {
            if (items == null || items.Count == 0)
                return false;
            // 删除现有文件
            if (System.IO.File.Exists(Common.XMLPath))
            {
                System.IO.File.Delete(Common.XMLPath);
            }

            // 生成xml文件
            XElement root = new XElement("Items");
            for (Int32 i = 0; i < items.Count; i++)
            {
                XElement tmpItem = new XElement("Item");
                tmpItem.SetAttributeValue("text", items[i].Text);
                tmpItem.SetAttributeValue("x", items[i].Location.X.ToString());
                tmpItem.SetAttributeValue("y", items[i].Location.Y.ToString());
                root.Add(tmpItem);
            }
            root.Save(Common.XMLPath);

            return true;
        }

        #endregion
    }
}
