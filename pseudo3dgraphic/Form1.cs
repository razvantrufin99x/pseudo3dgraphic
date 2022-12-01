using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace pseudo3dgraphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        public Pen pen0 = new Pen(Color.Black,1);
        public Pen pen1 = new Pen(Color.White, 3);
        public Brush brush0 = new SolidBrush(Color.Red);
        public  int mx = 20;
        public  int my = 20;
        public  float dimensiune = 50;
        public static int parts = 7;
        public float s = (360/parts);
        public float rad = (float)(180 / Math.PI);
        public float ktx;
        public float kty;
        public cub3d c1,c2,c3,c4;

        public void drawCircle()
        {

            g.DrawEllipse(pen1, ktx, kty, dimensiune, dimensiune);
          
        }

        public void calc()
        {
                ktx = (float)(mx - dimensiune / 2);
                kty = (float)(my - dimensiune / 2);
        }
        public void drawngon()
        { 
            for(float i = 0+mx/2+my/2 ; i<360+mx/2+my/2 ; i+=s)
            {
                g.DrawLine(pen0, (float)Math.Cos(i / rad) * dimensiune + ktx + dimensiune / 2, (float)Math.Sin(i / rad) * dimensiune + kty + dimensiune / 2, (float)Math.Cos((i + s) / rad) * dimensiune + ktx + dimensiune / 2, (float)Math.Sin((i + s) / rad) * dimensiune + kty + dimensiune / 2);
 
            }
        
        }

        public void drawngonxy(float a , float b)
        {
            for (float i = 0 + a / 5 + b / 5; i < 360 + a / 5 + b / 5; i += s)
            {
                g.DrawLine(pen0, (float)Math.Cos(i / rad) * dimensiune + ktx + dimensiune / 2, (float)Math.Sin(i / rad) * dimensiune + kty + dimensiune / 2, (float)Math.Cos((i + s) / rad) * dimensiune + ktx + dimensiune / 2, (float)Math.Sin((i + s) / rad) * dimensiune + kty + dimensiune / 2);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            c1 = new cub3d((float)mx, (float)my, (float)(mx + my), 100);
            c2 = new cub3d((float)mx+10, (float)my+10, (float)(mx + my), 100);
            c3 = new cub3d((float)mx+20, (float)my+40, (float)(mx + my), 50);
            c4 = new cub3d((float)mx+30, (float)my+60, (float)(mx + my), 89);
        }

        public void draw()
        {
            g.Clear(BackColor);
            drawCircle();
            drawngonxy(mx + 100, my + 60);
            drawngon();
            c1.move(mx, my, 10);
            c1.drawcub(g, pen0);

            c2.move(mx+21, my+21, 21);
            c2.drawcub(g, pen0);

            c3.move(mx-23, my+89, 34);
            c3.drawcub(g, pen0);

           
            
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;
            calc();
            draw();
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int l = 0; l < 100; l+=10)
            {
                draw();
                
                c4.move(mx + 30+l, my - 60+l, 25+l);
                c4.drawcub(g, pen0);
                
                Thread.Sleep(30);
            }
        }
    }
}
