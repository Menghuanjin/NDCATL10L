using Common;
using DevComponents.DotNetBar.Controls;
using ND;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ND6L
{
    public partial class frm_Parameter : Form
    {
        public frm_Parameter()
        {
            InitializeComponent();
        }

        private void frm_Parameter_Load(object sender, EventArgs e)
        {
            listSys1.Text = SySetHeip.Prefix.Trim();
            listSys2.Text = SySetHeip.Plc_ip.Trim();
            listSys3.Text = SySetHeip.Comaddress.Trim();
            listSys4.Text = SySetHeip.RefreshTimeInfo.Trim();
            listSys5.Text = SySetHeip.SetCSVInfo.Trim();
            listSys6.Text = SySetHeip.Cancellation.Trim();
        }
        private void revise_Click_1(object sender, EventArgs e)
        {
            string path = listSys5.Text; //用户设置的path
            try
            {
                if (Directory.Exists(path))
                { //如果存在
                    List<string> list = new List<string>();
                    for (int i = 0; i < 6; i++)
                    {
                        TextBoxX C = (TextBoxX)this.Controls.Find("listSys" + (i + 1), true)[0];
                        list.Add(C.Text.Trim());
                    }
                    if (SySetHeip.SysetInfo(list) > 0)
                    {
                        Common.Msg.Warning("修改成功");
                        SySetHeip.ConfigurationInfo(SySetHeip.GetSysConfig().Tables[0]);
                    }
                    else { Common.Msg.Warning("修改失败"); }               
                }
                //不存在，用用户设置path创建路径
                DirectoryInfo di = Directory.CreateDirectory(path);
            }//创建不成功 
            catch
            {
                Common.Msg.Warning("修改失败，请检查");
            }
        }
    }
}
