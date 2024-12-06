using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSys.Tool.TCP;
using AdjustmentSysUI.Forms.DeviceForms;
using AdjustmentSysUI.Forms.Drug;
using AdjustmentSysUI.Forms.DrugForms;
using AdjustmentSysUI.Forms.MedicineCabinetForms;
using AdjustmentSysUI.Forms.Pharmacopoeia;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.Forms.SystemSettingForms;
using AdjustmentSysUI.Forms.UserForms;
using Sunny.UI;
using Sunny.UI.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms
{
    public partial class FrmMain : UIForm
    {
        ModBusTCP_Cliect modBusTCP_Cliect = new ModBusTCP_Cliect();
        public FrmMain()
        {
            //TestFile();
            InitializeComponent();
            int pageIndex = 100;
            TreeNode parent = navMenuMainLeft.CreateNode("调剂管理", 558167, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmBoxedDevice(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmBoxedDevice1(), ++pageIndex));
            

            pageIndex = 200;
            parent = navMenuMainLeft.CreateNode("系统管理", 362718, 28, pageIndex);

            //通过设置PageIndex关联，节点文字、图标由相应的Page的Text、Symbol提供
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmUser(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDoctor(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDocDepartment(), ++pageIndex));


            pageIndex = 300;
            parent = navMenuMainLeft.CreateNode("药品管理", 361617, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugManagement(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugCompatibilityRuler(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugManufacturer(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugLog(), ++pageIndex));
            

            pageIndex = 400;
            parent = navMenuMainLeft.CreateNode("设备管理", 358723, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDevice(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmBoxedDeviceTest(), ++pageIndex));


            pageIndex = 500;
            parent = navMenuMainLeft.CreateNode("药柜管理", 358587, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMedicineCabinet(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMedicineCabinetManage(), ++pageIndex));

            pageIndex = 600;
            parent = navMenuMainLeft.CreateNode("处方管理", 361788, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmPrescriptionList(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmAgreementPrescriptionManager(), ++pageIndex));

            pageIndex = 700;
            parent = navMenuMainLeft.CreateNode("系统设置", 363449, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmSystemParameter(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMenu(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmColorful(), ++pageIndex));


            //登录用户信息
            lblLoginUser.Text = "当前用户:" + SysLoginUser._currentUser.UserName + " " + SysLoginUser._currentUser.UserLevelName;
            //主题设置
            SetTitle();
        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            this.lbltime.Text = DateTime.Now.DateTimeString();
        }

        private void SetTitle()
        {
            UIStyles.InitColorful(Color.DarkGray, Color.White);
            UIStyles.DPIScale = true;
            UIStyles.GlobalFont = true;
            UIStyles.GlobalFontName = "微软雅黑";
            UIStyles.GlobalFontScale = 100;
            UIStyles.SetDPIScale();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ModBusTCP_Cliect.port = 502;
            switch (SysDeviceInfo._currentDeviceInfo.DeviceType)
            {
                
                case DeviceTypeEnum.全自动:
                    {
                        ModBusTCP_Cliect.ip = "192.168.1.6";

                    }
                    break;
                case DeviceTypeEnum.半自动盒装:
                    {
                        ModBusTCP_Cliect.ip = "192.168.0.1";

                    }
                    break;
                case DeviceTypeEnum.半自动袋装:
                    {
                        ModBusTCP_Cliect.ip = "192.168.0.1";
                    }
                    break;
                    //case DeviceTypeEnum.半自动袋装:
                    //    {
                    //        ModBusTCP_Cliect.ip = "192.168.0.1";
                    //    }
                    //    break;

            }
            lblDeviceName.Text = $"设备名称：{SysDeviceInfo._currentDeviceInfo.DeviceName}";
            Thread thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 通讯线程
        /// </summary>
        private void CrossThreadFlush()
        {
            //Form1_Mian.objModBusTCP_Cliect = new ModBusTCP_Cliect();
            //Form1_Mian.DeviceConnentionState = ModBusTCP_Cliect.ConnState;
            //ModBusTCP_Cliect modBusTCP_Cliect = new ModBusTCP_Cliect();
            SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
            while (true)
            {
                ThreadFunction();
                //MethodInvoker setstate = new MethodInvoker(Setstate);
                //Invoke(setstate);
                Thread.Sleep(1000);

            }
        }

        private void ThreadFunction()
        {
            MachinePublic.ConnectionState = SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus;//Form1_Mian.DeviceConnentionState;
            if (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
            {
                if (lblDeviceConnectText.Text != "已连接")
                {
                    this.Invoke(new Action(() =>
                    {
                        lblDeviceConnectText.Text = "已连接";
                        lblDeviceConnectText.ForeColor = Color.Blue;
                    }));
                } 
            }
            else
            {
                if (lblDeviceConnectText.Text != "未连接")
                {
                    this.Invoke(new Action(() =>
                    {
                        lblDeviceConnectText.Text = "未连接";
                        lblDeviceConnectText.ForeColor = Color.Red;
                    }));
                }                
            }

            if (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus == false)
            {
                modBusTCP_Cliect.Connent();
                SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;     
            }

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool result = ShowAskDialog( "退出提示", "确定退出系统吗？退出后将结束所有任务", UIStyle.Blue, false, UIMessageDialogButtons.Ok);
            if (result)
            {
                this.ExitApp();
            }
            else
            {
                e.Cancel = true;//手动取消事件
            }
        }
        //程序退出
        private void ExitApp()
        {
            Process.GetCurrentProcess().Kill();
            Application.ExitThread();
            Application.Exit();
            Environment.Exit(Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

    }
}
