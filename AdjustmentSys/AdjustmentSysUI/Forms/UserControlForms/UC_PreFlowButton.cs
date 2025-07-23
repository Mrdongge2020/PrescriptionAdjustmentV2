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
    public partial class UC_PreFlowButton : UIUserControl
    {
        public UC_PreFlowButton()
        {
            InitializeComponent();
        }

        private Color fillEllipseColor = Color.Lime;

        public Color FillEllipseColor
        {
            get { return fillEllipseColor; }
            set
            {
                fillEllipseColor = value;
                this.Invalidate(); // 触发重绘
            }
        }

        private string content = "";

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                this.Invalidate(); // 触发重绘
            }
        }

        private string statusStr = "";

        public string StatusStr
        {
            get { return statusStr; }
            set
            {
                statusStr = value;
                this.Invalidate(); // 触发重绘
            }
        }
        private string fsStr = "";

        public string FSStr
        {
            get { return fsStr; }
            set
            {
                fsStr = value;
                this.Invalidate(); // 触发重绘
            }
        }

        private Color backColor = Color.LightSteelBlue;// Color.FromArgb(135, 206, 235); //Color.WhiteSmoke;

        public Color BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                this.Invalidate(); // 触发重绘
            }
        }

        private void UC_PreFlowButton_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillEllipse(Color.Lime, new Rectangle(10, 10, 20, 20));
            //e.Graphics.DrawString(Text, Font, ForeColor, new Rectangle(35, 0, Width, 40), ContentAlignment.MiddleLeft);
            //e.Graphics.DrawLine(ForeColor, 10, 40, Width - 20, 40);
            //e.Graphics.DrawString("Hello SunnyUI !", Font, ForeColor, new Rectangle(10, 40, Width, Height - 40), ContentAlignment.MiddleLeft);

            Color fillEllipseColor = Color.Yellow;//Color.Lime;
            if (statusStr=="已核对") 
            {
                fillEllipseColor= Color.Green;
            }
            e.Graphics.DrawString(Text, Font, ForeColor, new Rectangle(10, 0, Width, 40), ContentAlignment.MiddleLeft);
            e.Graphics.DrawLine(ForeColor, 10, 40, Width - 20, 40);
            e.Graphics.DrawString(content, Font, ForeColor, new Rectangle(10, 30, Width, Height - 40), ContentAlignment.MiddleLeft);
            e.Graphics.FillEllipse(fillEllipseColor, new Rectangle(10, 82, 20, 20));
            e.Graphics.DrawString(statusStr, Font, fillEllipseColor, new Rectangle(35, 58, Width, Height - 40), ContentAlignment.MiddleLeft);
            e.Graphics.DrawString(fsStr, Font, ForeColor, new Rectangle(105, 58, Width, Height - 40), ContentAlignment.MiddleLeft);
            this.fillColor = backColor;
            if (backColor == Color.LightSteelBlue)
            {
                this.RectColor = Color.LightSteelBlue;
            }
            else
            {
                this.RectColor = backColor;
            }

        }
        
    }
}
