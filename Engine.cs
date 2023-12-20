using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslatieDreptunghi
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color color = Color.FloralWhite;
        public static Random rnd = new Random();

        public static void Initialize(PictureBox pctbox)
        {
            display = pctbox;
            bmp = new Bitmap(pctbox.Width, pctbox.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);
        }

        public static void Refresh()
        {
            display.Image = bmp;
        }

        public static void Clear()
        {
            grp.Clear(color);
            display.Refresh();
        }
    }
}
