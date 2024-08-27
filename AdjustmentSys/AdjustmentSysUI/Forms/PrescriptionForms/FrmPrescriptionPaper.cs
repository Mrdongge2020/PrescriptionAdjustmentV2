using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
using Microsoft.Extensions.Primitives;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    public partial class FrmPrescriptionPaper : UIForm
    {
        private string _preId;
        public FrmPrescriptionPaper(string preid)
        {
            _preId = preid;
            InitializeComponent();
        }
        private void BindPreInfo()
        {
            PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
            var data = prescriptionBLL.GetAllPrescriptionInfo(_preId, ProcessStatusEnum.待核对, true);
            if (data.Item1 == null)
            {
                ClearPreInfo();
                return;
            }

            //处方主信息
            LocalDataPrescriptionInfo localDataPrescriptionInfo = (LocalDataPrescriptionInfo)data.Item1;
            lblCFBH.Text = localDataPrescriptionInfo.PrescriptionID;
            lblXM.Text = localDataPrescriptionInfo.PatientName;
            lblXB.Text = localDataPrescriptionInfo.PatientSex.ToString();
            lblNLYF.Text = localDataPrescriptionInfo.PatientAge + "岁/" + localDataPrescriptionInfo.PatientBirthMonth + "月";
            lblKFYS.Text = localDataPrescriptionInfo.DoctorName;
            lblKS.Text = localDataPrescriptionInfo.DepartmentName;
            lblFSFFCS.Text = localDataPrescriptionInfo.Quantity + "/" + localDataPrescriptionInfo.TaskFrequency;
            lblBZ.Text = localDataPrescriptionInfo.Remarks;
            lblXDFMC.Text = localDataPrescriptionInfo.PrescriptionName;
            lblLRY.Text = localDataPrescriptionInfo.CreateName;
            lblCFLY.Text = localDataPrescriptionInfo.PrescriptionSource == 0 ? "HIS系统" : "TMS系统";
            lblLRSJ.Text = localDataPrescriptionInfo.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            lblCFZJ.Text = localDataPrescriptionInfo.TotalPrice.ToString();

            //详情绑定
            if (data.Item2 != null && data.Item2.Count > 0)
            {
                StringBuilder sbParticle = new StringBuilder();
                float totalDose = 0;
                foreach (PrescriptionDetailModel model in data.Item2.OrderBy(x => x.ParticleOrder))
                {
                    sbParticle.Append("" + model.ParName + " " + model.DoseHerb.ToString() + "g(" + Math.Round(model.Dose, 3).ToString() + "g)        ");
                    //每五个换行
                    if (model.ParticleOrder % 5 == 0)
                    {
                        sbParticle.Append(" \r\n ");
                    }
                    totalDose += model.Dose;
                }
                txtPreDetails.Text = sbParticle.ToString();
                lblDFKLJL.Text = Math.Round(totalDose / localDataPrescriptionInfo.Quantity, 3).ToString();
            }
        }

        private void ClearPreInfo()
        {
            lblCFBH.Text = string.Empty;
            lblXM.Text = string.Empty;
            lblXB.Text = string.Empty;
            lblNLYF.Text = string.Empty;
            lblKFYS.Text = string.Empty;
            lblKS.Text = string.Empty;
            lblFSFFCS.Text = string.Empty;
            lblBZ.Text = string.Empty;
            lblXDFMC.Text = string.Empty;
            lblLRY.Text = string.Empty;
            lblCFLY.Text = string.Empty;
            lblCFZJ.Text = string.Empty;
            lblDFKLJL.Text = string.Empty;
            lblLRSJ.Text = string.Empty;

            txtPreDetails.Text = string.Empty;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrescriptionPaper_Load(object sender, EventArgs e)
        {
            BindPreInfo();
        }
    }
}
