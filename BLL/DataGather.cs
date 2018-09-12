using Common;
using ND;
using PLCSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
  public  class DataGather
    {
        public static void WriteSqlAddress(string door, double[] list, double RunTime, double SetTime)
        {
            string sql = string.Format(@"INSERT INTO [db_ND10L].[dbo].[dbo.tb_MachineStatus]
           ([WriteTime]
           ,[Door]
           ,[UpperLimitOfTemperature]
           ,[LowerTemperatureLimit]
           ,[MonitoringTemperature]
           ,[SetValueMonitoringTemperature]
           ,[RunTime],SetTime) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
           DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), door, list[0],
           list[1], list[2], list[3], RunTime, SetTime);
            SqlServerHelp.ExecuteSql(sql);
        }
        public static List<string> liststr = new List<string>();

        /// <summary>
        /// 把采集到的温度写入数据库
        /// </summary>
        public static void WriteSqlInfo()
        {
            //判断最后面一个是否有值  有值为PLC读写完成
            if (PlcQueryHelp.listAddressTime1[3] > 0)//1门
            {
                WriteSqlAddress("1", PlcQueryHelp.listAddressTime1, PlcQueryHelp.ConstantTime1, PlcQueryHelp.SetTime1);
            }
            if (PlcQueryHelp.listAddressTime2[3] > 0)//2门
            {
                WriteSqlAddress("2", PlcQueryHelp.listAddressTime2, PlcQueryHelp.ConstantTime2, PlcQueryHelp.SetTime2);
            }
            if (PlcQueryHelp.listAddressTime3[3] > 0)//3门
            {
                WriteSqlAddress("3", PlcQueryHelp.listAddressTime3, PlcQueryHelp.ConstantTime3, PlcQueryHelp.SetTime3);
            }
            if (PlcQueryHelp.listAddressTime4[3] > 0)//4门
            {
                WriteSqlAddress("4", PlcQueryHelp.listAddressTime4, PlcQueryHelp.ConstantTime4, PlcQueryHelp.SetTime4);
            }
            if (PlcQueryHelp.listAddressTime5[3] > 0)//5门
            {
                WriteSqlAddress("5", PlcQueryHelp.listAddressTime5, PlcQueryHelp.ConstantTime5, PlcQueryHelp.SetTime5);
            }
            if (PlcQueryHelp.listAddressTime6[3] > 0)//6门
            {
                WriteSqlAddress("6", PlcQueryHelp.listAddressTime6, PlcQueryHelp.ConstantTime6, PlcQueryHelp.SetTime6);
            }
            if (PlcQueryHelp.listAddressTime7[3] > 0)//7门
            {
                WriteSqlAddress("7", PlcQueryHelp.listAddressTime7, PlcQueryHelp.ConstantTime7, PlcQueryHelp.SetTime7);
            }
            if (PlcQueryHelp.listAddressTime8[3] > 0)//8门
            {
                WriteSqlAddress("8", PlcQueryHelp.listAddressTime8, PlcQueryHelp.ConstantTime8, PlcQueryHelp.SetTime8);
            }
        }
    }
}
