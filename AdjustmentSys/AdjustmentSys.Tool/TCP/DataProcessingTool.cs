using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.TCP
{
    public class DataProcessingTool
    {
        public static Int16 ReverseBit16(ref Int16 tag, byte bitIndex, bool trueORFalse)
        {
            Int16 temp = (Int16)(0x01 << (bitIndex - 1));
            if (trueORFalse)
            {
                return (tag |= temp);
            }
            else
            {
                if (((tag >> (bitIndex - 1)) & 0x01) == 1)
                {
                    return (tag &= (byte)(~temp));
                }
                else
                {
                    return tag;
                }
            }
        }
        public static UInt32 ReverseBit32(ref UInt32 tag, byte bitIndex, bool trueORFalse)
        {
            UInt16 temp = (UInt16)(0x01 << (bitIndex - 1));
            if (trueORFalse)
            {
                return (tag |= temp);
            }
            else
            {
                if (((tag >> (bitIndex - 1)) & 0x01) == 1)
                {
                    return (tag &= (byte)(~temp));
                }
                else
                {
                    return tag;
                }
            }
        }
        public static Int16 ByteCheck16(byte[] B400, byte Code1)
        {
            if (B400.Length > Code1 + 3)
            {
                return (Int16)((B400[Code1] << 8) + (B400[Code1 + 1]));
            }
            
            return -1;
        }
        public static UInt16 ByteCheckU16(byte[] B400, byte Code1)
        {
            if (B400.Length > Code1 + 3)
            {
                return (UInt16)((B400[Code1] << 8) + (B400[Code1 + 1]));
            }
            
            return 0;
        }

        public static int ByteCheck32(byte[] B200, byte Code1)
        {
            try
            {
                if (B200.Length > Code1 + 3)
                {
                    return (B200[Code1] << 8) + (B200[Code1 + 1]) + (B200[Code1 + 2] << 24) + (B200[Code1 + 3] << 16);
                }
                return -1;
                
            }
            catch
            {
                return -1;
            }
        }
        public static int[] RfidByteCheck32(byte[] B200, byte Code1)
        {
            try
            {
                int[] value = new int[9];
                int Pvalue;
                for (int i = 0; i < 9; i++)
                {
                    Pvalue = Code1 + (i * 4);
                    if (B200.Length > Pvalue + 3)
                    {
                        value[i] = (B200[Pvalue] << 8) + B200[Pvalue + 1] + (B200[Pvalue + 2] << 24) + (B200[Pvalue + 3] << 16);
                    }
                }

                return value;

            }
            catch
            {
                return null;
            }


        }

        /// <summary>
        ///int 位获取
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <returns></returns>

        public static bool GetBitValue(Int64 value, int index)      //  Bit位判断
        {
            if (index > 63) throw new ArgumentOutOfRangeException("index"); //索引出错
            {

                Int64 val = Value(index);
                return (value & val) == val;
            }
        }
        public static Int64 Value(int index)
        {
            Int64 Newvalue = 1;
            for (int i = 1; i < index; i++)
            {
                Newvalue = Newvalue * 2;
            }

            return Newvalue;
        }

    }
}
