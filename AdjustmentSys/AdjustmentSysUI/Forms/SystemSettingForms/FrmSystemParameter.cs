using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.DAL.Common;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Tool.Enums;
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

namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    public partial class FrmSystemParameter : UIPage
    {
        SystemParameterBLL systemParameterBLL = new SystemParameterBLL();

        public FrmSystemParameter()
        {

            InitializeComponent();
            ControlOpterUI.SetTitleStyle(this);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void InitDgvFormat()
        {
            //分页列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvList1.AutoGenerateColumns = false;//不自动生成列
            dgvList1.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList1.AllowUserToResizeRows = false;
            dgvList1.AllowUserToResizeColumns = false;
            dgvList1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            foreach (var item in ConfigTB.ConfigInfos)
            {
                DataGridViewRow Result = new DataGridViewRow();
                if (item.DataValueType == "bool")
                {

                    Result.CreateCells(dgvList);
                    Result.Cells[0].Value = item.DataValue.Trim() == "1" ? true : false;
                    Result.Cells[1].Value = item.ChineseName;
                    Result.Cells[2].Value = item.Name;
                    dgvList.Rows.Add(Result);
                }
                else
                {
                    Result.CreateCells(dgvList1);
                    Result.Cells[0].Value = item.ChineseName;
                    Result.Cells[1].Value = item.DataValue;
                    Result.Cells[2].Value = "保存";
                    Result.Cells[3].Value = item.Name;
                    dgvList1.Rows.Add(Result);
                }
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            //获取DataGridView中CheckBox的Cell
            DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(this.dgvList.Rows[this.dgvList.CurrentCell.RowIndex].Cells[0]);

            //获取被选中列的相关信息

            string name = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();


            //根据单击时，Cell的值进行处理。EditedFormattedValue和Value均可以

            //若单击时，CheckBox没有被勾上
            string error = "";
            if (Convert.ToBoolean(dgvCheck.EditedFormattedValue))
            {
                error = systemParameterBLL.UpdateConfigValue(name, "1");
                if (error == "")
                {
                    dgvList.Rows[e.RowIndex].Cells[0].Value = true;
                    ShowSuccessTip("启用成功");
                }
            }
            //若单击时，CheckBox已经被勾上
            else
            {
                error = systemParameterBLL.UpdateConfigValue(name, "0");
                if (error == "")
                {
                    dgvList.Rows[e.RowIndex].Cells[0].Value = false;
                    ShowSuccessTip("禁用成功");
                }
            }
            if (error != "")
            {
                ShowErrorDialog("操作出现异常，原因:" + error);
                return;
            }

            ConfigTB.SetConfigData();
        }

        private void dgvList1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            string buttonText = this.dgvList1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (buttonText == "保存")
            {

                string name = dgvList1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string data = dgvList1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string msg = DataCheck(name, data);
                if (msg == "")
                {
                    string error = systemParameterBLL.UpdateConfigValue(name, data);
                    if (error == "")
                    {
                        ShowSuccessTip("保存成功");
                        ConfigTB.SetConfigData();
                    }
                    else
                    {
                        ShowErrorDialog("保存失败，原因:" + error);
                    }
                }
                else
                {
                    ShowErrorDialog("保存失败，原因:" + msg);
                }

            }
        }

        private string DataCheck(string name, string dvalue)
        {
            var config = ConfigTB.ConfigInfos.FirstOrDefault(x => x.Name == name);
            if (config == null)
            {
                return "未找到改配置信息";
            }
            //根据特性中的默认值给属性赋值
            if (config.DataValueType == "int")
            {
                if (!int.TryParse(dvalue, out int value1))
                {
                    return "该数据只能是整数数字类型";
                }
                if (config.DataValuMin != config.DataValuMax && (value1 < config.DataValuMin || value1 > config.DataValuMax))
                {
                    return $"该数据只能是介于[{config.DataValuMin}]~[{config.DataValuMax}]的整数数字";
                }
            }
            else if (config.DataValueType == "double" || config.DataValueType == "float")
            {
                if (!int.TryParse(dvalue, out int value1))
                {
                    return "该数据只能是数字类型";
                }
                if (config.DataValuMin != config.DataValuMax && (value1 < config.DataValuMin || value1 > config.DataValuMax))
                {
                    return $"该数据只能是介于[{config.DataValuMin}]~[{config.DataValuMax}]的数字";
                }
            }
            return "";
        }

        private void FrmSystemParameter_Load(object sender, EventArgs e)
        {
            InitDgvFormat();
        }
    }
}
