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
    public partial class FrmBoxedDevice1 : UIPage
    {
        public FrmBoxedDevice1()
        {
            InitializeComponent();
            this.uC_CircleButton1.Text = "1#\r\n\r\n名称:当归\r\n\r\n状态:调剂中";
            this.uC_CircleButton2.Text = "1#\r\n\r\n名称:炒王不留行\r\n\r\n状态:调剂中";

            this.uC_WorkStationButton1.StationName = "1#";
            this.uC_WorkStationButton1.ParticName = "炒王不留行";
            this.uC_WorkStationButton1.Status = StationStatusEnum.调剂中;
            this.uC_WorkStationButton1.ProcessValue = 25;
            this.uC_WorkStationButton1.SetControlValue();
        }


    }
}
