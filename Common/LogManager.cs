using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Common
{
    public class LogManager
    {
        //日志文件所在路径
        private static string logPath = string.Empty;
        /// <summary>
        /// 保存日志的文件夹
        /// </summary>
        public static string LogPath
        {
            get
            {                
                if (logPath == string.Empty)
                {
                    logPath = AppDomain.CurrentDomain.BaseDirectory + "log";
                    if (Directory.Exists(logPath) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(logPath);
                    }                    
                }
                return logPath;
            }
            set { logPath = value; }
        }
        //日志前缀说明信息
        private static string logFielPrefix = string.Empty;
        /// <summary>
        /// 日志文件前缀
        /// </summary>
        public static string LogFielPrefix
        {
            get { return logFielPrefix; }
            set { logFielPrefix = value; }
        }
        /// <summary>
        /// 写日志
        /// <param name="logType">日志类型</param>
        /// <param name="msg">日志内容</param> 
        /// </summary>
        public static void WriteLogInfo(string logType, string msg)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                //同一天同一类日志以追加形式保存
                sw = System.IO.File.AppendText(
                    LogPath+@"\Log" + LogFielPrefix + "_" +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"
                    );
                sw.WriteLine(logType + "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + msg);
            }
            catch
            { }
            finally
            {
                sw.Close();
            }
        }
        ///// <summary>
        ///// 写日志
        ///// </summary>
        //public static void WriteLog(LogType logType, string msg)
        //{
        //    WriteLog(logType.ToString(), msg);
        //}
        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(string logType, string msg)
        {
            WriteLogInfo(logType.ToString(), msg);
        }


        public static void WriteLogToData(string type,string value,string rec)
        {
            if (rec != "")
            {
                if (rec.Substring(0, 2) == "06")
                {
                    Common.LogManager.WriteLogInfo(type, type + "：" + value + " 成功！  返回值：" + rec);
                }
                else
                {
                    Common.LogManager.WriteLogInfo(type, type + "：" + value + " 失败！  返回值：" + rec);
                }
            }
            else
            {
                Common.LogManager.WriteLogInfo(type, type + "：" + value + " 失败！  返回值：" + rec);
            }
           
        }
    }


    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        Trace,  //堆栈跟踪信息
        Warning,//警告信息
        Error,  //错误信息应该包含对象名、发生错误点所在的方法名称、具体错误信息
        SQL    //与数据库相关的信息
    }
}
