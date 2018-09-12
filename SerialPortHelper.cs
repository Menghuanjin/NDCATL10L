using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using ND6L;
using ND;
using Common;

namespace SerialPortHelper
{
    /// <summary>
    /// 串口开发辅助类
    /// </summary>
    public class SerialPortHelper
    {
        /// <summary>
        /// 接收事件是否有效 false表示有效
        /// </summary>
        public static bool ReceiveEventFlag = false;
        /// <summary>
        /// 结束符比特
        /// </summary>
        public static byte EndByte = 0x23;//string End = "#";

        /// <summary>
        /// 返回炉门条码
        /// </summary>
        public static string DoorBarCode { get; set; }
        /// <summary>
        /// 返回小车条码
        /// </summary>
        public static string SedanBarCode  { get; set; }

        /// <summary>
        /// 完整协议的记录处理事件
        /// </summary>
        public static event DataReceivedEventHandler DataReceived;
        public static event SerialErrorReceivedEventHandler Error;


        #region 变量属性
        public static string _portName = SySetHeip.Comaddress;//串口号，默认COM1
        public static SerialPortBaudRates _baudRate = SerialPortBaudRates.BaudRate_115200;//波特率
        public static Parity _parity = Parity.None;//校验位
        public static StopBits _stopBits = StopBits.One;//停止位
        public static SerialPortDatabits _dataBits = SerialPortDatabits.EightBits;//数据位

        public static SerialPort comPort = new SerialPort();


        /// <summary>
        /// 串口号
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }


