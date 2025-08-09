using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using AdjustmentSys.Models.Machine;

namespace YD.RewritingControl
{

    class RoundMachineD : Control
    {
        private Point center;  // 圆心位置
        private int numEllipses=0;
        private float angleIncrement=22.5f;
        private float diu;
        private float widthpen;
        private float radius;
        private float zradius;
        private float staionradius;
        private float angle = 0f;
        private float y;
        private float radiusbar;
        private float wstaionradius;
        private float maxadiusbar;
        private float sleft10;
        private float wleft;
        private float sleft;
        private float sleft40;
        private float sleft67;
        private float sleft57;
        private float sleft30;
        private float sleft37;
        private float sleft77;
        private float sleft32;
        private float sleft55;
        private float sleft28;
        private float sleft58;
        private int radiusBig = 240; //围绕大圆的大小
        private int radiusSmall = 55; //工位圆的半径
        private float spacing = 3; //围圆的 间距
        private float va = 68; //工位序号距离圆的间距
        private float sleft70;
        private float sleft120;
        private float sleft100;
        private float sleft160;
        private float sleft580;
        private float sleft600;
        private float sleft6;
        private float sleft60;
        private List<Station> stationitems = new List<Station>();
        [Description("调剂工位对象"), Category("自定义")]
        public Station[] StationItems
        {
            get { return stationitems.ToArray(); }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {

          
                        stationitems = value.ToList();
                     //  Refresh();
                    
                }

            }

        }
        [Description("袋膜对象"), Category("自定义")]
        private List<Model> modelitems = new List<Model>();
        public Model[] ModelItems

