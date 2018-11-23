// Luke Mayo
// 2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetrominoFactory
    {
        SquareBlock squareBlock;
        LineBlock lineBlock;
        SBlock sBlock;
        ZBlock zBlock;
        TBlock tBlock;
        LBlock lBlock;
        JBlock jBlock;


        // Object pool
        Stack<Tetromino> tetrominos;

        // Singleton pattern
        private static TetrominoFactory instance;
        public static TetrominoFactory Instance()
        {
            
            if (instance == null)
            {
                instance = new TetrominoFactory();
                instance.squareBlock = new SquareBlock();
                instance.lineBlock = new LineBlock();
                instance.sBlock = new SBlock();
                instance.zBlock = new ZBlock();
                instance.tBlock = new TBlock();
                instance.lBlock = new LBlock();
                instance.jBlock = new JBlock();
                instance.tetrominos = new Stack<Tetromino>();
            }
            return instance;
        }

        //generates a random shape
        public Tetromino GetRandShape(int x, int y, int num)
        {
            Tetromino r = null;
            //Random rnd = new Random(DateTime.Now.Millisecond);
            switch (num)
            {
                case 0:
                    r = Instance().CreateJBlock(x, y);
                    break;
                case 1:
                    r = Instance().CreateLBlock(x, y);
                    break;
                case 2:
                    r = Instance().CreateLineBlock(x, y);
                    break;
                case 3:
                    r = Instance().CreateSBlock(x, y);
                    break;
                case 4:
                    r = Instance().CreateSquareBlock(x, y);
                    break;
                case 5:
                    r = Instance().CreateTBlock(x, y);
                    break;
                case 6:
                    r = Instance().CreateZBlock(x, y);
                    break;
            }

            return r;
        }


        // Private function to be called by all public create functions ------------------------
        // Handles the stack
        private Tetromino GetTetromino(int x = 0, int y = 0)
        {
            if (tetrominos.Count == 0)
            {
                Tetromino tetromino = new Tetromino(x,y);
                return tetromino;
            }
            else
                return tetrominos.Pop();
        }

        // On break, Tetromino calls this ----------------------
        public void ReturnTetromino(Tetromino tetromino)
        {
            tetrominos.Push(tetromino);
        }

        // These assign the shape type. ---------------------------------------------------------
        public Tetromino CreateSquareBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x, y);
            tetromino.SetShape(squareBlock);
            return tetromino;
        }

        public Tetromino CreateLineBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x, y);
            tetromino.SetShape(lineBlock);
            return tetromino;
        }

        public Tetromino CreateJBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x, y);
            tetromino.SetShape(jBlock);
            return tetromino;
        }

        public Tetromino CreateLBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x, y);
            tetromino.SetShape(lBlock);
            return tetromino;
        }

        public Tetromino CreateTBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x, y);
            tetromino.SetShape(tBlock);
            return tetromino;
        }

        public Tetromino CreateSBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x, y);
            tetromino.SetShape(sBlock);
            return tetromino;
        }

        public Tetromino CreateZBlock(int x = 0, int y = 0)
        {
            Tetromino tetromino = GetTetromino(x,y);
            tetromino.SetShape(zBlock);
            return tetromino;
        }

    }
}
