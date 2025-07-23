using AdjustmentSys.DAL.Common;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms.DeviceForms;
using Microsoft.Extensions.DependencyInjection;

namespace AdjustmentSysUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new FrmLogin());
        //}
        [STAThread]
        static void Main(string[] args)
        {
            bool ret;
            System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                #region 初始化信息
                OperateLog.BaseUrl = Application.StartupPath;
                IniFileHelper.filePath = Application.StartupPath + "\\Config.ini";
                IniConfigTB.SetInitData();
                #endregion
                ApplicationConfiguration.Initialize();
                Application.Run(new FrmLogin());
                //  frmMain  为你程序的主窗体，如果是控制台程序不用这句
                m.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。 ", "调剂系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //  提示信息，可以删除。
                Application.Exit();//退出程序
            }
        }



    }
}