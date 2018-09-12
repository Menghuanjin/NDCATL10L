using Common;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InterfaceHelp;
using ND;
using ND.CoreList;
using ND.PattelCheck;
using PLCSocket;
using SerialPortHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ND6L
{
    public partial class SuperiorLimit : Form
    {
        public SuperiorLimit()
        {
            InitializeComponent();
        }
        public static string _portName = SySetHeip.Comaddress;//串口号，默认COM1
        public static SerialPortBaudRates _baudRate = SerialPortBaudRates.BaudRate_115200;//波特率
        public static Parity _parity = Parity.None;//校验位
        public static StopBits _stopBits = StopBits.One;//停止位
        public static SerialPortDatabits _dataBits = SerialPortDatabits.EightBits;//数据位
        private delegate void InitializtionInfo();//初始化委托
        private delegate void Entrust();//炉门操作委托
        private delegate void DelegateUpMes();
        private delegate void BarCode(string BarCode,string BarCode2);//将扫到的小车条形码，调接口，返回小车内绑定的所有托盘
        private delegate void EndOperate();//机器运行完成时，将小车内的托盘调接口出站
        private delegate void SerialPor();//串口操作委托
        public static string OperaterInfo = "One";//操作门号
        private bool UpMes = false;
        DictionaryHelp DictionaryHelp = new DictionaryHelp();//字典类初始化


        private Dictionary<string, Action> Dictionary = new Dictionary<string, Action>();//控件字典
        public int OperateAddress { get; set; }
        private void frm_Machine_Load(object sender, EventArgs e)
        {

            BarCode1.ReadOnly = true;
            BarCode2.ReadOnly = true;
            Thread th = new Thread(new ThreadStart(ExecuteEntrust));
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// MES接口自检
        /// </summary>
        private void Initializtion()
        {
            ControlHelp.ControlHelp.listBoxAddress = listBox;
            listBox = ControlHelp.ControlHelp.listBoxAddress;
            ControlHelp.ControlHelp.BarCode1 = BarCode1; ;
            ControlHelp.ControlHelp.BarCode2 = BarCode2;
            ControlHelp.ControlHelp.Resource = Resource;
            ControlHelp.ControlHelp.Operate = OperateShow;
            OpenCom();
            Dictionaryloading();
            LoadingControl();
            DictionaryHelp.Dictionary["Operater1"]();
        }
        /// <summary>
        /// 打开扫描枪端口
        /// </summary>
        private void OpenCom()
        {
            //打开串口
            if (comPort.IsOpen) comPort.Close();
            comPort.PortName = _portName;
            comPort.BaudRate = (int)_baudRate;
            comPort.Parity = _parity;
            comPort.DataBits = (int)_dataBits;
            comPort.StopBits = _stopBits;
            comPort.Open();
        }
        /// <summary>
        /// 加载字典
        /// </summary>
        private void Dictionaryloading()
        {
            Dictionary.Add("ReflexOne", ReflexOne); Dictionary.Add("ReflexTwo", RefleTwo);

            Dictionary.Add("ReflexThree", RefleThree); Dictionary.Add("ReflexFour", RefleFour);

            Dictionary.Add("ReflexFive", RefleFive); Dictionary.Add("ReflexSix", RefleSix);

            Dictionary.Add("ReflexSeven", RefleSeven); Dictionary.Add("ReflexEight", ORefleEight);

            DictionaryHelp.InitializtionErrorDictionary();
        }
        /// <summary>
        /// 加载控件
        /// </summary>
        private void LoadingControl()
        {
            for (int i = 0; i < 8; i++)
            {
                Button Butt = new Button();

                Butt.Name = "Operater" + (i + 1);

                Butt.Text = "操作" + (i + 1) + "号炉门";

                Butt.Size = new Size(127, 25);//设定位置

                Butt.Location = new Point(5, 25);
                Butt.Top = 40 + i * 50;

                Butt.BackColor = Color.PaleTurquoise;
                //添加控件
                groupBox1.Controls.Add(Butt);

                Butt.Click += new EventHandler(OperaterAddress_Click);
            }
        }
        /// <summary>
        /// 操作门号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperaterAddress_Click(object sender, EventArgs e)
        {
            Button Value = (Button)sender;
            DictionaryHelp.Dictionary[Value.Name]();
        }
        private void ExecuteEntrust()
        {
            try
            {
                Thread.Sleep(100);
                Invoke(new InitializtionInfo(Initializtion), new object[] { });
                while (true)
                {
                    ExecuteEntrustAddress();
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Common.Msg.Warning(ex.Message);
            }

        }
        private void ExecuteEntrustAddress()
        {
            try
            {
                BLL.DataGather.WriteSqlInfo();

                Invoke(new Entrust(DictionaryAddress), new object[] { });

                Invoke(new SerialPor(SerialPortConnect), new object[] { });
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 查询连接状态 例如串口
        /// </summary>
        void SerialPortConnect()
        {
            if (comPort.IsOpen)
            {
                SerialPort.Image = ND.Properties.Resources.greenlight;

                SerialPortInfo.Text = SySetHeip.Comaddress.Trim() + "扫码枪打开成功";
            }
            else
            {
                SerialPort.Image = ND.Properties.Resources.redlight;//显示红色灯    
                          
                SerialPortInfo.Text = SySetHeip.Comaddress.Trim() + "扫码枪打开失败";
            }
        }

        /// <summary>
        /// 更新显示窗体控件属性
        /// </summary>
        private void DictionaryAddress()
        {
            try
            {
                Dictionary["Reflex" + OperaterInfo]();
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 报警消除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtError_Click(object sender, EventArgs e)
        {
            try
            {
                DictionaryHelp.Dictionary["Error" + OperaterInfo]();
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 联机启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butTstart_Click(object sender, EventArgs e)
        {
            //FlushClient
            ////nvoke(new DelegateUpMes(MESandStart), new object[] { });
            if (!string.IsNullOrEmpty(this.BarCode1.Text) && !string.IsNullOrEmpty(this.BarCode2.Text))
            {
                if (this.BarCode1.Text != this.BarCode2.Text)
                {
                    new Thread(() =>
            {
                ControlHelp.ControlHelp.listBoxAddress.BeginInvoke(new MethodInvoker(() => MESandStar1()));

            })
                    { IsBackground = true }.Start();
                }
                else
                    Common.Msg.Warning("不能绑定两个相同的条码");
            }
        }
         
        private void MESandStar1()
        {
            try
            {
                //cquisitionElectricCoreHelp.MESSelectRun(this.BarCode1.Text, this.BarCode2.Text);
                Invoke(new BarCode(AcquisitionElectricCoreHelp.MESSelectRun), new object[] { this.BarCode1.Text, this.BarCode2.Text });
            }
            catch (Exception) { }

        }
        /// <summary>
        /// 停止指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttStop_Click(object sender, EventArgs e)
        {
            try
            {
                DictionaryHelp.Dictionary["Stop" + OperaterInfo]();
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 照明指令开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttLightingOpen_Click(object sender, EventArgs e)
        {
            try
            {
                DictionaryHelp.Dictionary["LightingOpen" + OperaterInfo]();
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 照明关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttLightingClose_Click(object sender, EventArgs e)
        {
            try
            {
                DictionaryHelp.Dictionary["LightingClose" + OperaterInfo]();
            }
            catch (Exception) { }

        }
        /// <summary>
        /// 1门控件赋值
        /// </summary>
        private void ReflexOne()
        {

            ConstantTemperature.Text = PlcQueryHelp.ConstantTime1.ToString();

            for (int i = 0; i < PlcQueryHelp.listAddressTime1.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];

                C.Text = PlcQueryHelp.listAddressTime1[i].ToString("0.0");

            }
            for (int i = 0; i < PlcQueryHelp.BitStatus1.Length; i++)
            {
                if (PlcQueryHelp.BitStatus1[i])
                {

                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];

                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯

                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];

                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 2门控件赋值
        /// </summary>
        private void RefleTwo()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime2.ToString();

            for (int i = 0; i < PlcQueryHelp.listAddressTime2.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];

                C.Text = PlcQueryHelp.listAddressTime2[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus2.Length; i++)
            {
                if (PlcQueryHelp.BitStatus2[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];

                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];

                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 3门控件赋值
        /// </summary>
        private void RefleThree()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime3.ToString();
            for (int i = 0; i < PlcQueryHelp.listAddressTime3.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];
                C.Text = PlcQueryHelp.listAddressTime3[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus3.Length; i++)
            {
                if (PlcQueryHelp.BitStatus3[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 4门控件赋值
        /// </summary>
        private void RefleFour()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime4.ToString();
            for (int i = 0; i < PlcQueryHelp.listAddressTime4.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];
                C.Text = PlcQueryHelp.listAddressTime4[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus4.Length; i++)
            {
                if (PlcQueryHelp.BitStatus4[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 5门控件赋值
        /// </summary>
        private void RefleFive()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime5.ToString();
            for (int i = 0; i < PlcQueryHelp.listAddressTime5.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];
                C.Text = PlcQueryHelp.listAddressTime5[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus5.Length; i++)
            {
                if (PlcQueryHelp.BitStatus5[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 6门控件赋值
        /// </summary>
        private void RefleSix()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime6.ToString();
            for (int i = 0; i < PlcQueryHelp.listAddressTime6.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];
                C.Text = PlcQueryHelp.listAddressTime6[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus6.Length; i++)
            {
                if (PlcQueryHelp.BitStatus6[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 7门控件赋值
        /// </summary>
        private void RefleSeven()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime7.ToString();
            for (int i = 0; i < PlcQueryHelp.listAddressTime7.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];
                C.Text = PlcQueryHelp.listAddressTime7[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus7.Length; i++)
            {
                if (PlcQueryHelp.BitStatus7[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        /// <summary>
        /// 8门控件赋值
        /// </summary>
        private void ORefleEight()
        {
            ConstantTemperature.Text = PlcQueryHelp.ConstantTime8.ToString();
            for (int i = 0; i < PlcQueryHelp.listAddressTime8.Length; i++)
            {
                TextBoxX C = (TextBoxX)this.Controls.Find("TextBox" + (i + 1), true)[0];
                C.Text = PlcQueryHelp.listAddressTime8[i].ToString("0.0");
            }
            for (int i = 0; i < PlcQueryHelp.BitStatus8.Length; i++)
            {
                if (PlcQueryHelp.BitStatus8[i])
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                }
                else
                {
                    PictureBox C = (PictureBox)this.Controls.Find("lamp" + (i + 1), true)[0];
                    C.Image = ND.Properties.Resources.redlight;//显示红色灯
                }
            }
        }
        private void buttPurge_Click(object sender, EventArgs e)
        {
            BarCode1.Text = "";
        }
        private void Reset2Code_Click(object sender, EventArgs e)
        {
            BarCode2.Text = "";
        }
        /// <summary>
        /// 从串口中接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
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
        public delegate void UpdateString(string NewData);//委托
        public void UpdateReceiveCount(object NewCount)
        {
            if (this.InvokeRequired)//等待异步
            {
                UpdateString _myInvoke = new UpdateString(UpdateReceiveCount);
                this.Invoke(_myInvoke, new object[] { NewCount });
            }
        }
        /// <summary>
        ///  霍尼韦尼扫码返回  例如炉门41 67 69 6E 67 30 30 34 0D (30 30 34为有效数字)
        /// </summary>
        /// <param name="NewData"></param>
        public void UpdateRecevie(string NewData)
        {
            string Value = "";
            string ValueAddress = "";
            int Address = 0;
            if (this.InvokeRequired)//等待异步
            {
                UpdateString _myInvoke = new UpdateString(UpdateRecevie);
                this.Invoke(_myInvoke, new object[] { NewData });
            }
            else
            {
                NewData = NewData.Replace(" ", "");//剔除空格
                if (NewData.Length == 18)//当前扫码到的值为炉门号41 67 69 6E 67 30 30 34 0D 
                {
                    Value = InterceptStringHelp.ExtractString(NewData, 10, 6);
                    for (int i = 0; i < Value.Length / 2; i++)
                    {
                        Address = DecimalConversion.HexToTen(NewData.Substring(10 + (i * 2), 2));// 十六进制转10进制
                        ValueAddress += ((char)Address).ToString();// 十进制转acsii码
                    }
                    if (SySetHeip.Prefix.Trim() + ValueAddress == "L10001")//扫到哪一个炉门，自动选择该门
                    {
                        OperateShow.Text = "当前1号门操作";
                        DictionaryHelp.Dictionary["Operater1"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10002")
                    {
                        OperateShow.Text = "当前2号门操作";
                        DictionaryHelp.Dictionary["Operater2"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10003")
                    {
                        OperateShow.Text = "当前3号门操作";
                        DictionaryHelp.Dictionary["Operater3"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10004")
                    {
                        OperateShow.Text = "当前4号门操作";
                        DictionaryHelp.Dictionary["Operater4"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10005")
                    {
                        OperateShow.Text = "当前5号门操作";
                        DictionaryHelp.Dictionary["Operater5"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10006")
                    {
                        OperateShow.Text = "当前6号门操作";
                        DictionaryHelp.Dictionary["Operater6"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10007")
                    {
                        OperateShow.Text = "当前7号门操作";
                        DictionaryHelp.Dictionary["Operater7"]();
                    }
                    else if (SySetHeip.Prefix.Trim() + ValueAddress == "L10008")
                    {
                        OperateShow.Text = "当前8号门操作";
                        DictionaryHelp.Dictionary["Operater8"]();
                    }
                }
                if (NewData.Length == 14)//当前扫码到的值为小车号  小车条码号4C31303031320D
                {
                    Value = InterceptStringHelp.ExtractString(NewData, 6, 6); ;
                    for (int i = 0; i < Value.Length / 2; i++)
                    {
                        Address = DecimalConversion.HexToTen(NewData.Substring(6 + (i * 2), 2));// 十六进制转10进制
                        ValueAddress += ((char)Address).ToString();// 十进制转acsii码
                    }
                    if (!string.IsNullOrEmpty(BarCode1.Text) && !string.IsNullOrEmpty(BarCode2.Text))
                    {
                        BarCode1.Text = "";
                        BarCode2.Text = "";
                    }
                    if (string.IsNullOrEmpty(BarCode1.Text))
                    {
                        BarCode1.Text = SySetHeip.Prefix.Trim()+ ValueAddress;
                        ValueAddress = "";
                    }
                    else
                    {
                        BarCode2.Text = SySetHeip.Prefix.Trim() + ValueAddress;
                        ValueAddress = "";
                    }
                    if (BarCode1.Text == BarCode2.Text)
                    {
                        Common.Msg.Warning("不能绑定两个相同的条码");
                        BarCode2.Text = "";
                    }

                }
            }
        }


    }
}
