using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitTest;

namespace Tetris
{
    public class UnitTests_Factory : UnitTestBase
    {
        public void DummyShapeTest()
        {
            Tetromino jBlock = TetrominoFactory.Instance().CreateJBlock();
            CHECK(jBlock.GetShape().GetType().Equals(new JBlock()));
        }
    }
}
