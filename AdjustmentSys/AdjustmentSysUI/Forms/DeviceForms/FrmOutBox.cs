using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
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

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmOutBox : UIForm
    {
        private string _preId;
        private int _boxCount;
        private bool _isSplitBox;
        private bool _isFinish;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _timeStr;
        private int _second;
        public FrmOutBox(string preid, int boxCount, bool isSplitBox, bool isFinish,DateTime? startTime)
        {
            _preId = preid;
            InitializeComponent();
            _boxCount = boxCount;
            _isSplitBox = isSplitBox;
            _isFinish = isFinish;
            if (startTime.HasValue)
            {
                _startTime = startTime.Value;
                _endTime = DateTime.Now;
                TimeSpan timeDifference = _endTime - startTime.Value;
                _second = (int)Math.Round(timeDifference.TotalSeconds, 0);
                _timeStr = (_second/60>0? _second / 60:0) +"分"+ (_second%60>0? _second % 60 :0)+"秒";
            }
        }

        private void FrmOutBox_Load(object sender, EventArgs e)
        {
            BindPreInfo();
        }

        private void BindPreInfo()
        {
            PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
            var data = prescriptionBLL.GetAllPrescriptionInfo(_preId, ProcessStatusEnum.待调剂, true);
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
            lblLRY.Text = localDataPrescriptionInfo.CreateName;
            lblCFLY.Text = localDataPrescriptionInfo.PrescriptionSource == 0 ? "HIS系统" : "TMS系统";
            lblLRSJ.Text = localDataPrescriptionInfo.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            lblCFZJ.Text = localDataPrescriptionInfo.TotalPrice.ToString();
            lblFenHe.Text = _isSplitBox ? "已分盒" : "未分盒";
            lblWanCheng.Text = _isFinish ? "处方已完成,请确认取盒,并移交患者!" : "药盒容量已达上限,请确认取盒";
            lblBoxNum.Text = _boxCount.ToString();

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
            lblLRY.Text = string.Empty;
            lblCFLY.Text = string.Empty;
            lblCFZJ.Text = string.Empty;
            lblDFKLJL.Text = string.Empty;
            lblLRSJ.Text = string.Empty;

            txtPreDetails.Text = string.Empty;
        }

        private void btnOutBox_Click(object sender, EventArgs e)
        {
            if (_isFinish) //插入处方日志
            {
                CommonDataBLL commonDataBLL = new CommonDataBLL();
                var data = commonDataBLL.GetPrescription(2, _preId);
                if (data.Item1==null || data.Item2==null) 
                {
                    return;
                }
                PrescriptionAdjustmentBLL prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();

                string msg = prescriptionAdjustmentBLL.AddLocalDataPrescriptionInfoRecord((LocalDataPrescriptionInfo)data.Item1, (List<LocalDataPrescriptionDetail>)data.Item2,
                    _boxCount, _endTime,_second,_timeStr);
                if (msg!="") 
                { 
                    this.ShowErrorDialog(msg);
                }
            }
        }
    }
}
