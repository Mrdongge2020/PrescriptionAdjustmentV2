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
    public  class BinFileHelper
    {
        // 将对象写入二进制文件
        public static void WriteObjectToBinaryFile<T>(string filePath, T objectToWrite) where T : class
        {
            FileExit(filePath);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, objectToWrite);
                
                fileStream.Close();
            }
        }

        // 从二进制文件读取对象
        public static T ReadObjectFromBinaryFile<T>(string filePath) where T : class
        {
            FileExit(filePath);
            T objectRead = null;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                if (fileStream.Length > 0)
                {
                    objectRead = JsonSerializer.Deserialize<T>(fileStream);
                    fileStream.Close();
                }
            }
            return objectRead;
        }

        private static  void FileExit(string filePath) 
        {
            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                // 文件不存在，创建文件
                using (File.Create(filePath))
                {
                    // 文件创建后，在此处可以添加额外的处理代码
                }
            }
        }
    }
}
