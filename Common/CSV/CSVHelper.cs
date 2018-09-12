using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Common
{
    public class CSVHelper
    {
        private static string csvpath;
        /// <summary>
        ///路径
        /// </summary>
        public static string CsvPath
        {
            get { return csvpath; }
            set { csvpath = value; }
        }      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="title"></param>
        /// <param name="isAtMath"></param>
        public static void WriteInfoToCSVFileDisMath(List<string[]> info, List<string[]> title, bool isAtMath )
        {
            if (!Directory.Exists(saveLogFilePath))//判断是否有此目录
                Directory.CreateDirectory(saveLogFilePath);//没有就创建
            DateTime now = DateTime.Now;
            string str1 = now.ToString("yyyyMM");
            if (!isAtMath)
            {
                now = DateTime.Now;
                str1 = now.ToString("yyyyMMdd");
            }
           string str2 = saveLogFilePath + "\\" + (str1 + ".csv");
            if (!File.Exists(str2) && title != null)
                WriteCSV(str2, title);
            WriteCSV(str2, true, info);
        }
        private static string saveLogFilePath
        {
            get
            {
                try
                {
                    string startupPath = CsvPath;//在哪一个盘路径
                    return string.Format("{0}", (object)startupPath);//文件夹名
                }
                catch
                {
                }
                return Application.StartupPath;
            }
            set
            {
                saveLogFilePath = value;
            }
        }
        public static void WriteCSV(string filePathName, List<string[]> ls)
        {
            WriteCSV(filePathName, false, ls);
        }

        public static void WriteCSV(string filePathName, bool append, List<string[]> ls)
        {
            StreamWriter streamWriter = new StreamWriter(filePathName, append, Encoding.Default);
            foreach (string[] strArray in ls)
                streamWriter.WriteLine(string.Join(",", strArray));
            streamWriter.Flush();
            streamWriter.Close();
        }

        public static List<string[]> ReadCSV(string filePathName)
        {
            List<string[]> list = new List<string[]>();
            StreamReader streamReader = new StreamReader(filePathName);
            string str = "";
            while (str != null)
            {
                str = streamReader.ReadLine();
                if (str != null && str.Length > 0)
                    list.Add(str.Split(','));
            }
            streamReader.Close();
            return list;
        }
        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public static void SaveCSV(DataTable dt, string fullPath)
        {
            try
            {
                FileInfo fi = new FileInfo(fullPath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string data = "";
                //写出列名称
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += dt.Columns[i].ColumnName.ToString();
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
                //写出各行数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                        if (str.Contains(',') || str.Contains('"')
                            || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                        {
                            str = string.Format("\"{0}\"", str);
                        }

                        data += str;
                        if (j < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }
                sw.Close();
                fs.Close();
            }
            catch (Exception) { }
            //  DialogResult result = MessageBox.Show("CSV文件保存成功！");
        }

    }
}
