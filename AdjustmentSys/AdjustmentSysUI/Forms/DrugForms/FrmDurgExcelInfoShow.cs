using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Common.Tool;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSysUI.UITool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming.Values;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.DrugForms
{
    public partial class FrmDurgExcelInfoShow : UIForm
    {
        DrugManagermentBLL _drugManagermentBLL = new DrugManagermentBLL();
        List<ErrorParticlesExportModel> ErrorParticlesExportList = new List<ErrorParticlesExportModel>();
        ExcelOpterUI excelOpterUI = new ExcelOpterUI();
        public FrmDurgExcelInfoShow()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
        }
        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            if (ErrorParticlesExportList != null && ErrorParticlesExportList.Count > 0)
            {
                ErrorParticlesExportList.Clear();
            }

            ErrorParticlesExportList = excelOpterUI.GetExcelData<ErrorParticlesExportModel>();
            dgvList.DataSource = ErrorParticlesExportList;
            if (ErrorParticlesExportList != null && ErrorParticlesExportList.Count > 0)
            {
                btnCheckData.Enabled = true;
            }
            else
            {
                btnCheckData.Enabled = false;
                ShowWarningDialog("导入提示", "未找到合规的药品信息。");
            }

            btnConfimImport.Enabled = false;
            lblCheckResult.Text = $"校验结果：暂无。 ";
        }

        private void btnConfimImport_Click(object sender, EventArgs e)
        {
            var datas = ErrorParticlesExportList.Where(x => x.IsPassed == "通过").ToList();
            if (dgvList.Rows.Count <= 0 || datas == null || datas.Count == 0)
            {
                ShowWarningDialog("导入提示", "要导入的药品信息不存在");
                return;
            }
            string msg = _drugManagermentBLL.SaveAllParticlesImport(datas);
            if (msg == "")
            {
                ShowSuccessTip("导入数据成功");
                dgvList.DataSource = null;
                ErrorParticlesExportList.AddRange(datas);
                btnConfimImport.Enabled = false;
                btnCheckData.Enabled = false;
                lblCheckResult.Text = $"校验结果：暂无。 ";
            }
            else
            {
                ShowErrorDialog("导入数据失败,原因:" + msg);
            }
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count <= 0)
            {
                ShowWarningDialog("校验提示", "要校验的药品信息不存在");
                return;
            }
            ErrorParticlesExportList = _drugManagermentBLL.CheckAllParticlesImport(ErrorParticlesExportList);

            if (ErrorParticlesExportList == null || ErrorParticlesExportList.Count == 0)
            {
                dgvList.DataSource = null;
                return;
            }

            dgvList.DataSource = ErrorParticlesExportList.Where(x => x.IsPassed == "通过").ToList();
            int passCount = ErrorParticlesExportList.Count(x => x.IsPassed == "通过");
            int unpassCount = ErrorParticlesExportList.Count(x => x.IsPassed != "通过");
            if (unpassCount > 0)
            {
                btnLoadErroeData.Enabled = true;
            }
            if (passCount > 0)
            {
                btnConfimImport.Enabled = true;
            }
            lblCheckResult.Text = $"校验结果：通过{passCount}条，未通过{unpassCount}条";
        }

        private void btnLoadErroeData_Click(object sender, EventArgs e)
        {
            var exportDatas = ErrorParticlesExportList.Where(x => x.IsPassed != "通过").ToList();
            if (exportDatas == null || !exportDatas.Any())
            {
                ShowWarningDialog("导出提示", "要导出的异常药品信息不存在");
                return;
            }
            excelOpterUI.ExportSinglePage(exportDatas.ToList<object>(), "异常药品信息");
        }

        private void lblRuler_Click(object sender, EventArgs e)
        {
            string remark = "1.导入前请在药品管理<药品数据导出>导出一个数据模版，并填写正确数据。\r\n" +
                            "2.异常校验过后，通过校验数据会在窗口列表展示，此类数据可导入；未通过的可以下载到本地后再次导入。\r\n" +
                            "3.此功能根据药品简称唯一性导入，重复和系统已存在的名称简称将不会被导入。\r\n" +
                            "4.数字列请正确填写，否则数据会校验不通过不能导入。" +
                            "5.导入有风险，操作需谨慎。";
            ShowInfoDialog(remark);
        }
    }
}
