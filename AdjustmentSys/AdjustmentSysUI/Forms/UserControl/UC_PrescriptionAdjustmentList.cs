using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace AdjustmentSysUI.Forms.UserControl
{
    public partial class UC_PrescriptionAdjustmentList : UIUserControl
    {
        public UC_PrescriptionAdjustmentList()
        {
            InitializeComponent();
        }

        private void UC_PrescriptionAdjustmentList_Load(object sender, EventArgs e)
        {
            List<DownLoadedPre> dlist = new List<DownLoadedPre>();
            for (int i = 0; i < 5; i++)
            {
                DownLoadedPre model = new DownLoadedPre();
                model.PrescriptionID = "xt20240810" + i;
                model.PatientName = "患者" + i;
                model.Quantity = 10;
                model.PatientAge = 20;
                model.PatientSex= SexEnum.女.ToString();
                model.ProcessStatus = "已下载";
            }
            UC_PreButton btn;
            foreach (var item in dlist)
            {
                btn = new UC_PreButton();
                //btn.SetDPIScale();
                string btnText = btn.Name+"\r\n"+ $@"患者姓名:" + item.PatientName + "\r\n" + "患者性别:" + item.PatientSex + "\r\n"
                    + "处方付数:" + item.Quantity + "\r\n" + "处方状态:" + item.ProcessStatus;
                btn.Text = btnText;
                btn.Name ="处方编号:"+item.PrescriptionID;
                //btn.Click += Btn_Click;
                btn.BackColor = Color.Blue;
                //建议用封装的方法Add
                uiFlowLayoutPanel1.Add(btn);
            }

            lblDownLoadCount.Text = "已下载列表(" + dlist.Count + ")";
            //this.Render();
        }
    }
}
