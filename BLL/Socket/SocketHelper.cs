using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PLCSocket
{
    public class SocketHelper
    {
        public static List<StocketInfo.StocketInfo> socketList = new List<StocketInfo.StocketInfo>();
        public static bool IsCoon { get; set; }

        /// <summary>
        /// socket通讯连接
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Socket tcpConn(string IP, int port, int outTime)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), Convert.ToInt32(port));
            Socket clienSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clienSocket.ReceiveTimeout = outTime;
                clienSocket.Connect((EndPoint)ipEndPoint);
                IsCoon = true;            
            }
            catch (Exception )
            {
                //Console.Write((object)ex);
            }
            return clienSocket;
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        private static readonly object Locker1 = new object();
        public static string SendAddress(Socket st, string address)
        {
            string rev = "";
            lock (Locker1)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(address + "\r");
                    byte[] numArray = new byte[1024];
                    st.Send(bytes);
                    Thread.Sleep(100);
                    st.Receive(numArray);               
                    rev = Encoding.ASCII.GetString(numArray).Replace("\0", "");
                    if (rev.Contains("!"))//未读到了正确数据
                    {
                        rev = "";
                    }
                }
                catch
                {
                    rev = "";
                }
            }
            return rev;
        }
    }
}
