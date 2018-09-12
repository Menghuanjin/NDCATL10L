using Common;
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
    public partial class frm_TimeQuery : Form
    {
        public frm_TimeQuery()
        {
            InitializeComponent();
            try
            {
                string sql = string.Format(@"SELECT * FROM [db_ND10L].[dbo].[dbo.tb_RnuInfo]");
                dgvmain.DataSource = SqlServerHelp.Query(sql).Tables[0];
            }
            catch { }
        }
    }
}
