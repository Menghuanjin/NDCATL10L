using Common;
using DevComponents.DotNetBar.Controls;
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
    public partial class frm_Upload : Form
    {
        public frm_Upload()
        {
            InitializeComponent();
        }
        private void revise_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("ElectricCore" + (i + 1), true)[0];
                list.Add(C.Text.Trim());
            }
            if (SySetHeip.UploadCheckoutMES(list) > 0)
            {
                Common.Msg.Warning("修改成功");
                SySetHeip.ConfigureMES(SySetHeip.GetSysConfigMES().Tables[0]);//查询MES系统配置文件
            }
            else { Common.Msg.Warning("修改失败"); }
        }
        private void frm_Upload_Load(object sender, EventArgs e)
        {
            ElectricCore1.Text = InterfaceHelp.ConfigureHelp.ElectricCoreMES_WSDL;
            ElectricCore2.Text = InterfaceHelp.ConfigureHelp.ElectricCoreTimeOut.ToString();
            ElectricCore3.Text = InterfaceHelp.ConfigureHelp.ElectricCoreUser;
            ElectricCore4.Text = InterfaceHelp.ConfigureHelp.ElectricCoretPassword;
            ElectricCore5.Text = InterfaceHelp.ConfigureHelp.ElectricCoreSite;
            ChargeNumber1.Text = InterfaceHelp.ConfigureHelp.hargeNumberMES_WSDL;
            ChargeNumber2.Text = InterfaceHelp.ConfigureHelp.hargeNumberTimeOut.ToString(); ;
            ChargeNumber3.Text = InterfaceHelp.ConfigureHelp.hargeNumberUser;
            ChargeNumber4.Text = InterfaceHelp.ConfigureHelp.hargeNumberPassword;
            ChargeNumber5.Text = InterfaceHelp.ConfigureHelp.hargeNumberSite;
            ChargeNumber6.Text = InterfaceHelp.ConfigureHelp.hargeNumberOperation;
            ChargeNumber7.Text = InterfaceHelp.ConfigureHelp.hargeNumberOperationRevision;
            ChargeNumber8.Text = InterfaceHelp.ConfigureHelp.hargeNumberActivityId;
            ChargeNumber9.Text = InterfaceHelp.ConfigureHelp.hargeNumberIsDispositionRequired;
            ChargeNumber10.Text = InterfaceHelp.ConfigureHelp.hargeNumberDcGroup;
            ChargeNumber11.Text = InterfaceHelp.ConfigureHelp.hargeNumberDcGroupRevision;
        }

        private void ChargeNumberRevise_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 11; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("ChargeNumber" + (i + 1), true)[0];
                list.Add(C.Text.Trim());
            }
            if (SySetHeip.UploadChargeNumberMES(list) > 0)
            {
                Common.Msg.Warning("修改成功");
                SySetHeip.ConfigureMES(SySetHeip.GetSysConfigMES().Tables[0]);//查询MES系统配置文件
            }
            else { Common.Msg.Warning("修改失败"); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
