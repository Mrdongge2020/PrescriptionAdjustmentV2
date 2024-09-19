using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdjustmentSys.Tool.TCP
{
    /// <summary>
    /// 施耐德控制器
    /// </summary>
    public class ModBusTCP_Cliect
    {
        public static bool ConnState;
        public static string ip;
        public static int port;
        // public static EndPoint CIP = "m43a460959.zicp.vip:59124";
        //   public static IPEndPoint CIP = "m43a460959.zicp.vip:59124";

        private TcpClient Cliect = new TcpClient();

        private Ping pingSender = new Ping();
        NetworkStream DataStream;
        private bool CheckNet()
        {
            try
            {
                PingReply reply = pingSender.Send(ip, 500);//第一个参数为ip地址，第二个参数为ping的时间 
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 重新连接
        /// </summary>
        /// <param name="IP"></param>
        public void Connent()
        {
            this.Cliect.Close();
            //Application.DoEvents();
            try
            {
                Cliect = new TcpClient();

                Cliect.Connect(ip, port);
                ConnState = true;
                DataStream = Cliect.GetStream();
            }
            catch (Exception ex)
            {
                ConnState = false;
            }

        }


        private void TestConnection()
        {
            if (this.CheckNet())
            {
                //this.CheckNet()  //互联网连接ping 不能调用 ，局网连接ping 
                try
                {
                    this.Cliect.Connect(ip, port);
                    Cliect.ReceiveTimeout = 1000;
                    Cliect.SendTimeout = 1000;

                    ConnState = true;
                    DataStream = Cliect.GetStream();
                    if (!checkline())
                    {
                        ConnState = false;


                    }

                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("设备通信打开失败! <" + ex.Message + ">", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ConnState = false;

                }
            }
            else
            {
                //  MessageBox.Show("未连接到设备!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnState = false;
            }
        }
        private bool checkline()
        {
            if (Read_Int16(1) == -1)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        public ModBusTCP_Cliect()
        {

            TestConnection();

        }

        public bool GetConnState()
        {
            try
            {
                ConnState = Cliect.Connected;
                if (Cliect.Connected)
                {
                    return true;
                }
                else { return false; }
            }
            catch (System.NullReferenceException)
            {
                return false;
            }
        }





        private byte[] SendData(byte[] DataFrame)
        {

            try
            {
                Monitor.Enter(Cliect);
                if (this.GetConnState())
                {
                    // NetworkStream DataStream = Cliect.GetStream();

                    DataStream.Write(DataFrame, 0, DataFrame.Length);

                a1: byte[] RetData = new byte[300];
                    int RetByteLength = DataStream.Read(RetData, 0, RetData.Length);
                    if (RetByteLength > 0)
                    {
                        if ((RetData[1] * 256 + RetData[0]) == (DataFrame[1] * 256 + DataFrame[0]))
                        {
                            return RetData;
                        }
                        else
                        {

                            return null;
                        }
                    }
                    else
                    {
                        goto a1;
                    }
                }
                else
                {

                    return null;
                }
            }
            catch (Exception ex)
            {
                ConnState = false;
                return null;
            }
            finally
            {
                Monitor.Exit(Cliect);
            }
        }
        private bool IDAdmin(UInt16 ID)
        {
            if (ID > 65535)
            {
                //MessageBox.Show("地址不合法!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else { return true; }
        }
        public void BitSet(UInt16 ID, byte Bit, bool State)
        {
            if (Bit < 0 | Bit > 14)
            {
                //MessageBox.Show("位址不合法!");
                return;
            }
            Int16 Value = this.Read_Int16(ID);
            if (State)
            {
                Int16 value = (Int16)(Value | (Int16)(Math.Pow(2, Bit)));
                this.Write_Int16(ID, value);
            }
            else
            {
                Int16 value = (Int16)(Value & (Int16)(Value - Math.Pow(2, Bit)));
                this.Write_Int16(ID, value);
            }
        }
        public bool GetBitState(UInt16 ID, byte Bit)
        {
            if (Bit < 0 | Bit > 14)
            {
                //MessageBox.Show("位址不合法!");
                return false;
            }
            Int16 Value = this.Read_Int16(ID);
            Int16 State = (Int16)(Value & (Int16)Math.Pow(2, Bit));
            if (State == Math.Pow(2, Bit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 读多个寄存器
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public byte[] Read_Intall(UInt16 ID, byte nuber)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[12];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 6;//数据长度
                DataFrame[6] = 1;//单元标识
                DataFrame[7] = 3;//功能码
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];//地址高字节
                DataFrame[9] = temp[0];//地址低字节
                DataFrame[10] = 0;
                DataFrame[11] = nuber;
                byte[] RetData = SendData(DataFrame);
                if (RetData != null)
                {
                    byte[] OutData = { RetData[10], RetData[9] };
                    return RetData;
                }
                else
                { return null; }
            }
            else { return null; }
        }
        /// <summary>
        ///写多个寄存器
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Write_Intall(UInt16 ID, Int16[] Value)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[Value.Length * 2 + 13];
                byte[] temp1 = BitConverter.GetBytes(Value.Length * 2 + 7);
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = temp1[1];// 数据长度
                DataFrame[5] = temp1[0];// 数据长度
                DataFrame[6] = 1;//单元标识
                DataFrame[7] = 16;//功能码
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                byte[] temp3 = BitConverter.GetBytes(Value.Length);
                DataFrame[10] = temp3[1];
                DataFrame[11] = temp3[0];
                DataFrame[12] = (Byte)(Value.Length * 2);
                for (int i = 0; i < Value.Length; i++)
                {
                    byte[] temp2 = BitConverter.GetBytes(Value[i]);
                    DataFrame[13 + i * 2] = temp2[1];
                    DataFrame[14 + i * 2] = temp2[0];
                }
                if (SendData(DataFrame) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }
        }
        /// <summary>
        ///写多个寄存器
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Write_32Intall(UInt16 ID, Int32[] Value)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[Value.Length * 4 + 13];
                byte[] temp1 = BitConverter.GetBytes(Value.Length * 4 + 7);
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = temp1[1];// 数据长度
                DataFrame[5] = temp1[0];// 数据长度
                DataFrame[6] = 1;//单元标识
                DataFrame[7] = 16;//功能码
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                byte[] temp3 = BitConverter.GetBytes(Value.Length);
                DataFrame[10] = temp3[1];
                DataFrame[11] = temp3[0];
                DataFrame[12] = (Byte)(Value.Length * 4);
                for (int i = 0; i < Value.Length; i++)
                {
                    byte[] temp2 = BitConverter.GetBytes(Value[i]);
                    DataFrame[13 + i * 4] = temp2[1];
                    DataFrame[14 + i * 4] = temp2[0];
                    DataFrame[15 + i * 4] = temp2[3];
                    DataFrame[16 + i * 4] = temp2[2];
                }
                if (SendData(DataFrame) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }
        }
        /// <summary>
        /// 读16位
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Int16 Read_Int16(UInt16 ID)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[12];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 6;//数据长度
                DataFrame[6] = 1;//单元标识
                DataFrame[7] = 3;//功能码
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];//地址高字节
                DataFrame[9] = temp[0];//地址低字节
                DataFrame[10] = 0;
                DataFrame[11] = 1;
                byte[] RetData = SendData(DataFrame);
                if (RetData != null)
                {
                    byte[] OutData = { RetData[10], RetData[9] };
                    return BitConverter.ToInt16(OutData, 0);
                }
                else
                { return -1; }
            }
            else { return -1; }
        }
        /// <summary>
        /// 写16位
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool Write_Int16(UInt16 ID, Int16 Value)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[12];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 6;
                DataFrame[6] = 1;
                DataFrame[7] = 6;
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                byte[] temp1 = BitConverter.GetBytes(Value);
                DataFrame[10] = temp1[1];
                DataFrame[11] = temp1[0];
                if (SendData(DataFrame) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }
        }

        /// <summary>
        /// 读32位
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Int32 Read_Int32(UInt16 ID)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[12];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 6;
                DataFrame[6] = 1;
                DataFrame[7] = 3;
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                DataFrame[10] = 0;
                DataFrame[11] = 4;
                byte[] RetData = SendData(DataFrame);
                if (RetData != null)
                {
                    byte[] OutData = { RetData[10], RetData[9], RetData[12], RetData[11] };
                    return BitConverter.ToInt32(OutData, 0);
                }
                else
                {
                    return -1;
                }
            }
            else { return -1; }
        }
        public Int64 Read_Int64(UInt16 ID)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[12];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 6;
                DataFrame[6] = 1;
                DataFrame[7] = 3;
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                DataFrame[10] = 0;
                DataFrame[11] = 8;
                byte[] RetData = SendData(DataFrame);
                if (RetData != null)
                {
                    byte[] OutData = { RetData[10], RetData[9], RetData[12], RetData[11], RetData[14], RetData[13], RetData[16], RetData[15] };
                    return BitConverter.ToInt64(OutData, 0);
                }
                else
                {
                    return -1;
                }
            }
            else { return -1; }
        }
        /// <summary>
        /// 写32位
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool Write_Int32(UInt16 ID, Int32 Value)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[17];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 11;
                DataFrame[6] = 1;
                DataFrame[7] = 16;
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                DataFrame[10] = 0;
                DataFrame[11] = 2;
                DataFrame[12] = 4;
                byte[] temp1 = BitConverter.GetBytes(Value);
                DataFrame[13] = temp1[1];
                DataFrame[14] = temp1[0];
                DataFrame[15] = temp1[3];
                DataFrame[16] = temp1[2];
                if (SendData(DataFrame) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void Write_Int64(UInt16 ID, Int64 Value)
        {
            byte[] DataFrame = BitConverter.GetBytes(Value);
            byte[] Hip = { DataFrame[0], DataFrame[1], DataFrame[2], DataFrame[3] };
            byte[] Lop = { DataFrame[4], DataFrame[5], DataFrame[6], DataFrame[7] };
            Int32 Hi = BitConverter.ToInt32(Hip, 0);
            Int32 Lo = BitConverter.ToInt32(Lop, 0);
            for (int i = 0; i < 3; i += 2)
            {
                if (i == 0)
                {
                    this.Write_Int32((UInt16)(ID + i), Hi);
                }
                else if (i == 2)
                {
                    this.Write_Int32((UInt16)(ID + i), Lo);
                }
            }
        }
        /// <summary>
        /// 读浮点数
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Single Read_Single(UInt16 ID)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[12];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 6;
                DataFrame[6] = 1;
                DataFrame[7] = 3;
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                DataFrame[10] = 0;
                DataFrame[11] = 4;
                byte[] RetData = SendData(DataFrame);
                if (RetData != null)
                {
                    byte[] OutData = { RetData[10], RetData[9], RetData[12], RetData[11] };
                    return BitConverter.ToSingle(OutData, 0);
                }
                else
                {
                    return -1.1f;
                }
            }
            else
            {
                return -1.1f;
            }
        }
        /// <summary>
        /// 写浮点数
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool Write_Single(UInt16 ID, Single Value)
        {
            if (this.IDAdmin(ID))
            {
                byte[] DataFrame = new byte[17];
                DataFrame[0] = 100;
                DataFrame[1] = 1;
                DataFrame[2] = 0;
                DataFrame[3] = 0;
                DataFrame[4] = 0;
                DataFrame[5] = 11;
                DataFrame[6] = 1;
                DataFrame[7] = 16;
                byte[] temp = BitConverter.GetBytes(ID);
                DataFrame[8] = temp[1];
                DataFrame[9] = temp[0];
                DataFrame[10] = 0;
                DataFrame[11] = 2;
                DataFrame[12] = 4;
                byte[] temp1 = BitConverter.GetBytes(Value);
                DataFrame[13] = temp1[1];
                DataFrame[14] = temp1[0];
                DataFrame[15] = temp1[3];
                DataFrame[16] = temp1[2];
                if (SendData(DataFrame) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }




    }
}
