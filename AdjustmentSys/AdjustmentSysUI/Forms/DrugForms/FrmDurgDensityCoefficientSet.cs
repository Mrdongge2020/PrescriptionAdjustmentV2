using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Models.CommModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdjustmentSysUI.Forms.DrugForms
{
    public partial class FrmDurgDensityCoefficientSet : UIForm
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        public FrmDurgDensityCoefficientSet()
        {
            InitializeComponent();
            BindInitData();
        }

        private void BindInitData()
        {
            //厂家
            List<ComboxModel> mDatas = _comboxDataBLL.GetManufacturerComboxData();
            cbCJ.ValueMember = "Id";
            cbCJ.DisplayMember = "Name";
            cbCJ.DataSource = mDatas;
            cbCJ.SelectedIndex = -1;

            //dgv列

            //列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.RowHeadersVisible = false;
        }

        private void QueryParticleDatas()
        {
            int? cjId = null;
            if (cbCJ.SelectedIndex != -1)
            {
                cjId = int.Parse(cbCJ.SelectedValue.ToString());
            }
            var datas = _drugManagermentBLL.GetParticlesByNameOrManufacturerId(txtName.Text, cjId);

            dgvList.DataSource = datas;
        }

        private void FrmDurgDensityCoefficientSet_Load(object sender, EventArgs e)
        {
            QueryParticleDatas();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            QueryParticleDatas();
        }

        private void btnCJXG_Click(object sender, EventArgs e)
        {
            if (cbCJ.SelectedValue == null || (int)cbCJ.SelectedValue <= 0)
            {
                this.ShowWarningDialog("异常提示", "请选择厂家");
                return;
            }
            if (dudNumber.Value <= 0)
            {
                this.ShowWarningDialog("异常提示", "系数调整值必须大于0");
                dudNumber.Focus();
                return;
            }
            var ids = CheckedIds();
            if (ids == null || ids.Count <= 0)
            {
                this.ShowWarningDialog("异常提示", "该厂家没有需要修改的数据");
                return;
            }

            string msg = _drugManagermentBLL.UpdateParticlesDensityCoefficient(ids, (float)dudNumber.Value);
            if (msg == "")
            {
                this.ShowSuccessTip("批量修改成功");
            }
            else
            {
                this.ShowErrorDialog("批量修改失败:" + msg);
            }
        }

        private void checkedOpter()
        {
            if (cbSelectAll.Checked)
            {
                //结束列表的编辑状态,否则可能无法改变CheckBox的状态
                dgvList.EndEdit();
                for (var i = 0; i < dgvList.Rows.Count; i++)
                {
                    dgvList.Rows[i].Cells[0].Value = true;//设置为选中状态
                }
            }
            else
            {
                //结束列表的编辑状态,否则可能无法改变CheckBox的状态
                dgvList.EndEdit();
                for (var i = 0; i < dgvList.Rows.Count; i++)
                {
                    dgvList.Rows[i].Cells[0].Value = false;//设置为取消选中状态
                }
            }
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            checkedOpter();
        }

        private void cbCJ_SelectedValueChanged(object sender, EventArgs e)
        {
            QueryParticleDatas();
            if (cbCJ.SelectedValue != null && (int)cbCJ.SelectedValue > 0)
            {
                cbSelectAll.Checked = true;
            }
            else
            {
                cbSelectAll.Checked = false;

            }
            cbSelectAll_CheckedChanged(cbSelectAll, new EventArgs());
            txtName.Focus();
        }

        /// <summary>
        /// 获取选中的id
        /// </summary>
        /// <returns></returns>
        private List<int> CheckedIds()
        {
            List<int> ids = new List<int>();
            for (var i = 0; i < dgvList.Rows.Count; i++)
            {
                if (dgvList.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    int particlesID = int.Parse(dgvList.Rows[i].Cells["ID"].Value.ToString());
                    ids.Add(particlesID);
                }
            }
            return ids;
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            //非列头点击，只选择一行
            DataGridViewCell cell = this.dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.GetType() == typeof(DataGridViewButtonCell))
            {
                try
                {
                    float value;
                    bool flag = float.TryParse(this.dgvList.Rows[e.RowIndex].Cells["DensityCoefficient"].Value.ToString(), out value);
                    if (!flag || value <= 0 || value > 2)
                    {
                        this.ShowWarningDialog("异常提示", "密度系数只能是大于0且小于2的数值");
                        this.dgvList.CurrentCell = dgvList.Rows[e.RowIndex].Cells["DensityCoefficient"]; //设置当前单元格
                        dgvList.BeginEdit(true); //设置可编辑状态
                        return;
                    }
                    float densityCoefficient = float.Parse(this.dgvList.Rows[e.RowIndex].Cells["DensityCoefficient"].Value.ToString());
                    int particlesID = int.Parse(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    string msg = _drugManagermentBLL.UpdateParticlesDensityCoefficient(new List<int>() { particlesID }, densityCoefficient);
                    if (msg == "")
                    {
                        this.ShowSuccessTip("保存成功");
                    }
                    else
                    {
                        this.ShowErrorDialog(msg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，错误:" + ex.Message);
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryParticleDatas();
            this.cbSelectAll.Checked = false;
            cbSelectAll_CheckedChanged(cbSelectAll, new EventArgs());
        }

        private void dgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
