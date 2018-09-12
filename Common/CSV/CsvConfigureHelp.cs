using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Common
{
    public class CsvDataTableHelp
    {
        /// <summary>
        /// 查询采集温度到的datatable展示并导出相应的查询数据
        /// </summary>
        public static DataTable conn = new DataTable();
        /// <summary>
        /// 查询报警信息到的datatable展示并导出相应的查询数据
        /// </summary>
        public static DataTable connError = new DataTable();
        /// <summary>
        /// 查询采集温度
        /// </summary>
        /// <param name="Door">门号</param>
        /// <param name="LineNumber">查询行数</param>
        /// <param name="timeBegin">查询开始时间</param>
        /// <param name="timeEnd">查询停止时间</param>
        /// <returns></returns>
        public static DataTable Inquiry(string Door, string LineNumber, string timeBegin, string timeEnd)
        {
            string sql = string.Format(@"select top {0}*from dbo.[dbo.tb_MachineStatus] 
        where [Door] like '%{1}%'and  [WriteTime] >= '{2}'
        and [WriteTime] <= '{3}'", LineNumber, Door, timeBegin, timeEnd);
            //sql查询语句，注意查询命令不能加 % 号
            //语法and [SyTime] >= '{2}' and [SyTime] <= '{3}'"
            conn =  SqlServerHelp.Query(sql).Tables[0];
            return conn;
        }
        /// <summary>
        /// 报警日志错误查询
        /// </summary>
        /// <param name="LineNumber"></param>
        /// <param name="timeBegin"></param>
        /// <param name="timeEnd"></param>
        /// <returns></returns>
        public static DataTable InquiryError(string LineNumber, string timeBegin, string timeEnd)
        {
            string sql = string.Format(@"select top {0}*from dbo.[dbo.tb_Error]  where [ErrorTime] >= '{1}' and [ErrorTime] <= '{2}'", LineNumber,  timeBegin, timeEnd);
            //sql查询语句，注意查询命令不能加 % 号
            //语法and [SyTime] >= '{2}' and [SyTime] <= '{3}'"
            connError = SqlServerHelp.Query(sql).Tables[0];
            return connError;
        }

        /// <summary>
        ///  保存一天的CSV文件
        /// </summary>
        /// <param name="Door">门号</param>
        /// <param name="Way">路径</param>
        public static void PaeserveInfo(int  Door, string Way)
        {
            string BeginTime = Convert.ToString(DateTime.Now.AddDays(0).ToString("yyyy-MM-dd 00:00:00"));

            string EndTime = Convert.ToString(DateTime.Now.AddDays(0).ToString("yyyy-MM-dd 23:59:59"));
            try
            {
                string sql = string.Format(@"select * from [dbo.tb_MachineStatus] where [Door] like '%{0}%'and [WriteTime] >= '{1}' and [WriteTime] <= '{2}'", Door, BeginTime, EndTime);
                DataTable dt = SqlServerHelp.Query(sql).Tables[0];
                //DataTable dt = new DataTable();
                // dt = SqlServerHelp.Query(sql).Tables[0];
                dt.Columns["id"].ColumnName = "ID";

                dt.Columns["WriteTime"].ColumnName = "采集时间";

                dt.Columns["Door"].ColumnName = "门号";

                dt.Columns["UpperLimitOfTemperature"].ColumnName = "上限温度";

                dt.Columns["LowerTemperatureLimit"].ColumnName = "下限温度";

                dt.Columns["SetValueMonitoringTemperature"].ColumnName = "设定温度";

                dt.Columns["MonitoringTemperature"].ColumnName = "监控温度";  
                       
                dt.Columns["RunTime"].ColumnName = "运行时间";

                dt.Columns["SetTime"].ColumnName = "设定时间";
                Common.CSVHelper.SaveCSV(dt, Way);//保存CSV文件
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// 保存当天CSV文件
        /// </summary>
        public static void PaeserveCSV()
        {
            while (true)
            {
                CSVaddress();
                Thread.Sleep(Convert.ToInt16(SySetHeip.RefreshTimeInfo) * 1000);
            }
        }
     
        public static void CSVaddress()
        {
            try
            {
                string[] numList = new string[]
                {
                    SySetHeip.ResourceNumberOne,
                        SySetHeip.ResourceNumberTwo,
                            SySetHeip.ResourceNumberThree,
                                 SySetHeip.ResourceNumberFour,
                                      SySetHeip.ResourceNumberFive,
                                            SySetHeip.ResourceNumberSix,
                                               SySetHeip.ResourceNumberSeven,
                                                    SySetHeip.ResourceNumberEight
                };
                for (int i = 0; i < numList.Length; i++)
                {
                    string Way1 = string.Format(@"{0}\[{1}]{2}.CSV", SySetHeip.SetCSVInfo, DateTime.Now.ToString("yyyy-MM-dd"),i);
                    PaeserveInfo(i+1, Way1);
                }
               
            }
            catch { }
        }
        /// <summary>
        /// 获取用户选择的excel文件名称
        /// </summary>
        /// <returns></returns>
        public static string RouteCSV()
        {
            string path = ""; ; //获取用户选择的excel文件名称

            SaveFileDialog savefile = new SaveFileDialog();

            savefile.Filter = "Excel files(*.CSV)|*.CSV";//更改导出的类型

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                path = savefile.FileName; //获取保存路径      
            }
            return path;      
        }
      
    }
}
