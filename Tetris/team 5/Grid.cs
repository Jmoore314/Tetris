using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.team_4;

namespace Tetris
{
    
    static class Grid
    {
        public const int ROWS = 30;
        public const int COLS = 10;
        static TetroBlock[,] field = new TetroBlock[ROWS, COLS];

        /*
         * returns if a cell == null or not
         */
        public static bool CellEmpty(Vect2 v)
        {
            if (v.x>29 || field[v.x, v.y] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * checks if given row has no null spaces
         */
        static public void Draw()
        {
            foreach (var VARIABLE in field)
            {
                VARIABLE?.Draw();
            }
        }
        static bool LineComplete(int row)
        {
            for (int column = 0; column < COLS; ++column)
            {
                if (field[row, column] == null)
                {
                    return false;
                }
            }
            return true;
        }
        /*
         * removes the given row and calls shiftRowDown on all rows above in ascending order
         * row zero is the bottom row
         */
        static void DeleteLine(int row)
        {

            if (row < 0 || row >= ROWS)
                return;

            for (var i = 0; i < COLS; ++i)
                field[row, i] = null;

            for (var j = row + 1; j < ROWS; ++j)
                ShiftRowDown(j);

        }

        /*
         * moves the given rows' TetroBlocks down one row while decrementing the TetroBlock y positions by 1;
         */
        static void ShiftRowDown(int row)
        {
            if(row > 0)
            {
                for(int x = 0; x < COLS; x++)
                {
                    if(field[row, x] != null) field[row, x].Pos.y -= 1;
                    if (field[row, x] != null) field[row - 1, x] = field[row, x];
                    field[row, x] = null;
                }
            }
        }

        public static void RegisterBlocks(TetroBlock[] blocks)
        {
#if true
            foreach (var t in blocks)
            {
                if (t.Pos.y >= ROWS)
                {
                    GameManager.EndGame();
                    return;
                }
            }
            foreach (var t in blocks)
            {
                field[P2G(t.Pos).x, P2G(t.Pos).y] = t;
            }

            HashSet<int> rowsComplete = new HashSet<int>();
            foreach (var t in blocks)
            {
                if (LineComplete(P2G(t.Pos).x))
                {
                    rowsComplete.Add(P2G(t.Pos).x);
                    DeleteLine(P2G(t.Pos).x);
                }
            }

            ScoreManager.CalculateLineClear(rowsComplete.Count);
#endif


            Player.TetroCollided();
        }

        public static void ClearGrid()
        {
            Array.Clear(field,0,field.Length);
        }

        public static Vect2 P2G(Vect2 v)
        {
            return new Vect2(v.y,v.x);
        }
    }
}
