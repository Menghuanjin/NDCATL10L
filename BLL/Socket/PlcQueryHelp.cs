using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PLCSocket
{
    public class PlcQueryHelp
    {
        /// <summary>
        /// 查询1#是否断线
        /// </summary>
        /// 
        public static bool BreakThread_one { get; set; }

        /// <summary>
        /// 查询1门恒温时间
        /// </summary>
        public static  double ConstantTime1 { get; set; }
        /// <summary>
        /// 查询1门设定时间
        /// </summary>
        public static double SetTime1{ get; set; }
        /// <summary>
        /// 查询2门恒温时间
        /// </summary>
        public static double ConstantTime2 { get; set; }
        /// <summary>
        /// 查询2门设定时间
        /// </summary>
        public static double SetTime2 { get; set; }
        /// <summary>
        /// 查询3门恒温时间
        /// </summary>
        public static double ConstantTime3 { get; set; }
        /// <summary>
        /// 查询3门设定时间
        /// </summary>
        public static double SetTime3 { get; set; }
        /// <summary>
        /// 查询4门恒温时间
        /// </summary>
        public static double ConstantTime4 { get; set; }
        /// <summary>
        /// 查询4门设定时间
        /// </summary>
        public static double SetTime4 { get; set; }
        /// <summary>
        /// 查询5门恒温时间
        /// </summary>
        public static double ConstantTime5 { get; set; }
        /// <summary>
        /// 查询5门设定时间
        /// </summary>
        public static double SetTime5 { get; set; }
        /// <summary>
        /// 查询6门恒温时间
        /// </summary>
        public static double ConstantTime6 { get; set; }
        /// <summary>
        /// 查询6门设定时间
        /// </summary>
        public static double SetTime6 { get; set; }
        /// <summary>
        /// 查询7门恒温时间
        /// </summary>
        public static double ConstantTime7 { get; set; }
        /// <summary>
        /// 查询7门设定时间
        /// </summary>
        public static double SetTime7 { get; set; }
        /// <summary>
        /// 查询8门恒温时间
        /// </summary>
        public static double ConstantTime8 { get; set; }
        /// <summary>
        /// 查询8门设定时间
        /// </summary>
        public static double SetTime8 { get; set; }
        /// <summary>
        /// 1门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus1 = new bool[5];
        /// <summary>
        /// 2门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus2 = new bool[5];
        /// <summary> 
        /// 3门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus3 = new bool[5];
        /// <summary>
        /// 4门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus4 = new bool[5];
        /// <summary>
        /// 5门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus5 = new bool[5];
        /// <summary>
        /// 6门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus6 = new bool[5];
        /// <summary>
        /// 7门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus7 = new bool[5];
        /// <summary>
        /// 8门位状态  List0=联机状态 ， List1=照明灯， List2=风机状态  List3=加热状态 list4=运行完成标志
        /// </summary>
        public static bool[] BitStatus8 = new bool[5];

        /// <summary>
        /// 1门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度 
        /// </summary>
        public static double[] listAddressTime1 = new double[5];
        /// <summary>
        /// 2门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>
        public static double[] listAddressTime2 = new double[5];
        /// <summary>
        /// 3门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>
        public static double[] listAddressTime3 = new double[5];
        /// <summary>
        /// 4门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>
        public static double[] listAddressTime4 = new double[5];
        /// <summary>
        /// 5门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>
        public static double[] listAddressTime5 = new double[5];
        /// <summary>
        /// 6门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>
        public static double[] listAddressTime6 = new double[5];
        /// <summary>
        /// 7门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>

        public static double[] listAddressTime7 = new double[5];
        /// <summary>
        /// 8门运行时间  List0=温度上限值 ， List1=温度下限值， List2=监控温度  List3=设定温度
        /// </summary>
        public static double[] listAddressTime8 = new double[5];
        /// <summary>
        /// 查询PLC时间
        /// </summary>
        /// <param name="IPAddress">list索引</param>
        public static void PLC_QueryTime(int IPAddress)
        {
            SetTime1 = TimeAddress(IPAddress, 32462);//设定时间
            ConstantTime1 = TimeAddress(IPAddress, 32460);//恒温计时
            listAddressTime1[0] = TimeAddress(IPAddress, 32464) / 10;//1温度上限值
            listAddressTime1[1] = TimeAddress(IPAddress, 32466) / 10;//1温度下限值
            listAddressTime1[2] = TimeAddress(IPAddress, 601) / 10;//1监控温度
            listAddressTime1[3] = TimeAddress(IPAddress, 32600) / 10;//设定温度

            SetTime2 = TimeAddress(IPAddress, 32472);//设定时间
            ConstantTime2 = TimeAddress(IPAddress, 32470);//恒温计时
            listAddressTime2[0] = TimeAddress(IPAddress, 32474) / 10;//2温度上限值
            listAddressTime2[1] = TimeAddress(IPAddress, 32476) / 10;//2温度下限值
            listAddressTime2[2] = TimeAddress(IPAddress, 603) / 10;//2监控温度
            listAddressTime2[3] = TimeAddress(IPAddress, 32601) / 10;//2设定温度

            SetTime3 = TimeAddress(IPAddress, 32482);//设定时间
            ConstantTime3 = TimeAddress(IPAddress, 32480);//恒温计时
            listAddressTime3[0] = TimeAddress(IPAddress, 32484) / 10;//3温度上限值
            listAddressTime3[1] = TimeAddress(IPAddress, 32486) / 10;//3温度下限值
            listAddressTime3[2] = TimeAddress(IPAddress, 605) / 10;//3监控温度
            listAddressTime3[3] = TimeAddress(IPAddress, 32602) / 10;//3设定温度

            SetTime4 = TimeAddress(IPAddress, 32492);//设定时间
            ConstantTime4 = TimeAddress(IPAddress, 32490);//恒温计时
            listAddressTime4[0] = TimeAddress(IPAddress, 32494) / 10;//4温度上限值
            listAddressTime4[1] = TimeAddress(IPAddress, 32496) / 10;//4温度下限值
            listAddressTime4[2] = TimeAddress(IPAddress, 607) / 10;//4监控温度
            listAddressTime4[3] = TimeAddress(IPAddress, 32603) / 10;//4设定温度

            SetTime5 = TimeAddress(IPAddress, 32502);//设定时间
            ConstantTime5 = TimeAddress(IPAddress, 32500);//恒温计时
            listAddressTime5[0] = TimeAddress(IPAddress, 32504) / 10;//5温度上限值
            listAddressTime5[1] = TimeAddress(IPAddress, 32506) / 10;//5温度下限值
            listAddressTime5[2] = TimeAddress(IPAddress, 621) / 10;//5监控温度
            listAddressTime5[3] = TimeAddress(IPAddress, 32604) / 10;//5设定温度

            SetTime6 = TimeAddress(IPAddress, 32512);//设定时间
            ConstantTime6 = TimeAddress(IPAddress, 32510);//恒温计时
            listAddressTime6[0] = TimeAddress(IPAddress, 32514) / 10;//6温度上限值
            listAddressTime6[1] = TimeAddress(IPAddress, 32516) / 10;//6温度下限值
            listAddressTime6[2] = TimeAddress(IPAddress, 623) / 10;//6监控温度
            listAddressTime6[3] = TimeAddress(IPAddress, 32605) / 10;//6设定温度

            SetTime7 = TimeAddress(IPAddress, 32522);//设定时间
            ConstantTime7 = TimeAddress(IPAddress, 32520);//恒温计时
            listAddressTime7[0] = TimeAddress(IPAddress, 32524) / 10;//7温度上限值
            listAddressTime7[1] = TimeAddress(IPAddress, 32526) / 10;//7温度下限值
            listAddressTime7[2] = TimeAddress(IPAddress, 625) / 10;//7监控温度
            listAddressTime7[3] = TimeAddress(IPAddress, 32606) / 10;//7设定温度

            SetTime8 = TimeAddress(IPAddress, 32532);//设定时间
            ConstantTime8 = TimeAddress(IPAddress, 32530);//恒温计时
            listAddressTime8[0] = TimeAddress(IPAddress, 32534) / 10;//8温度上限值
            listAddressTime8[1] = TimeAddress(IPAddress, 32536) / 10;//8温度下限值
            listAddressTime8[2] = TimeAddress(IPAddress, 627) / 10;//8监控温度
            listAddressTime8[3] = TimeAddress(IPAddress, 32607) / 10;//8设定温度
        }
        /// <summary>
        /// 查询bit地址
        /// </summary>
        /// <param name="IPAddress"></param>
        public static void PLC_QueryStatus(int IPAddress)
        {

            BitStatus1[0] = !PLC_QueryBit(IPAddress, "4");//1联机状态
            BitStatus1[1] = PLC_QueryBit(IPAddress, "2");//1照明状态
            BitStatus1[2] = Valur(IPAddress, 100);//1加热
            BitStatus1[3] = Valur(IPAddress, 102);//1运风
            BitStatus1[4] = PLC_QueryBit(IPAddress, "9");

            BitStatus2[0] = !PLC_QueryBit(IPAddress, "14");//2联机状态
            BitStatus2[1] = PLC_QueryBit(IPAddress, "12");//2照明状态
            BitStatus2[2] = Valur(IPAddress, 110);//2加热
            BitStatus2[3] = Valur(IPAddress, 112);//2运风
            BitStatus2[4] = PLC_QueryBit(IPAddress, "19");

            BitStatus3[0] = !PLC_QueryBit(IPAddress, "24");//3联机状态
            BitStatus3[1] = PLC_QueryBit(IPAddress, "22");//3照明状态
            BitStatus3[2] = Valur(IPAddress, 120);//3加热
            BitStatus3[3] = Valur(IPAddress, 122);//3运风
            BitStatus3[4] = PLC_QueryBit(IPAddress, "29");

            BitStatus4[0] = !PLC_QueryBit(IPAddress, "34");//4联机状态
            BitStatus4[1] = PLC_QueryBit(IPAddress, "32");//4照明状态
            BitStatus4[2] = Valur(IPAddress, 130);//4加热
            BitStatus4[3] = Valur(IPAddress, 132);//4运风
            BitStatus4[4] = PLC_QueryBit(IPAddress, "39");

            BitStatus5[0] = !PLC_QueryBit(IPAddress, "44");//5联机状态
            BitStatus5[1] = PLC_QueryBit(IPAddress, "42");//5照明状态
            BitStatus5[2] = Valur(IPAddress, 140);//5加热
            BitStatus5[3] = Valur(IPAddress, 142);//5运风
            BitStatus5[4] = PLC_QueryBit(IPAddress, "49");

            BitStatus6[0] = !PLC_QueryBit(IPAddress, "54");//6联机状态
            BitStatus6[1] = PLC_QueryBit(IPAddress, "52");//6照明状态
            BitStatus6[2] = Valur(IPAddress, 150);//6加热
            BitStatus6[3] = Valur(IPAddress, 152);//6运风
            BitStatus6[4] = PLC_QueryBit(IPAddress, "59");


            BitStatus7[0] = !PLC_QueryBit(IPAddress, "64");//7联机状态
            BitStatus7[1] = PLC_QueryBit(IPAddress, "62");//7照明状态
            BitStatus7[2] = Valur(IPAddress, 160);//7加热
            BitStatus7[3] = Valur(IPAddress, 162);//7运风
            BitStatus7[4] = PLC_QueryBit(IPAddress, "69");

            BitStatus8[0] = !PLC_QueryBit(IPAddress, "74");//8联机状态
            BitStatus8[1] = PLC_QueryBit(IPAddress, "72");//8照明状态
            BitStatus8[2] = Valur(IPAddress, 170);//8加热
            BitStatus8[3] = Valur(IPAddress, 172);//8运风
            BitStatus8[4] = PLC_QueryBit(IPAddress, "79");
          
        }
        /// <summary>
        /// 查询PLC位地址状态
        /// </summary>
        /// <param name="listip"></param>
        /// <param name="Value"></param>
        public static bool PLC_QueryBit(int listip, string Value)
        {
            //%01$RC021
            string strValue = SocketHelper.SendAddress(SocketHelper.socketList[listip].socket, PLCAddressHelper.RAddressReadConvert(Value));
            return PLCAddressHelper.ValueInfo(strValue);
        }

        /// <summary>
        /// 查询PLC 例如温度，
        /// </summary>
        /// <param name="ListIp">list索引的ip</param>
        /// <param name="Address">PLC读取的寄存器</param>
        /// <returns></returns>
        public static Double  TimeAddress(int ListIp, int Address)
        {
            string DataInfo = "";
            string ss = "";
            string strValue = SocketHelper.SendAddress(SocketHelper.socketList[ListIp].socket, PLCAddressHelper.DTAddressReadConvert(Address));
            strValue = strValue.Replace("\r", "");
            string highOrder = "";
            string lowOrder = "";
            if (!string.IsNullOrEmpty(strValue))//未读到了正确数据
            {
                ss = HexStr(strValue);
            }
            for (int i = 0; i < ss.Length / 4; i++)
            {
                highOrder = ss.Substring((i * 4), 2);//高位数据  09100910
                lowOrder = ss.Substring((i * 4) + 2, 2);//低位数据
                DataInfo = HexToTen(lowOrder + highOrder).ToString();
            }          
            return Convert.ToDouble(DataInfo);         
        }
        /// <summary>
        /// 截取寄存器地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HexStr(string str)
        {
            return str.Substring(6, str.Length - 8);
        }
        /// <summary>
        /// 查询PLC寄存的值，转bool
        /// </summary>
        /// <param name="ListIp">连接的List的IP</param>
        /// <param name="str">查询的plc地址</param>
        /// <returns></returns>
        public static bool Valur(int ListIp, int Value)
        {
         //   bool Analyze = false;
            string DataInfo = "";
            string ss = "";
            string strValue = SocketHelper.SendAddress(SocketHelper.socketList[ListIp].socket, PLCSocket.PLCAddressHelper.DTAddressReadConvert(Value));
            strValue = strValue.Replace("\r", "");
            string highOrder = "";
            string lowOrder = "";
            if (!string.IsNullOrEmpty(strValue))//未读到了正确数据
            {
                ss = HexStr(strValue);
            }
            for (int i = 0; i < ss.Length / 4; i++)
            {
                highOrder = ss.Substring((i * 4), 2);//高位数据  09100910
                lowOrder = ss.Substring((i * 4) + 2, 2);//低位数据
                DataInfo = HexToTen(lowOrder + highOrder).ToString();
            }
            return ValueInfo(DataInfo);
        }
        /// <summary>
        /// 截取触点返回值 例如读取当前触点信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ValueInfo(string str)
        {
           bool ValueAddress = false;
            switch (str)
            {
                case "0":
                    ValueAddress= false;
                    break;
                case "1":
                    ValueAddress = true;
                    break;
            }
            return ValueAddress;
        }
        /// <summary>
        /// 十六进制转10进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int HexToTen(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }


    }
}
