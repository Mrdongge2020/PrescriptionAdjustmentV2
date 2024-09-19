using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.FileOpter
{
    public class IniFileHelper
    {
        #region API函数声明  
        [DllImport("kernel32")]//返回0表示失败，非0为成功   
        
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);     
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度    
        
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);     
        #endregion  
        
        #region 读ini文件    
        public static string ReadIniData(string Section,string Key,string NoText,string iniFilePath)      
        {
            FileExit(iniFilePath);
            if (File.Exists(iniFilePath))     
            {                
                StringBuilder temp = new StringBuilder(1024); 
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);   
                return temp.ToString();     
            }            
            else   
            {             
                return String.Empty;        
            }      
        }       
        #endregion  

        #region 写ini文件   
        public static bool WriteIniData(string Section,string Key,string Value,string iniFilePath)   
        {
            FileExit(iniFilePath);
            if (File.Exists(iniFilePath))     
            {       
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);     
                if (OpStation == 0)       
                {                 
                    return false;         
                }                
                else            
                {               
                    return true;   
                }           
            }          
            else     
            {             
                return false;  
            }        
        }
        #endregion

        private static void FileExit(string filePath)
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
