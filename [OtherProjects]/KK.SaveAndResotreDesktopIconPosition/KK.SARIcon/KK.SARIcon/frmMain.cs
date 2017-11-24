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
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                lblState.Text = String.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveIcon_Click(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.friendly_icons;
                List<IconItem> icons = GetIcons();

                lblState.Text = "获取到【" + icons.Count + "】个图标数据！";

                // 保存图标数据到xml文件
                Boolean result = WriteItemsToXML(icons);
                lblState.Text = "保存完成！";
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }
        }

        private void btnRestoreIcon_Click(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Properties.Resources.hello_;

                Desktop d = new Desktop(Desktop.GetDefaultIntptr());
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
                            d.SetItemLocation(tmpIcon.Index, new Point(locationX, locationY));
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

        #region 公共处理
        private List<IconItem> GetIcons()
        {
            List<IconItem> icons = new List<IconItem>();
            this.Icon = Properties.Resources.friendly_icons;

            // 获取图标数量，遍历获取文本与坐标
            Desktop d = new Desktop(Desktop.GetDefaultIntptr());
            Int32 iconsCount = d.GetItemsCount();
            for (Int32 i = 0; i < iconsCount; i++)
            {
                IconItem tmpIcon = new IconItem();
                tmpIcon.Text = d.GetItemText(i);
                tmpIcon.Location = d.GetItemLocation(i);
                tmpIcon.Index = i;
                icons.Add(tmpIcon);
            }
            return icons;
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
