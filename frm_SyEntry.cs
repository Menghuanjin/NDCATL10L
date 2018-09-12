using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ND6L
{
    public partial class frm_SyEntry : Form

    {
        public frm_SyEntry()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        { switch ((int)(m.WParam)) { case (0xf030): break; default: base.WndProc(ref m); break; } }
       
        private void UserSet_Load(object sender, EventArgs e)
        {           
        }
        private void button1_Click(object sender, EventArgs e)
        {
          string sql = string.Format("select * from tb_Login where OrderNumber='1002' and  Name='{0}' and password='{1}'", SetName.Text.Trim(), SetPwodr.Text.Trim());
           DataTable dt = DbHelperSQL.Query(sql).Tables[0];
           if (dt.Rows.Count > 0 && dt != null)
             {
                SySetHeip.MANU_Address = true;
                Common.Msg.ShowInformation("登录成功");
                this.Close();
            }
            else
            {
                SySetHeip.MANU_Address = false;
                Common.Msg.Warning("登录失败");
            }         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }
}
