using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.team_4;

namespace Tetris
{
    class Tetromino
    {
        private static readonly Dictionary<Shape.Orientation, Shape.Orientation> nextLeftOrientation;
        private static readonly Dictionary<Shape.Orientation, Shape.Orientation> nextRightOrientation;
        // TODO: Update as needed
        private static readonly int MIN_X = 0;
        private static readonly int MAX_X = 256;

        private IShape shape;
        private Shape.Orientation orientation;
        public Vect2 position;
        private int updateCount = 0;

        //for slow drop
        int rate = 1;
        bool downPressed = false;

        //tickdowns for the levels
        long level0 =  new TimeSpan(0, 0, 0, 0, 800).Ticks; 
        long level1 =  new TimeSpan(0, 0, 0, 0, 728).Ticks;
        long level2 =  new TimeSpan(0, 0, 0, 0, 656).Ticks;
        long level3 =  new TimeSpan(0, 0, 0, 0, 584).Ticks;
        long level4 =  new TimeSpan(0, 0, 0, 0, 512).Ticks;
        long level5 =  new TimeSpan(0, 0, 0, 0, 440).Ticks;
        long level6 =  new TimeSpan(0, 0, 0, 0, 368).Ticks;
        long level7 =  new TimeSpan(0, 0, 0, 0, 296).Ticks;
        long level8 =  new TimeSpan(0, 0, 0, 0, 224).Ticks;
        long level9 =  new TimeSpan(0, 0, 0, 0, 152).Ticks;
        long level10 = new TimeSpan(0, 0, 0, 0, 80).Ticks;











        long lastUpdate = DateTime.Now.Ticks;

        /// <summary>
        /// Static constructor that populates the next left and next right oritentation dictionaries
        /// </summary>
        static Tetromino()
        {
            nextLeftOrientation = new Dictionary<Shape.Orientation, Shape.Orientation>
            {
                [Shape.Orientation.ORIENT_0] = Shape.Orientation.ORIENT_3,
                [Shape.Orientation.ORIENT_1] = Shape.Orientation.ORIENT_0,
                [Shape.Orientation.ORIENT_2] = Shape.Orientation.ORIENT_1,
                [Shape.Orientation.ORIENT_3] = Shape.Orientation.ORIENT_2
            };

            nextRightOrientation = new Dictionary<Shape.Orientation, Shape.Orientation>
            {
                [Shape.Orientation.ORIENT_0] = Shape.Orientation.ORIENT_1,
                [Shape.Orientation.ORIENT_1] = Shape.Orientation.ORIENT_2,
                [Shape.Orientation.ORIENT_2] = Shape.Orientation.ORIENT_3,
                [Shape.Orientation.ORIENT_3] = Shape.Orientation.ORIENT_0
            };
        }

        public Tetromino()
        {
            this.position = new Vect2(0, 0);
        }
        public Tetromino(int x, int y)
        {
            this.position = new Vect2(x, y);
        }

        public IShape GetShape()
        {
            return shape;
        }

        public void SetShape(IShape shape)
        {
            this.shape = shape;
        }

        public Shape.Orientation GetOrientation()
        {
            return orientation;
        }

        public void SetOrientation(Shape.Orientation orientation)
        {
            this.orientation = orientation;
        }

        /// <summary>
        /// Returns block array and removes this tetromino from the board (via Recycle)
        /// </summary>
        /// <returns>TetroBlock[]</returns>
        public TetroBlock[] Break()
        {
            Recycle();

            TetroBlock[] tetroBlocks = null;
            DrawColor.Shade shade = shape.GetShade();
            if (shape != null)
            {
                Vect2[] vects = shape.GetOffsetArray(orientation);
                tetroBlocks = new TetroBlock[vects.Length];
                for (int i = 0; i < vects.Length; i++)
                {
                    Vect2 vect = vects[i];
                    tetroBlocks[i] = new TetroBlock(vect, shade);
                    // TODO: Where do I find the color? Another instance variable?
                }
            }

            return tetroBlocks;
        }

        /// <summary>
        /// Moves this tetromino to the specified X and Y axis.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(int x, int y)
        {
            if (x >= Constants.GAME_MIN_X &&
                x <= Constants.GAME_MAX_X &&
                y >= Constants.GAME_MIN_Y &&
                y <= Constants.GAME_MAX_Y)
            {
                position.x = x;
                position.y = y;
            }
            else
            {
                // TODO: Throw exception?
            }
        }

        /// <summary>
        /// Moves this tetromino to the left along the x axis
        /// </summary>
        public void MoveLeft()
        {
            Vect2 newPos = new Vect2(position.x - 1, position.y);
            bool isValidPlacement = IsValidPosition(newPos);

            if (isValidPlacement && position.x > Constants.GAME_MIN_X)
            {
                //position.x--;
                position.x = newPos.x;
            }
        }

        /// <summary>
        /// Moves this tetromino down along the y axis
        /// </summary>
        public void MoveDown()
        {
            
            Vect2 newPos = new Vect2(position.x, position.y - 2);
            bool isValidPlacement = IsValidPosition(newPos);

            if (isValidPlacement && position.x > Constants.GAME_MIN_X)
            {
                //position.x--;
                position.y = newPos.y;
            }
        }

