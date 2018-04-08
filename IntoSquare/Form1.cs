using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntoSquare
{
    public partial class IntSqer : Form
    {
       public static Random r;
        Background background;
        Sqer sq1;
        Sqer sq2;
        List<Sqer> Sqery; 
        Bitmap bit;
        public IntSqer()
        {
            InitializeComponent();
            r = new Random();
            count = 0;
            bity = new List<Bitmap>();
            int i;int seci = 0;
            bit = new Bitmap(2 * 255, 2 * 255);
            background = new Background(bit);
            Sqery = new List<Sqer>();
            sq1 = new Sqer(bit, bit.Width / 2, background);
       //     sq2 = new Sqer(bit, bit.Width / 4, background);
            Sqery.Add(sq1);
         //   Sqery.Add(sq2);
            //#region b&w 
            //for (i = 0; i < 255; i++)
            //{
            //    Bitmap bit = new Bitmap(2 * 255, 2 * 255);

            //    Rectangle r1 = new Rectangle(0, 0, bit.Width, bit.Height);
            //    SolidBrush b1 = new SolidBrush(Color.FromArgb(i, i, i));
            //    using (Graphics g = Graphics.FromImage(bit))
            //    {
            //        g.FillRectangle(b1, r1);
            //    }

            //    //Rectangle rb = new Rectangle(bit.Width / 2 - 2*i, bit.Height / 2 - 2*i, 4 * i, 4 * i);
            //    //SolidBrush bb = new SolidBrush(Color.FromArgb((255 - i)/2, (255 - i) / 2, (255 - i) / 2));
            //    //using (Graphics g = Graphics.FromImage(bit))
            //    //{
            //    //    g.FillRectangle(bb, rb);
            //    //}

            //    //Rectangle rb = new Rectangle(bit.Width / 4 -  i, bit.Height / 4 -  i, (bit.Width-(bit.Width / 4 - i))/2, 4 * i);
            //    //SolidBrush bb = new SolidBrush(Color.FromArgb((255 - i) / 2, (255 - i) / 2, (255 - i) / 2));
            //    //using (Graphics g = Graphics.FromImage(bit))
            //    //{
            //    //    g.FillRectangle(bb, rb);
            //    //}

            //    Rectangle rb = new Rectangle(bit.Width / 4 - i, bit.Height / 4 - i, (bit.Width - 2 * (bit.Width / 4 - i)), (bit.Width - 2 * (bit.Width / 4 - i)));
            //    SolidBrush bb = new SolidBrush(Color.FromArgb((255 - i) / 2, (255 - i) / 2, (255 - i) / 2));
            //    using (Graphics g = Graphics.FromImage(bit))
            //    {
            //        g.FillRectangle(bb, rb);
            //    }

            //    Rectangle r2 = new Rectangle(bit.Width / 2 - i, bit.Height / 2 - i, 2 * i, 2 * i);
            //    SolidBrush b2 = new SolidBrush(Color.FromArgb(255 - i, 255 - i, 255 - i));
            //    using (Graphics g = Graphics.FromImage(bit))
            //    {
            //        g.FillRectangle(b2, r2);
            //    }

            //    if (bit.Width / 2 - 2 * i <= 0)
            //    {
            //        Rectangle rb2 = new Rectangle(bit.Width / 2 - seci, bit.Height / 2 - seci, 2 * seci, 2 * seci);
            //        SolidBrush bb2 = new SolidBrush(Color.FromArgb(255 - seci, 255 - seci, 255 - seci));
            //        using (Graphics g = Graphics.FromImage(bit))
            //        {
            //            g.FillRectangle(bb2, rb2);
            //        }
            //        seci++;
            //    }

            //    bity.Add(bit);
            //}
            //pictureBox1.Image = bity[0];
            //#endregion b&w
        }
        List<Bitmap> bity;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if(timer1.Enabled)
            //    timer1.Enabled = false;
            //else
            //    timer1.Enabled = true;
            Sqery.Add(new Sqer(bit, bit.Width / 2, background));
        }
        int count;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //for b&w
            //pictureBox1.Image = bity[count];
            //if (count == 254)
            //    count = 0;
            //count++;
            Sqery.Sort(Comparator);
            using (Graphics g = Graphics.FromImage(bit))
            {
                g.FillRectangle(new SolidBrush(background.c), background.r);
                foreach(Sqer s in Sqery)
                    g.FillRectangle(new SolidBrush(s.c), s.r);
                //if (sq1.r.Width > sq2.r.Width)
                //{
                //    g.FillRectangle(new SolidBrush(sq1.c), sq1.r);
                //    g.FillRectangle(new SolidBrush(sq2.c), sq2.r);
                //}
                //else
                //{
                //    g.FillRectangle(new SolidBrush(sq2.c), sq2.r);
                //    g.FillRectangle(new SolidBrush(sq1.c), sq1.r);
                //}
            }
            pictureBox1.Image = bit;
            background.Step();
            foreach (Sqer s in Sqery)
                s.Step();
            //sq1.Step();
            //sq2.Step();
        }
        private static int Comparator(Sqer x, Sqer y)
        {
            if (x.r.Width < y.r.Width)
                return 1;
            else
                return -1;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Sqery.Clear();
            Sqery.Add(new Sqer(bit, bit.Width / 2, background));
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }
    }
}
