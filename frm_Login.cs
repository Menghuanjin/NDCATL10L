using Common;
using InterfaceHelp;
using ND;
using PLCSocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ND6L
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
            GetConfigInfo();

        }
        public static void  GetConfigInfo()
        {

          Common.SqlServerHelp.connectionString =ND. Properties.Settings.Default.SqlName;
  
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Thread th = new Thread(new ThreadStart(PlcToConnect));
                th.IsBackground = true;
                th.Start();
                Authority.SelectedIndex = 0;
            }
            catch{ }
        }
        void PlcToConnect()
        {
            try
            {
                
                SySetHeip.ConfigurationInfo(SySetHeip.GetSysConfig().Tables[0]);//查询系统配置文件
                SySetHeip.ConfigureMES(SySetHeip.GetSysConfigMES().Tables[0]);//查询MES系统配置文件
                StocketInfo.StocketInfo s = new StocketInfo.StocketInfo();
                s.socket = SocketHelper.tcpConn(SySetHeip.Plc_ip.Trim(), 9094, 10);
                SocketHelper.socketList.Add(s);
            }
            catch { }

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                //textName.Text = "ADMIN";
                //textPassword.Text = "ADMIN";
                string sql = string.Format("select * from tb_Login where  Name='{0}' and password='{1}' and Authority='{2}'",
                 textName.Text.Trim(), textPassword.Text.Trim(), Authority.Text.Trim());
                DataTable dt = SqlServerHelp.Query(sql).Tables[0];
                if (dt.Rows.Count > 0 && dt != null)
                {
                    SySetHeip.LoginInfo = Authority.SelectedItem.ToString();
                    if (dt.Rows[0]["Authority"].ToString().Trim() == "操作员")
                    { SySetHeip.Operate = true; }
                    else if (dt.Rows[0]["Authority"].ToString().Trim() == "管理员")
                    { SySetHeip.Admin = true; }
                    else if (dt.Rows[0]["Authority"].ToString().Trim() == "工程师")
                    { SySetHeip.Engineer = true; }
                    frm_Authoring f = new frm_Authoring();
                    this.Hide();
                    f.Show();
                }
                else
                {
                    Common.Msg.ShowError("未找到登录的相关信息");
                }
            }
            catch {}
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }  
}
