using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetroBlock
    {
        public Vect2 Pos { get; set; }
        private DrawColor.Shade shade;

        public TetroBlock()
        {
            Pos = new Vect2(0,0);
        }

        public TetroBlock(Vect2 pos, DrawColor.Shade shade)
        {
            this.Pos = pos;
            this.shade = shade;
        }

        public DrawColor.Shade GetShade()
        {
            return shade;
        }

        public void SetShade(DrawColor.Shade shade)
        {
            this.shade = shade;
        }

        public void Draw()
        {
            SOM.DrawBox(Pos.x, Pos.y, shade);
        }
    }
}