        {
            get { return modelitems.ToArray(); }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {
           
                        modelitems = value.ToList();
                   //   Refresh();
                    
                }
            }
        }

        [Description("封口对象"), Category("自定义")]
        private ShowsItem seal =new ShowsItem();
    
        public ShowsItem Seals

        {
            get { return seal; }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {
      
                        seal = value;
                   //     Refresh();
                    
                }
            }
        }
        [Description("封口对象"), Category("自定义")]
        private ShowsItem makebox = new ShowsItem();
        public ShowsItem Makeboxs

        {
            get { return makebox; }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {
           
                        makebox = value;
                    //    Refresh();
                    
                }
            }
        }
        [Description("温度显示对象"), Category("自定义")]
        private ShowsItem temshow = new ShowsItem();
        public ShowsItem Temshows

        {
            get { return temshow; }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {
           
                    temshow = value;
               //     Refresh();
                    
                }
            }
        }


        private Station stationweight = new Station();
        [Description("称重工位对象"), Category("自定义")]
        public Station Stationweight
        {
            get { return stationweight; }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {


                    stationweight = value;
                  

                }

            }

        }



        private Color modelColor = Color.CadetBlue;

        [Description("袋膜颜色"), Category("自定义")]
        public Color ModelColor
        {
            get { return modelColor; }
            set
            {
                modelColor = value;
               // Refresh();
            }
        }
        private Color textmodelColor = Color.Black;
        [Description("袋膜字颜色"), Category("自定义")]
        public Color TextmodelColor
        {
            get { return textmodelColor; }
            set
            {
                textmodelColor = value;
               // Refresh();
            }
        }
        private Color turntableColor = Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
        [Description("袋膜字颜色"), Category("自定义")]
        public Color TurntableColor
        {
            get { return turntableColor; }
            set
            {
                turntableColor = value;
              //  Refresh();
            }
        }
        private Color stationparcolor = Color.CadetBlue;
        [Description("工位进度颜色"), Category("自定义")]
        public Color Stationparcolor
        {
            get { return stationparcolor; }
            set
            {
                stationparcolor = value;
              //  Refresh();
            }
        }


        private float allBarvalue = 0;
        [Description("总进度值"), Category("自定义")]
        public float AllBarvalue
        {
            get { return allBarvalue; }
            set
            {
                allBarvalue = value;
              //  Refresh();
            }
        }
        private Color stationrestparcolor = System.Drawing.SystemColors.MenuBar;
        [Description("工位进度为0的颜色颜色"), Category("自定义")]
        public Color Stationrestparcolor
        {
            get { return stationrestparcolor; }
            set
            {
                stationrestparcolor = value;
             //   Refresh();
            }
        }

        private Color stationnoColor = Color.CadetBlue;
        [Description("工位编号颜色"), Category("自定义")]
        public Color StationnoColor
        {
            get { return stationnoColor; }
            set
            {
                stationnoColor = value;
              //  Refresh();
            }
        }
        private Color stationnameColor = Color.WhiteSmoke;
        [Description("工位名称颜色"), Category("自定义")]
        public Color StationnameColor
        {
            get { return stationnameColor; }
            set
            {
                stationnameColor = value;
              //  Refresh();
            }
        }
        //private string stationwtext = "无";
        //[Description("称重工位文本"), Category("自定义")]
        //public string Stationwtext
        //{
        //    get { return stationwtext; }
        //    set
        //    {
        //        stationwtext = value;
        //      //  Refresh();
        //    }
        //}
        //private Color stationwbackColor = Color.WhiteSmoke;
        //[Description("称重工位背景色"), Category("自定义")]
        //public Color StationwbackColor
        //{
        //    get { return stationwbackColor; }
        //    set
        //    {
        //        stationwbackColor = value;
        //      // Refresh();
        //    }
        //}
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            // 在这里处理双击事件
            OnMyDoubleClick(e); // 触发自定义的双击事件
        }

        // 定义一个自定义的双击事件
        public event MouseEventHandler MyDoubleClick;

        // 触发自定义双击事件的方法
        protected virtual void OnMyDoubleClick(MouseEventArgs e)
        {
            MyDoubleClick?.Invoke(this, e);
        }
        public RoundMachineD()
        {
          
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);//空间大小改变时，控件会重绘
            this.BackColor = Color.Transparent;
      
        }
        

        public void setmo()
        {
            Station station = new Station();
            Model model = new Model();
            ShowsItem showsItem = new ShowsItem();
            for (int i = 0; i < 16; i++)
            {
                modelitems.Add(model);
                if (i < 8)
                {
                    stationitems.Add(station);
                }
            }
            makebox=showsItem;
            seal = showsItem;
           temshow = showsItem;
        }

        //    Dictionary<Station, RectangleF> m_lstItemRectCache = new Dictionary<Station, RectangleF>();
        protected override void OnPaint(PaintEventArgs e)
        {
 
            
            if (modelitems.Count == 0 || stationitems.Count == 0) { setmo(); }
            if (numEllipses == 0)
            {
                setvalue();
            }
            base.OnPaint(e);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;//字符水平对齐方式
            sf.LineAlignment = StringAlignment.Center;//字符垂直对齐方式
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //绘制温度信息
            Rectangle rectW = new Rectangle((int)sleft10-8, (int)sleft10, (int)staionradius+8, (int) sleft100);
            int cornerRadiusW = (int)sleft10/2; // 圆角半径

            // 绘制倒圆的方形
            DrawRoundedRectangle(g, rectW, cornerRadiusW,temshow);
         

            //绘制处方信息
            Rectangle rectc = new Rectangle((int)sleft580, (int)sleft10, (int)sleft160, (int)sleft100);
           // int cornerRadiusW = 5; // 圆角半径

            // 绘制倒圆的方形
            //DrawRoundedRectangle(g, rectc, cornerRadiusW, "调剂信息");
            //g.DrawString("本次调剂1000/1\r\n已拆分10次\r\n共16/2轮\r\n", new Font("微软雅黑", 12F), new SolidBrush(Color.Black), sleft580 + sleft160 / 2, sleft10 + (int)sleft100 / 2 + new Font("微软雅黑", 12F).Height, sf);

            g.TranslateTransform(center.X, center.Y);  // 设置圆的中心点为绘图原点
            //绘制大圆
            Pen penx = new Pen(Color.Black, 1);
            g.DrawEllipse(penx, maxadiusbar / -2, (maxadiusbar / -2), maxadiusbar, maxadiusbar);
            g.FillEllipse(new SolidBrush(turntableColor), zradius / -2, zradius / -2, zradius, zradius);
            //
            //绘制总进度
            g.FillEllipse(new SolidBrush(Color.White), radiusbar / -2, radiusbar / -2, radiusbar, radiusbar);
            Pen pen2 = new Pen(modelColor, sleft10);
            Pen pen3 = new Pen(Color.LightGray, sleft10);
            g.DrawArc(pen3, radiusbar / -2, radiusbar / -2, radiusbar, radiusbar, -90, 1 * 360f); // 从-90度开始画弧，顺时针方向
            g.DrawArc(pen2, radiusbar / -2, radiusbar / -2, radiusbar, radiusbar, -90, AllBarvalue * 3.6f); // 从-90度开始画弧，顺时针方向
            g.DrawString(AllBarvalue.ToString() + "%", new Font("微软雅黑", 20F), new SolidBrush(modelColor), 0, 0, sf);

            //绘制工位圆环连接
            Pen penf = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(79)))), ((int)(((byte)(129))))), widthpen);
            g.DrawArc(penf, diu / -2, (diu / -2), diu, diu, -2, 1 * 160); // 从-90度开始画弧，顺时针方向
            
            //绘制称重工位
            //称重工位
            g.ResetTransform();
            RectangleF rectangleF = new RectangleF(Width - sleft70+((-wstaionradius - sleft10) / 2), this.Height - sleft70+((-wstaionradius - sleft10) / 2), wstaionradius + sleft10, wstaionradius + sleft10);
            g.FillEllipse(new SolidBrush(Color.CadetBlue), rectangleF);
            g.FillEllipse(new SolidBrush(stationweight.BGColor), Width - sleft70  -wstaionradius / 2, this.Height - sleft70 - wstaionradius / 2, wstaionradius, wstaionradius);
            if (string.IsNullOrEmpty(stationweight.Text)) { stationweight.Text = "无"; }
            g.DrawString(stationweight.Text, this.Font, new SolidBrush(stationnameColor), rectangleF.X+( wstaionradius+ sleft10)/2,  rectangleF.Y+ (wstaionradius + sleft10)/2, sf);
            stationweight.rectangleF = rectangleF;
            g.ResetTransform();
            
            
            for (int i = 0; i < 16; i++)
            {
                //计算袋膜椭圆的位置和旋转角度
                PointF ellipseCenter = new PointF(center.X + radius * (float)Math.Cos(angle * Math.PI / 180),
                                                 center.Y + radius * (float)Math.Sin(angle * Math.PI / 180));
              
               
                g.TranslateTransform(ellipseCenter.X, ellipseCenter.Y);  // 设置椭圆的中心点为绘图原点
                g.RotateTransform(angle);  // 旋转画布以绘制椭圆
                //绘制袋膜  
                g.FillRectangle(new SolidBrush(modelColor), rectangle("袋膜方形坐标"));//方行
                g.FillEllipse(new SolidBrush(modelColor), rectangle("袋膜外椭圆1"));  // 外椭圆1
                g.FillEllipse(new SolidBrush(modelColor), rectangle("袋膜外椭圆2"));  // 外椭圆2
                g.FillEllipse(new SolidBrush(modelitems[i].HaveColor), rectangle("袋膜内椭圆1"));  // 内椭圆1
                g.FillEllipse(new SolidBrush(modelitems[i].HaveColor), rectangle("袋膜内椭圆2"));  //                                                         //
                g.ResetTransform();
                //绘制袋膜序号
                PointF ellipseCenter1 = new PointF(center.X + radius * (float)Math.Cos((angle + 7) * Math.PI / 180),
                                        center.Y + radius * (float)Math.Sin((angle + 7) * Math.PI / 180));
                g.DrawString(modelitems[i].Text, new Font("微软雅黑", 10F), new SolidBrush(SystemColors.MenuBar), ellipseCenter1.X, ellipseCenter1.Y, sf);
                RectangleF rectangleF1 = new RectangleF(ellipseCenter.X-30, ellipseCenter.Y-30, 70, 70);
                modelitems[i].rectangleF = rectangleF1;
                angle += angleIncrement;  // 更新角度以绘制下一个椭圆
                g.ResetTransform();
            }
            g.ResetTransform();
            angle = 0;
            
            //画工位
            for (int i = 0; i < 8; i++)
            {
                angle = angleIncrement * i;
        
                float x = (float)(center.X + Math.Cos(angle * Math.PI / 180) * (radiusBig + spacing + radiusSmall));
                float y = (float)(center.Y + Math.Sin(angle * Math.PI / 180) * (radiusBig + spacing + radiusSmall));

                    float x1 = (float)(center.X + Math.Cos(angle * Math.PI / 180) * (radiusBig + spacing + radiusSmall + va));
                    float y1 = (float)(center.Y + Math.Sin(angle * Math.PI / 180) * (radiusBig + spacing + radiusSmall + va));
                    Rectangle rectSmall = new Rectangle((int)x - radiusSmall, (int)y - radiusSmall, radiusSmall * 2, radiusSmall * 2);
                    // 计算袋膜椭圆的位置和旋转角度
                    Pen pen1 = new Pen(stationparcolor, sleft6);
                    Pen pen5 = new Pen(Color.CadetBlue, sleft6);
                    //绘制工位//绘制工位进度
                    g.FillEllipse(new SolidBrush(stationitems[7 - i].BGColor), rectSmall);
                    g.DrawArc(pen5, rectSmall, -90, 1 * 360); // 从-90度开始画弧，顺时针方向
                    g.DrawArc(pen1, rectSmall, -90, stationitems[7 - i].Parvalue * 3.6f); // 从-90度开始画弧，顺时针方向
                    g.DrawString((8 - i).ToString(), new Font("微软雅黑", 16F), new SolidBrush(stationparcolor), x1, y1, sf);
                    if (!string.IsNullOrEmpty(stationitems[7 - i].Text))
                    {
                        g.DrawString(stationitems[7 - i].Text, this.Font, new SolidBrush(stationnameColor), x, y, sf);
                    }
                stationitems[7 - i].rectangleF = rectSmall;


            angle += angleIncrement;  // 更新角度以绘制下一个椭圆
          
            }
            
            float x3 = (float)(center.X + Math.Cos(181 * Math.PI / 180) * (radiusBig+ sleft60));
            float y3 = (float)(center.Y + Math.Sin(181 * Math.PI / 180) * (radiusBig+ sleft60));

            int wd = (int)staionradius+8;
            int hd =(int) sleft70;
            // 定义倒圆的方形位置和大小
            Rectangle rect = new Rectangle((int)x3 - wd / 2-5, (int)y3- hd / 2+5, wd, hd);
            int cornerRadius = 5; // 圆角半径

            // 绘制倒圆的方形
            DrawRoundedRectangle(g, rect, cornerRadius,makebox);
         
            float x4 = x3; // sleft600;
            float y4 = y3- hd*1.2f;
            // 定义倒圆的方形位置和大小
            Rectangle rect1 = new Rectangle((int)x4 - wd / 2-5, (int)y4 - hd / 2+5, wd, hd);
            // 绘制倒圆的方形
            DrawRoundedRectangle(g, rect1, cornerRadius,seal);
            g.ResetTransform();
        }


        //  g.DrawString("温度偏差过大\r\n 1000/1000", new Font("微软雅黑", 12F), new SolidBrush(Color.Black), x3, y3+ new Font("微软雅黑", 12F).Height/2, sf);
        //   g.DrawString(" 温度偏差过大\r\n 1000/1000", new Font("微软雅黑", 12F), new SolidBrush(Color.Black), x4, y4 + new Font("微软雅黑", 12F).Height / 2, sf);

     //   g.DrawString("竖封温度：180\r\n竖封温度：180\r\n竖封温度：180\r\n", new Font("微软雅黑", 12F), new SolidBrush(Color.Black), sleft10 + sleft120/2, sleft10 + sleft100 / 2+ new Font("微软雅黑", 12F).Height, sf);


        public void setvalue()
        {
            float w= this.Width/ 750f ;
            float h = this.Height / 635f ;
            numEllipses = 16;
            float sen = 0.8f;
            center = new Point((int)(750f*w/2- 10*w), (int)(250 * h ));  // 圆心位置
            diu =  595*w;
            widthpen = 115 * w;
            maxadiusbar = 480 * w; //绘制袋膜基圆
            zradius = 480 * w;// //转盘大小;
            radiusbar = 160 * w;//240  //进度圆
            radius = 200 * w;//300; //200;// // 半径大小     
            staionradius = 110 * w;// 110;
            wstaionradius = 110 * w;// Aato(120);//120f;
            wleft = 20 * sen * w;// Aato(40); //20
            sleft = 5 * sen * w;  //
            sleft40 = 40 * sen * w;//Aato(40); //袋膜宽度
            y = -26  *sen * w;  //袋膜椭圆坐标
            sleft67 = 67 * sen * w;//Aato(67); //袋膜小椭圆长度
            sleft57 = 57 * sen * w;// Aato(57); //袋膜椭圆宽度
            sleft30 = 30 * sen * w;// Aato(30); //袋膜内椭圆宽度
            sleft37 = 37 * sen * w;// Aato(37); //37
            sleft77 = 77 * sen * w;// Aato(77); //袋膜方形长度
            sleft32 = 32 * sen * w;// Aato(32); //袋膜椭圆
            sleft6 = 6 * sen * w;// 工位进度宽度
            sleft10 = 10 * w;
            sleft120 = 120 * w;
            radiusBig = (int)(240f* w); //围绕大圆的大小
         radiusSmall = (int)(55f*w); //工位圆的半径
         spacing = 3f*w; //围圆的 间距
         va = 68*w; //工位序号距离圆的间距
           sleft70 = 70 * w;
            sleft100 = 100 * w;
            sleft160 = 160 * w;
            sleft580 = 580 * w;
            sleft600 = 600 * w;
            sleft60 = 60 * w;

    }
        //圆角方
        private void DrawRoundedRectangle(Graphics g, Rectangle rect,  int radius ,ShowsItem showsItem)
        {
            Pen pen = new Pen(showsItem.MGColor, 1);
            if (radius == 0)
            {
               
                g.DrawRectangle(pen, rect);
                return;
            }
            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90); // 左上角圆弧
                path.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y); // 上边线
                path.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90); // 右上角圆弧
                path.AddLine(rect.Right, rect.Y + radius + this.Font.Height, rect.X, rect.Y + radius + this.Font.Height); //标题线
                path.CloseFigure();
                g.FillPath(new SolidBrush(showsItem.MGColor), path);
                g.DrawPath(pen, path); // 用黑色画笔绘制路径
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;//字符水平对齐方式
            sf.LineAlignment = StringAlignment.Center;//字符垂直对齐方式
            using (GraphicsPath path = new GraphicsPath())
            {              

                path.StartFigure();
                path.AddLine(rect.X, rect.Y + radius + this.Font.Height, rect.Right, rect.Y + radius + this.Font.Height); //标题线
                path.AddLine(rect.Right, rect.Y + radius+ this.Font.Height, rect.Right, rect.Y + rect.Height - radius); // 右边线
                path.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2+8, radius * 2, radius * 2, 0, 90); // 右下角圆弧
                path.AddLine(rect.Right - radius, rect.Bottom+8, rect.X + radius, rect.Bottom+8); // 下边线
                path.AddArc(rect.X, rect.Y + rect.Height - radius * 2+8, radius * 2, radius * 2, 90, 90); // 左下角圆弧
                path.CloseFigure();
                g.FillPath(new SolidBrush(showsItem.BGColor), path);
                g.DrawString(showsItem.MText, this.Font, new SolidBrush(SystemColors.MenuBar), rect.X + rect.Width / 2, rect.Y + (this.Font.Height + radius) / 2, sf);
                g.DrawString(showsItem.Text, this.Font, new SolidBrush(showsItem.Textcolor), rect.X + rect.Width / 2, rect.Y +(this.Font.Height + radius)+((rect.Height- this.Font.Height - radius) / 2)+5, sf);

                g.DrawPath(pen, path); // 用黑色画笔绘制路径
            }
        }
        //圆角方
        //private void DrawRoundedRectangle1(Graphics g, Rectangle rect, int radius, string name)
        //{
        //    Pen pen = new Pen(stationnoColor, 2);
        //    if (radius == 0)
        //    {

        //        g.DrawRectangle(pen, rect);
        //        return;
        //    }
        //    using (GraphicsPath path = new GraphicsPath())
        //    {
        //        StringFormat sf = new StringFormat();
        //        sf.Alignment = StringAlignment.Center;//字符水平对齐方式
        //        sf.LineAlignment = StringAlignment.Center;//字符垂直对齐方式
        //        path.StartFigure();
        //        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90); // 左上角圆弧
        //        path.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y); // 上边线
        //        path.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90); // 右上角圆弧
        //        path.AddLine(rect.Right, rect.Y + radius + new Font("微软雅黑", 12F).Height, rect.X, rect.Y + radius + new Font("微软雅黑", 12F).Height); //标题线
        //        path.CloseFigure();
        //        g.FillPath(new SolidBrush(stationparcolor), path);
        //        g.DrawString(name, new Font("微软雅黑", 12F), new SolidBrush(SystemColors.MenuBar), rect.X + rect.Width / 2, rect.Y + (new Font("微软雅黑", 12F).Height + radius) / 2, sf);

        //    }
        //    using (GraphicsPath path = new GraphicsPath())
        //    {
        //        path.Reset();
        //        path.StartFigure();
        //        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90); // 左上角圆弧
        //        path.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y); // 上边线
        //        path.AddArc(rect.X + rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90); // 右上角圆弧
        //        path.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Y + rect.Height - radius); // 右边线
        //        path.AddArc(rect.X + rect.Width - radius * 2, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 0, 90); // 右下角圆弧
        //        path.AddLine(rect.Right - radius, rect.Bottom, rect.X + radius, rect.Bottom); // 下边线
        //        path.AddArc(rect.X, rect.Y + rect.Height - radius * 2, radius * 2, radius * 2, 90, 90); // 左下角圆弧
        //        path.CloseFigure();


        //        g.DrawPath(pen, path); // 用黑色画笔绘制路径
        //    }
        //}
        //绘制袋膜
        public Rectangle rectangle(string Sw)
        {
            //g.FillRectangle(new SolidBrush(modelColor), -wleft, -sleft + y, sleft40, sleft77);//方行
            //g.FillEllipse(new SolidBrush(modelColor), -sleft,   -sleft + y, sleft40, sleft67);  // 外椭圆1
            //g.FillEllipse(new SolidBrush(modelColor), -sleft37, -sleft + y, sleft40, sleft67);  // 外椭圆2
            //g.FillEllipse(new SolidBrush(modelitems[i].HaveColor), 0, y, sleft30, sleft57);  // 内椭圆1
            //g.FillEllipse(new SolidBrush(modelitems[i].HaveColor), -sleft32, y, sleft30, sleft57);  //内椭圆2

            Rectangle frectangle = new Rectangle();
            switch (Sw)
            {
                case "袋膜方形坐标":
                    // -wleft, -sleft + y, sleft40, sleft77
                    frectangle.X = (int)-wleft;
                    frectangle.Y = (int)(-sleft + y);
                    frectangle.Width = (int)sleft40;
                    frectangle.Height = (int)sleft77;

                    break;
                case "袋膜外椭圆1":
                    //-sleft,   -sleft + y, sleft40, sleft67
                    frectangle.X = (int)-sleft;
                    frectangle.Y = (int)(-sleft + y);
                    frectangle.Width = (int)sleft40;
                    frectangle.Height = (int)sleft67;
                    break;
                case "袋膜外椭圆2":
                    //-sleft37, -sleft + y, sleft40, sleft67
                    frectangle.X = (int)-sleft37;
                    frectangle.Y = (int)(-sleft + y);
                    frectangle.Width = (int)sleft40;
                    frectangle.Height = (int)sleft67;
                    break;
                case "袋膜内椭圆1":
                    //0, y, sleft30, sleft57
                    frectangle.X = 0;
                    frectangle.Y = (int)(y);
                    frectangle.Width = (int)sleft30;
                    frectangle.Height = (int)sleft57;
                    break;
                case "袋膜内椭圆2":
                    //-sleft32, y, sleft30, sleft57
                    frectangle.X = (int)-sleft32;
                    frectangle.Y = (int)y;
                    frectangle.Width = (int)sleft30;
                    frectangle.Height = (int)sleft57;
                    break;


            }
            return frectangle;
        }
        //绘制工位


      
    }
}
//if (stationitems[i].BGColor == null)
//{
//    stationitems[i].BGColor = Color.White;
//}

