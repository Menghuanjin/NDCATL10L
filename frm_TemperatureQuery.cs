using Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace ND6L
{
    public partial class frm_Query : Form
    {
        public frm_Query()
        {
            InitializeComponent();
        }

        private void buttQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string Begin = dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss ");
                //因为数据库是datetime类型，所以先把控件的时间格式化在进行查询
                string End = dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss ");
                CsvDataTableHelp.conn = CsvDataTableHelp.Inquiry(Door.SelectedItem.ToString(), LineNumber.Value.ToString(), Begin, End);
                dgvmain.DataSource = CsvDataTableHelp.conn;
            }
            catch (Exception)
            {
                Common.Msg.Warning("查询失败");
            }

        }
        private void query_Load(object sender, EventArgs e)
        {
            dtpBegin.Value = DateTime.Now.AddDays(-1);
            dtpEnd.Value = DateTime.Now.AddDays(1);
             Door.SelectedIndex = 0;
        }

        private void buttOutInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable conn = new DataTable();
                conn = CsvDataTableHelp.conn.Copy();
                string CSVInfo = CsvDataTableHelp.RouteCSV();//路径
                if (!string.IsNullOrEmpty(CSVInfo))
                {
                    conn.Columns["ID"].ColumnName = "ID";
                    conn.Columns["WriteTime"].ColumnName = "采集时间";
                    conn.Columns["Door"].ColumnName = "门号";
                    conn.Columns["UpperLimitOfTemperature"].ColumnName = "上限温度";
                    conn.Columns["LowerTemperatureLimit"].ColumnName = "温度下限";
                    conn.Columns["SetValueMonitoringTemperature"].ColumnName = "设定温度";
                    conn.Columns["MonitoringTemperature"].ColumnName = "监控温度";
                    conn.Columns["RunTime"].ColumnName = "运行时间";
                    conn.Columns["SetTime"].ColumnName = "设定时间";
                    Common.CSVHelper.SaveCSV(conn, CSVInfo);
                }
            }
            catch (Exception  )
            {
                Common.Msg.Warning("导出报警日志失败");
            }

            }
        // <summary>
        /// 执行DataTable中的查询返回新的DataTable
        /// </summary>
        /// <param name="dt">源数据DataTable</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {

            DataTable newdt = new DataTable();
            try
            {
                newdt = dt.Clone();
                DataRow[] dr = dt.Select(condition);
                for (int i = 0; i < dr.Length; i++)
                {
                    newdt.ImportRow((DataRow)dr[i]);
                }
                return newdt;//返回的查询结果
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return newdt;
            }
        }
    }   
}
