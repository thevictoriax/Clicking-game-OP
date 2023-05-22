using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicking_game
{
    public class Circle : Control
    {
        public int score;
        public Color color;
        public bool Clicked { get; set; } 

        public Circle(int xpos, int ypos, int size, Color color, int score)
        {
            this.score = score;
            this.color = color;
            Location = new Point(xpos, ypos);
            Size = new Size(size, size);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(new SolidBrush(color), ClientRectangle);
        }
    }

}
