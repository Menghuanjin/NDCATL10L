using Common;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ND
{
    public partial class frm__ResourceNumber : Form
    {
        public frm__ResourceNumber()
        {
            InitializeComponent();
        }

        private void frm__ResourceNumber_Load(object sender, EventArgs e)
        {
            ResourceNumber1.Text = SySetHeip.ResourceNumberOne;
            ResourceNumber2.Text = SySetHeip.ResourceNumberTwo;
            ResourceNumber3.Text = SySetHeip.ResourceNumberThree;
            ResourceNumber4.Text = SySetHeip.ResourceNumberFour;
            ResourceNumber5.Text = SySetHeip.ResourceNumberFive;
            ResourceNumber6.Text = SySetHeip.ResourceNumberSix;
            ResourceNumber7.Text = SySetHeip.ResourceNumberSeven;
            ResourceNumber8.Text = SySetHeip.ResourceNumberEight;
        }

        private void ButtSet_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("ResourceNumber" + (i + 1), true)[0];
                list.Add(C.Text.Trim());
            }         
            if (SySetHeip.ResourceNumberSet(list) > 0)
            {
                Common.Msg.Warning("修改成功");
                SySetHeip.ConfigureMES(SySetHeip.GetSysConfigMES().Tables[0]);//查询MES系统配置文件
            }
            else { Common.Msg.Warning("修改失败"); }
        }

    }
}
