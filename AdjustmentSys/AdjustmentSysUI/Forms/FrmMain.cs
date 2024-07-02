using AdjustmentSys.Models.User;
using AdjustmentSysUI.Forms.DeviceForms;
using AdjustmentSysUI.Forms.Drug;
using AdjustmentSysUI.Forms.MedicineCabinetForms;
using AdjustmentSysUI.Forms.Pharmacopoeia;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.Forms.UserForms;
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

namespace AdjustmentSysUI.Forms
{
    public partial class FrmMain : UIForm
    {
        public FrmMain()
        {
            InitializeComponent();
            int pageIndex = 1000;
            TreeNode parent = navMenuMainLeft.CreateNode("系统管理", 362718, 28, pageIndex);

            //通过设置PageIndex关联，节点文字、图标由相应的Page的Text、Symbol提供
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmUser(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDoctor(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDocDepartment(), ++pageIndex));


            pageIndex = 1100;
            parent = navMenuMainLeft.CreateNode("药品管理", 361617, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugManagement(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugCompatibilityRuler(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugManufacturer(), ++pageIndex));

            pageIndex = 1200;
            parent = navMenuMainLeft.CreateNode("设备管理", 358723, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDevice(), ++pageIndex));

            pageIndex = 1300;
            parent = navMenuMainLeft.CreateNode("药柜管理", 358587, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMedicineCabinet(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMedicineCabinetManage(), ++pageIndex));

            pageIndex = 1400;
            parent = navMenuMainLeft.CreateNode("处方管理", 358587, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmPrescriptionList(), ++pageIndex));


            //登录用户信息
            lblLoginUser.Text ="当前用户:"+ SysLoginUser._currentUser.UserName+" "+SysLoginUser._currentUser.UserLevelName;
        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            this.lbltime.Text = DateTime.Now.DateTimeString();
        }
    }
}
