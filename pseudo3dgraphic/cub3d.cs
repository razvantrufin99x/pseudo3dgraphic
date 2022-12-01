using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace pseudo3dgraphic
{
    public class cub3d
    {
        public float x;
        public float y;
        public float z;
        public float w;
        
        public cub3d() { }
        public cub3d(float px, float py, float pz, float pw) {
            x = px;
            y = py;
            z = pz;
            w = pw;
        }

        public void move(float px, float py, float pz) {
            x = px;
            y = py;
            z = pz;
        }
        public void drawcub(Graphics gg, Pen p0)
        {
            float u = 25;
            gg.DrawRectangle(p0, x, y, w, w);
            gg.DrawRectangle(p0, x + u, y + u, w, w);
            gg.DrawLine(p0, x, y, x + u, y + u);
            gg.DrawLine(p0, x + w, y + w, x + u + w, y + u + w);
            gg.DrawLine(p0, x + w, y , x + u + w, y + u );
            gg.DrawLine(p0, x , y + w, x + u , y + u + w);
        }


    }
}
