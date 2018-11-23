using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitTest;

namespace Tetris
{
    class UnitTests_Block : UnitTestBase
    {
        public void SimpleSetPosTest()
        {
            TetroBlock block = new TetroBlock();
            Vect2 pos = new Vect2(1, 2);
            block.Pos = pos;
            CHECK(pos.Equals(block.Pos));
        }
    }
}
