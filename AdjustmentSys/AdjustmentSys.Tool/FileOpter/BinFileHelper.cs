using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

namespace AdjustmentSys.Tool.FileOpter
{
    public static class BinFileHelper
    {
        // 将对象写入二进制文件
        public static void WriteObjectToBinaryFile<T>(string filePath, T objectToWrite) where T : class
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, objectToWrite);
                
                fileStream.Close();
            }
        }

        // 从二进制文件读取对象
        public static T ReadObjectFromBinaryFile<T>(string filePath) where T : class
        {
            T objectRead = null;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                if (fileStream.Length > 0)
                {
                    objectRead = JsonSerializer.Deserialize<T>(fileStream);
                    //BinaryReader reader = new BinaryReader(fileStream);
                    //objectRead = reader.ReadObject() as T;
                    //reader.Close();
                    fileStream.Close();
                }
            }
            return objectRead;
        }
    }
}
