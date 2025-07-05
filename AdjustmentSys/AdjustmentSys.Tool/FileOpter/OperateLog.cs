using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AdjustmentSys.Tool.Enums;
using System.ComponentModel;
using NPOI.SS.Formula.Functions;

namespace AdjustmentSys.Tool.FileOpter
{
    public class OperateLog
    {
        public static void WriteLog(LogTypeEnum logtype, string logContent) 
        {
            Action action = () =>
            {
                //获取日志地址
                string logUrl = $"Logs\\{logtype.ToString()}s\\{logtype.ToString()}{DateTime.Now.ToString("yyyyMMdd")}.log";

                Task.Run(() =>
                {
                    try
                    {
                        if (!IsFileInUse(logUrl))
                        {
                            FileStream fs = new FileStream(logUrl, FileMode.Append);
                            lock (fs)
                            {
                                StreamWriter sw = new StreamWriter(fs);
                                sw.WriteLine("【" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "】 " + logContent);
                                sw.Close();
                                fs.Close();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Write_SystemException(logContent);
                    }
                });
            };
        }



        public static void Write_SystemException(string logContent)
        {
            Action action = () =>
            {
                //获取日志地址
                string logUrl = $"Logs\\{LogTypeEnum.系统异常.ToString()}s\\{LogTypeEnum.系统异常.ToString()}{DateTime.Now.ToString("yyyyMMdd")}.log";

                Task.Run(() =>
                {
                    try
                    {
                        if (!IsFileInUse(logUrl))
                        {
                            FileStream fs = new FileStream(logUrl, FileMode.Append);
                            lock (fs)
                            {
                                StreamWriter sw = new StreamWriter(fs);
                                sw.WriteLine("【" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "】 " + logContent);
                                sw.Close();
                                fs.Close();
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                });
            };
        }

        public static void FileCheck()
        {
            try
            {
               // Action action = () => {
                    foreach (FieldInfo fi in typeof(LogTypeEnum).GetFields())
                    {
                        var attribute = Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
                        if (attribute != null)
                        {
                            string logUrl = $"Logs\\{((DescriptionAttribute)attribute).Description}s\\{((DescriptionAttribute)attribute).Description}{DateTime.Now.ToString("yyyyMMdd")}.log";
                            FileInfo fileInfo = new FileInfo(logUrl);
                            string directory = Path.GetDirectoryName(fileInfo.FullName);

                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            if (!fileInfo.Exists)
                            {
                                using (FileStream fs = fileInfo.Create())
                                {
                                    // 操作文件
                                }

                            }
                            else
                            {
                                string pat = $"{((DescriptionAttribute)attribute).Description}*.log";

                                DeleteLoginFile(directory, pat, 7);
                            }
                        }
                    }
               // };
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 删除超期的日志文件
        /// </summary>
        /// <param name="logDirectory"></param>
        /// <param name="pattern"></param>
        public static void DeleteLoginFile(string logDirectory, string pattern,int limit)
        {
            //string logDirectory = @"C:\path\to\logs"; // 日志文件夹路径
            //string pattern = "log-*.txt"; // 日志文件模式匹配
            var logFiles = Directory.GetFiles(logDirectory, pattern)
                               .OrderByDescending(f => new FileInfo(f).CreationTime) // 按创建时间排序
                               .Skip(limit) // 跳过最新的两个文件
                               .ToList(); // 获取要删除的文件列表
            if (logFiles != null && logFiles.Count > 0)
            {
                foreach (var file in logFiles)
                {
                    File.Delete(file); // 删除文件
                }
            }
        }

        /// <summary>
        /// 获取目录下全部日志
        /// </summary>
        /// <param name="logDirectory">目录</param>
        /// <param name="pattern">匹配字符串</param>
        /// <returns></returns>
        public static List<string> GetFiles(string logDirectory, string pattern)
        {
            //string logDirectory = @"C:\path\to\logs"; // 日志文件夹路径
            //string pattern = "log-*.txt"; // 日志文件模式匹配
            var logFiles = Directory.GetFiles(logDirectory, pattern)
                               .OrderByDescending(f => new FileInfo(f).CreationTime) // 按创建时间排序
                               .ToList(); // 获取要删除的文件列表
            if (logFiles != null && logFiles.Count > 0)
            {
                return logFiles;
            }
            else 
            { 
                return null;
            }
        }


        /// <summary>
        /// true表示正在使用,false没有使用
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return inUse;
        }
    }

}