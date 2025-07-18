﻿using AdjustmentSys.BLL.Device;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.DAL.Common;
using AdjustmentSys.IService;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms;
using AdjustmentSysUI.Forms.UserForms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AdjustmentSysUI
{
    public partial class FrmLogin : UILoginForm
    {
        //private string ConfigPath = Application.StartupPath + "\\Config.ini";
        private UserInfoBLL  _userInfoBLL=new UserInfoBLL();
        public FrmLogin()
        {
            InitializeComponent();
            UserName = "admin";
            Password = "111111";            
        }

        private void FrmLogin_ButtonLoginClick(object sender, System.EventArgs e)
        {
            string name = UserName;
            if (string.IsNullOrEmpty(name)) 
            {
                this.ShowWarningDialog("登录用户名不能为空");    
                return;
            }
            string pwd = Password;
            if (string.IsNullOrEmpty(pwd))
            {
                this.ShowWarningDialog("登录密码不能为空");
                return;
            }
            var user = _userInfoBLL.Login(name, pwd);
            
            if (user!=null)
            {
                this.ShowSuccessTip("登录成功");
                //登录信息
                #region 登录信息
                IsLogin = true;
                SysLoginUser.currentUser.UserId = user.ID;
                SysLoginUser.currentUser.UserName = name;
                SysLoginUser.currentUser.UserLevelId = user.UserLevel;
                SysLoginUser.currentUser.UserLevelName = user.UserLevelName;
                SysLoginUser.currentUser.UserPhone = user.Phone;
                #endregion

                #region 设备,药柜信息

                //设备信息
                string deviceid = IniFileHelper.ReadIniData("DeviceInfo", "DeviceID");
                if (!string.IsNullOrEmpty(deviceid))
                {
                    DeviceBLL _deviceBLL = new DeviceBLL();
                    var device = _deviceBLL.GetDeviceInfo(int.Parse(deviceid));
                    if (device == null)
                    {
                        //设备信息
                        SysDeviceInfo.currentDeviceInfo.DeviceName = "无";
                        SysDeviceInfo.currentDeviceInfo.DeviceId = 1;
                        SysDeviceInfo.currentDeviceInfo.DeviceConnectStatus = false;
                        SysDeviceInfo.currentDeviceInfo.DeviceType = DeviceTypeEnum.半自动袋装;
                        SysDeviceInfo.currentDeviceInfo.MedicineCabinetCode = "20000";
                    }
                    else
                    {
                        if (!device.IsEnable)
                        {
                            this.ShowWarningDialog("异常提示", "设备信息已禁用，请先启用");
                        }
                        //设备信息
                        SysDeviceInfo.currentDeviceInfo.DeviceName = device.Name;
                        SysDeviceInfo.currentDeviceInfo.DeviceId = device.ID;
                        SysDeviceInfo.currentDeviceInfo.DeviceConnectStatus = false;
                        SysDeviceInfo.currentDeviceInfo.DeviceType = device.DeviceType;// DeviceTypeEnum.半自动袋装;
                        SysDeviceInfo.currentDeviceInfo.MedicineCabinetCode = device.MedicineCabinetCode;
                    }
                }
                else
                {
                    SysDeviceInfo.currentDeviceInfo.DeviceName = "无";
                    SysDeviceInfo.currentDeviceInfo.DeviceId = 1;
                    SysDeviceInfo.currentDeviceInfo.DeviceConnectStatus = false;
                    SysDeviceInfo.currentDeviceInfo.DeviceType = DeviceTypeEnum.半自动袋装;
                    SysDeviceInfo.currentDeviceInfo.MedicineCabinetCode = "20000";
                }

                //药柜信息
                MedicineCabinetInfoBLL medicineCabinetInfoBLL = new MedicineCabinetInfoBLL();
                var mcinfos=medicineCabinetInfoBLL.GetCabinetInfoList();
                if (mcinfos != null && mcinfos.Count > 0)
                {
                    SysDeviceInfo.currentDeviceInfo.LargeCabinetCount = mcinfos.Count(x => x.Specifications == "大药柜");
                    SysDeviceInfo.currentDeviceInfo.SmallCabinetCount = mcinfos.Count(x => x.Specifications == "小药柜");
                }
                else 
                {
                    SysDeviceInfo.currentDeviceInfo.LargeCabinetCount = 0;
                    SysDeviceInfo.currentDeviceInfo.SmallCabinetCount = 0;
                }
                #endregion
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();

            }
            else
            {
                this.ShowErrorDialog("用户名或者密码错误。");
                return;
            }
        }
    }

    
}
