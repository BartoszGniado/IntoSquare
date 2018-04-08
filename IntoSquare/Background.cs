using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoSquare
{
    class Background
    {
        public Rectangle r;
        public Color c;
        public Background(Bitmap bit)
        {
            r = new Rectangle(0, 0, bit.Width, bit.Height);
            c = Utils.NewColor();
        }
        public void Step()
        {
            c = Utils.ChangeColor(c);
        }
        public void Switch(Sqer s)
        {
            c = Color.FromArgb(s.c.R,s.c.G,s.c.B);
        }
    }
}