        /// <summary>
        /// 波特率
        /// </summary>
        public SerialPortBaudRates BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }


        /// <summary>
        /// 奇偶校验位
        /// </summary>
        public Parity Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }


        /// <summary>
        /// 数据位
        /// </summary>
        public SerialPortDatabits DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }


        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }


        #endregion


        #region 构造函数


        /// <summary>
        /// 参数构造函数（使用枚举参数构造）
        /// </summary>
        /// <param name="baud">波特率</param>
        /// <param name="par">奇偶校验位</param>
        /// <param name="sBits">停止位</param>
        /// <param name="dBits">数据位</param>
        /// <param name="name">串口号</param>
        public SerialPortHelper(string name, SerialPortBaudRates baud, Parity par, SerialPortDatabits dBits, StopBits sBits)
        {
            _portName = name;
            _baudRate = baud;
            _parity = par;
            _dataBits = dBits;
            _stopBits = sBits;


            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }


        /// <summary>
        /// 参数构造函数（使用字符串参数构造）
        /// </summary>
        /// <param name="baud">波特率</param>
        /// <param name="par">奇偶校验位</param>
        /// <param name="sBits">停止位</param>
        /// <param name="dBits">数据位</param>
        /// <param name="name">串口号</param>
        public SerialPortHelper(string name, string baud, string par, string dBits, string sBits)
        {
            _portName = name;
            _baudRate = (SerialPortBaudRates)Enum.Parse(typeof(SerialPortBaudRates), baud);
            _parity = (Parity)Enum.Parse(typeof(Parity), par);
            _dataBits = (SerialPortDatabits)Enum.Parse(typeof(SerialPortDatabits), dBits);
            _stopBits = (StopBits)Enum.Parse(typeof(StopBits), sBits);


            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }


        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SerialPortHelper()
        {
            _portName = "COM1";
            _baudRate = SerialPortBaudRates.BaudRate_9600;
            _parity = Parity.None;
            _dataBits = SerialPortDatabits.EightBits;
            _stopBits = StopBits.One;


            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }


        #endregion


        /// <summary>
        /// 端口是否已经打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return comPort.IsOpen;
            }
        }


        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns></returns>
        public static  void OpenPort()
        {
            try
            {
                if (comPort.IsOpen) comPort.Close();
                comPort.PortName = _portName;
                comPort.BaudRate = (int)_baudRate;
                comPort.Parity = _parity;
                comPort.DataBits = (int)_dataBits;
                comPort.StopBits = _stopBits;
                comPort.Open();
                comPort.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                comPort.Close();
            }
        
        }


        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePort()
        {
            if (comPort.IsOpen) comPort.Close();
        }


        /// <summary>
        /// 丢弃来自串行驱动程序的接收和发送缓冲区的数据
        /// </summary>
        public void DiscardBuffer()
        {
            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();
        }

        /// <summary>
        /// 数据返回处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void ComDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        private  static  void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
            Thread.Sleep(300);
            byte[] ReDatas = new byte[comPort.BytesToRead];//返回命令包
            comPort.Read(ReDatas, 0, ReDatas.Length);//读取数据   
            //16进制显示
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ReDatas.Length; i++)
            {
                sb.AppendFormat("{0:x2}" + " ", ReDatas[i]);
            }
            UpdateRecevie(sb.ToString().ToUpper());//返回条码处理
        }
        /// <summary>
        /// 霍尼韦尼扫码返回  例如炉门41 67 69 6E 67 30 30 34 0D (30 30 34为有效数字)
        /// </summary>
        /// <param name="NewData"></param>
        /// <returns></returns>
        private  static void UpdateRecevie(string NewData)
        {           
            string Value = "";
            string ValueAddress = "";
            int Address = 0;
            NewData = NewData.Replace(" ", "");//剔除空格
            try
            {
                if (NewData.Length == 18)//当前扫码到的值为炉门号41 67 69 6E 67 30 30 34 0D 
                {
                    Value = InterceptStringHelp.ExtractString(NewData, 10, 6);
                    for (int i = 0; i < Value.Length / 2; i++)
                    {
                        Address = PLCSocket.DecimalConversion.HexToTen(NewData.Substring(10 + (i * 2), 2));// 十六进制转10进制
                        ValueAddress += ((char)Address).ToString();// 十进制转acsii码
                    }
                    delegateAddress fc = new delegateAddress(DoorBarCodeAddress);
                    ControlHelp.ControlHelp.Resource.Invoke(fc, SySetHeip.Prefix.Trim() + ValueAddress); //通过代理调用刷新方法                         
                }
                if (NewData.Length == 14)//当前扫码到的值为小车号  小车条码号4C31303031320D
                {
                    Value = InterceptStringHelp.ExtractString(NewData, 6, 6); ;
                    for (int i = 0; i < Value.Length / 2; i++)
                    {
                        Address = PLCSocket.DecimalConversion.HexToTen(NewData.Substring(6 + (i * 2), 2));// 十六进制转10进制
                        ValueAddress += ((char)Address).ToString();// 十进制转acsii码
                    }
                    SedanBarCode = SySetHeip.Prefix.Trim() + ValueAddress;
                    delegateAddress fc = new delegateAddress(Voluation);
                    ControlHelp.ControlHelp.BarCode1.Invoke(fc, SySetHeip.Prefix.Trim() + ValueAddress); //通过代理调用刷新方法
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}

        }
        private delegate void  delegateAddress(string str);
        /// <summary>
        /// 控件赋值
        /// </summary>
        /// <param name="Voluation"></param>
        private static void Voluation(string Voluation)
        {        
            if (string.IsNullOrEmpty(ControlHelp.ControlHelp.BarCode1.Text))
            {
                ControlHelp.ControlHelp.BarCode1.Text = Voluation;
                Voluation = "";
            }
            else 
            {
                ControlHelp.ControlHelp.BarCode2.Text = Voluation;
                Voluation = "";
            }
            if (ControlHelp.ControlHelp.BarCode1.Text == ControlHelp.ControlHelp.BarCode2.Text)
            {
                Common.Msg.Warning("不能绑定两个相同的条码");
                ControlHelp.ControlHelp.BarCode2.Text = "";
            }
        }
        /// <summary>
        /// 扫码枪扫炉门号，自动选择该炉门号
        /// </summary>
        /// <param name="str"></param>
        public static void DoorBarCodeAddress(string str)
        {
            ControlHelp.ControlHelp.Resource.Text = str;
            switch (str)
            {
                case "L10001":
                    DictionaryHelp.Dictionary["Operater1"]();
                    break;
                case "L10002":
                    DictionaryHelp.Dictionary["Operater2"]();
                    break;
                case "L10003":
                    DictionaryHelp.Dictionary["Operater3"]();
                    break;
                case "L10004":
                    DictionaryHelp.Dictionary["Operater4"]();
                    break;
                case "L10005":
                    DictionaryHelp.Dictionary["Operater5"]();
                    break;
                case "L10006":
                    DictionaryHelp.Dictionary["Operater6"]();
                    break;
                case "L10007":
                    DictionaryHelp.Dictionary["Operater7"]();
                    break;
                case "L10008":
                    DictionaryHelp.Dictionary["Operater8"]();
                    break;
                default:
                    break;
            }


        }
        /// <summary>
        /// 数据接收处理
        /// </summary>
        public static   void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //禁止接收事件时直接退出
            if (ReceiveEventFlag) return;
            #region 根据结束字节来判断是否全部获取完成
            List<byte> _byteData = new List<byte>();
            bool found = false;//是否检测到结束符号
            while (comPort.BytesToRead > 0 || !found)
            {
                byte[] readBuffer = new byte[comPort.ReadBufferSize + 1];
                int count = comPort.Read(readBuffer, 0, comPort.ReadBufferSize);
                for (int i = 0; i < count; i++)
                {
                    _byteData.Add(readBuffer[i]);


                    if (readBuffer[i] == EndByte)
                    {
                        found = true;
                    }
                }
            }
            #endregion

            //字符转换
            string readString = System.Text.Encoding.Default.GetString(_byteData.ToArray(), 0, _byteData.Count);

            //触发整条记录的处理
            if (DataReceived != null)
            {
                DataReceived(new DataReceivedEventArgs(readString));
            }
        }


        /// <summary>
        /// 错误处理函数
        /// </summary>
        void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (Error != null)
            {
                Error(sender, e);
            }
        }


        #region 数据写入操作


        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="msg"></param>
        public void WriteData(string msg)
        {
            if (!(comPort.IsOpen)) comPort.Open();


            comPort.Write(msg);
        }


        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="msg">写入端口的字节数组</param>
        public void WriteData(byte[] msg)
        {
            if (!(comPort.IsOpen)) comPort.Open();


            comPort.Write(msg, 0, msg.Length);
        }


        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="msg">包含要写入端口的字节数组</param>
        /// <param name="offset">参数从0字节开始的字节偏移量</param>
        /// <param name="count">要写入的字节数</param>
        public void WriteData(byte[] msg, int offset, int count)
        {
            if (!(comPort.IsOpen)) comPort.Open();


            comPort.Write(msg, offset, count);
        }


        /// <summary>
        /// 发送串口命令
        /// </summary>
        /// <param name="SendData">发送数据</param>
        /// <param name="ReceiveData">接收数据</param>
        /// <param name="Overtime">重复次数</param>
        /// <returns></returns>
        public int SendCommand(byte[] SendData, ref  byte[] ReceiveData, int Overtime)
        {
            if (!(comPort.IsOpen)) comPort.Open();


            ReceiveEventFlag = true;        //关闭接收事件
            comPort.DiscardInBuffer();      //清空接收缓冲区                 
            comPort.Write(SendData, 0, SendData.Length);

            int num = 0, ret = 0;
            while (num++ < Overtime)
            {
                if (comPort.BytesToRead >= ReceiveData.Length) break;
                System.Threading.Thread.Sleep(1);
            }


            if (comPort.BytesToRead >= ReceiveData.Length)
            {
                ret = comPort.Read(ReceiveData, 0, ReceiveData.Length);
            }


            ReceiveEventFlag = false;       //打开事件
            return ret;
        }


        #endregion


        #region 常用的列表数据获取和绑定操作


        /// <summary>
        /// 封装获取串口号列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }


        /// <summary>
        /// 设置串口号
        /// </summary>
        /// <param name="obj"></param>
        public static void SetPortNameValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                obj.Items.Add(str);
            }
        }


        /// <summary>
        /// 设置波特率
        /// </summary>
        public static void SetBauRateValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (SerialPortBaudRates rate in Enum.GetValues(typeof(SerialPortBaudRates)))
            {
                obj.Items.Add(((int)rate).ToString());
            }
        }


        /// <summary>
        /// 设置数据位
        /// </summary>
        public static void SetDataBitsValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (SerialPortDatabits databit in Enum.GetValues(typeof(SerialPortDatabits)))
            {
                obj.Items.Add(((int)databit).ToString());
            }
        }


        /// <summary>
        /// 设置校验位列表
        /// </summary>
        public static void SetParityValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                obj.Items.Add(str);
            }
            //foreach (Parity party in Enum.GetValues(typeof(Parity)))
            //{
            //    obj.Items.Add(((int)party).ToString());
            //}
        }


        /// <summary>
        /// 设置停止位
        /// </summary>
        public static void SetStopBitValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                obj.Items.Add(str);
            }
            //foreach (StopBits stopbit in Enum.GetValues(typeof(StopBits)))
            //{
            //    obj.Items.Add(((int)stopbit).ToString());
            //}   
        }


        #endregion


        #region 格式转换
        /// <summary>
        /// 转换十六进制字符串到字节数组
        /// </summary>
        /// <param name="msg">待转换字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");//移除空格


            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                //convert each set of 2 characters to a byte and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            }


            return comBuffer;
        }


        /// <summary>
        /// 转换字节数组到十六进制字符串
        /// </summary>
        /// <param name="comByte">待转换字节数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ByteToHex(byte[] comByte)
        {
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            foreach (byte data in comByte)
            {
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            }


            return builder.ToString().ToUpper();
        }
        #endregion


        /// <summary>
        /// 检查端口名称是否存在
        /// </summary>
        /// <param name="port_name"></param>
        /// <returns></returns>
        public static bool Exists(string port_name)
        {
            foreach (string port in SerialPort.GetPortNames()) if (port == port_name) return true;
            return false;
        }


        /// <summary>
        /// 格式化端口相关属性
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string Format(SerialPort port)
        {
            return String.Format("{0} ({1},{2},{3},{4},{5})",
                port.PortName, port.BaudRate, port.DataBits, port.StopBits, port.Parity, port.Handshake);
        }
    }


    public class DataReceivedEventArgs : EventArgs
    {
        public string DataReceived;
        public DataReceivedEventArgs(string m_DataReceived)
        {
            this.DataReceived = m_DataReceived;
        }
    }


    public delegate void DataReceivedEventHandler(DataReceivedEventArgs e);




    /// <summary>
    /// 串口数据位列表（5,6,7,8）
    /// </summary>
    public enum SerialPortDatabits : int
    {
        FiveBits = 5,
        SixBits = 6,
        SeventBits = 7,
        EightBits = 8
    }


    /// <summary>
    /// 串口波特率列表。
    /// 75,110,150,300,600,1200,2400,4800,9600,14400,19200,28800,38400,56000,57600,
    /// 115200,128000,230400,256000
    /// </summary>
    public enum SerialPortBaudRates : int
    {
        BaudRate_75 = 75,
        BaudRate_110 = 110,
        BaudRate_150 = 150,
        BaudRate_300 = 300,
        BaudRate_600 = 600,
        BaudRate_1200 = 1200,
        BaudRate_2400 = 2400,
        BaudRate_4800 = 4800,
        BaudRate_9600 = 9600,
        BaudRate_14400 = 14400,
        BaudRate_19200 = 19200,
        BaudRate_28800 = 28800,
        BaudRate_38400 = 38400,
        BaudRate_56000 = 56000,
        BaudRate_57600 = 57600,
        BaudRate_115200 = 115200,
        BaudRate_128000 = 128000,
        BaudRate_230400 = 230400,
        BaudRate_256000 = 256000
    }
}