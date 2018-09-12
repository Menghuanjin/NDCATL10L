using ID;
using ND6L;
using ND6L;
using PLCSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLC_DataSend
{
  /// <summary>
  /// 数据发送，数据接收，插入数据库
  /// </summary>
  public  class DataSend
    {
        /// <summary>
        /// 1#数据发送
        /// </summary>
        public static void DataSend1()
        {
            if (PLC_InquiryHelp.BreakThread_one)
            {
                PLC_InquiryHelp.PLC_InquiryOne(0);//查询PLC
                InsertHelp.InsertInfo1_5 = JointInfoHelp.ReturnSend5(1180, 1195, 0);//五层温度数据
                InsertHelp.UpdateInfo(1, 5, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark1_5), InsertHelp.InsertInfo1_5, 1015);
                InsertHelp.InsertInfo1_4 = JointInfoHelp.ReturnSend4(1160, 1175, 0);//四层温度数据
                InsertHelp.UpdateInfo(1, 4, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark1_4), InsertHelp.InsertInfo1_4, 1014);
                InsertHelp.InsertInfo1_3 = JointInfoHelp.ReturnSend3(1100, 1115, 0);//三层温度数据
                InsertHelp.UpdateInfo(1, 3, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark1_3), InsertHelp.InsertInfo1_3, 1013);
                InsertHelp.InsertInfo1_2 = JointInfoHelp.ReturnSend2(1120, 1135, 0);//二层温度数据
                InsertHelp.UpdateInfo(1, 2, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark1_2), InsertHelp.InsertInfo1_2, 1012);
                InsertHelp.InsertInfo1_1 = JointInfoHelp.ReturnSend1(1140, 1155, 0);//一层温度数据 
                InsertHelp.UpdateInfo(1, 1, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark1_1), InsertHelp.InsertInfo1_1, 1011);
                InsertHelp.InsertSql(MachineIDHelp.MachineIDInfo1(), InsertHelp.InsertInfo1_5, InsertHelp.InsertInfo1_4, InsertHelp.InsertInfo1_3, InsertHelp.InsertInfo1_2, InsertHelp.InsertInfo1_1);
            }
        }
        /// <summary>
        /// 2#数据发送
        /// </summary>
        public static void DataSend2()
        {
            if (PLC_InquiryHelp.BreakThread_two)
            {
                PLC_InquiryHelp.PLC_InquiryTwo(1);
                InsertHelp.InsertInfo2_5 = JointInfoHelp.ReturnSend5(1180, 1195, 1);//五层温度数据
                InsertHelp.UpdateInfo(2, 5, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark2_5), InsertHelp.InsertInfo2_5, 1025);
                InsertHelp.InsertInfo2_4 = JointInfoHelp.ReturnSend4(1160, 1175, 1);//四层温度数据
                InsertHelp.UpdateInfo(2, 4, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark2_4), InsertHelp.InsertInfo2_4, 1024);
                InsertHelp.InsertInfo2_3 = JointInfoHelp.ReturnSend3(1100, 1115, 1);//三层温度数据
                InsertHelp.UpdateInfo(2, 3, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark2_3), InsertHelp.InsertInfo2_3, 1023);
                InsertHelp.InsertInfo2_2 = JointInfoHelp.ReturnSend2(1120, 1135, 1);//二层温度数据
                InsertHelp.UpdateInfo(2, 3, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark2_2), InsertHelp.InsertInfo2_2, 1022);
                InsertHelp.InsertInfo2_1 = JointInfoHelp.ReturnSend1(1140, 1155, 1);//一层温度数据    
                InsertHelp.UpdateInfo(2, 1, PLC_InquiryHelp.StatusTo(PLC_InquiryHelp.RunMark2_1), InsertHelp.InsertInfo2_1, 1021);
                InsertHelp.InsertSql(MachineIDHelp.MachineIDInfo2(), InsertHelp.InsertInfo2_5, InsertHelp.InsertInfo2_4, InsertHelp.InsertInfo2_3, InsertHelp.InsertInfo2_2, InsertHelp.InsertInfo2_1);
            }
        }
        /// <summary>
        /// 3#数据发送
        /// </summary>
        public static void DataSend3()
        {
            if (PLC_InquiryHelp.BreakThread_three)
            {
                PLC_InquiryHelp.PLC_InquiryThree(2);
                InsertHelp.InsertInfo3_5 = JointInfoHelp.ReturnSend5(1180, 1195, 2);//五层温度数据
                InsertHelp.InsertInfo3_4 = JointInfoHelp.ReturnSend4(1160, 1175, 2);//四层温度数据
                InsertHelp.InsertInfo3_3 = JointInfoHelp.ReturnSend3(1100, 1115, 2);//三层温度数据
                InsertHelp.InsertInfo3_2 = JointInfoHelp.ReturnSend2(1120, 1135, 2);//二层温度数据
                InsertHelp.InsertInfo3_1 = JointInfoHelp.ReturnSend1(1140, 1155, 2);//一层温度数据 
                InsertHelp.InsertSql(MachineIDHelp.MachineIDInfo3(), InsertHelp.InsertInfo3_5, InsertHelp.InsertInfo3_4, InsertHelp.InsertInfo3_3, InsertHelp.InsertInfo3_2, InsertHelp.InsertInfo3_1);
            }

        }
        /// <summary>
        /// 4#数据发送
        /// </summary>
        public static void DataSend4()
        {
            if (PLC_InquiryHelp.BreakThread_four)
            {
                InsertHelp.InsertInfo4_5 = JointInfoHelp.ReturnSend5(1180, 1195, 3);//五层温度数据
                InsertHelp.InsertInfo4_4 = JointInfoHelp.ReturnSend4(1160, 1175, 3);//四层温度数据
                InsertHelp.InsertInfo4_3 = JointInfoHelp.ReturnSend3(1100, 1115, 3);//三层温度数据
                InsertHelp.InsertInfo4_2 = JointInfoHelp.ReturnSend2(1120, 1135, 3);//二层温度数据
                InsertHelp.InsertInfo4_1 = JointInfoHelp.ReturnSend1(1140, 1155, 3);//一层温度数据   
                PLCSocket.PLC_InquiryHelp.BreakThread_four = true;
                InsertHelp.InsertSql(MachineIDHelp.MachineIDInfo4(), InsertHelp.InsertInfo4_5, InsertHelp.InsertInfo4_4, InsertHelp.InsertInfo4_3, InsertHelp.InsertInfo4_2, InsertHelp.InsertInfo4_1);
            }

        }
        /// <summary>
        /// 5#数据发送
        /// </summary>
        public static void DataSend5()
        {
            if (PLC_InquiryHelp.BreakThread_five)
            {
                PLC_InquiryHelp.PLC_InquiryFive(4);
                InsertHelp.InsertInfo5_5 = JointInfoHelp.ReturnSend5(1180, 1195, 4);//五层温度数据
                InsertHelp.InsertInfo5_4 = JointInfoHelp.ReturnSend4(1160, 1175, 4);//四层温度数据
                InsertHelp.InsertInfo5_3 = JointInfoHelp.ReturnSend3(1100, 1115, 4);//三层温度数据
                InsertHelp.InsertInfo5_2 = JointInfoHelp.ReturnSend2(1120, 1135, 4);//二层温度数据
                InsertHelp.InsertInfo5_1 = JointInfoHelp.ReturnSend1(1140, 1155, 4);//一层温度数据 
                InsertHelp.InsertSql(MachineIDHelp.MachineIDInfo5(), InsertHelp.InsertInfo5_5, InsertHelp.InsertInfo5_4, InsertHelp.InsertInfo5_3, InsertHelp.InsertInfo5_2, InsertHelp.InsertInfo5_1);
            }
        }
        /// <summary>
        /// 6#数据发送
        /// </summary>
        public static void DataSend6()
        {
            if (PLC_InquiryHelp.BreakThread_six)
            {
                PLC_InquiryHelp.PLC_InquirySix(5);
                InsertHelp.InsertInfo6_5 = JointInfoHelp.ReturnSend5(1160, 1175, 5);//五层温度数据
                InsertHelp.InsertInfo6_4 = JointInfoHelp.ReturnSend4(1160, 1175, 5);//四层温度数据
                InsertHelp.InsertInfo6_3 = JointInfoHelp.ReturnSend3(1100, 1115, 5);//三层温度数据
                InsertHelp.InsertInfo6_2 = JointInfoHelp.ReturnSend2(1120, 1135, 5);//二层温度数据
                InsertHelp.InsertInfo6_1 = JointInfoHelp.ReturnSend1(1140, 1155, 5);//一层温度数据    
                InsertHelp.InsertSql(MachineIDHelp.MachineIDInfo6(), InsertHelp.InsertInfo6_5, InsertHelp.InsertInfo6_4, InsertHelp.InsertInfo6_3, InsertHelp.InsertInfo6_2, InsertHelp.InsertInfo6_1);
            }         
        }
        public static void DataSend7()
        {
            if (PLC_InquiryHelp.BreakThread_seven)
            { 
                PLC_InquiryHelp.PLC_InquirySeven(6);
            }

        }
        public static void DataSend8()
        {
            if (PLC_InquiryHelp.BreakThread_eight)
            {
                PLC_InquiryHelp.PLC_InquiryEight(7);
            }
            
        }
        
    }
}
