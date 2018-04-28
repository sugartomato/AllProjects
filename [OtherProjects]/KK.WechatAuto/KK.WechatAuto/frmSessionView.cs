using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KK.WechatAuto
{
    public partial class frmSessionView : Form
    {
        public frmSessionView()
        {
            InitializeComponent();
        }

        private void frmSessionView_Load(object sender, EventArgs e)
        {
            if (Session == null)
            {
                textBox1.Text = "无效的Session对象！";
            }

            try
            {
                textBox1.Text = Newtonsoft.Json.JsonConvert.SerializeObject(Session, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                textBox1.Text = "转换Session对象失败：" + ex.Message + ex.StackTrace;
            }
        }

        public Session Session { get; set; }
    }
}
