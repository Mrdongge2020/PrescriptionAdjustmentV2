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

namespace AdjustmentSysUI.Forms.UserControlForms
{
    public partial class UC_WorkStationButton : UIUserControl
    {
        public string StationName;
        public string ParticName;
        public StationStatusEnum Status;
        public int ProcessValue;
        public UC_WorkStationButton()
        {
            InitializeComponent();
            SetControlValue();
        }

        public void SetControlValue() 
        {
            lblStationName.Text = StationName;
            lblParticleName.Text = ParticName;
            SetStatus();
            pbProcess.Value = ProcessValue;
            pbProcess.Text = pbProcess + "%";
        }
        public void SetProcessValue()
        {
            pbProcess.Value = ProcessValue;
            pbProcess.Text = pbProcess + "%";
        }
        public void SetStatus()
        {
            lblStatus.Text = Status.ToString();
            switch (Status) 
            {
                case StationStatusEnum.无:
                case StationStatusEnum.待放入:
                    this.fillColor=Color.Green;
                    break;
                case StationStatusEnum.待调剂:
                    this.fillColor = Color.GreenYellow; 
                    break;
                case StationStatusEnum.调剂中:
                    this.fillColor = Color.Orange;
                    break;
                case StationStatusEnum.待取走:
                    this.fillColor = Color.Olive;
                    break;
                case StationStatusEnum.回零中:
                case StationStatusEnum.回零完成:
                    this.fillColor = Color.PaleGreen;
                    break;
                //case StationStatusEnum.被禁用:
                //    lblStatus.ForeColor = Color.BlanchedAlmond;
                //    break;
                //case StationStatusEnum.余量不足:
                case StationStatusEnum.非处方药品:
                    this.fillColor = Color.Red;
                    break;
                //case StationStatusEnum.该药品未称重:
                //    lblStatus.ForeColor = Color.WhiteSmoke;
                //    break;

            }
        }
    }
}