//if (stationitems[i].BGColor != null)
//{
//    stationitems[i].BGColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
//}
//        if (modelitems[i].Text == null)
//{
//    modelitems[i].Text = (i + 1).ToString();
//}


//}
// g.DrawEllipse(Pens.Black, 110, 63, 565, 565);  
//e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);
//e.Graphics.DrawLine(pen, this.Width, 0, this.Width , this.Height );
//e.Graphics.DrawLine(pen, this.Width, this.Height, 0, this.Height );
//e.Graphics.DrawLine(pen, 0, this.Height, 0, 0);


//if (i == 8)
//{
//    g.DrawString("制袋\r\n10000/10000", new Font("微软雅黑", 12F), new SolidBrush(stationnoColor), ellipseCenter2.X + 20, ellipseCenter2.Y, sf);
//}
//      g.ResetTransform();  // 重置画布状态以供下一个椭圆使用
//      //绘制袋膜序号
//      PointF ellipseCenter1 = new PointF(center.X + radius * (float)Math.Cos((angle + 7) * Math.PI / 180),
//                              center.Y + radius * (float)Math.Sin((angle + 7) * Math.PI / 180));
//      g.DrawString(modelitems[i].Text, new Font("微软雅黑", 10F), new SolidBrush(SystemColors.MenuBar), ellipseCenter1.X, ellipseCenter1.Y, sf);
/////绘制工位序号  工位内容
//PointF ellipseCenter2 = new PointF(center.X + (radius - sleft75) * (float)Math.Cos((angle) * Math.PI / 180),
// center.Y + (radius - sleft75) * (float)Math.Sin((angle) * Math.PI / 180));

