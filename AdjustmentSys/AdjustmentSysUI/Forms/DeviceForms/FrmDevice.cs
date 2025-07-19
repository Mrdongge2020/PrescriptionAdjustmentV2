using AdjustmentSys.BLL.Device;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms.Drug;
using AdjustmentSysUI.UITool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmDevice : UIPage
    {
        private string ConfigPath = Application.StartupPath + "\\Config.ini";
        private int _Id;
        DeviceBLL _deviceBLL = new DeviceBLL();
        public FrmDevice()
        {
           
            InitializeComponent();
            InitDgvFormat();
            QueryList();
            ControlOpterUI.SetTitleStyle(this);
        }


        /// <summary>
        /// 设置列表
        /// </summary>
        private void InitDgvFormat()
        {
            //分页列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();

            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "id", true, false, 4, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DeviceCode", "设备编组", true, true, 14, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "设备名称", true, true, 14, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DeviceTypeText", "设备类型", true, true, 14, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "MedicineCabinetCode", "药柜编号", true, true, 14, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "IsEnable", "是否启用", true, true, 14, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "IPAddress", "IP地址", true, true, 14, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 14, "");

        }

        /// <summary>
        /// 查询设备列表信息
        /// </summary>
        public void QueryList()
        {
            var datas = _deviceBLL.GetDeviceInfoList();

            dgvList.DataSource = datas;

            //清除默认选中的行
            dgvList.ClearSelection();
            _Id = 0;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            _Id = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDeviceEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDeviceEdit frmEdit = new FrmDeviceEdit(0);
            frmEdit.Text = "新增设备";
            frmEdit.ShowDialog();
            var issuccess = frmEdit.isSuccess;
            if (issuccess)
            {
                this.ShowSuccessTip("新增设备成功");
                QueryList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Id == 0)
            {
                this.ShowWarningDialog("异常提示", "请先选择要删除的设备信息");
                return;
            }
            if (!this.ShowAskDialog("删除提示", "确定要删除选中的设备信息吗？这将同时删除此设备相关配置信息，不可恢复！", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            var msg = _deviceBLL.DeleteDeviceInfo(_Id);
            if (msg == "")
            {
                this.ShowSuccessTip("删除成功");
                QueryList();
            }
            else
            {
                this.ShowErrorDialog("错误提示", msg);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_Id == 0)
            {
                this.ShowWarningDialog("异常提示", "请先选择要编辑的设备信息");
                return;
            }
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmDeviceEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmDeviceEdit frmEdit = new FrmDeviceEdit(_Id);
            frmEdit.Text = "编辑设备";
            frmEdit.ShowDialog();
            var issuccess = frmEdit.isSuccess;
            if (issuccess)
            {
                this.ShowSuccessTip("编辑设备成功");
                QueryList();
            }
        }

        private void FrmDevice_Load(object sender, EventArgs e)
        {
            //清除默认选中的行
            dgvList.ClearSelection();
            _Id = 0;
        }

        private void btnSetMyself_Click(object sender, EventArgs e)
        {
            if (_Id == 0) 
            {
                this.ShowWarningDialog("异常提示", "请先选择要设置为本机设备的设备信息");
                return;
            }
            var device = _deviceBLL.GetDeviceInfo(_Id);
            if (device == null) 
            {
                this.ShowWarningDialog("异常提示", "设备信息不存在");
                return;
            }
            if (!device.IsEnable)
            {
                this.ShowWarningDialog("异常提示", "设备信息已禁用，不能设为本机，请先启用");
                return;
            }
            
            //设备信息
            SysDeviceInfo.currentDeviceInfo.DeviceName = device.Name;
            SysDeviceInfo.currentDeviceInfo.DeviceId = device.ID;
            SysDeviceInfo.currentDeviceInfo.DeviceConnectStatus = false;
            SysDeviceInfo.currentDeviceInfo.DeviceType = device.DeviceType;// DeviceTypeEnum.半自动袋装;
            SysDeviceInfo.currentDeviceInfo.MedicineCabinetCode = device.MedicineCabinetCode;

            bool isWriteSuccess= IniFileHelper.WriteIniData("DeviceInfo", "DeviceID", device.ID.ToString());
            if (isWriteSuccess) 
            {
                this.ShowSuccessDialog("设备设为本机成功，请重新登录");
            }
        }
    }
}
