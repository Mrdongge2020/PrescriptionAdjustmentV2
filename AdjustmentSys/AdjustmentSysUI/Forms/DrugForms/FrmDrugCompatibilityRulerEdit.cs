using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
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

namespace AdjustmentSysUI.Forms.Drug
{
    public partial class FrmDrugCompatibilityRulerEdit : UIEditForm
    {
        private int _id;
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        ParticleProhibitionRuleBLL _particleProhibitionRuleBLL = new ParticleProhibitionRuleBLL();
        int fValue = 0; int sValue=0;
        public FrmDrugCompatibilityRulerEdit(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void InitData()
        {
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cbfp.ValueMember = "Id";
            cbfp.DisplayMember = "Name";
            cbfp.DataSource = pDatas;

            cbSp.ValueMember = "Id";
            cbSp.DisplayMember = "Name";
            cbSp.DataSource = pDatas;
            cbfp.SelectedIndex = -1;
            cbSp.SelectedIndex = -1;

            if (_id == 0)
            {
               
                InitControlData();
                return;
            }

            //编辑赋值
            var rule = _particleProhibitionRuleBLL.GetRuleInfo(_id);
            if (rule != null)
            {
                txtName.Text = rule.Name;
                txtBZ.Text = rule.Remark;

                var firstdata = pDatas.FirstOrDefault(x => x.Id == rule.FirstParticlesID);
                var secorddata = pDatas.FirstOrDefault(x => x.Id == rule.SecondParticlesID);
                cbfp.Text = firstdata.Name;
                cbSp.Text = secorddata.Name;
                fValue = rule.FirstParticlesID;
                sValue = rule.SecondParticlesID;
            }
            
        }

        private void InitControlData()
        {
            txtName.Text = string.Empty;
            txtBZ.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitControlData();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInfo())
            {
                return;
            };
            ParticleProhibitionRule rule = new ParticleProhibitionRule();
            rule.ID = _id;
            rule.Name = txtName.Text;
            rule.Remark = txtBZ.Text;
            rule.FirstParticlesID = cbfp.SelectedValue!=null?int.Parse(cbfp.SelectedValue.ToString()):fValue;
            rule.SecondParticlesID = cbSp.SelectedValue!=null?int.Parse(cbSp.SelectedValue.ToString()):sValue;
            string msg = _particleProhibitionRuleBLL.AddOrEditRuleInfo(rule);
            if (msg == "")
            {
                ShowSuccessTip((_id > 0 ? "编辑" : "新增") + "成功");
                this.Close();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }
        }

        private bool CheckInfo()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowWarningDialog("异常提示", "规则名称不能为空");
                txtName.Focus();
                return false;
            }
            if (cbfp.SelectedValue == null && _id==0)
            {
                ShowWarningDialog("异常提示", "请选择第一味颗粒");
                return false;
            }
            if (cbSp.SelectedValue == null && _id == 0)
            {
                ShowWarningDialog("异常提示", "请选择第二味颗粒");
                return false;
            }

            if (cbfp.SelectedValue!=null &&  cbSp.SelectedValue!=null && cbfp.SelectedValue == cbSp.SelectedValue)
            {
                ShowWarningDialog("异常提示", "第一味颗粒与第二味颗粒不能重复");
                return false;
            }
            return true;
        }

        private void FrmDrugCompatibilityRulerEdit_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
