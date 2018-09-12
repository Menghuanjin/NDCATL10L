using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHelp
{
    public class ConfigureHelp
    {

        //托盘校验

        /// <summary>
        /// WS服务器WSDL url
        /// </summary>
        public static string CheckoutMES_WSDL { get; set; }
        /// <summary>
        /// WS服务器连接超时设置，毫秒
        /// </summary>
        public static int CheckoutTimeOut { get; set; }
        /// <summary>
        /// 连接服务器用户名
        /// </summary>
        public static string CheckoutUser { get; set; }
        /// <summary>
        /// 连接服务器密码
        /// </summary>
        public static string CheckoutPassword { get; set; }
        /// <summary>
        /// 设备所在的站点
        /// </summary>
        public static string CheckoutSite { get; set; }

        //检查电芯状态
        /// <summary>
        /// WS服务器WSDL
        /// </summary>
        public static string ElectricCoreStateMES_WSDL { get; set; }
        /// <summary>
        /// WS服务器连接超时设置，毫秒
        /// </summary>
        public static string ElectricCoreStateTimeOut { get; set; }
        /// <summary>
        /// 连接服务器用户名
        /// </summary>
        public static string ElectricCoreStateUser { get; set; }
        /// <summary>
        /// 连接服务器密码
        /// </summary>
        public static string ElectricCoreStatePassword { get; set; }
        /// <summary>
        /// 设备所在的站点
        /// </summary>
        public static string ElectricCoreStateSite { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public static string ElectricCoreStateOperation { get; set; }

        //电芯绑定到托盘

        /// <summary>
        /// 上传WS服务器WSDL
        /// </summary>
        public static string BindingPalletMES_WSDL { get; set; }
        /// <summary>
        /// 上传WS服务器连接超时设置，毫秒
        /// </summary>
        public static string BindingPalletTimeOut { get; set; }
        /// <summary>
        ///上传连接服务器用户名
        /// </summary>
        public static string BindingPalletUser { get; set; }
        /// <summary>
        /// 上传连接服务器密码
        /// </summary>
        public static string BindingPalletPassword { get; set; }
        /// <summary>
        /// 上传设备所在的站点
        /// </summary>
        public static string BindingPalletSite { get; set; }
        /// <summary>
        /// 上传所在的位置
        /// </summary>
        public static int BindingPalletOperation { get; set; }
        /// <summary>
        /// 上传托盘号
        /// </summary>
        public static string BindingPalletTrayId { get; set; }





        //获取电芯列表

        /// <summary>
        /// 上传WS服务器WSDL
        /// </summary>
        public static string ElectricCoreMES_WSDL { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public static int ElectricCoreTimeOut { get; set; }
        /// <summary>
        ///上传连接服务器用户名
        /// </summary>
        public static string ElectricCoreUser { get; set; }
        /// <summary>
        /// 上传连接服务器密码
        /// </summary>
        public static string ElectricCoretPassword { get; set; }
        /// <summary>
        /// 上传设备所在的站点
        /// </summary>
        public static string ElectricCoreSite { get; set; }
































        //高温静置收数

        /// <summary>
        /// WS服务器WSDL
        /// </summary>
        public static string hargeNumberMES_WSDL { get; set; }
        /// <summary>
        /// WS服务器连接超时设置，毫秒
        /// </summary>
        public static int hargeNumberTimeOut { get; set; }
        /// <summary>
        /// 连接服务器用户名
        /// </summary>
        public static string hargeNumberUser { get; set; }
        /// <summary>
        /// 连接服务器密码
        /// </summary>
        public static string hargeNumberPassword { get; set; }
        /// <summary>
        /// 设备所在的站点
        /// </summary>
        public static string hargeNumberSite { get; set; }
        /// <summary>
        /// 工位
        /// </summary>
        public static string hargeNumberOperation { get; set; }
        /// <summary>                   
        /// 工位版本
        /// </summary>
        public static string hargeNumberOperationRevision { get; set; }
        /// <summary>
        /// 空
        /// </summary>
        public static string hargeNumberActivityId { get; set; }
        /// <summary>
        /// 空
        /// </summary>
        public static string hargeNumberIsDispositionRequired { get; set; }
        /// <summary>
        /// DC采集组
        /// </summary>
        public static string hargeNumberDcGroup { get; set; }
        /// <summary>
        ///DC采集组版本号
        /// </summary>
        public static string hargeNumberDcGroupRevision { get; set; }
        /// <summary>
        /// 操作用户
        /// </summary>
        public static string hargeNumberOperateUser { get; set; }



        public static void SaveInfoToCSVFileAtLog(string startTime, string endTime, string timeS, string UseredS, string ErrorCode, string ErrorString, int logType)
        {
            List<string[]> l = new List<string[]>();
            List<string[]> info = new List<string[]>();
            string[] title = new string[] { "开始时间", "结束时间", "耗时(毫秒)", "调用内容", "返回代码", "错误提示信息" };

            string tempPathMM = DateTime.Now.ToString("yyyyMMdd");
            string filePath = @"D:\MESLog\MES\SFC\" + DateTime.Now.ToString("yyyyMMdd");
            if (logType == 1)
            {
                filePath = @"D:\MESLog\BeginTime\SFC\" + DateTime.Now.ToString("yyyyMMdd"); 
            }
            else if (logType == 2)
            {
                filePath = @"D:\MESLog\EndTime\SFC\" + DateTime.Now.ToString("yyyyMMdd");
            }
            else if (logType == 3)
            {
                filePath = @"D:\MESLog\MESOutInfo\SFC\" + DateTime.Now.ToString("yyyyMMdd");
            }
            //D:\MESLog\MES\SFC\20150826
            //E:\MESData\backup\MES\SFC\20150826\12B000000001_20150826105626.csv

            if (!System.IO.File.Exists(string.Format(@"{0}\{1}\{2}.csv", filePath, tempPathMM, tempPathMM)))
            {
                l.Add(title);
            }
            else
            {
                l = null;
            }


            string[] inputSS = { startTime, endTime, timeS, UseredS, ErrorCode, ErrorString };
            info.Add(inputSS);
            try
            {
                CSVHelper.CsvPath = filePath;//路径
                CSVHelper.WriteInfoToCSVFileDisMath(info, l, false);//写CSV
            }
            catch { }
        }
        /// <summary>
        /// 写CVS调用接口错误文件
        /// </summary>
        /// <param name="CarNo"></param>
        /// <param name="BackingBoxNum"></param>
        /// <param name="Reces"></param>
        /// <param name="Operation"></param>
        public static void SaveInfoToCSVFile(string CarNo, string BackingBoxNum, string Reces, string ErrorMessge)
        {
            List<string[]> l = new List<string[]>();
            List<string[]> info = new List<string[]>();
            string[] title = new string[] { "日期", "小车号", "炉号", "资源号", "ErrorMessge" };


            string tempPathMM = DateTime.Now.ToString("yyyyMMdd");
            string filePath = @"D:\MESData\MES\SFC\"+DateTime.Now.ToString("yyyyMMdd");//调用接口错误保存路径
            //D:\MESData\MES\SFC\20150826
            //E:\MESData\backup\MES\SFC\20150826\12B000000001_20150826105626.csv

            if (!System.IO.File.Exists(string.Format(@"{0}\{1}\{2}.csv", filePath, tempPathMM, tempPathMM)))
            {
                l.Add(title);
            }
            else
            {
                l = null;
            }
            string[] inputSS = { DateTime.Now.ToString(), CarNo,  BackingBoxNum, Reces, ErrorMessge };
            info.Add(inputSS);
            try
            {
                CSVHelper.CsvPath = filePath;//路径
                CSVHelper.WriteInfoToCSVFileDisMath(info, l, false);//写CSV
            }
            catch { }
        }
    }
}

