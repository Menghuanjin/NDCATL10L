using System;
using System.Reflection;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;
using ND;
using System.Diagnostics;
using Common;
using ND10L;
using System.Data;

namespace ND6L
{
    public partial class frm_Authoring : Form
    {
        public frm_Authoring()
        {
            InitializeComponent();      
            MyMessager msg = new MyMessager();
            Application.AddMessageFilter(msg);
        }
        private delegate void delegateInfo();
        private delegate void delegateCancellation();
        private delegate void AuthorityAddress();
        static int iOperCount = 0;
        /// <summary>
        /// 检测到有鼠标或则键盘的消息    没有就超过多长时间后注销用户
        /// </summary>
        internal class MyMessager : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                //如果检测到有鼠标或则键盘的消息，则使计数为0.....  
                if (m.Msg == 0x0200 || m.Msg == 0x0201 || m.Msg == 0x0204 || m.Msg == 0x0207)
                {
                    iOperCount = 0;
                }
                return false;
            }
        }
        /// <summary>
        /// 创建或者显示一个多文档界面页面
        /// </summary>
        /// <param name="caption">窗体标题</param>
        /// <param name="formType">窗体类型</param>
        public void SetMdiForm(string caption, Form form)
        {
            bool IsOpened = false;

            //遍历现有的Tab页面，如果存在，那么设置为选中即可
            foreach (SuperTabItem tabitem in NavTabControl1.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    NavTabControl1.SelectedTab = tabitem;
                    IsOpened = true;
                    break;
                }
            }
            //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
            if (!IsOpened)
            {
                SuperTabItem tabItem = NavTabControl1.CreateTab(caption);
                tabItem.Name = caption;
                tabItem.Text = caption;
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                //tabItem.Icon = form.Icon;
                tabItem.AttachedControl.Controls.Add(form);
                NavTabControl1.SelectedTab = tabItem;
            }
        }
        private void frm_Authoring_Load(object sender, EventArgs e)
        {        
            //// 运行线程，当有数据写入数据库时，使用
            Thread th1 = new Thread(new ThreadStart(SocketSendHelp.ThStartSend));//轮询查询时间
            th1.IsBackground = true;
            th1.Start();


            Thread th2 = new Thread(new ThreadStart(OutInfo));//出站操作
            th2.IsBackground = true;
           th2.Start();


            Thread th3 = new Thread(new ThreadStart(ThreadInvo));//查询PLC连接状态
            th3.IsBackground = true;
            th3.Start();


            Thread th4 = new Thread(new ThreadStart(CsvDataTableHelp.PaeserveCSV));//保存CSV文件
            th4.IsBackground = true;
            th4.Start();      
        }
        private void OutInfo()
        {
            string sql = string.Format(@"SELECT OutTem,OutTime FROM [dbo.tb_RnuInfo] ");
            DataTable dt = SqlServerHelp.DtQuery(sql).Tables[0];

            string[] timeList = new string[]
            {
                OutAndInInfoHelp.time1,
                  OutAndInInfoHelp.time2,
                      OutAndInInfoHelp.time3,
                          OutAndInInfoHelp.time4,
                              OutAndInInfoHelp.time5,
                                 OutAndInInfoHelp.time6,
                                    OutAndInInfoHelp.time7,
                                      OutAndInInfoHelp.time8,
            };
            for (int i = 0; i < timeList.Length; i++)
            {
                timeList[i] = dt.Rows[i]["OutTem"].ToString();
            }
            while (true)
            {
                OutAndInInfoHelp.StopTimeAddress();//完成时，调用接口

                Thread.Sleep(5000);
            }
        }

        private void ThreadInvo()
        {
            AcquisitionElectricCoreHelp.CheckupMES();
            while (IsHandleCreated)
            {
                Invoke(new AuthorityAddress(QueryAuthority), new object[] { });//当前登录用户

                Invoke(new delegateInfo(PlctConnect), new object[] { });//查询PLC连接状态


                Invoke(new delegateCancellation(Cancellation), new object[] { });//监控键盘跟鼠标消息

                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// 监控键盘跟鼠标消息
        /// </summary>
        private void Cancellation()
        {
            iOperCount++;
            if (iOperCount > (int.Parse(SySetHeip.Cancellation)))//超过多长时间没有操作，自动注销用户
            {
                iOperCount = 0;
                SySetHeip.Admin = false;
                SySetHeip.Operate=true;
                SySetHeip.Engineer = false;
                SySetHeip.LoginInfo = "操作员";
            }
        }
        /// <summary>
        /// 刷新查询现在登录的用户
        /// </summary>
        private void QueryAuthority()
        {
            if (SySetHeip.Admin)
            {
                Authority.Enabled = true; Run.Enabled = true;
                Query.Enabled = true; ErrorMessge.Enabled = true;
                SySet.Enabled = true; Upload.Enabled = true;
                Time.Enabled = true; Resource.Enabled = true;
            }
            if (SySetHeip.Operate)
            {
                Authority.Enabled = false; SySet.Enabled = false;
                Upload.Enabled = false; Resource.Enabled = false;

                Run.Enabled = true; Query.Enabled = true;
                ErrorMessge.Enabled = true; Time.Enabled = true;
            }
            if (SySetHeip.Engineer)
            {
                Run.Enabled = true; Query.Enabled = true;
                ErrorMessge.Enabled = true; SySet.Enabled = true;
                Upload.Enabled = true; Time.Enabled = true;
                Resource.Enabled = true;
            }
        }

        /// <summary>
        /// 查询连接状态 例如plc
        /// </summary>
        private void PlctConnect()
        {
            toolStripStatusLabel1.Text = "欢迎使用高温静置系统" + "            ";
            toolStripStatusLabel2.Text = "欢迎您：" + SySetHeip.LoginInfo + "  " + DateTime.Now.ToString();
            DeleteInfo++;
            if (DeleteInfo >= 36000)//删除温度数据
            {
                string SqlError = string.Format(@"delete [dbo.tb_Error] where  [ErrorTime] <= '{0} '", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss "));
                SqlServerHelp.ExecuteSql(SqlError);//删除一个月外的报警记录

                string SqlStatus = string.Format(@"delete [dbo.tb_MachineStatus] where  [WriteTime] <= '{0} '", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss "));
                SqlServerHelp.ExecuteSql(SqlStatus);//删除一个月外的温度记录
                DeleteInfo = 0;
            }
            if (PLCSocket.PlcQueryHelp.BreakThread_one)//plc连接状态
            {
                Plc.Image = ND.Properties.Resources.greenlight;//显示绿色灯
                lblWranInfo.Text = "PLC通信正常";            
            }
            else
            {
                Plc.Image = ND.Properties.Resources.redlight;//显示红色灯  
                lblWranInfo.Text =" PLC通信失败";
            }
        }
        int DeleteInfo;

        /// <summary>
        /// 显示桌面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Type oleType = Type.GetTypeFromProgID("Shell.Application");
            object oleObject = Activator.CreateInstance(oleType);
            oleType.InvokeMember("ToggleDesktop", BindingFlags.InvokeMethod, null, oleObject, null);
        }
        //protected override void WndProc(ref Message m)
        //{// switch ((int)(m.WParam)) { case (0xf030): break; default: base.WndProc(ref m); break; } 
        //}
        private void frm_Authoring_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowInfo(e, "是否退出系统？");
        }      
        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            frm_Authority f = new frm_Authority();
            SetMdiForm("权限操作", f);
        }
        private void Run_Click(object sender, EventArgs e)
        {

            SuperiorLimit f = new SuperiorLimit();
            SetMdiForm("运行操作", f);
        }

       private void query_Click(object sender, EventArgs e)
        {
            frm_Query f = new frm_Query();
            SetMdiForm("数据查询", f);
        }

        private void Temperature_Click(object sender, EventArgs e)
        {
            frm_Log log = new frm_Log();
            SetMdiForm("报警查询", log);
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            frm_Upload Upload = new frm_Upload();
            SetMdiForm("上传配置", Upload);
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            frm_TimeQuery TC = new frm_TimeQuery();
            SetMdiForm("时间查询", TC);
        }
        private void buttonItem5_Click_1(object sender, EventArgs e)
        {
            frm__ResourceNumber RN = new frm__ResourceNumber();
            SetMdiForm("炉子资源号", RN);
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            frm_Parameter P = new frm_Parameter();
            SetMdiForm("参数设置", P);
        }


        private  bool WindowInfo(FormClosingEventArgs ClosingInfo, string msgfInfo)
        {
            bool BoolInfn = false;
            DialogResult r;
            r = MessageBox.Show(msgfInfo, "确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                BoolInfn = false;
                ClosingInfo.Cancel = true;
            }
            return BoolInfn;
        }
        private void ribbonControl1_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.Location = new System.Drawing.Point(this.Width - 350, 2);
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Msg.AskQuestion("是否切换用户?"))
                    return;

                string appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                System.Diagnostics.Process.Start(appStartupPath + @"\NDL10.exe");

                Process.GetCurrentProcess().Kill();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 选项卡关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavTabControl1_TabItemClose_1(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            foreach (SuperTabItem item in NavTabControl1.Tabs)
            {
                if (item.Name == "运行操作")
                {
                    SerialPortHelper.SerialPortHelper.comPort.Close();
                    SerialPortHelper.SerialPortHelper.comPort.Dispose();
                }
            }
        }
    }
  }


     