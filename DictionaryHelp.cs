using Common;
using ND;
using PLCSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ND6L
{
  public   class DictionaryHelp
    {
        public static Dictionary<string, Action> Dictionary = new Dictionary<string, Action>();
        /// <summary>
        /// 初始化字典
        /// </summary>
        public void InitializtionErrorDictionary()
        {
            try
            {
                Dictionary.Clear();
                //操作门号
                Dictionary.Add("Operater1", OperaterOne); Dictionary.Add("Operater2", OperaterTwo);
                Dictionary.Add("Operater3", OperaterThree); Dictionary.Add("Operater4", OperaterFour);
                Dictionary.Add("Operater5", OperaterFive); Dictionary.Add("Operater6", OperaterSix);
                Dictionary.Add("Operater7", OperaterSeven); Dictionary.Add("Operater8", OperaterEight);
                //操作报警消除功能
                Dictionary.Add("ErrorOne", ErrorOne); Dictionary.Add("ErrorTwo", ErrorTwo);
                Dictionary.Add("ErrorThree", ErrorThree); Dictionary.Add("ErrorFour", ErrorFour);
                Dictionary.Add("ErrorFive", ErrorFive); Dictionary.Add("ErrorSix", ErrorSix);
                Dictionary.Add("ErrorSeven", ErrorSeven); Dictionary.Add("ErrorEight", ErrorEight);
                //操作启动机器功能 
                Dictionary.Add("StartOne", StartOne); Dictionary.Add("StartTwo", StartTwo);
                Dictionary.Add("StartThree", StartThree); Dictionary.Add("StartFour", StartFour);
                Dictionary.Add("StartFive", StartFive); Dictionary.Add("StartSix", StartSix);
                Dictionary.Add("StartSeven", StartSeven); Dictionary.Add("StartEight", StartEight);
                //操作停止机器功能
                Dictionary.Add("StopOne", StopOne); Dictionary.Add("StopTwo", StopTwo);
                Dictionary.Add("StopThree", StopThree); Dictionary.Add("StopFour", StopFour);
                Dictionary.Add("StopFive", StopFive); Dictionary.Add("StopSix", StopSix);
                Dictionary.Add("StopSeven", StopSeven); Dictionary.Add("StopEight", StopEight);
                //操作照明开启功能
                Dictionary.Add("LightingOpenOne", LightingOpenOne); Dictionary.Add("LightingOpenTwo", LightingOpenTwo);
                Dictionary.Add("LightingOpenThree", LightingOpenThree); Dictionary.Add("LightingOpenFour", LightingOpenFour);
                Dictionary.Add("LightingOpenFive", LightingOpenFive); Dictionary.Add("LightingOpenSix", LightingOpenSix);
                Dictionary.Add("LightingOpenSeven", LightingOpenSeven); Dictionary.Add("LightingOpenEight", LightingOpenEight);
                //操作照明关闭功能
                Dictionary.Add("LightingCloseOne", LightingCloseOne); Dictionary.Add("LightingCloseTwo", LightingCloseTwo);
                Dictionary.Add("LightingCloseThree", LightingCloseThree); Dictionary.Add("LightingCloseFour", LightingCloseFour);
                Dictionary.Add("LightingCloseFive", LightingCloseFive); Dictionary.Add("LightingCloseSix", LightingCloseSix);
                Dictionary.Add("LightingCloseSeven", LightingCloseSeven); Dictionary.Add("LightingCloseEight", LightingCloseEight);
            }
            catch (Exception)
            {}
        }

        /// <summary>
        /// 当前1号门操作
        /// </summary>
        private static void  OperaterOne()
        {
            SuperiorLimit.OperaterInfo = "One";
            ControlHelp.ControlHelp.Operate.Text= "当前1号门操作";
            ControlHelp.ControlHelp.Resource.Text =   SySetHeip.ResourceNumberOne;
        }
        /// <summary>
        /// 当前2号门操作
        /// </summary>
        private static  void OperaterTwo()
        {
            SuperiorLimit.OperaterInfo = "Two";
            ControlHelp.ControlHelp.Operate.Text = "当前2号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberTwo;
        }
        /// <summary>
        /// 当前3号门操作
        /// </summary>
        private static void OperaterThree()
        {
            SuperiorLimit.OperaterInfo = "Three";
            ControlHelp.ControlHelp.Operate.Text = "当前3号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberThree;
        }
        /// <summary>
        /// 当前4号门操作
        /// </summary>
        private static void OperaterFour()
        {
            SuperiorLimit.OperaterInfo = "Four";
            ControlHelp.ControlHelp.Operate.Text = "当前4号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberFour;
        }
        /// <summary>
        /// 当前5号门操作
        /// </summary>
        private static void OperaterFive()
        {
            SuperiorLimit.OperaterInfo = "Five";
            ControlHelp.ControlHelp.Operate.Text = "当前5号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberFive;
        }
        /// <summary>
        /// 当前6号门操作
        /// </summary>
        private static void OperaterSix()
        {
            SuperiorLimit.OperaterInfo = "Six";
            ControlHelp.ControlHelp.Operate.Text = "当前6号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberSix;
        }
        /// <summary>
        /// 当前7号门操作
        /// </summary>
        private static void OperaterSeven()
        {
            SuperiorLimit.OperaterInfo = "Seven";
            ControlHelp.ControlHelp.Operate.Text = "当前7号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberSeven;
        }
        /// <summary>
        /// 当前8号门操作
        /// </summary>
        private static void OperaterEight()
        {
            SuperiorLimit.OperaterInfo = "Eight";
            ControlHelp.ControlHelp.Operate.Text = "当前8号门操作";
            ControlHelp.ControlHelp.Resource.Text = SySetHeip.ResourceNumberEight;
        }
        /// <summary>
        /// 1门发送报警消除指令
        /// </summary>
        private static void ErrorOne()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("80", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("80", 0));
                ControlHelp.ControlHelp.listBoxInfo("1门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("1门发送报警消除指令失败");
            }

        }
        /// <summary>
        /// 2门发送报警消除指令
        /// </summary>
        private static void ErrorTwo()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("81", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("81", 0));
                ControlHelp.ControlHelp.listBoxInfo("2门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("2门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 3门发送报警消除指令
        /// </summary>
        private static void ErrorThree()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("82", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("82", 0));
                ControlHelp.ControlHelp.listBoxInfo("3门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("3门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 4门发送报警消除指令
        /// </summary>
        private static void ErrorFour()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("83", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("83", 0));
                ControlHelp.ControlHelp.listBoxInfo("4门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("4门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 5门发送报警消除指令
        /// </summary>
        private static void ErrorFive()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("84", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("84", 0));
                ControlHelp.ControlHelp.listBoxInfo("5门发送报警消除指令成功");

            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("5门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 6门发送报警消除指令
        /// </summary>
        private static void ErrorSix()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("85", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("85", 0));
                ControlHelp.ControlHelp.listBoxInfo("6门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("6门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 7门发送报警消除指令
        /// </summary>
        private static void ErrorSeven()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("86", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("86", 0));
                ControlHelp.ControlHelp.listBoxInfo("7门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("7门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 8门发送报警消除指令
        /// </summary>
        private static void ErrorEight()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("87", 1))))
            {
                Thread.Sleep(1000);
                SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("87", 0));
                ControlHelp.ControlHelp.listBoxInfo("8门发送报警消除指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("8门发送报警消除指令失败");
            }
        }
        /// <summary>
        /// 1门联机启动
        /// </summary>
        private static void StartOne()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("1号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("1门发送联机启动指令失败");
            }
        }
        /// <summary>
        /// 2门联机启动
        /// </summary>
        private static void StartTwo()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("1C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("2号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("2号发送联机启动指令失败");
            }

        }
        /// <summary>
        ///  3门联机启动
        /// </summary>
        private static void StartThree()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("2C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("3号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("3号发送联机启动指令失败");
            }

        }
        /// <summary>
        ///  4门联机启动
        /// </summary>
        private static void StartFour()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("3C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("4号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("4号发送联机启动指令失败");
            }
        }
        /// <summary>
        ///  5门联机启动
        /// </summary>
        private static void StartFive()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("4C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("5号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("5号发送联机启动指令失败");
            }
        }
        /// <summary>
        ///  6门联机启动
        /// </summary>
        private static void StartSix()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("5C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("6号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("6号发送联机启动指令失败");
            }
        }
        /// <summary>
        ///  7门联机启动
        /// </summary>
        private static void StartSeven()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("6C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("7号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("7号发送联机启动指令失败");
            }
        }
        /// <summary>
        ///  8门联机启动
        /// </summary>
        private static void StartEight()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("7C", 1))))
            {
                ControlHelp.ControlHelp.listBoxInfo("8号发送联机启动指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("8号发送联机启动指令失败");
            }
        }
        /// <summary>
        /// 1门停止
        /// </summary>
        private static void StopOne()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("C", 0))))
            {               
                ControlHelp.ControlHelp.listBoxInfo("1号发送停止指令指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("1号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 2门停止
        /// </summary>
        private static void StopTwo()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("1C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("2号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("2号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 3门停止
        /// </summary>
        private static void StopThree()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("2C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("3号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("3号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 4门停止
        /// </summary>
        private static void StopFour()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("3C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("4号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("4号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 5门停止
        /// </summary>
        private static void StopFive()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("4C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("5号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("5号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 6门停止
        /// </summary>
        private static void StopSix()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("5C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("6号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("6号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 7门停止
        /// </summary>
        private static void StopSeven()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("6C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("7号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("7号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 8门停止
        /// </summary>
        private static void StopEight()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("7C", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("8号发送停止指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("8号发送停止指令指令失败");
            }
        }
        /// <summary>
        /// 1门照明灯开启
        /// </summary>
        private static void LightingOpenOne()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("2", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("1号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("1号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 2门照明灯开启
        /// </summary>
        private static void LightingOpenTwo()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("12", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("2号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("2号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 3门照明灯开启
        /// </summary>
        private static void LightingOpenThree()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("22", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("3号发送照明指令指令成功"); }
            else
            { ControlHelp.ControlHelp.listBoxInfo("3号发送照明指令指令失败"); }
        }
        /// <summary>
        /// 4门照明灯开启
        /// </summary>
        private static void LightingOpenFour()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("32", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("4号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("4号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 5门照明灯开启
        /// </summary>
        private static void LightingOpenFive()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("42", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("5号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("5号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 6门照明灯开启
        /// </summary>
        private static void LightingOpenSix()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("52", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("6号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("6号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 7门照明灯开启
        /// </summary>
        private static void LightingOpenSeven()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("62", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("7号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("7号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 8门照明灯开启
        /// </summary>
        private static void LightingOpenEight()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("72", 1))))
            { ControlHelp.ControlHelp.listBoxInfo("8号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("8号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 1门照明灯关闭
        /// </summary>
        private static void LightingCloseOne()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("2", 0))))
            {
                ControlHelp.ControlHelp.listBoxInfo("1号发送照明指令指令成功");
            }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("1号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 2门照明灯关闭
        /// </summary>
        private static void LightingCloseTwo()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("12", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("2号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("2号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 3门照明灯关闭
        /// </summary>
        private static void LightingCloseThree()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("22", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("3号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("3号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 4门照明灯关闭
        /// </summary>
        private static void LightingCloseFour()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("32", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("4号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("4号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 5门照明灯关闭
        /// </summary>
        private static void LightingCloseFive()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("42", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("5号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("5号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 6门照明灯关闭
        /// </summary>
        private static void LightingCloseSix()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("52", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("6号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("6号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 7门照明灯关闭
        /// </summary>
        private static void LightingCloseSeven()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("62", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("7号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("7号发送照明指令指令失败");
            }
        }
        /// <summary>
        /// 8门照明灯关闭
        /// </summary>
        private static void LightingCloseEight()
        {
            if (!string.IsNullOrEmpty(SocketHelper.SendAddress(SocketHelper.socketList[0].socket, PLCAddressHelper.RAddressWrite("72", 0))))
            { ControlHelp.ControlHelp.listBoxInfo("8号发送照明指令指令成功"); }
            else
            {
                ControlHelp.ControlHelp.listBoxInfo("8号发送照明指令指令失败");
            }
        }
    }
}
