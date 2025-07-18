﻿using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Device;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmDeviceEdit : UIForm
    {
        private int _Id;
        DeviceBLL _deviceBLL = new DeviceBLL();
        CommonDataBLL _commonDataBLL = new CommonDataBLL();
        public bool isSuccess=false;
        public FrmDeviceEdit(int id)
        {
            InitializeComponent();
            _Id = id;
            InitData();
        }

        private void InitData()
        {
            cbLX.Items.Insert(0, "全自动");
            cbLX.Items.Insert(1, "半自动袋装");
            cbLX.Items.Insert(2, "半自动盒装");
            cbLX.Items.Insert(3, "单工位");
           
            if (_Id == 0)
            {
                txtSBMC.Text = "";
                cbLX.SelectedIndex = 1;
                txtSBBZ.Text = "80000";
                txtSBIP.Text = "";
                txtMECode.Text = "20000";
                rbQY.Checked = true;
                rbJY.Checked = false;
                return;
            }
            var device = _deviceBLL.GetDeviceInfo(_Id);
            if (device != null)
            {
                txtSBMC.Text = device.Name;
                cbLX.SelectedIndex = (int)device.DeviceType;
                txtSBBZ.Text = device.DeviceCode;
                txtSBIP.Text = device.IPAddress;
                cbLX.Enabled= false;
                txtMECode.Text = device.MedicineCabinetCode;
                if (device.IsEnable)
                {
                    rbQY.Checked = true;
                    rbJY.Checked = false;
                }
                else 
                {
                    rbQY.Checked = false;
                    rbJY.Checked = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                return;
            };
            DeviceInfo deviceInfo = new DeviceInfo();
            deviceInfo.ID = _Id;
            deviceInfo.Name = txtSBMC.Text;
            deviceInfo.DeviceCode = txtSBBZ.Text;
            deviceInfo.DeviceType =(DeviceTypeEnum)cbLX.SelectedIndex;
            deviceInfo.IPAddress = txtSBIP.Text;
            deviceInfo.MedicineCabinetCode= txtMECode.Text;
            deviceInfo.IsEnable=rbQY.Checked?true:false;
            string msg = _deviceBLL.AddOrEditDeviceInfo(deviceInfo);
            if (msg == "")
            {
                isSuccess = true;
                this.Close();
            }
            else
            {
                this.ShowErrorDialog("错误提示", msg);
            }
        }

        private bool CheckInfo()
        {
            if (string.IsNullOrEmpty(txtSBMC.Text))
            {
                this.ShowWarningDialog("异常提示", "设备名称不能为空");
                txtSBMC.Focus();
                return false;
            }
            if (cbLX.SelectedIndex==-1)
            {
                this.ShowWarningDialog("异常提示", "请选择设备类型");
                return false;
            }
            if (string.IsNullOrEmpty(txtSBBZ.Text))
            {
                this.ShowWarningDialog("异常提示", "设备编组不能为空");
                txtSBBZ.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtMECode.Text))
            { 
                var codes = _commonDataBLL.GetMedicineCabinetCodes();
                if (codes != null && codes.Count > 0)
                {
                    if (!codes.Contains(txtMECode.Text))
                    {
                        this.ShowWarningDialog("异常提示", "药柜编组信息在系统不存在");
                        txtMECode.Focus();
                        return false;
                    }
                }
                else 
                {
                    this.ShowWarningDialog("异常提示", "药柜编组信息在系统不存在");
                    txtMECode.Focus();
                    return false;
                }
            }
            else
            {
                this.ShowWarningDialog("异常提示", "药柜编组不能为空");
                txtMECode.Focus();
                return false;
            }
           
            return true;
        }
    }
}
