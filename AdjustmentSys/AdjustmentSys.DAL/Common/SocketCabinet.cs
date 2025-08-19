using AdjustmentSys.Models.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Common
{
    /// <summary>
    /// 处理Socket监听逻辑
    /// </summary>
    public class SocketCabinet
    {
        public static Socket socketServer;
        public static string IP;

        //   public static int Port;

        public static void StartServer()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 8500));
            socket.Listen(100);
            Task.Run(() =>
            {
                Socket socketClient = socket.Accept();
                while (true)
                {
                    try
                    {
                        //收到客户端消息
                        byte[] buffer = new byte[102];
                        int length = socketClient.Receive(buffer);
                        if (length == 102)
                        {
                            ByteToInt16(buffer, 102, ref MachinePublic.RD600);
                        }
                    }
                    catch (Exception ex)
                    {
                        socket.Close();
                        StartServer();
                    }
                }
            });
        }

        public static void StartClient()
        {


            //实例化一个TCP协议的Socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //服务端的地址和端口
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(IP), 8500);
            try
            {
                //连接远程的服务端
                socket.Connect(iPEndPoint);

            }
            catch (Exception ex)
            {
                socket.Close();
            }
            //循环发送数据
            Task.Run(() =>
            {
                try
                {

                    while (true)
                    {
                        try
                        {
                            if (!socket.Connected)
                            {
                                Thread.Sleep(2000);
                                socket.Close();
                                Thread.Sleep(2000);
                                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                socket.Connect(iPEndPoint);
                            }
                        }
                        catch (Exception ex)
                        {
                            socket.Close();
                        }

                        try
                        {
                            if (MachinePublic.WD600[50] == 1 && socket.Connected)
                            {
                                byte[] buffer = new byte[102];
                                Int16ToByte(MachinePublic.WD600, 51, ref buffer);
                                socket.Send(buffer);
                                MachinePublic.WD600[50] = 0;

                                //等待接收对方发送的数据，返回对方发送数据的长度，数据会存放在buffer里面
                            }
                            Thread.Sleep(500);
                        }
                        catch
                        {
                            socket.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("出现异常：" + ex.Message);
                }
                finally
                {
                    //关闭连接，释放资源
                    socket.Close();
                }
            });



        }
        private static void Int16ToByte(Int16[] arrInt16, int nInt16Count, ref Byte[] destByteArr)
        {
            //遵守X86规则，低字节放在前面，高字节放在后面
            for (int i = 0; i < nInt16Count; i++)
            {
                destByteArr[2 * i + 0] = Convert.ToByte((arrInt16[i] & 0x00FF));
                destByteArr[2 * i + 1] = Convert.ToByte((arrInt16[i] & 0xFF00) >> 8);
            }
        }

        private static void ByteToInt16(Byte[] arrByte, int nByteCount, ref Int16[] destInt16Arr)
        {
            int i = 0;
            try
            {
                //按两个字节一个整数解析，前一字节当做整数低位，后一字节当做整数高位，调用系统函数转化
                for (i = 0; i < nByteCount / 2; i++)
                {
                    Byte[] tmpBytes = new Byte[2] { arrByte[2 * i + 0], arrByte[2 * i + 1] };
                    destInt16Arr[i] = BitConverter.ToInt16(tmpBytes, 0);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Byte to Int16转化错误！i=" + e.Message + i.ToString());
            }
        }


    }
}
