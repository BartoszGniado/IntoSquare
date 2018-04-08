using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoSquare
{
    class Utils
    {
       public static Color NewColor()
        {
            int maxStart = 100;
            return Color.FromArgb(IntSqer.r.Next(maxStart), IntSqer.r.Next(maxStart), IntSqer.r.Next(maxStart));
        }
        public static int DoTheThing(int x)
        {

         //   double wsp = Form1.r.NextDouble() + 0.5;
            double znak = IntSqer.r.NextDouble() - 0.5;
            int ret;
            if (znak > 0)
                ret = x + 1;
            else
                ret = x - 0;
            
            //   ret = (int) Math.Floor(x*wsp);// + ret;
            if (ret > 255)
                ret = 255;
            if (ret < 1)
                ret = 1;
            return ret;
        }

        internal static Color ChangeColor(Color c)
        {
            int r = DoTheThing(c.R);
            int g = DoTheThing(c.G);
            int b = DoTheThing(c.B);
            return Color.FromArgb(r,g,b);
        }
    }
}