//StringFormat sf3 = new StringFormat();
//sf3.Alignment = StringAlignment.Center;//字符水平对齐方式
//sf3.LineAlignment = StringAlignment.Center;//字符垂直对齐方式  
//if (i < 8)
//{
//    g.DrawString((8 - i).ToString(), new Font("微软雅黑", 15F), new SolidBrush(stationnoColor), ellipseCenter2.X, ellipseCenter2.Y, sf3);
//    //if (!string.IsNullOrEmpty(stationitems[7 - i].Text))
//    //{
//    //    g.DrawString(stationitems[7 - i].Text, this.Font, new SolidBrush(stationnameColor), ellipseCenter.X, ellipseCenter.Y, sf3);
//    //}
//    g.DrawString("麸炒白术\r\n(麸炒白术)\r\n待调剂", this.Font, new SolidBrush(stationnameColor), ellipseCenter.X, ellipseCenter.Y, sf3);
//}
//if (i == 8)
//{
//    g.DrawString("制袋\r\n10000/10000", new Font("微软雅黑", 12F), new SolidBrush(stationnoColor), ellipseCenter2.X+20, ellipseCenter2.Y, sf3);
//}





////绘制轮廓
//e.Graphics.DrawArc(pen, maxadiusbar / -2+ pen.Width/2, maxadiusbar / -2+ pen.Width/2, maxadiusbar, maxadiusbar, 13, 66);
//// 计算椭圆的位置和旋转角度
//PointF ellipseCenterW = new PointF((float)Math.Sin(7.5 * Math.PI / 180) * maxadiusbar * (float)Math.Sin(8.5 *Math.PI / 180),
//                                   (float)Math.Sin(7.5 * Math.PI / 180) * maxadiusbar * (float)Math.Cos(8.5 * Math.PI / 180));


