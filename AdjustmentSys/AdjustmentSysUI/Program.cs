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
                #region ��ʼ����Ϣ
                OperateLog.BaseUrl = Application.StartupPath;
                IniFileHelper.filePath = Application.StartupPath + "\\Config.ini";
                IniConfigTB.SetInitData();
                #endregion
                ApplicationConfiguration.Initialize();
                Application.Run(new FrmLogin());
                //  frmMain  Ϊ�����������壬����ǿ���̨���������
                m.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(null, "��һ���ͱ�������ͬ��Ӧ�ó����Ѿ������У��벻Ҫͬʱ���ж��������\n\n������򼴽��˳��� ", "����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //  ��ʾ��Ϣ������ɾ����
                Application.Exit();//�˳�����
            }
        }



    }
}