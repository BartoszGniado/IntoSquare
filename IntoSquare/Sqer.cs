using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoSquare
{
    class Sqer
    {
        public Rectangle r;
        public Color c;
        Background back;
        int srodek;
        public Sqer(Bitmap bit,int startLT, Background background)
        {
            srodek = bit.Width / 2;
            c = Utils.NewColor();
            r = new Rectangle(startLT, startLT, bit.Width - 2 * startLT, bit.Width - 2 * startLT);
            back = background;
        }
        public void Step()
        {
            c = Utils.ChangeColor(c);
            if (r.X == 1)
            {
                back.Switch(this);
                c = Utils.NewColor();
                r = new Rectangle(srodek, srodek, 1,1);
            }
            else
            {
                r.X--;
                r.Y--;
                r.Height++;
                r.Height++;
                r.Width++;
                r.Width++;
            }
        }
    }
}
