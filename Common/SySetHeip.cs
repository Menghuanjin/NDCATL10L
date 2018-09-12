using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
 public   class SySetHeip
    {
        /// <summary>
        /// 管理员
        /// </summary>
        public static bool Admin { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public static bool Operate { get; set; }
        /// <summary>
        /// 工程师
        /// </summary>
        public static bool Engineer { get; set; }
        /// <summary>
        /// 登录信息
        /// </summary>
        public static string LoginInfo { get; set; }
        /// <summary>
        /// 登录操作
        /// </summary>
        public static bool LoginRefresh { get; set; }
        /// <summary>
        /// 刷新时间
        /// </summary>
        public static string RefreshTimeInfo { get; set; }
        /// <summary>
        /// COM端口
        /// </summary>
        public static string Comaddress { get; set; }
        /// <summary>
        /// 添加条码前缀名
        /// </summary>
        public static string Prefix { get; set; }
        /// <summary>
        /// CSV文件保存路径
        /// </summary>
        public static string SetCSVInfo { get; set; }

        /// <summary>
        /// plc连接的ip
        /// </summary>
        public static string Plc_ip { get; set; }
        /// <summary>
        /// 监控鼠标跟键盘消息
        /// </summary>
        public static string Cancellation { get; set; }
        /// <summary>
        /// 炉子资源号1
        /// </summary>
        public static string ResourceNumberOne { get; set; }
        /// <summary>
        /// 炉子资源号2
        /// </summary>
        public static string ResourceNumberTwo { get; set; }
        /// <summary>
        /// 炉子资源号3
        /// </summary>
        public static string ResourceNumberThree { get; set; }
        /// <summary>
        /// 炉子资源号4
        /// </summary>
        public static string ResourceNumberFour { get; set; }
        /// <summary>
        /// 炉子资源号5
        /// </summary>
        public static string ResourceNumberFive { get; set; }
        /// <summary>
        /// 炉子资源号6
        /// </summary>
        public static string ResourceNumberSix { get; set; }
        /// <summary>
        /// 炉子资源号7
        /// </summary>
        public static string ResourceNumberSeven { get; set; }
        /// <summary>
        /// 炉子资源号8
        /// </summary>
        public static string ResourceNumberEight { get; set; }
        /// <summary>
        /// 修改系统配置
        /// </summary>
        /// <param name="COM">端口号</param>
        /// <param name="RefreshTime">刷新时间</param>
        /// <param name="SetCSV">CSV保存路径</param>
        /// <returns></returns>
        public static int SysetInfo(List<string > List)
        {
            string Setsql = string.Format(@"Update tb_syset set Prefix='{0}', Plc_ip='{1}',  ComAddress='{2}',
            Renovate='{3}' ,[CSV_log]='{4}',Cancellation='{5}'", List[0], List[1], List[2], List[3], List[4], List[5]);
            int conn = SqlServerHelp.ExecuteSql(Setsql);
            return conn;
        }
     //   string Prefix, string Plc_ip, string COM, string RefreshTime, string SetCSV
        /// <summary>
        /// 修改炉子资源号配置
        /// </summary>
        /// <param name="List"></param>
        public static int ResourceNumberSet(List<string> List)
        {
            string Setsql = string.Format(@"Update [dbo.tb_MES] set ResourceNumberOne='{0}', ResourceNumberTwo='{1}',  ResourceNumberThree='{2}',
            ResourceNumberFour='{3}' ,ResourceNumberFive='{4}',  ResourceNumberSix='{5}' ,ResourceNumberSeven='{6}' ,ResourceNumberEight='{7}'",
            List[0], List[1], List[2], List[3], List[4], List[5], List[6], List[7]);
            int conn = SqlServerHelp.ExecuteSql(Setsql);
            return conn;
        }
        /// <summary>
        /// 修改MES校验接口配置
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int UploadCheckoutMES(List<string> list)
        {
            String Sql = string.Format(@"Update [dbo.tb_MES] set ElectricCore_WSDL='{0}', ElectricCore_TimeOut='{1}', ElectricCore_User='{2}',
            ElectricCore_Password='{3}' ,ElectricCore_site='{4}'", list[0], list[1], list[2], list[3], list[4]);
            int conn = SqlServerHelp.ExecuteSql(Sql);
            return conn;
        }
        /// <summary>
        /// 修改MES收数接口配置
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int UploadChargeNumberMES(List<string> list)
        {
            String Sql = string.Format(@"Update [dbo.tb_MES] set ChargeNumber_WSDL='{0}', ChargeNumber_TimeOut='{1}', ChargeNumber_User='{2}',
            ChargeNumber_Password='{3}',ChargeNumber_site='{4}',  ChargeNumber_Operation='{5}',ChargeNumber_OperationRevision='{6}',
            ChargeNumber_ActivityId='{7}',ChargeNumber_IsDispositionRequired='{8}',ChargeNumber_DcGroup='{9}',
            ChargeNumber_DcGroupRevision='{10}'", list[0], list[1], list[2], list[3], list[4],
            list[5], list[6], list[7], list[8], list[9], list[10]);
            int conn = SqlServerHelp.ExecuteSql(Sql);
            return conn;
        }
        /// <summary>
        /// 查询系统配置
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSysConfig()
        {
            string sql = string.Format(@"select * from tb_SySet ");
            return SqlServerHelp.DtQuery(sql);
        }
        /// <summary>
        /// 查询MES系统配置
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSysConfigMES()
        {
            string sql = string.Format(@"select * from [dbo.tb_MES] ");
            return SqlServerHelp.DtQuery(sql);
        }
        /// <summary>
        /// 系统配置查询
        /// </summary>
        /// <param name="dt"></param>
        public static void ConfigurationInfo(DataTable dt)
        {
            if (dt.Rows.Count >= 1 && dt != null)
            {
                Comaddress = dt.Rows[0]["ComAddress"].ToString().Trim();
                RefreshTimeInfo = dt.Rows[0]["renovate"].ToString().Trim();
                SetCSVInfo = dt.Rows[0]["CSV_log"].ToString().Trim();
                Prefix = dt.Rows[0]["Prefix"].ToString().Trim();
                Plc_ip = dt.Rows[0]["PLC_IP"].ToString().Trim();
                Cancellation = dt.Rows[0]["Cancellation"].ToString().Trim();
            }
        }
        /// <summary>
        /// MES系统配置查询
        /// </summary>
        /// <param name="dt"></param>
        public static void ConfigureMES(DataTable dt)
        {
            if (dt.Rows.Count >= 1 && dt != null)
            {
                InterfaceHelp.ConfigureHelp.ElectricCoreMES_WSDL = dt.Rows[0]["ElectricCore_WSDL"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.ElectricCoreTimeOut = Convert.ToInt32( dt.Rows[0]["ElectricCore_TimeOut"].ToString().Trim());
                InterfaceHelp.ConfigureHelp.ElectricCoreUser = dt.Rows[0]["ElectricCore_User"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.ElectricCoretPassword = dt.Rows[0]["ElectricCore_Password"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.ElectricCoreSite = dt.Rows[0]["ElectricCore_site"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.hargeNumberMES_WSDL = dt.Rows[0]["ChargeNumber_WSDL"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.hargeNumberTimeOut = Convert.ToInt32(dt.Rows[0]["ChargeNumber_TimeOut"].ToString().Trim());
                InterfaceHelp.ConfigureHelp.hargeNumberUser = dt.Rows[0]["ChargeNumber_User"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.hargeNumberPassword = dt.Rows[0]["ChargeNumber_Password"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.hargeNumberSite = dt.Rows[0]["ChargeNumber_site"].ToString().Trim();//站点
                InterfaceHelp.ConfigureHelp.hargeNumberOperation= dt.Rows[0]["ChargeNumber_Operation"].ToString().Trim();//工号
                InterfaceHelp.ConfigureHelp.hargeNumberOperationRevision= dt.Rows[0]["ChargeNumber_OperationRevision"].ToString().Trim();//工号版本
                InterfaceHelp.ConfigureHelp.hargeNumberActivityId= dt.Rows[0]["ChargeNumber_ActivityId"].ToString().Trim();//
                InterfaceHelp.ConfigureHelp.hargeNumberIsDispositionRequired=dt.Rows[0]["ChargeNumber_IsDispositionRequired"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.hargeNumberDcGroup= dt.Rows[0]["ChargeNumber_DcGroup"].ToString().Trim();
                InterfaceHelp.ConfigureHelp.hargeNumberDcGroupRevision= dt.Rows[0]["ChargeNumber_DcGroupRevision"].ToString().Trim();
                //资源号
                ResourceNumberOne = dt.Rows[0]["ResourceNumberOne"].ToString().Trim();
                ResourceNumberTwo = dt.Rows[0]["ResourceNumberTwo"].ToString().Trim();
                ResourceNumberThree = dt.Rows[0]["ResourceNumberThree"].ToString().Trim();
                ResourceNumberFour = dt.Rows[0]["ResourceNumberFour"].ToString().Trim();
                ResourceNumberFive = dt.Rows[0]["ResourceNumberFive"].ToString().Trim();
                ResourceNumberSix = dt.Rows[0]["ResourceNumberSix"].ToString().Trim();
                ResourceNumberSeven = dt.Rows[0]["ResourceNumberSeven"].ToString().Trim();
                ResourceNumberEight = dt.Rows[0]["ResourceNumberEight"].ToString().Trim();

            }


        }

        public static bool PlcConnectAddress(string Value)
        {
            bool ValueAddress = false;
            switch (Value)
            {
                case "0":
                    ValueAddress = false;
                    break;
                case "1":
                    ValueAddress = true;
                    break;
            }
            return ValueAddress;


        }
        /// <summary>
        /// 采集到的温度写入数据库
        /// </summary>
        /// <param name="stove">机器号</param>
        /// <param name="storey">机器层数</param>
        /// <param name="RunStatus">机器运行状态</param>
        /// <param name="data">机器温度集合</param>
        /// <param name="id">数据库id</param>
        public static void UpdateInfo(int stove, int storey, string RunStatus, List<double> data, int id)
        {
            string str = "";
            for (int i = 0; i < data.Count; i++)
            {
                str += "0" + data[i] + ",";
            }
            string sql = string.Format(@"update dbo_Rur set stove='{0}',storey='{1}',RunStatus='{2}',temperature='{3}',UpdateTime='{4}' where id='{5}' ",
                stove, storey, RunStatus, str, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), id);
            SqlServerHelp.ExecuteSql(sql);
        }
    }
}
