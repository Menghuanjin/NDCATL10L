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
    public partial class frm_logManager : Form
    {
        public frm_logManager()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        { switch ((int)(m.WParam)) { case (0xf030): break; default: base.WndProc(ref m); break; } }
        private void btnSet_Click(object sender, EventArgs e)
        {
            string path = SetCSV.Text; //用户设置的path
            try
            {
                if (Directory.Exists(path))
                { //如果存在

                    if (RefreshTime.Text != "" && SetCSV.Text != "")
                    {
                        int conn = SySetHeip.SysetInfo(RefreshTime.Text.Trim(), SetCSV.Text.Trim());
                        if (conn > 0)
                        {
                            Common.Msg.Warning("修改成功");
                            SySetHeip.ConfigurationInfo(SySetHeip.GetSysConfig().Tables[0]);
                        }
                        else { Common.Msg.Warning("修改失败"); }
                    }
                    else { Common.Msg.Warning("修改失败"); }        
                }
                //不存在，用用户设置path创建路径
                DirectoryInfo di = Directory.CreateDirectory(path);
            }//创建不成功 
            catch { Common.Msg.Warning("CSV保存路径不合法，请检查");
            }                                   
        }
        private void logManager_Load(object sender, EventArgs e)
        {
            SySetHeip.ConfigurationInfo(SySetHeip.GetSysConfig().Tables[0]);
            RefreshTime.Text = SySetHeip.RefreshTimeInfo1.Trim();
            SetCSV.Text = SySetHeip.SetCSVInfo1.Trim();
            
        }
    }
}
