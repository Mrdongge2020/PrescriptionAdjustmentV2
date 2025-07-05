using AdjustmentSys.Tool.FileOpter;
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var service = new ServiceCollection();
            //ConfigureServices(service);
            OperateLog.FileCheck();
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin());
        }



    }
}