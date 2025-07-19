using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.UITool;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    public partial class FrmSysLog : UIPage
    {
        public FrmSysLog()
        {
            InitializeComponent();
            ControlOpterUI.SetTitleStyle(this);
        }

        private void FrmSysLog_Load(object sender, EventArgs e)
        {
            List<ComboxStringModel> list = new List<ComboxStringModel>();
            foreach (LogTypeEnum item in Enum.GetValues(typeof(LogTypeEnum)))
            {
                ComboxStringModel comboxModel = new ComboxStringModel();
                comboxModel.Id = CommFunHelper.GetEnumDescription(item);
                comboxModel.Name = item.ToString();
                list.Add(comboxModel);
            }
            cbLogType.ValueMember = "Id";
            cbLogType.DisplayMember = "Name";
            cbLogType.DataSource = list;
            cbLogType.SelectedIndex = 0;

        }

        private void cbLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCheckLog.Items.Count > 0)
            {
                cbCheckLog.Items.Clear();
            }
            uiRichTextBox1.Text = "";
            if (cbLogType.SelectedValue == null)
            {
                this.ShowInfoDialog("请选择日志类型");
                cbLogType.Focus();
                return;
            }

            string logDirectory = Application.StartupPath + $"Logs\\{cbLogType.SelectedValue}s";
            string pattern = cbLogType.SelectedValue + "*.log";
            List<string> paths = OperateLog.GetFiles(logDirectory, pattern);
            if (paths != null)
            {
                foreach (string path in paths)
                {
                    string name = path.Replace(logDirectory + "\\", "");
                    cbCheckLog.Items.Add(name);
                }
                cbCheckLog.SelectedIndex = 0;
            }
        }

        private void cbCheckLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCheckLog.SelectedIndex == -1)
            {
                return;
            }
            if (string.IsNullOrEmpty(cbCheckLog.Text))
            {
                return;
            }
            string logDirectory= Application.StartupPath + $"Logs\\{cbLogType.SelectedValue}s";
            if (string.IsNullOrEmpty(logDirectory))
            {
                return;
            }

            //获取日志文件内容
            FileStream fs = new FileStream(logDirectory + "\\" + cbCheckLog.Text, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string logtext = sr.ReadToEnd();
            if (string.IsNullOrEmpty(logtext))
            {
                logtext="未查找到日志信息";
            }
       
            this.uiRichTextBox1.Text = logtext;
            
            fs.Close();
            sr.Close();
        }
    }
}
