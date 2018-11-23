using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
using static Tetris.Shape;

namespace Tetris
{
    interface IShape
    {
        void Draw(int x, int y, Orientation orient);
        DrawColor.Shade GetShade();
        Vect2[] GetOffsetArray(Orientation orient);
        
    }

    class SquareBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawSquare(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_RED;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {
                        offset[0].x += 0;
                        offset[1].x += 1;
                        offset[2].x += 1;   offset[2].y -= 1;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                        offset[0].x += 0;
                        offset[1].x -= 1;
                        offset[2].x -= 1;   offset[2].y -= 1;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {
                        offset[0].x += 0;
                        offset[1].x -= 1;
                        offset[2].x -= 1;   offset[2].y += 1;
                        offset[3].x += 0;   offset[3].y += 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                        offset[0].x += 0;
                        offset[1].x += 1;
                        offset[2].x += 1;   offset[2].y += 1;
                        offset[3].x += 0;   offset[3].y += 1;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }

    class LineBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawLine(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_ORANGE;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {
                        offset[0].x -= 1;
                        offset[1].x += 0;
                        offset[2].x += 1;
                        offset[3].x += 2;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                                            offset[0].y += 1;
                                            offset[1].y += 0;
                                            offset[2].y -= 1;
                                            offset[3].y -= 2;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {
                        offset[0].x -= 2;
                        offset[1].x -= 1;
                        offset[2].x += 0;
                        offset[3].x += 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                                            offset[0].y += 2;
                                            offset[1].y += 1;
                                            offset[2].y += 0;
                                            offset[3].y -= 1;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }
    class TBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawT(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_YELLOW;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {
                        offset[0].x -= 1;
                        offset[1].x += 0;
                        offset[2].x += 1;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                                            offset[0].y += 1;
                                            offset[1].y += 0;
                                            offset[2].y -= 1;
                        offset[3].x -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {
                        offset[0].x += 0;   offset[0].y += 1;
                        offset[1].x -= 1;
                        offset[2].x += 0;
                        offset[3].x += 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                        offset[0].x += 1;
                                            offset[1].y += 1;
                                            offset[2].y += 0;
                                            offset[3].y -= 1;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }
    class LBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawL1(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_BLUE;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {
                        offset[0].x += 0;
                        offset[1].x += 1;
                        offset[2].x += 2;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                        offset[0].x -= 1;
                        offset[1].x += 0;   offset[1].y += 0;
                        offset[2].x += 0;   offset[2].y -= 1;
                        offset[3].x += 0;   offset[3].y -= 2;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {
                        offset[0].x -= 2;
                        offset[1].x -= 1;
                        offset[2].x += 0;
                        offset[3].x += 0;   offset[3].y += 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                                            offset[0].y += 2;
                                            offset[1].y += 1;
                                            offset[2].y += 0;
                        offset[3].x += 1;   offset[3].y += 0;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }
    class JBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawL2(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_PURPLE;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {
                        offset[0].x -= 2;
                        offset[1].x -= 1;
                        offset[2].x += 0;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                        offset[0].x -= 1;
                        offset[1].x += 0;
                        offset[2].x += 0;   offset[2].y += 1;
                        offset[3].x += 0;   offset[3].y += 2;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {
                        offset[0].x += 2;
                        offset[1].x += 1;
                        offset[2].x += 0;
                        offset[3].x += 0;   offset[3].y += 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                                            offset[0].y -= 2;
                                            offset[1].y -= 1;
                                            offset[2].y += 0;
                        offset[3].x += 1;   offset[3].y += 0;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }
    class SBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawZ2(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_CYAN;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {
                        offset[0].x -= 1;   offset[0].y -= 1;
                        offset[1].x += 0;
                        offset[2].x += 1;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                        offset[0].x -= 1;   offset[0].y += 1;
                                            offset[1].y += 0;
                                            offset[2].y -= 1;
                        offset[3].x -= 1; 
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {
                        offset[0] = new Vect2(0, 1);
                        offset[1] = new Vect2(-1, 0);
                        offset[2] = new Vect2(0, 0);
                        offset[3] = new Vect2(1, 1);

                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                        offset[0].x += 1;   
                                            offset[1].y += 1;
                                            offset[2].y += 0;
                        offset[3].x += 1;   offset[3].y -= 1;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }
    class ZBlock : IShape
    {
        void IShape.Draw(int x, int y, Orientation orient)
        {
            Shape.drawZ1(x, y, orient);
        }

        DrawColor.Shade IShape.GetShade()
        {
            return DrawColor.Shade.COLOR_LT_GREEN;
        }

        public Vect2[] GetOffsetArray(Orientation orient)
        {
            Vect2[] offset = new Vect2[4];
            offset[0] = new Vect2(0, 0);
            offset[1] = new Vect2(0, 0);
            offset[2] = new Vect2(0, 0);
            offset[3] = new Vect2(0, 0);

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    {

                        offset[0].x -= 1;
                        offset[1].x += 0;
                        offset[2].x += 1;   offset[2].y -= 1;
                        offset[3].x += 0;   offset[3].y -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_1:
                    {
                                            offset[0].y += 1;
                                            offset[1].y += 0;
                        offset[2].x -= 1;   offset[2].y -= 1;
                        offset[3].x -= 1;
                        return offset;
                    }

                case Shape.Orientation.ORIENT_2:
                    {

                        offset[0] = new Vect2( 0,  1);
                        offset[1] = new Vect2(-1,  1);
                        offset[2] = new Vect2( 0,  0);
                        offset[3] = new Vect2( 1,  0);

                        return offset;
                    }

                case Shape.Orientation.ORIENT_3:
                    {
                        offset[0].x += 1;
                        offset[1].x += 1;   offset[1].y += 1;
                                            offset[2].y += 0;
                                            offset[3].y -= 1;
                        return offset;
                    }

                default:
                    return offset;
            }
        }
    }
}