        /// <summary>
        /// Moves this tetromino to the right along the x axis
        /// </summary>
        public void MoveRight()
        {
            Vect2 newPos = new Vect2(position.x + 1, position.y);
            bool isValidPlacement = IsValidPosition(newPos);

            if (isValidPlacement && position.x < Constants.GAME_MAX_X)
            {
                //position.x++;
                position.x = newPos.x;
            }
        }

        /// <summary>
        /// Rotate this tetromino to the left
        /// </summary>
        public void RotateLeft()
        {
            Shape.Orientation newOrientation = nextLeftOrientation[orientation];
            if (IsValidRotation(newOrientation))
            {
                // orientation = nextLeftOrientation[orientation];
                orientation = newOrientation;
            }
        }

        /// <summary>
        /// Rotate this tetromino to the right
        /// </summary>
        public void RotateRight()
        {
            Shape.Orientation newOrientation = nextRightOrientation[orientation];
            if (IsValidRotation(newOrientation))
            {
                // orientation = nextRightOrientation[orientation];
                orientation = newOrientation;
            }
        }

        /// <summary>
        /// Drops this tetromino to the bottom of the grid
        /// </summary>
        public void ForceDrop(int startingYPosition)
        {
            // TODO: Are we dealing with collisions? How do we know where we need to stop?
            // For example, if there is a block below this.
            // position.y = Constants.GAME_MIN_Y;
            
            // The position we will use
            Vect2 finalPosition = new Vect2(position.x, position.y);
            // The position we will use to look below us
            Vect2 checkPosition = new Vect2(position.x, position.y - 1);

            // Keep moving checkPosition down until it can't anymore
            while (IsValidPosition(checkPosition))
            {
                finalPosition.y = checkPosition.y;
                --checkPosition.y;
            }

            position = finalPosition;
            ScoreManager.CalculateHardDrop(startingYPosition - position.y);
            Collide();
        }

        public void Collide()
        {
            //Player.TetroCollided();
            Grid.RegisterBlocks(GetTetroBlocks());
        }

        /// <summary>
        /// Draws this tetromino
        /// </summary>
        public void Draw()
        {
            shape.Draw(position.x, position.y, orientation);
        }

        /// <summary>
        /// ???
        /// </summary>
        public void Update()
        {
            long updateTime = DateTime.Now.Ticks;
            
            if((updateTime - lastUpdate) > GetTickDownSpan())
            {
                Vect2 newPosition = new Vect2(position.x, position.y - 1);

                if (IsValidPosition(newPosition))
                {
                    Move(position.x, position.y - 1 * rate);
                }
                else
                {
                    Collide();
                }

                lastUpdate = updateTime;
            }
        }

        public TetroBlock [] GetTetroBlocks()
        {
            TetroBlock[] retBlocks = new TetroBlock[4];
            Vect2 [] vects = shape.GetOffsetArray(orientation);

            for (int i = 0; i < vects.Length; i++)
            {
                vects[i].x += position.x;
                vects[i].y += position.y;

                retBlocks[i] = new TetroBlock(vects[i], shape.GetShade());
            }

            return retBlocks;
        }

        private bool IsValidPosition(Vect2 newPosition)
        {
            Vect2[] vects = shape.GetOffsetArray(orientation);

            for (int i = 0; i < vects.Length; i++)
            {
                vects[i].x += newPosition.x;
                vects[i].y += newPosition.y;
            }

            return CheckNewPlacement(vects);
        }

        private bool IsValidRotation(Shape.Orientation newOrientation)
        {
            Vect2[] vects = shape.GetOffsetArray(newOrientation);

            for (int i = 0; i < vects.Length; i++)
            {
                vects[i].x += position.x;
                vects[i].y += position.y;
            }

            return CheckNewPlacement(vects);
        }

        private bool CheckNewPlacement(Vect2[] newPositions)
        {

            bool retVal = true;

            for (int i = 0; i < newPositions.Length; i++)
            {
                bool validX = newPositions[i].x >= Constants.GAME_MIN_X && newPositions[i].x <= Constants.GAME_MAX_X;
                bool validY = newPositions[i].y >= Constants.GAME_MIN_Y && newPositions[i].y <= Constants.GAME_MAX_Y;
                retVal &= validX && validY;
                if (validX && validY)
                {
                    retVal &= Grid.CellEmpty(Grid.P2G(newPositions[i]));
                }
            }

            return retVal;
        }

        /// <summary>
        /// Recycles this tetromino back into the board
        /// </summary>
        public virtual void Recycle()
        {
            TetrominoFactory.Instance().ReturnTetromino(this);
        }

        //gets the correct tick speed for each level
        public long GetTickDownSpan()
        {
            long speed = 0;
            
            switch (ScoreManager.CurrentLevel)
            {
                case 0:
                    speed = level0;
                    break;
                case 1:
                    speed = level1;
                    break;
                case 2:
                    speed = level2;
                    break;
                case 3:
                    speed = level3;
                    break;
                case 4:
                    speed = level4;
                    break;
                case 5:
                    speed = level5;
                    break;
                case 6:
                    speed = level6;
                    break;
                case 7:
                    speed = level7;
                    break;
                case 8:
                    speed = level8;
                    break;
                case 9:
                    speed = level9;
                    break;
                case 10:
                    speed = level10;
                    break;
                default:
                    speed = level10;
                    break;
            }

            return speed;
        }




    }
}
