using Common;
using PLCSocket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND10L
{
    /// <summary>
    /// 小车出入站状态
    /// </summary>
    public class OutAndInInfoHelp
    {
        /// <summary>
        /// 条形码1
        /// </summary>
        public static string Barcode { get; set; }
        /// <summary>
        /// 条形码2
        /// </summary>
        public static string Barcode2 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public   static  string time1{ get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public  static  string temperature1 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time2 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature2 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time3 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature3 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time4 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature4 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time5 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature5 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time6 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature6 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time7 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature7 { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public static string time8 { get; set; }
        /// <summary>
        /// 运行温度
        /// </summary>
        public static string temperature8 { get; set; }
        /// <summary>
        /// 查询第一个的条形码
        /// </summary>
        /// <param name="door">炉门条件</param>
        /// <returns></returns>
        public static List<string> QueryBarcodeInfo(string door)
        {
            string Sql = string.Format(@"SELECT * FROM[db_ND10L].[dbo].[dbo.tb_RnuInfo] WHERE Door = '{0}'", door);
            DataTable bt = SqlServerHelp.Query(Sql).Tables[0];
            Barcode = bt.Rows[0]["Barcode"].ToString();
            string[] list = InterceptStringHelp.SingleCharacter(bt.Rows[0]["BarcodeInclude"].ToString().Trim());
            List<string> listTemp = new List<string>();
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s)) continue;
                listTemp.Add(s);
            }
            return listTemp;
        }
        /// <summary>
        /// 查询第二个的条形码
        /// </summary>
        /// <param name="door">炉门条件</param>
        /// <returns></returns>
        public static List<string> QueryBarcodeInfo2(string door)
        {
            string Sql = string.Format(@"SELECT * FROM[db_ND10L].[dbo].[dbo.tb_RnuInfo] WHERE Door = '{0}'", door);
            DataTable bt = SqlServerHelp.Query(Sql).Tables[0];
            Barcode2 = bt.Rows[0]["Barcode2"].ToString();
            string[] list = InterceptStringHelp.SingleCharacter(bt.Rows[0]["BarcodeInclude2"].ToString().Trim());
            List<string> listTemp = new List<string>();
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s)) continue;
                listTemp.Add(s);
            }
            return listTemp;
        }
        /// <summary>
        ///该炉子入站运行状态，开始时间 写入数据库
        /// </summary>
        /// <param name="door"></param>
        public static void PlcBeginTime(string door)
        {
            string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET   OutAndInInfo ='{0}' WHERE Door='{1}'",10, door);
            SqlServerHelp.ExecuteSql(Sql);
        }
        /// <summary>
        /// 调用出站接口，更改出站小车状态
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="door"></param>
        public static void PlcEndTime(string Info, string door)
        {
            string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", Info, door);
            SqlServerHelp.ExecuteSql(Sql);
        }

        /// <summary>
        /// 查询数据库已经出站第几个小车
        /// </summary>
        /// <param name="Door"></param>
        /// <returns></returns>
        //10=已经入站，15=已经出站一个小车，20=已经全部出站完
        public static string RunOutInfo(string Door)
        {
            string Sql = string.Format(@"SELECT * FROM [db_ND10L].[dbo].[dbo.tb_RnuInfo] WHERE Door ='{0}'", Door);
            DataTable dt = SqlServerHelp.Query(Sql).Tables[0];
            return dt.Rows[0]["OutAndInInfo"].ToString().Trim();
        }
        /// <summary>
        /// 炉门开始/停止时间写入数据库(运行完成时，调接口出站)
        /// </summary>
       //dt.Rows[0]["OutAndInInfo"].ToString().Trim()=20为已经出完两个小车
        public static void StopTimeAddress()
        {
            List<string> List = new List<string>();
            List<string> List2 = new List<string>();
            try
            {
                if (PlcQueryHelp.BreakThread_one)
                {
                    if (PlcQueryHelp.BitStatus1[0])//联机
                    {
                        if (PlcQueryHelp.BitStatus1[2])//启动时写入时间
                        {
                            if (RunOutInfo("1") != "10")
                            {
                                PlcBeginTime("1");//该炉子已经入站运行
                            }
                        }
                        if (PlcQueryHelp.BitStatus1[4])
                        {
                            if (string.IsNullOrEmpty(time1) && string.IsNullOrEmpty(temperature1))//运行完成
                            {
                                time1 = PlcQueryHelp.SetTime1.ToString();//时间    
                                temperature1 = PlcQueryHelp.listAddressTime1[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time1, temperature1 ,1);
                                SqlServerHelp.ExecuteSql(sql);
                            }
                            if (RunOutInfo("1") == "10" || string.IsNullOrEmpty(RunOutInfo("1")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("1");//小车1内的所有托盘信息
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "1", "15", SySetHeip.ResourceNumberOne, time1, temperature1);
                            }
                            if (RunOutInfo("1") == "15")//已经出完第一个小车，开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("1");//小车2内的所有托盘信息                             
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "1", "20", SySetHeip.ResourceNumberOne, time1, temperature1);
                            }
                            if (RunOutInfo("1") == "20")//已经出完两个小车，
                            {
                                time1 = "";
                                temperature1 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 1);
                                SqlServerHelp.ExecuteSql(Sql);
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "",1);
                        SqlServerHelp.ExecuteSql(Sql);
                    }

                    //2
                    if (PlcQueryHelp.BitStatus2[0])
                    {

                        if (PlcQueryHelp.BitStatus2[2])//启动时写入时间
                        {
                            if (RunOutInfo("2") != "10")
                            {
                                PlcBeginTime("2");//该炉子已经入站运行
                            }
                        }
                        if (PlcQueryHelp.BitStatus2[4])
                        {
                            if (string.IsNullOrEmpty(time2) && string.IsNullOrEmpty(temperature2))//运行完成
                            {
                                time2 = PlcQueryHelp.SetTime2.ToString();//时间    
                                temperature2 = PlcQueryHelp.listAddressTime2[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time2, temperature2, 2);
                                SqlServerHelp.ExecuteSql(sql);
                            }

                            if (RunOutInfo("2") == "10" || string.IsNullOrEmpty(RunOutInfo("2")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("2");
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "2", "15", SySetHeip.ResourceNumberTwo, time2, temperature2);
                            }
                            if (RunOutInfo("2") == "15")//已经出完第一个小车，开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("2");
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "2", "20", SySetHeip.ResourceNumberTwo, time2, temperature2);
                            }
                            if (RunOutInfo("2") == "20")//已经出完两个小车，
                            {
                                time2 = "";
                                temperature2 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 2);
                                SqlServerHelp.ExecuteSql(Sql);
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 2);
                        SqlServerHelp.ExecuteSql(Sql);
                    }
                    //3
                    if (PlcQueryHelp.BitStatus3[0])
                    {
                        if (PlcQueryHelp.BitStatus3[2])//启动时写入时间
                        {
                            if (RunOutInfo("3") != "10")
                            {
                                PlcBeginTime("3");//该炉子已经入站运行
                            }
                        }
                        if (PlcQueryHelp.BitStatus3[4])
                        {
                            if (string.IsNullOrEmpty(time3) && string.IsNullOrEmpty(temperature3))//运行完成
                            {
                                time3 = PlcQueryHelp.SetTime3.ToString();//时间    
                                temperature3 = PlcQueryHelp.listAddressTime3[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time3, temperature3,3 );
                                SqlServerHelp.ExecuteSql(sql);
                            }

                            if (RunOutInfo("3") == "10"||string .IsNullOrEmpty(RunOutInfo("3")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("3");
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "3", "15", SySetHeip.ResourceNumberThree, time3, temperature3);
                            }
                            if (RunOutInfo("3") == "15")//已经出完第一个小车，开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("3");
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "3", "20", SySetHeip.ResourceNumberThree, time3, temperature3);
                            }
                            if (RunOutInfo("3") == "20")//已经出完两个小车
                            {
                                time3 = "";
                                temperature3 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 3);
                                SqlServerHelp.ExecuteSql(Sql);
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 3);
                        SqlServerHelp.ExecuteSql(Sql);
                    }
                    //4
                    if (PlcQueryHelp.BitStatus4[0])
                    {
                        if (PlcQueryHelp.BitStatus4[2])//启动时写入时间
                        {
                            if (RunOutInfo("4") != "10")
                            {
                                PlcBeginTime("4");//该炉子已经入站运行
                            }
                        }

                        if (PlcQueryHelp.BitStatus4[4])
                        {
                            if (string.IsNullOrEmpty(time4) && string.IsNullOrEmpty(temperature4))//运行完成
                            {
                                time4 = PlcQueryHelp.SetTime4.ToString();//时间    
                                temperature4 = PlcQueryHelp.listAddressTime4[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time4, temperature4, 4);
                                SqlServerHelp.ExecuteSql(sql);
                            }

                            if (RunOutInfo("4") == "10" || string.IsNullOrEmpty(RunOutInfo("4")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("4");
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "4", "15", SySetHeip.ResourceNumberFour, time4, temperature4);
                            }
                            if (RunOutInfo("4") == "15")//运行完成,开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("4");
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "4", "20", SySetHeip.ResourceNumberFour, time4, temperature4);
                            }
                            if (RunOutInfo("4") == "20")
                            {
                                time4="";
                                temperature4 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 4);
                                SqlServerHelp.ExecuteSql(Sql);
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 4);
                        SqlServerHelp.ExecuteSql(Sql);
                    }
                    //5
                    if (PlcQueryHelp.BitStatus5[0])
                    {
                        if (PlcQueryHelp.BitStatus5[2])//启动时写入时间
                        {
                            if (RunOutInfo("5") != "10")
                            {

                                PlcBeginTime("5");//该炉子已经入站运行
                            }
                        }

                        if (PlcQueryHelp.BitStatus5[4])
                        {
                            if (string.IsNullOrEmpty(time5) && string.IsNullOrEmpty(temperature5))//运行完成
                            {
                                time5 = PlcQueryHelp.SetTime5.ToString();//时间    
                                temperature5 = PlcQueryHelp.listAddressTime5[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time5, temperature5,5 );
                                SqlServerHelp.ExecuteSql(sql);
                            }


                            if (RunOutInfo("5") == "10" || string.IsNullOrEmpty(RunOutInfo("5")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("5");
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "5", "15", SySetHeip.ResourceNumberFive, time5, temperature5);
                            }
                            if (RunOutInfo("5") == "15")//运行完成,开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("5");
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "5", "20", SySetHeip.ResourceNumberFive, time5, temperature5);
                            }
                            if (RunOutInfo("5") == "20")
                            {
                                time5 = "";
                                temperature5 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 5);
                                SqlServerHelp.ExecuteSql(Sql);
                            }

                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 5);
                        SqlServerHelp.ExecuteSql(Sql);
                    }
                    //6
                    if (PlcQueryHelp.BitStatus6[0])
                    {
                        if (PlcQueryHelp.BitStatus6[2])//启动时写入时间
                        {
                            if (RunOutInfo("6") != "10")
                            {
                                PlcBeginTime("6");//该炉子已经入站运行
                            }
                        }
                        else
                        {
                            if (PlcQueryHelp.BitStatus6[4])
                            {
                                if (string.IsNullOrEmpty(time6) && string.IsNullOrEmpty(temperature6))//运行完成
                                {
                                    time6 = PlcQueryHelp.SetTime6.ToString();//时间    
                                    temperature6 = PlcQueryHelp.listAddressTime6[2].ToString();//温度
                                    string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time6, temperature6,6 );
                                    SqlServerHelp.ExecuteSql(sql);
                                }

                                if (RunOutInfo("6") == "10" || string.IsNullOrEmpty(RunOutInfo("6")))//运行完成,开始出第一个小车
                                {
                                    List = QueryBarcodeInfo("6");
                                    InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "6", "15", SySetHeip.ResourceNumberSix, time6, temperature6);
                                }
                                if (RunOutInfo("6") == "15")//运行完成,开始出第二个小车
                                {
                                    List2 = QueryBarcodeInfo2("6");
                                    InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "6", "20", SySetHeip.ResourceNumberSix, time6, temperature6);
                                }
                                if (RunOutInfo("6") == "20")
                                {
                                    time6 = "";
                                    temperature6 = "";
                                    string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 6);
                                    SqlServerHelp.ExecuteSql(Sql);
                                }
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 6);
                        SqlServerHelp.ExecuteSql(Sql);
                    }

                    //7
                    if (PlcQueryHelp.BitStatus7[0])
                    {
                        if (PlcQueryHelp.BitStatus7[2])//启动时写入时间
                        {
                            if (RunOutInfo("7") != "10")
                            {
                                PlcBeginTime("7");//该炉子已经入站运行
                            }
                        }
                        if (PlcQueryHelp.BitStatus7[4])
                        {
                            if (string.IsNullOrEmpty(time7) && string.IsNullOrEmpty(temperature7))//运行完成
                            {
                                time7 = PlcQueryHelp.SetTime7.ToString();//时间    
                                temperature7 = PlcQueryHelp.listAddressTime7[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time7, temperature7,7 );
                                SqlServerHelp.ExecuteSql(sql);
                            }

                            if (RunOutInfo("7") == "10" || string.IsNullOrEmpty(RunOutInfo("7")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("7");
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "7", "15", SySetHeip.ResourceNumberSeven, time7, temperature7);
                            }

                            if (RunOutInfo("7") == "15")//运行完成,开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("7");
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "7", "20", SySetHeip.ResourceNumberSeven, time7, temperature7);
                            }
                            if (RunOutInfo("7") == "20")
                            {
                                time7 = "";
                                temperature7 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 7);
                                SqlServerHelp.ExecuteSql(Sql);
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 7);
                        SqlServerHelp.ExecuteSql(Sql);
                    }
                    //8
                    if (PlcQueryHelp.BitStatus8[0])
                    {
                        if (PlcQueryHelp.BitStatus8[2])//启动时写入时间
                        {
                            if (RunOutInfo("8") != "10")
                            {
                                PlcBeginTime("8");//该炉子已经入站运行
                            }
                        }

                        if (PlcQueryHelp.BitStatus8[4])
                        {
                            if (string.IsNullOrEmpty(time8) && string.IsNullOrEmpty(temperature8))//运行完成
                            {
                                time8 = PlcQueryHelp.SetTime8.ToString();//时间    
                                temperature8 = PlcQueryHelp.listAddressTime8[2].ToString();//温度
                                string sql = string.Format(@"UPDATE [dbo.tb_RnuInfo] SET OutTem={0}, OutTime={1}
                                WHERE Door={2}", time8, temperature8,8 );
                                SqlServerHelp.ExecuteSql(sql);
                            }

                            if (RunOutInfo("8") == "10" || string.IsNullOrEmpty(RunOutInfo("8")))//运行完成,开始出第一个小车
                            {
                                List = QueryBarcodeInfo("8");
                                InterfaceHelp.Interface.ReceiveNumber(List, Barcode, "8", "15", SySetHeip.ResourceNumberEight, time8, temperature8);
                            }
                            if (RunOutInfo("8") == "15")//运行完成,开始出第二个小车
                            {
                                List2 = QueryBarcodeInfo2("8");
                                InterfaceHelp.Interface.ReceiveNumber(List2, Barcode2, "8", "20", SySetHeip.ResourceNumberEight, time8, temperature8);
                            }
                            if (RunOutInfo("8") == "20")
                            {
                                time8 = "";
                                temperature8 = "";
                                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  OutAndInInfo='{0}'  WHERE Door='{1}'", "两个小车出站完成", 8);
                                SqlServerHelp.ExecuteSql(Sql);
                            }
                        }
                    }
                    else
                    {
                        string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET Barcode='{0}',BarcodeInclude ='{0}', Barcode2='{0}',BarcodeInclude2 ='{0}' , OutAndInInfo='{0}'  WHERE Door='{1}'", "", 8);
                        SqlServerHelp.ExecuteSql(Sql);
                    }
                }
            }
            catch { }
        }
    }   
}
