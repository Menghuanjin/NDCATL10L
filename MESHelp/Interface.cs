using ND;
using ND.BindingPallt;
using ND.ChargeNumber;
using ND.CoreList;
using ND.ElectricCoreState;
using ND.PattelCheck;
using ND10L;
using ND6L;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHelp
{
    public class Interface
    {
        /// <summary>
        /// (小车号)托盘校验
        /// </summary>
        /// <param name="BarCode">(小车号)托盘号</param>
        /// <returns></returns>
        public static miCheckProcessLotResponse CheckoutAddress(string BarCode)
        {
            miCheckProcessLotResponse ReturnTarget = new miCheckProcessLotResponse();
            MiCheckProcessLotServiceService service = new MiCheckProcessLotServiceService();
            service.Url = ConfigureHelp.CheckoutMES_WSDL;// "http://172.26.11.3:50000/atlmeswebservice/MiCheckProcessLotServiceService?wsdl";
            service.Timeout = ConfigureHelp.CheckoutTimeOut;//时间
            service.Credentials = new System.Net.NetworkCredential(ConfigureHelp.CheckoutUser, ConfigureHelp.CheckoutPassword, null); //Baiduhai7     //验证信息
            service.PreAuthenticate = true;
            checkProcessLotRequest request = new checkProcessLotRequest();
            request.site = ConfigureHelp.CheckoutSite;//站点
            request.processLot = BarCode;//小车号

            miCheckProcessLot mt = new miCheckProcessLot();
            mt.Request = request;
            

            ReturnTarget = service.miCheckProcessLot(mt);
            if (Convert.ToInt16(ReturnTarget.@return.code)==0)//校验成功
            {
              
            }


            return ReturnTarget;
        }

        /// <summary>
        /// 检查电芯状态
        /// </summary>
        /// <param name="sfc">电芯号</param>
        /// <returns></returns>
        public static miCheckSFCstatusResponse ElectricCoreState(string sfc)
        {
            miCheckSFCstatusResponse miCheckSFCstatusResponseAddress = new miCheckSFCstatusResponse();
            try
            {
                MiCheckSFCStatusServiceService ElectricCoreStateAddress = new MiCheckSFCStatusServiceService();
                ElectricCoreStateAddress.Url = "http://172.26.11.3:50000/atlmeswebservice/MiCheckSFCStatusServiceService?wsdl";
                ElectricCoreStateAddress.Timeout = 300000;
                ElectricCoreStateAddress.Credentials = new System.Net.NetworkCredential("SUP_TEST01", "test12345", null); //Baiduhai7     //验证信息
                ElectricCoreStateAddress.PreAuthenticate = true;
                miCheckSFCstatus ms = new miCheckSFCstatus();
                changeSFCStatusRequest ct = new changeSFCStatusRequest();
                ct.site = "2001";
                ct.operation = "HSTDY1";
                ct.operationRevision = "#";
                ct.sfc = "PL0205005";
               
                ms.ChangeSFCStatusRequest = ct;
                miCheckSFCstatusResponseAddress = ElectricCoreStateAddress.miCheckSFCstatus(ms);
            }
            catch 
            {
                ////写CSV文件
                //ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                //string.Format("开始时间代码Error　[BeginTime]({0}、{1})", BarCode1.Text, resource),
            }
            return miCheckSFCstatusResponseAddress;
        }
        //}
        ///// <summary>
        ///// 电芯绑定到托盘
        ///// </summary>
        ///// <returns></returns>
        //public static miBindSFCintoTrayResponse BindingPalletAddress(string sfc)
        //{
        //    miBindSFCintoTrayResponse miBindSFCintoTrayResponseAddress = new miBindSFCintoTrayResponse();

        //    try
        //    {
        //        MiCheckProcessLotServiceClient Client = new MiCheckProcessLotServiceClient();
        //        var uname = Client.ClientCredentials.UserName;
        //        uname.UserName = ConfigureHelp.BindingPalletUser;// "SUP_TEST01";//用户
        //        uname.Password = ConfigureHelp.BindingPalletPassword; //"test12345";//密码
        //        MiBindSFCintoTrayServiceService MiBindSFCintoTrayServiceServiceAddress = new MiBindSFCintoTrayServiceService();
        //        miBindSFCintoTray miBindSFCintoTrayAddress = new miBindSFCintoTray();
        //        MiBindSFCintoTrayServiceServiceAddress.Url = "";
        //        miBindSFCintoTrayAddress.BindSFCintoTrayRequest.site = ConfigureHelp.BindingPalletSite;//所在的站点
        //        miBindSFCintoTrayAddress.BindSFCintoTrayRequest.mode = ND.BindingPallt.ModeTrayMatrix.COLUMNFIRST;//模式
        //        miBindSFCintoTrayAddress.BindSFCintoTrayRequest.position = ConfigureHelp.BindingPalletOperation;//所在的位置
        //        miBindSFCintoTrayAddress.BindSFCintoTrayRequest.trayId = ConfigureHelp.BindingPalletTrayId;//托盘号
        //        miBindSFCintoTrayAddress.BindSFCintoTrayRequest.sfc = sfc;//电芯号号
        //        miBindSFCintoTrayResponseAddress = MiBindSFCintoTrayServiceServiceAddress.miBindSFCintoTray(miBindSFCintoTrayAddress);
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //    return miBindSFCintoTrayResponseAddress;
        //}
        ///// <summary>
        ///// 获取托盘中的列表
        ///// </summary>
        ///// <returns></returns>
        //public static getCellListByTrayIdResponse ElectricCoreListAddress()
        //{
        //    getCellListByTrayIdResponse getCellListByTrayIdResponseAddress = new getCellListByTrayIdResponse();
        //    try
        //    {
        //        MiCheckProcessLotServiceClient Client = new MiCheckProcessLotServiceClient();
        //        var uname = Client.ClientCredentials.UserName;
        //        uname.UserName = ConfigureHelp.BindingPalletUser;// "SUP_TEST01";//用户
        //        uname.Password = ConfigureHelp.BindingPalletPassword; //"test12345";//密码
        //        CellTestIntegrationServiceService CellTestIntegrationServiceServiceAddress = new CellTestIntegrationServiceService();
        //        CellTestIntegrationServiceServiceAddress.Url = "";

        //        getCellListByTrayId getCellListByTrayIdAddress = new getCellListByTrayId();
        //        getCellListByTrayIdAddress.CellListRequest.site = "";//所在的站点
        //        getCellListByTrayIdAddress.CellListRequest.processLot = "";//托盘号
        //        getCellListByTrayIdAddress.CellListRequest.mode = ND.CoreList.ModeTrayMatrix.COLUMNFIRST;
        //        getCellListByTrayIdResponseAddress = CellTestIntegrationServiceServiceAddress.getCellListByTrayId(getCellListByTrayIdAddress);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return getCellListByTrayIdResponseAddress;
        //}




        // 
        /// <summary>
        ///  WebService接口参数配置：获取托盘中电芯列表
        /// </summary>
        /// <param name="barcode">小车条形码</param>
        /// <param name="resource">资源号</param>
        /// <param name="door">门</param>
        /// <returns></returns>
        public static getCellListByTrayIdResponse ChargeNumberAddess( string barcode, string resource ,int door)
        {

            CellTestIntegrationServiceService cell = new CellTestIntegrationServiceService();
            getCellListByTrayIdResponse getCell = new getCellListByTrayIdResponse();
            try
            {
                cell.Url = ConfigureHelp.ElectricCoreMES_WSDL;//"http://172.26.11.3:50000/atlmeswebservice/CellTestIntegrationServiceService?wsdl";
                cell.Timeout = ConfigureHelp.ElectricCoreTimeOut;//超时时间
                cell.Credentials = new System.Net.NetworkCredential(ConfigureHelp.ElectricCoreUser, ConfigureHelp.ElectricCoretPassword, null); //Baiduhai7     //验证信息
                getCellListByTrayId getId = new getCellListByTrayId();

                cellListRequest cellListRequest = new cellListRequest();
                cellListRequest.site = ConfigureHelp.ElectricCoreSite;

                cellListRequest.processLot = barcode;//托盘号;
                cellListRequest.mode = ND.CoreList.ModeTrayMatrix.ROWFIRST;
                getId.CellListRequest = cellListRequest;
                getCell = cell.getCellListByTrayId(getId);
        }
            catch (Exception ex)
            {
                ConfigureHelp.SaveInfoToCSVFile( barcode, door.ToString(), resource, ex.Message);
                Common.Msg.Warning("MES返回报错:" + ex.Message);//返回信息   
            }
            return getCell;
        }
        /// <summary>
        /// WebService接口参数配置：高温静置收数（每次循环提交给MES）
        /// </summary>
        /// <param name="str">小车内所有的托盘号</param>
        /// <param name="processLot">小车条码号</param>
        /// <param name="door">炉门</param>
        /// <param name="Info">出站状态(10=已经入站运行，15=已经出站一个小车，20=已经出站两个小车，)</param>
        /// <param name="resource">设备资源号</param>
        /// <param name="time">运行的时间</param>
        /// <param name="wd">监控温度</param>
        public static miDataCollectForProcessLotForEachResponse ReceiveNumber( List<string> str, string processLot, string door,string Info,  string resource ,string  time ,string wd)
        {                            //  sfcArray数组
            dataCollectSfcParametricData dataCollData = new dataCollectSfcParametricData();
            dataCollectSfcParametricData[] DATA = new dataCollectSfcParametricData[] { dataCollData };

            //出站数组
            nonConfirmCodeArray ncc = new nonConfirmCodeArray();
            nonConfirmCodeArray[] nonAdd = new nonConfirmCodeArray[] { ncc };


            //ParametricDataArray库位号数组
            ND.ChargeNumber.machineIntegrationParametricData mach = new ND.ChargeNumber.machineIntegrationParametricData();

            //ParametricDataArray托盘号数组
            ND.ChargeNumber.machineIntegrationParametricData machPallet = new ND.ChargeNumber.machineIntegrationParametricData();

            //ParametricDataArray时间数组
          //  ND.ChargeNumber.machineIntegrationParametricData machTime = new ND.ChargeNumber.machineIntegrationParametricData();

            //ParametricDataArray时间数组
            ND.ChargeNumber.machineIntegrationParametricData SJ = new ND.ChargeNumber.machineIntegrationParametricData();
            ND.ChargeNumber.machineIntegrationParametricData WD = new ND.ChargeNumber.machineIntegrationParametricData();

            //数组

            dataCollectSfcParametricData sfcData = new dataCollectSfcParametricData();


            ND.ChargeNumber.machineIntegrationParametricData[] jo = new ND.ChargeNumber.machineIntegrationParametricData[] { mach, machPallet,  SJ , WD };


            miDataCollectForProcessLotForEachResponse receive = new miDataCollectForProcessLotForEachResponse();//返回数据接收

            try
            {

                MiDataCollectForProcessLotForEachServiceService MiDa = new MiDataCollectForProcessLotForEachServiceService();
                dataCollectForProcessLotForEachRequest dataColl = new dataCollectForProcessLotForEachRequest();

                miDataCollectForProcessLotForEach mh = new miDataCollectForProcessLotForEach();

                for (int i = 0; i < str.Count; i++)
                {
                    MiDa.Url = ConfigureHelp.hargeNumberMES_WSDL;//"http://ndmesd003.ATLbattery.com:50000/atlmeswebservice/MiDataCollectForProcessLotForEachServiceService";
                    MiDa.Timeout = ConfigureHelp.hargeNumberTimeOut;

                    MiDa.Credentials = new System.Net.NetworkCredential(ConfigureHelp.hargeNumberUser, ConfigureHelp.hargeNumberPassword, null); //Baiduhai7     //验证信息



                    dataColl.site = ConfigureHelp.hargeNumberSite;//ConfigureHelp.hargeNumberOperation;//站点
                    dataColl.processLot = processLot; //"PL0205005";//托盘号(小车)
                    dataColl.operation = ConfigureHelp.hargeNumberOperation;//"HSTDY1";//工位
                    dataColl.resource = resource; //"HTSX0001";//设备资源号
                    dataColl.modeProcessSfc = ModeProcessSfc.MODE_PASS_SFC_POST_DC;//过站模式


                    dataCollData.sfc = str[i];
                    dataCollData.dcGroup = ConfigureHelp.hargeNumberDcGroup;//"*";//dc采集组
                    dataCollData.dcGroupRevision = ConfigureHelp.hargeNumberDcGroupRevision;// "#";//dc采集组版号
                    // dataCollData.parametricDataArray

                    //数组
                    dataColl.sfcArray = DATA;


                    //出站数组
                    // 上传异常信息
                    ncc.hasNc = true;
                    ncc.ncCode = "success";//上传异常信息

                    mach.name = "HSTDBYSTATION";
                    mach.dataType = ND.ChargeNumber.ParameterDataType.TEXT;
                    mach.value = resource;// "HTSX0001";//高温静置库位号


                    machPallet.name = "HSTDBYTRAYID";
                    machPallet.dataType = ND.ChargeNumber.ParameterDataType.TEXT;
                    machPallet.value = processLot;//"PL0205005";//高温静置托盘号









                    //machTime.name = "HSTDBYTIME";
                    //machTime.dataType = ND.ChargeNumber.ParameterDataType.NUMBER;  
                    //machTime.value = time;//"30000";//高温静置时间









                    SJ.name = "STADCAPTIM";
                    SJ.dataType = ND.ChargeNumber.ParameterDataType.NUMBER;
                    SJ.value = time;

                    WD.name = "STATEM";
                    WD.dataType = ND.ChargeNumber.ParameterDataType.NUMBER;
                    WD.value = wd;//






                    //给定两个数组
                    // dataCollData.ncCodeArray = nonAdd;//ncCodeArray  数组
                    dataCollData.parametricDataArray = jo;

                    DateTime beginTime = DateTime.Now;
                    DateTime endTime = DateTime.Now;
                    TimeSpan timeS = new TimeSpan();
                    timeS = endTime - beginTime;
                    mh.DataCollectForProcessLotForEachRequest = dataColl;


                    receive = MiDa.miDataCollectForProcessLotForEach(mh);


                    //上传给接口信息保存(出站info)
                    ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                    string.Format("开始时间代码Error　[EndTime]( sfc(条码)：{0}、HSTDBYSTATION(库位号)数组：{1}、 HSTDBYTRAYID(托盘号)数组{2} 、 STADCAPTIM(时间)数组：{3}、STATEM(温度)数组：{4})",
                    str[i], resource, processLot, time, wd),
                  null+ "", null, 3);

                    if (receive.@return.code == 0)//不等于0时挑出记录
                    {

                        //写结束CSV文件
                        ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                        string.Format("开始时间代码Error　[EndTime]({0}、{1}、{2}、{3})", processLot, time, wd, resource),
                        receive.@return.code + "", receive.@return.message, 2);
                    }
                    else
                    {
                        if (receive.@return.resultArray.Length > 0)
                        {
                            string str1 = "";
                            foreach (var item in receive.@return.resultArray)//遍历数组
                            {
                                str1 = item.errorMessage;
                            }
                            //写错误CSV文件
                            ConfigureHelp.SaveInfoToCSVFileAtLog(beginTime.ToString("yyyy-MM-dd hh:mm:ss"), endTime.ToString("yyyy-MM-dd hh:mm:ss"), timeS.TotalMilliseconds.ToString(),
                            string.Format("开始时间代码Error　[EndTime]({0}、{1}、{2}、{3})", processLot, time, wd, resource),
                            receive.@return.code + "", str1, 2);
                        }
                    }
                   
                }
                OutAndInInfoHelp.PlcEndTime(Info, door);//出了几个小车写入数据库
            }   
            catch (Exception ex)
            {
                ConfigureHelp.SaveInfoToCSVFile(processLot, door.ToString(), resource, ex.Message);     //有错误发生写入日志         
            }
            return receive;
        }



        /// <summary>
        /// 电芯解绑
        /// </summary>
        /// <returns></returns>
        public static releaseTrayIdResponse ElectricCoreStrappedAddress()
        {
            releaseTrayIdResponse releaseTrayIdResponseAddress = new releaseTrayIdResponse();
            try
            {
                CellTestIntegrationServiceService CellTestIntegrationServiceServiceAddress = new CellTestIntegrationServiceService();
                releaseTrayId releaseTrayIdAddress = new releaseTrayId();
                releaseTrayIdAddress.ProcessLotReleaseRequest.site = "";//所在的站点
                releaseTrayIdResponseAddress = CellTestIntegrationServiceServiceAddress.releaseTrayId(releaseTrayIdAddress);
            }
            catch (Exception)
            {

                throw;
            }
            return releaseTrayIdResponseAddress;
        }
    }
}