//float WZ=this.Width / 2 - maxadiusbar / 2+ ellipseCenterW.X;
//e.Graphics.DrawArc(pen, this.Width / 2 - WZ + pen.Width, ellipseCenterW.Y- WZ/2, WZ- pen.Width*2, WZ- pen.Width*2, 0, -180);

//e.Graphics.DrawLine(pen, this.Width / 2- pen.Width, ellipseCenterW.Y, this.Width / 2- pen.Width, this.Height / 2);
//e.Graphics.DrawLine(pen, this.Width / 2 , this.Height / 2 - pen.Width, ellipseCenterW.Y, this.Height / 2- pen.Width);
//e.Graphics.DrawLine(pen, 10, 120, 120, 120);


//g.FillRectangle(new SolidBrush(Color.White), -100, this.Height / -2, 100, 45);
////  g.FillRectangle(new SolidBrush(Color.White), -100, this.Height / 2 - 45, 200, 45);
//g.FillRectangle(new SolidBrush(Color.White), this.Width / -2, -100, 45, 100);
////  g.FillRectangle(new SolidBrush(Color.White), this.Width / 2 - 45, -100, 45, 200);
//g.FillRectangle(new SolidBrush(Color.White), this.Width / -2, this.Height / -2, 50 / 2, 50 / 2);
////绘制椭圆
//g.FillEllipse(new SolidBrush(this.BackColor), -120, (this.Height / -2), 38, 38);
//g.FillEllipse(new SolidBrush(this.BackColor), this.Width / -2, -120, 38, 38);
//g.FillEllipse(new SolidBrush(this.BackColor), (this.Width / -2), (this.Height / -2), 50, 50);
//g.RotateTransform(90);


