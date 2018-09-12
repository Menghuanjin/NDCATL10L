
using PLCSocket;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ND
{
    public class SocketSendHelp
    {

        private static Dictionary<string, Action> Dictionary = new Dictionary<string, Action>();
        /// <summary>
        /// 轮询查询时间数据
        /// </summary>
        public static void ThStartSend()
        {
            while (true)
            {
                InspectConnectAddress();
                Thread.Sleep(1000);
            }
        }
       /// <summary>
        /// 查询PLC连接状态
        /// </summary>
        private static void InspectConnectAddress()
        {
            try
            {
                if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, "%01#RCSR002A**")))
                {
                    PlcQueryHelp.PLC_QueryStatus(0);                  
                    PlcQueryHelp.BreakThread_one = true;
                    PlcQueryHelp.PLC_QueryTime(0);//查询PLC时间
                }
                else
                {
                    PlcQueryHelp.BreakThread_one = false;//1#PLC已经断线
                    s.socket = SocketHelper.tcpConn(Common.SySetHeip.Plc_ip.Trim(), 9094, 100);
                    SocketHelper.socketList[0].socket = s.socket;//从第零个重新代替一个新的socket连接    
                }
            }
            catch (Exception)//.异常重连
            {
                //PlcQueryHelp.BreakThread_one = false;//1#PLC已经断线
                //s.socket = SocketHelper.tcpConn(SySetHeip.Plc_ip.Trim(), 9094, 100);
                //SocketHelper.socketList[0].socket = s.socket;//从第零个重新代替一个新的socket连接    
            }
        }
        public static StocketInfo.StocketInfo s = new StocketInfo.StocketInfo();
    }
    }
