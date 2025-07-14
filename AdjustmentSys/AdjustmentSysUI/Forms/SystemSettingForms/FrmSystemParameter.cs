using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.DAL.Common;
using AdjustmentSys.IService;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.UITool;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    public partial class FrmSystemParameter : UIPage
    {
        SystemParameterBLL systemParameterBLL = new SystemParameterBLL();
        private bool canTriggerEvent = false;
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

            foreach (var item in PrintConfigTB.PrintItemInfos)
            {
                DataGridViewRow Result = new DataGridViewRow();
                Result.CreateCells(uiDataGridView1);

                if (item.CheckedValue == 3 || item.CheckedValue == 1)
                {
                    Result.Cells[0].Value = true;
                }
                else
                {
                    Result.Cells[0].Value = false;
                }
                if (item.CheckedValue == 3 || item.CheckedValue == 2)
                {
                    Result.Cells[1].Value = true;
                }
                else
                {
                    Result.Cells[1].Value = false;
                }
                Result.Cells[2].Value = item.ItemChineseName.ToString();
                Result.Cells[3].Value = item.ItemName;
                uiDataGridView1.Rows.Add(Result);
            }

            LoaduiDataGridView2();

            LoaduiDataGridView3();

            if (PrintConfigTB.Automainpaper)
            {
                chbIsPrintMainTag.Checked = true;
            }
            else 
            { 
                chbIsPrintMainTag.Checked = false;
            }
            switch (PrintConfigTB.Automodepapertype) 
            {
                case 0:
                    uiRadioButton1.Checked = true;
                    uiRadioButton2.Checked = false;
                    uiRadioButton3.Checked = false;
                    break;
                case 1:
                    uiRadioButton1.Checked = false;
                    uiRadioButton2.Checked = true;
                    uiRadioButton3.Checked = false;
                    break;
                case 2:
                    uiRadioButton1.Checked = false;
                    uiRadioButton2.Checked = false;
                    uiRadioButton3.Checked = true;
                    break;
            }
            canTriggerEvent = true;
        }
        private void LoaduiDataGridView2()
        {
            if (uiDataGridView2.Rows.Count > 0)
            {
                uiDataGridView2.Rows.Clear();
            }
            foreach (var item in PrintConfigTB.PrintItemInfos.Where(x => x.CheckedValue > 0).OrderBy(x => x.Sort).ToList())
            {
                DataGridViewRow Result = new DataGridViewRow();
                Result.CreateCells(uiDataGridView2);
                Result.Height = 30;
                Result.Cells[0].Value = item.ItemChineseName;
                Result.Cells[1].Value = item.Sort;
                Result.Cells[2].Value = item.Title;
                Result.Cells[3].Value = "保存";
                Result.Cells[4].Value = item.ItemName;
                uiDataGridView2.Rows.Add(Result);
            }
        }

        private void LoaduiDataGridView3()
        {
            if (uiDataGridView3.Rows.Count > 0)
            {
                uiDataGridView3.Rows.Clear();
            }
            foreach (var item in PrintConfigTB.PrintConfigs)
            {
                DataGridViewRow Result = new DataGridViewRow();
                Result.CreateCells(uiDataGridView3);
                Result.Height = 30;
                Result.Cells[0].Value = item.ItemChineseName;
                Result.Cells[1].Value = item.DataValue;
                Result.Cells[2].Value = "保存";
                Result.Cells[3].Value = item.ItemName;
                uiDataGridView3.Rows.Add(Result);
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            //获取DataGridView中CheckBox的Cell
            DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(this.dgvList.Rows[this.dgvList.CurrentCell.RowIndex].Cells[0]);

            //获取被选中列的相关信息

            string name = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();


            //根据单击时，Cell的值进行处理。EditedFormattedValue和Value均可以

            //若单击时，CheckBox没有被勾上
            string error = "";
            if (Convert.ToBoolean(dgvCheck.EditedFormattedValue))
            {
                error = systemParameterBLL.UpdateConfigValue(name, "1");
                if (error == "")
                {
                    dgvList.Rows[e.RowIndex].Cells[0].Value = true;
                    ShowSuccessTip(name + "启用成功");
                }
            }
            //若单击时，CheckBox已经被勾上
            else
            {
                error = systemParameterBLL.UpdateConfigValue(name, "0");
                if (error == "")
                {
                    dgvList.Rows[e.RowIndex].Cells[0].Value = false;
                    ShowSuccessTip(name+"禁用成功");
                }
            }
            if (error != "")
            {
                ShowErrorDialog(name + "操作出现异常，原因:" + error);
                return;
            }

            ConfigTB.SetConfigData();
        }

        private void dgvList1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 2) { return; }
            string buttonText = this.dgvList1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (buttonText == "保存")
            {

                string name = dgvList1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string data = dgvList1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string msg = DataCheck(name, data);
                if (msg == "")
                {
                    string error = systemParameterBLL.UpdateConfigValue(name, data);
                    if (error == "")
                    {
                        ShowSuccessTip(name+"保存成功");
                        ConfigTB.SetConfigData();
                    }
                    else
                    {
                        ShowErrorDialog(name+"保存失败，原因:" + error);
                    }
                }
                else
                {
                    ShowErrorDialog(name+"保存失败，原因:" + msg);
                }

            }
        }

        private string DataCheck(string name, string dvalue)
        {
            var config = ConfigTB.ConfigInfos.FirstOrDefault(x => x.ChineseName == name);
            if (config == null)
            {
                return "未找到改配置信息";
            }
            if (string.IsNullOrEmpty(dvalue) && config.DataValueType != "string")
            {
                return "该数据不能为空";
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
            else if (config.DataValueType == "bool")
            {
                if (dvalue != "0" && dvalue != "1")
                {
                    return "该数据只能是数字(0或1)";
                }
            }
            return "";
        }
        private string PrintDataCheck(string name, string dvalue)
        {
            var config = PrintConfigTB.PrintConfigs.FirstOrDefault(x => x.ItemChineseName == name);
            if (config == null)
            {
                return "未找到改配置信息";
            }
            if (string.IsNullOrEmpty(dvalue) && config.DataValueType != "string") 
            {
                return "该数据不能为空";
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
            } else if (config.DataValueType == "bool" )
            {
                if (dvalue!="0" && dvalue!="1")
                {
                    return "该数据只能是数字(0或1)";
                }
            }
            return "";
        }

        private void FrmSystemParameter_Load(object sender, EventArgs e)
        {
            InitDgvFormat();
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || this.uiDataGridView1.CurrentCell.ColumnIndex == 2) { return; }
            DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(this.uiDataGridView1.Rows[this.uiDataGridView1.CurrentCell.RowIndex].Cells[0]);
            DataGridViewCheckBoxCell dgvCheck1 = (DataGridViewCheckBoxCell)(this.uiDataGridView1.Rows[this.uiDataGridView1.CurrentCell.RowIndex].Cells[1]);
            if (this.uiDataGridView1.CurrentCell.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dgvCheck.EditedFormattedValue) == false)
                {
                    uiDataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    uiDataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
                }
            }
            if (this.uiDataGridView1.CurrentCell.ColumnIndex == 1)
            {
                if (Convert.ToBoolean(dgvCheck1.EditedFormattedValue) == false)
                {
                    uiDataGridView1.Rows[e.RowIndex].Cells[1].Value = true;
                }
                else
                {
                    uiDataGridView1.Rows[e.RowIndex].Cells[1].Value = false;
                }
            }

            //获取被选中列的相关信息
            string chinesename = uiDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            bool bool1 = Convert.ToBoolean(dgvCheck.EditedFormattedValue);
            bool bool2 = Convert.ToBoolean(dgvCheck1.EditedFormattedValue);

            int combinedValue = (bool1 ? 1 : 0) | (bool2 ? 1 : 0) << 1;
            string error = systemParameterBLL.UpdatePrintItemValue(chinesename, null, null, combinedValue);
            if (error == "")
            {
                ShowSuccessTip(chinesename + "操作成功");
                PrintConfigTB.SetPrintItemData();
                LoaduiDataGridView2();
            }
            else
            {
                ShowErrorDialog(chinesename+"操作失败，原因:" + error);
            }
        }

        private void uiDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 3) { return; }
            string buttonText = this.uiDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (buttonText == "保存")
            {

                string chinesename = uiDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sort = uiDataGridView2.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string title = uiDataGridView2.Rows[e.RowIndex].Cells[2].Value?.ToString();
                if (string.IsNullOrEmpty(sort)) 
                {
                    ShowErrorDialog("排序不能为空");
                    return;
                }
                if (!double.TryParse(sort, out double s) || s<0)
                {
                    ShowErrorDialog("排序请输入整数或2位小数的数字");
                    return;
                }
                if (string.IsNullOrEmpty(title))
                {
                    title = "";
                }
                string error = systemParameterBLL.UpdatePrintItemValue(chinesename, s, title, null);
                if (error == "")
                {
                    ShowSuccessTip(chinesename+"保存成功");
                    PrintConfigTB.SetPrintItemData();
                    LoaduiDataGridView2();
                }
                else
                {
                    ShowErrorDialog(chinesename+"操作失败，原因:" + error);
                }
            }
        }

        private void uiDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 2) { return; }
            string buttonText = this.uiDataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (buttonText == "保存")
            {

                string name = uiDataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                string data = uiDataGridView3.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string msg = PrintDataCheck(name, data);
                if (msg == "")
                {
                    string error = systemParameterBLL.UpdatePrintConfigValue(name, data);
                    if (error == "")
                    {
                        ShowSuccessTip(name+"保存成功");
                        PrintConfigTB.SetConfigData();
                    }
                    else
                    {
                        ShowErrorDialog(name + "保存失败，原因:" + error);
                    }
                }
                else
                {
                    ShowErrorDialog(name + "保存失败，原因:" + msg);
                }

            }
        }

        private void chbIsPrintMainTag_CheckedChanged(object sender, EventArgs e)
        {
            string checkValue = "";
            if (chbIsPrintMainTag.Checked)
            {
                PrintConfigTB.Automainpaper = true;
                checkValue = "1";
            }
            else
            {
                PrintConfigTB.Automainpaper = false;
                checkValue = "0";
            }

            string error = systemParameterBLL.UpdatePrintConfigValue("是否自动打印处方主标签", checkValue);
            if (error == "")
            {
                ShowSuccessTip($"是否自动打印处方主标签设置成功");
            }
            else
            {
                ShowErrorDialog("操作出现异常，原因:" + error);
                return;
            }

            PrintConfigTB.SetConfigData();
            LoaduiDataGridView3();
        }

        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton1.Checked)
            {
                //radioButton2.Checked = false;
                //radioButton3.Checked = false;
                PrintConfigTB.Automodepapertype = 0;
                SrtPrintType("处方打印方式", "0");
            }
        }

        private void uiRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton2.Checked)
            {
                //radioButton2.Checked = false;
                //radioButton3.Checked = false;
                PrintConfigTB.Automodepapertype = 1;
                SrtPrintType("处方打印方式", "1");
            }
        }

        private void uiRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton3.Checked)
            {
                //radioButton2.Checked = false;
                //radioButton3.Checked = false;
                PrintConfigTB.Automodepapertype = 2;
                SrtPrintType("处方打印方式", "2");
            }
        }

        private void SrtPrintType(string name,string value) 
        {
            if (!canTriggerEvent) { return; }
            string error = systemParameterBLL.UpdatePrintConfigValue(name, value);
            if (error == "")
            {
                ShowSuccessTip("处方打印方式设置成功");
            }
            else
            {
                ShowErrorDialog(name + "操作出现异常，原因:" + error);
                return;
            }

            PrintConfigTB.SetConfigData();
            LoaduiDataGridView3();
        }
    }
}