//g.FillRectangle(new SolidBrush(Color.White), -100, this.Height / -2, 100, 45);
////  g.FillRectangle(new SolidBrush(Color.White), -100, this.Height / 2 - 45, 200, 45);
//g.FillRectangle(new SolidBrush(Color.White), this.Width / -2, -100, 45, 100);
////  g.FillRectangle(new SolidBrush(Color.White), this.Width / 2 - 45, -100, 45, 200);
//g.FillRectangle(new SolidBrush(Color.White), this.Width / -2, this.Height / -2, 50 / 2, 50 / 2);
////绘制椭圆
//g.FillEllipse(new SolidBrush(this.BackColor), -120, (this.Height / -2), 38, 38);

//g.FillEllipse(new SolidBrush(this.BackColor), this.Width / -2, -120, 38, 38);
//g.FillEllipse(new SolidBrush(this.BackColor), (this.Width / -2), (this.Height / -2), 50, 50);
//g.RotateTransform(180);
//g.FillRectangle(new SolidBrush(Color.White), this.Width / -2, this.Height / -2, 50 / 2, 50 / 2);
//g.FillEllipse(new SolidBrush(this.BackColor), (this.Width / -2), (this.Height / -2), 50, 50);

//g.RotateTransform(270);
//g.FillRectangle(new SolidBrush(Color.White), this.Width / -2, this.Height / -2, 50 / 2, 50 / 2);
//g.FillEllipse(new SolidBrush(this.BackColor), (this.Width / -2), (this.Height / -2), 50, 50);


