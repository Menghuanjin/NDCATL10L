using Common;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ND;
using ND6L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlHelp
{
  public   class ControlHelp
    {
        public static ListBox listBoxAddress = null;
        public static TextBoxX BarCode1 = null;
        public static TextBoxX BarCode2 = null;
        public static TextBoxX Resource = null;
        /// <summary>
        /// 显示当前要操作的门号
        /// </summary>
        public static LabelX Operate = null;
        public static void listBoxInfo(String ValueAddress)
        {
            listBoxCount++;
            String Value = "[" + DateTime.Now.ToString() + "]" + "编号：" + listBoxCount.ToString() + "  " + "信息内容：" + ValueAddress;
            listBoxAddress.Items.Insert(0, Value);
            SqlErrorInfo(ValueAddress);//插入Sql
            if (listBoxCount > 100)//超过100行自动清除
            {
                listBoxCount = 0;
                listBoxAddress.Items.Clear();
            }
        }
        /// <summary>
        /// 将报警记录写入数据库
        /// </summary>
        /// <param name="ValueAddress"></param>
        public static void SqlErrorInfo(string ValueAddress)
        {
            string Sql = string.Format(@"INSERT INTO [dbo.tb_Error](ErrorTime,ErrorContent) VALUES ( '{0}','{1}')", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ValueAddress.Trim());
            SqlServerHelp.ExecuteSql(Sql);
        }
        /// <summary>
        /// 报警编号
        /// </summary>
        public static  int listBoxCount;

    }
}
