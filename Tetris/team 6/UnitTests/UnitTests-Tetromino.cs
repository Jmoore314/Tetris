using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitTest;

namespace Tetris
{
    class UnitTests_Tetromino : UnitTestBase
    {

        public void DummYDraw4Now()
        {
            Tetromino someBlock = TetrominoFactory.Instance().CreateLBlock();
            someBlock.SetOrientation(Shape.Orientation.ORIENT_2);
            someBlock.Draw();
        }

        public void SimpleSetShapeTest()
        {
            Tetromino tet = new Tetromino();
            IShape val = new SBlock();
            tet.SetShape(val);
            CHECK(val == tet.GetShape());
        }

        public void SimpleSetOrientationTest()
        {
            Tetromino tet = new Tetromino();
            Shape.Orientation val = Shape.Orientation.ORIENT_0;
            tet.SetOrientation(val);
            CHECK(val == tet.GetOrientation());
        }

        public void RotateLeftTest()
        {
            Tetromino tet = new Tetromino();
            tet.SetOrientation(Shape.Orientation.ORIENT_0);

            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_0);
            tet.RotateLeft();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_1);
            tet.RotateLeft();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_2);
            tet.RotateLeft();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_3);
            tet.RotateLeft();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_0);
        }

        public void RotateRightTest()
        {
            Tetromino tet = new Tetromino();
            tet.SetOrientation(Shape.Orientation.ORIENT_0);

            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_0);
            tet.RotateRight();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_3);
            tet.RotateRight();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_2);
            tet.RotateRight();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_1);
            tet.RotateRight();
            CHECK(tet.GetOrientation() == Shape.Orientation.ORIENT_0);
        }
    }
}