// RoundMachineD_SizeChanged(null,null);
//空间大小改变时，控件会重绘






//Dictionary<Station, RectangleF> m_station = new Dictionary<Station, RectangleF>();
//Dictionary<Station, RectangleF> m_moldel = new Dictionary<Station, RectangleF>();
//RectangleF centreRect;

//void RoundMachineD_SizeChanged(object sender, EventArgs e)
//{
//    m_station.Clear();
//    m_moldel.Clear();
//    if (stationitems == null || stationitems.Count <= 0  || modelitems==null  || modelitems.Count<=0)
//        return;

//    int numEllipses = 16;
//    float angleIncrement = 360f / numEllipses;

//    float radius = this.Width * 0.387f;//310;//565/2-35;  // 半径大小
//    float zradius = radius * 2 + this.Width * 0.15F; //120;
//    float staionradius = this.Width * 0.137F;// 110;

//    float angle = 0f;
//    float y = this.Width * -0.0325f;   // -26f;
//    float radiusbar = this.Width * 0.487f;// 390f;    //进度圆
//    float wstaionradius = this.Width * 0.137F;//120f;
//    float maxadiusbar = this.Width * 0.937f;  //750f ;
//    float sleft10 = Aato(10); //40
//    float wleft = this.Width * 0.025f; //20
//    float sleft = this.Width * 0.006f; //
//    float sleft40 = Aato(40); //40
//    float sleft67 = Aato(67); //67
//    float sleft57 = Aato(57); //67
//    float sleft30 = Aato(30); //67
//    float sleft37 = Aato(37); //37
//    float sleft77 = Aato(77); //77
//    float sleft32 = Aato(32); //32
//    float sleft55 = Aato(55); //32
//    float sleft28 = Aato(28); //28
//    float sleft58 = Aato(58); //58
//    float sleft75 = Aato(75); //58
//    float sleft6 = Aato(6); //58



//    Point center = new Point(this.Width / 2, this.Height / 2);  // 圆心位置

//    for (int i = 0; i < 16; i++)
//    {

//        // 计算椭圆的位置和旋转角度
//        PointF ellipseCenter = new PointF(center.X + radius * (float)Math.Cos(angle * Math.PI / 180),
//                                          center.Y + radius * (float)Math.Sin(angle * Math.PI / 180));



//       //  g.TranslateTransform(ellipseCenter.X, ellipseCenter.Y);  // 设置椭圆的中心点为绘图原点
//       // g.RotateTransform(angle);  // 旋转画布以绘制椭圆




//        g.FillRectangle(new SolidBrush(modelColor), -wleft, -sleft + y, sleft40, sleft77);//方行
//        g.FillEllipse(new SolidBrush(modelColor), -sleft, -sleft + y, sleft40, sleft67);  // 外椭圆1
//        g.FillEllipse(new SolidBrush(modelColor), -sleft37, -sleft + y, sleft40, sleft67);  // 外椭圆2
//        if (havemodelColor[i] != null)
//        {
//            havemodelColor[i] = System.Drawing.SystemColors.MenuBar;
//        }


//        g.FillEllipse(new SolidBrush(havemodelColor[i]), 0, y, sleft30, sleft57);  // 内椭圆1
//        g.FillEllipse(new SolidBrush(havemodelColor[i]), -sleft32, y, sleft30, sleft57);  //内椭圆2

//        if (i < 8)
//        {
//            //绘制工位
//            if (stationitems[i].BGColor == null)
//            {
//                stationitems[i].BGColor = Color.White;
//            }
//            //绘制工位圆 绘制进度
//            if (stationitems[i].BGColor != null)
//            {
//                stationitems[i].BGColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
//            }

//            g.FillEllipse(new SolidBrush(stationitems[i].BGColor), -sleft55, (-sleft28 + y), staionradius, staionradius);
//            Pen pen1 = new Pen(stationitems[i].BarColor, sleft6);
//            Pen pen5 = new Pen(Color.WhiteSmoke, sleft6);
//            g.DrawArc(pen5, -sleft58, (-sleft28 + y), (int)staionradius, (int)staionradius, -90, 1 * 360); // 从-90度开始画弧，顺时针方向
//            g.DrawArc(pen1, -sleft58, (-sleft28 + y), (int)staionradius, (int)staionradius, -90, stationitems[i].Parvalue * 3.6f); // 从-90度开始画弧，顺时针方向

//        }


//        g.ResetTransform();  // 重置画布状态以供下一个椭圆使用
//        //绘制袋膜序号
//        PointF ellipseCenter1 = new PointF(center.X + radius * (float)Math.Cos((angle + 7) * Math.PI / 180),
//                                center.Y + radius * (float)Math.Sin((angle + 7) * Math.PI / 180));
//        g.DrawString(modelitems[i].Text, new Font("微软雅黑", 10F), new SolidBrush(TextmodelColor), ellipseCenter1.X, ellipseCenter1.Y, sf);



