using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Be.Windows.Forms
{
    class ColorMap
    {
        public Brush _brush;
        public int _length;
        public PointF _pf;
        public Rectangle rect; 

        public ColorMap(Color Color, int Length, PointF pf, int CharWidth, int CharHeight)
        {
            _brush = new SolidBrush(Color);
            _length = Length;
            _pf = pf;
            rect = new Rectangle((int)_pf.X, (int)_pf.Y, (CharWidth * 2) * _length, CharHeight);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(_brush, rect);
            g.DrawRectangle(new Pen(SystemBrushes.ControlDarkDark), rect);
        }
    }
}
