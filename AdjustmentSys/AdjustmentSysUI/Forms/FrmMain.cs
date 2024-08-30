using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms.DeviceForms;
using AdjustmentSysUI.Forms.Drug;
using AdjustmentSysUI.Forms.MedicineCabinetForms;
using AdjustmentSysUI.Forms.Pharmacopoeia;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.Forms.SystemSettingForms;
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
            //TestFile();
            InitializeComponent();
            int pageIndex = 100;
            TreeNode parent = navMenuMainLeft.CreateNode("调剂管理", 362718, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmBoxedDevice(), ++pageIndex));

            pageIndex = 200;
            parent = navMenuMainLeft.CreateNode("系统管理", 362718, 28, pageIndex);

            //通过设置PageIndex关联，节点文字、图标由相应的Page的Text、Symbol提供
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmUser(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDoctor(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDocDepartment(), ++pageIndex));


            pageIndex = 300;
            parent = navMenuMainLeft.CreateNode("药品管理", 361617, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugManagement(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugCompatibilityRuler(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDrugManufacturer(), ++pageIndex));

            pageIndex = 400;
            parent = navMenuMainLeft.CreateNode("设备管理", 358723, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmDevice(), ++pageIndex));

            pageIndex = 500;
            parent = navMenuMainLeft.CreateNode("药柜管理", 358587, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMedicineCabinet(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmMedicineCabinetManage(), ++pageIndex));

            pageIndex = 600;
            parent = navMenuMainLeft.CreateNode("处方管理", 361788, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmPrescriptionList(), ++pageIndex));
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmAgreementPrescriptionManager(), ++pageIndex));

            pageIndex = 700;
            parent = navMenuMainLeft.CreateNode("系统设置", 361788, 28, pageIndex);
            navMenuMainLeft.CreateChildNode(parent, AddPage(new FrmSystemParameter(), ++pageIndex));

            //登录用户信息
            lblLoginUser.Text ="当前用户:"+ SysLoginUser._currentUser.UserName+" "+SysLoginUser._currentUser.UserLevelName;
        }

        private void timerRight_Tick(object sender, EventArgs e)
        {
            this.lbltime.Text = DateTime.Now.DateTimeString();
        }

        //private void TestFile() 
        //{
        //    string fileUrl = Application.StartupPath + "\\testbinfile.bin";
        //    TestFileModel testFileModel = new TestFileModel();
        //    testFileModel.LoadedPreIds = new List<string>() {"222222","333333" };
        //    BinFileHelper.WriteObjectToBinaryFile(fileUrl, testFileModel);

        //    var dd = BinFileHelper.ReadObjectFromBinaryFile<TestFileModel>(fileUrl);
        //}
    }
}
