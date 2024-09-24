using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.UserControlForms
{
    public partial class UC_CircleButton : UIUserControl
    {
        public UC_CircleButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SetGDIHigh(g);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            g.DrawEllipse(new Pen(this.ForeColor), 0, 0, this.Width - 1, this.Height - 1);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new RectangleF(0, 0, this.Width, this.Height), strFormat);
            
            //base.OnPaint(e);
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //Rectangle rect = e.ClipRectangle;

            //Rectangle rect1 = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
            //g.DrawEllipse(new Pen(this.ForeColor), rect1);
            //g.FillEllipse(new SolidBrush(this.BackColor), rect1);
        }

        

        /// <summary>
        /// 设置GDI高质量模式抗锯齿
        /// </summary>
        void SetGDIHigh(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
        }
    }
}