//        ///绘制工位序号  工位内容
//        PointF ellipseCenter2 = new PointF(center.X + (radius - sleft75) * (float)Math.Cos((angle) * Math.PI / 180),
//         center.Y + (radius - sleft75) * (float)Math.Sin((angle) * Math.PI / 180));
//        StringFormat sf3 = new StringFormat();
//        sf3.Alignment = StringAlignment.Center;//字符水平对齐方式
//        sf3.LineAlignment = StringAlignment.Center;//字符垂直对齐方式  
//        if (i < 8)
//        {
//            g.DrawString((8 - i).ToString(), new Font("微软雅黑", 20F), new SolidBrush(stationnoColor), ellipseCenter2.X, ellipseCenter2.Y, sf3);
//            if (string.IsNullOrEmpty(stationitems[7 - i].Text)) { stationitems[7 - i].Text = "无"; }
//            g.DrawString(stationitems[7 - i].Text, new Font("微软雅黑", 13F), new SolidBrush(stationnameColor), ellipseCenter.X, ellipseCenter.Y, sf3);
//        }
//        if (i == 8)
//        {
//            g.DrawString("制袋", new Font("微软雅黑", 18F), new SolidBrush(stationnoColor), ellipseCenter2.X, ellipseCenter2.Y, sf3);
//        }

//        angle += angleIncrement;  // 更新角度以绘制下一个椭圆
//    }



//centreRect = new RectangleF((float)(this.Width - itemSize * 1.5) / 2f, (float)(this.Height - itemSize * 1.5) / 2f, (float)itemSize * 1.5f, (float)itemSize * 1.5f);


//var zhijing = this.Width > this.Height ? this.Height : this.Width;
//var yuanzhouchang = Math.PI * zhijing;
//var zongZhouChang = yuanzhouchang;
//if (this.Width > this.Height)
//{
//    zongZhouChang += (this.Width - zhijing) * 2;
//}
//else
//{
//    zongZhouChang += (this.Height - zhijing) * 2;
//}
//var sp = (float)(zongZhouChang / items.Count);

//int c1 = (int)(yuanzhouchang / 2 / sp);//计算半个圆可以放几个
//int c2 = items.Count / 2 - c1;//半个横线放几个
//if (this.Width > this.Height)
//{
//    int index = 0;
//    //上
//    for (int i = 0; i < c2; i++)
//    {
//        var rect = new RectangleF(this.Height / 2 + (this.Width - this.Height) / c2 / 2 + i * ((this.Width - this.Height) / c2) - itemSize / 2, 5f, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
//    //右
//    float fltSplitValue = (float)180 / (float)c1;
//    for (int i = 0; i < c1; i++)
//    {
//        float fltAngle = (fltSplitValue * i + 90 + fltSplitValue / 2) % 360;
//        float fltFY1 = (float)(0 - itemSize / 2 + this.Height / 2 - ((this.Height / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
//        float fltFX1 = (float)(this.Width - this.Height / 2 - itemSize - ((this.Height / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F))));
//        var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }

//    //下
//    for (int i = c2 - 1; i >= 0; i--)
//    {
//        var rect = new RectangleF(this.Height / 2 + (this.Width - this.Height) / c2 / 2 + i * ((this.Width - this.Height) / c2) - itemSize / 2, this.Height - 5f - itemSize, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
//    //左
//    for (int i = 0; i < c1; i++)
//    {
//        float fltAngle = (fltSplitValue * i + 90 + 180 + fltSplitValue / 2) % 360;
//        float fltFY1 = (float)(0 - itemSize / 2 + this.Height / 2 - ((this.Height / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
//        float fltFX1 = (float)(this.Height / 2 - (((this.Height / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
//        var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
//}
//else
//{
//    int index = 0;
//    float fltSplitValue = (float)180 / (float)c1;
//    //上
//    for (int i = 0; i < c1; i++)
//    {
//        float fltAngle = (fltSplitValue * i + fltSplitValue / 2) % 360;
//        float fltFY1 = (float)(this.Width / 2 - ((this.Width / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
//        float fltFX1 = (float)(this.Width / 2 - itemSize / 2 - ((this.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F))));
//        var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
//    //右
//    for (int i = 0; i < c2; i++)
//    {
//        var rect = new RectangleF(this.Width - itemSize - 5, this.Width / 2 + (this.Height - this.Width) / c2 / 2 + i * ((this.Height - this.Width) / c2) - itemSize / 2, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
//    //下
//    for (int i = 0; i < c1; i++)
//    {
//        float fltAngle = (fltSplitValue * i + 180 + fltSplitValue / 2) % 360;
//        float fltFY1 = (float)(this.Height - this.Width / 2 - itemSize - ((this.Width / 2 - 15) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
//        float fltFX1 = (float)(this.Width / 2 - itemSize / 2 - ((this.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F))));
//        var rect = new RectangleF(fltFX1, fltFY1, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
//    //左
//    for (int i = c2 - 1; i >= 0; i--)
//    {
//        var rect = new RectangleF(5, this.Width / 2 + (this.Height - this.Width) / c2 / 2 + i * ((this.Height - this.Width) / c2) - itemSize / 2, itemSize, itemSize);
//        m_lstItemRectCache[items[index]] = rect;
//        index++;
//    }
// }








//}
//}


