using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinkiManEscape
{
    class Blocks:Figura
    {
        public Blocks(int length, int positionX, int positionY, int orientation)
            : base(length, positionX, positionY, orientation)
        {

        }

        public override void draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(this.brush, this.rec);
        } 
    }
}
