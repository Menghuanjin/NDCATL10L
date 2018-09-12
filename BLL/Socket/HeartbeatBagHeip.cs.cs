using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PLC_HeartbeatBagHeip
{
 /// <summary>
 /// 心跳包类
 /// </summary>
    public    class HeartbeatBagHeip
    {
        /// <summary>
        /// 制作PLC心跳包
        /// </summary>
        /// <param name="sk">连接的Ip</param>
        /// <param name="nullHeartbeatBag">包</param>
        public static bool HeartbeatBag( Socket sk,  string nullHeartbeatBag)
        {
            byte[] byHeartbeatBag = Encoding.ASCII.GetBytes(nullHeartbeatBag + "\r");//回车结尾
            bool SendInfo=HeartbeatBagSend(sk, byHeartbeatBag);
            return SendInfo;
        }
      public static  object LockObj = new object();

      public static List<string > HeartbeatBagError=new List<string>();//异常集合数
        /// <summary>
        /// 发送空包
        /// </summary>
        /// <param name="st">连接的Ip</param>
        /// <param name="address">包</param>
        /// <returns></returns>
      public static bool HeartbeatBagSend(Socket st, byte[] address)
        {
            string rev = "";
            bool HeartbeatBagBool = false;//判断是否返回true
            lock (LockObj)
            {
                try
                {
                    byte[] numArray = new byte[1024];
                    st.Send(address);//发送包
                    st.Receive(numArray);                  
                    rev = Encoding.ASCII.GetString(numArray).Replace("\0", "");
                    HeartbeatBagBool = true;//发送成功                   
                    if (rev.Contains("!"))//未读到了正确数据
                    {
                        rev = "";
                    }
                }
                catch(Exception ex)
                {
                    rev = "";
                    HeartbeatBagBool = false;//发送出现异常返回false
                }
            }
            return HeartbeatBagBool;
        }
      /// <summary>
      /// socket通讯断线重连连接
      /// </summary>
      /// <param name="IP"></param>
      /// <param name="port"></param>
      /// <returns></returns>
      public static Socket Reconnection_tcpConn(string IP, int port, int outTime)
      {
          IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), Convert.ToInt32(port));
          Socket clienSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          try
          {
              clienSocket.ReceiveTimeout = outTime;
              clienSocket.Connect((EndPoint)ipEndPoint);
          }
          catch (Exception )
          {           
              //Console.Write((object)ex);
          }
          return clienSocket;
      }
    }
}
