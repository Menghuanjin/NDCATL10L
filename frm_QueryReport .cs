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
    public partial class frm_Log : Form
    {
        public frm_Log()
        {
            InitializeComponent();
        }
        private void frm_Log_Load(object sender, EventArgs e)
        {
            dtpBegin.Value = DateTime.Now.AddDays(-1);//当前时间减去1天
            dtpEnd.Value = DateTime.Now;
        }
        private void buttQuery_Click(object sender, EventArgs e)
        {
            string Begin = dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss ");
            //因为数据库是datetime类型，所以先把控件的时间格式化在进行查询
            string End = dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss ");
              CsvDataTableHelp.conn = CsvDataTableHelp.InquiryError(LineNumber.Value.ToString(), Begin, End);
            dgvmain.DataSource = CsvDataTableHelp.conn;
        }
        private void buttOutInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable conn = new DataTable();
                conn = CsvDataTableHelp.connError.Copy();
                string CSVInfo = CsvDataTableHelp.RouteCSV();//路径
                if (!string.IsNullOrEmpty(CSVInfo))
                {
                    conn.Columns["ID"].ColumnName = "ID";
                    conn.Columns["ErrorTime"].ColumnName = "报警时间";
                    conn.Columns["ErrorContent"].ColumnName = "报警内容";
                    Common.CSVHelper.SaveCSV(conn, CSVInfo);
                }              
            }
            catch (Exception)
            {
              
                Common.Msg.Warning("导出报警日志失败");
            }
        }
    }
}
