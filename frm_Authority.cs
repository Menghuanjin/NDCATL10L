using Common;
using ND;
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
    public partial class frm_Authority : Form
    {
        public frm_Authority()
        {
            InitializeComponent();
        }      
        private void UserSet_Load(object sender, EventArgs e)
        {
            Authority.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SetName.Text.Trim()) && !string.IsNullOrEmpty(SetPwodr.Text.Trim()) && !string.IsNullOrEmpty(Authority.Text.Trim()))
            {
                string sql = string.Format(@"INSERT INTO [db_ND10L].[dbo].[tb_Login](Name,[password],Authority  ) VALUES('{0}','{1}','{2}')",
                    SetName.Text.Trim(), SetPwodr.Text.Trim(), Authority.Text.Trim());
                SqlServerHelp.ExecuteSql(sql);

                //增加用户
                ControlHelp.ControlHelp.SqlErrorInfo("增加用户" + SetName.Text.Trim() + " " + "权限:" + Authority.Text.Trim());

                string sql1 = string.Format("select * from tb_Login ");
                dgvmain.DataSource = SqlServerHelp.Query(sql1).Tables[0];
            }
            else
            {
                Common.Msg.Warning("增加的用户,密码,权限,三者之间不能有一个为空");
            }
        }
        private void Revise_Click(object sender, EventArgs e)
        {
            string sql=string .Format(@"UPDATE [db_ND10L].[dbo].[tb_Login] set Name='{0}' ,password='{1}',Authority='{2}' where ID='{3}'",
              SetName.Text.Trim(), SetPwodr.Text.Trim(), Authority.Text.Trim(), Order.Text.Trim());
            SqlServerHelp.ExecuteSql(sql);

            //修改用户
            ControlHelp.ControlHelp.SqlErrorInfo("修改用户" + SetName.Text.Trim() + " " + "权限:" + Authority.Text.Trim());

            string sql1 = string.Format("select * from tb_Login ");
            dgvmain.DataSource = SqlServerHelp.Query(sql1).Tables[0];
        }
    
        private void Query_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from tb_Login ");
            dgvmain.DataSource = SqlServerHelp.Query(sql).Tables[0];       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("DELETE FROM[db_ND10L].[dbo].[tb_Login] WHERE ID ='{0}'",Order.Text.Trim());
            SqlServerHelp.ExecuteSql(sql);

            //删除用户
            ControlHelp.ControlHelp.SqlErrorInfo("删除用户" + SetName.Text.Trim()+" " + "权限:" + Authority.Text.Trim()+" "+"序列号:" + Order.Text.Trim());

            string sql1 = string.Format("select * from tb_Login ");
            dgvmain.DataSource = SqlServerHelp.Query(sql1).Tables[0];

        }
    }
}
