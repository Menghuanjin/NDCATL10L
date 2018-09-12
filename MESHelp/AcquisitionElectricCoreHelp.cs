using Common;
using InterfaceHelp;
using ND.CoreList;
using ND6L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND
{
   public  class AcquisitionElectricCoreHelp
    {
        private static string Number = "";
        private static string BarcodeList ;//把小车1条形码，给MES返回小车内的托盘信息
        private static string BarcodeList2;//把小车2条形码，给MES返回小车内的托盘信息
        private static int DoorInfo ;//门信息
        private static int Code ;
        private static string Meg;
        private  static bool MESReturn;
        ///// <summary>
        ///// 获取小车内的电芯列表
        ///// </summary>
        public static getCellListByTrayIdResponse getCell = new getCellListByTrayIdResponse();

        /// <summary>
        /// 开机自检接口
        /// </summary>
        /// <param name="HandbarrowBarCode"></param>
        public static void  CheckupMES(string HandbarrowBarCode =null)
        {
            try
            {
                getCell = Interface.ChargeNumberAddess(HandbarrowBarCode, SySetHeip.ResourceNumberOne, 1);//调用接口  
                if (getCell.@return == null)
                {
                    Common.Msg.Warning("MES开机自检失败，请检查");
                }  
            }
            catch (Exception){ }
        } 


        /// <summary>
        /// MES获取电芯列表
        /// </summary>
        /// <param name="Barcode"></param>
        /// <param name="Barcode2"></param>
        /// <returns></returns>
        public static void  MESSelectRun(string Barcode, string Barcode2=null)
        {
           
            if (SuperiorLimit.OperaterInfo == "One") { Number = SySetHeip.ResourceNumberOne; DoorInfo = 1; }
            if (SuperiorLimit.OperaterInfo == "Two") { Number = SySetHeip.ResourceNumberTwo; DoorInfo = 2; }
            if (SuperiorLimit.OperaterInfo == "Three") { Number = SySetHeip.ResourceNumberThree; DoorInfo = 3; }
            if (SuperiorLimit.OperaterInfo == "Four") { Number = SySetHeip.ResourceNumberFour; DoorInfo = 4; }
            if (SuperiorLimit.OperaterInfo == "Five") { Number = SySetHeip.ResourceNumberFive; DoorInfo = 5; }
            if (SuperiorLimit.OperaterInfo == "Six") { Number = SySetHeip.ResourceNumberSix; DoorInfo = 6; }
            if (SuperiorLimit.OperaterInfo == "Seven") { Number = SySetHeip.ResourceNumberSeven; DoorInfo = 7; }
            if (SuperiorLimit.OperaterInfo == "Eight") { Number = SySetHeip.ResourceNumberEight; DoorInfo = 8; }

            if (Barcode != Barcode2)
            {
                //if (!string.IsNullOrEmpty(Barcode) && string.IsNullOrEmpty(Barcode2))//单个小车获取电芯列表
                //{
                //    if (SolitaryHandbarrow(Barcode) == 0)//单个条码获取成功
                //        DictionaryHelp.Dictionary["Start" + SuperiorLimit.OperaterInfo]();
                //}
              


                if (!string.IsNullOrEmpty(Barcode) && !string.IsNullOrEmpty(Barcode2))//两个小车获取电芯列表
                {
                    if (string.IsNullOrEmpty(Number))
                    {
                        Common.Msg.Warning("查询到有资源号为空，启动失败！");
                        return;
                    }
                    if (SolitaryHandbarrow(Barcode) == 0 && SolitaryHandbarrow2(Barcode2) == 0)//两个条码获取电芯列表成功
                    {
                        MESReturn = true;//mes返回
                        DictionaryHelp.Dictionary["Start" + SuperiorLimit.OperaterInfo]();
                    }                 
                }
            }    
        }
        /// <summary>
        /// 单个小车获取电芯列表
        /// </summary>
        /// <param name="HandbarrowBarCode"></param>
        public static  int  SolitaryHandbarrow(string HandbarrowBarCode)
        {
            DateTime beginTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            TimeSpan timeS = new TimeSpan();
            try
            { ////  返回小车1内的电芯列表                
                getCell = Interface.ChargeNumberAddess(HandbarrowBarCode, Number, DoorInfo);//调用接口
                Meg = getCell.@return.message;//返回信息
                Code = getCell.@return.code;//code
            }
            catch (Exception ex)
            {
                Meg = ex.Message;
                Code = 1001;
            }
            finally
            {
                if (string.IsNullOrEmpty(Meg)&& getCell.@return.code == 0)
                {
                    BarcodeList = "";
                    endTime = DateTime.Now;
                    timeS = endTime - beginTime;
                    ControlHelp.ControlHelp.listBoxInfo("MES返回:" + getCell.@return.code + "信息:" + getCell.@return.message + "  耗时：" + timeS.Milliseconds.ToString());//返回信息
                    List<string> list = strToNull(getCell.@return.sfcList);
                    for (int i = 0; i < list.Count; i++)
                    {
                        BarcodeList += list[i] + ",";
                    }
                    if (!string.IsNullOrEmpty(BarcodeList))
                    {
                        BarcodeList = InterceptStringHelp.Delectlast(BarcodeList);
                        //写CSV文件
                        ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                        string.Format("开始时间代码Error　[BeginTime]({0}、{1})", HandbarrowBarCode, Number),
                       Code + "", Meg, 1);
                    }
                }
                else
                {
                    ControlHelp.ControlHelp.listBoxInfo("MES返回:" + getCell.@return.code + "信息:" + getCell.@return.message + "  耗时：" + timeS.Milliseconds.ToString());//返回信息      
                    Common.Msg.Warning("条码号:" + HandbarrowBarCode + "获取小车内的托盘失败");
                    //写CSV文件
                    ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                    string.Format("开始时间代码Error　[BeginTime]({0}、{1})", HandbarrowBarCode, Number),
                   Code + "", Meg, 1);
                }
                //扫到的条形码写入数据库
                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  Barcode ='{0}',BarcodeInclude='{1}'  WHERE Door='{2}'", HandbarrowBarCode, BarcodeList, DoorInfo);
                SqlServerHelp.ExecuteSql(Sql);
            }
            return Code;
        }
        public static int  SolitaryHandbarrow2(string HandbarrowBarCode2)
        {
            DateTime beginTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            TimeSpan timeS = new TimeSpan();
            try
            {
                getCell = Interface.ChargeNumberAddess(HandbarrowBarCode2, Number, DoorInfo);//调用接口
                Meg = getCell.@return.message;//返回信息
                Code = getCell.@return.code;//code
            }
            catch (Exception ex)
            {
                Meg = ex.Message;
                Code = 1001;
            }
            finally
            {
                if (string.IsNullOrEmpty(Meg) && getCell.@return.code == 0)
                {
                    BarcodeList2 = "";
                    endTime = DateTime.Now;
                    timeS = endTime - beginTime;
                    ControlHelp.ControlHelp.listBoxInfo("MES返回:" + getCell.@return.code + "信息:" + getCell.@return.message + "  耗时：" + timeS.Milliseconds.ToString());//返回信息      
                    List<string> list = strToNull(getCell.@return.sfcList);
                    for (int i = 0; i < list.Count; i++)
                    {
                        BarcodeList2 += list[i] + ",";
                    }
                    if (!string.IsNullOrEmpty(BarcodeList2))
                    {
                        BarcodeList2 = InterceptStringHelp.Delectlast(BarcodeList2);
                        //写CSV文件
                        ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                        string.Format("开始时间代码Error　[BeginTime]({0}、{1})", HandbarrowBarCode2, Number),
                        Code + "", Meg, 1);
                    }
                }
                else
                {
                    ControlHelp.ControlHelp.listBoxInfo("MES返回:" + getCell.@return.code + "信息:" + getCell.@return.message + "  耗时：" + timeS.Milliseconds.ToString());//返回信息      
                    //写CSV文件
                    ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                    string.Format("开始时间代码Error　[BeginTime]({0}、{1})", HandbarrowBarCode2, Number),
                    Code + "", Meg, 1);
                    Common.Msg.Warning("条码号:" + HandbarrowBarCode2 + "获取小车内的托盘失败,请重新两个绑定小车");
                }
                //扫到的条形码写入数据库
                string Sql = string.Format(@"UPDATE [db_ND10L].[dbo].[dbo.tb_RnuInfo] SET  Barcode2 ='{0}',BarcodeInclude2='{1}'  WHERE Door='{2}'", HandbarrowBarCode2, BarcodeList2, DoorInfo);
                SqlServerHelp.ExecuteSql(Sql);
            }
            return Code;
        }
        /// <summary>
        /// 剔除返回的数组的空值
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<string> strToNull(string[] list)
        {
            List<string> listTemp = new List<string>();
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s)) continue;
                listTemp.Add(s);
            }
            return listTemp;
        }

    }
}
