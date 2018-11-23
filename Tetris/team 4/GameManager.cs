using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azul;


namespace Tetris.team_4
{
    static class GameManager
    {
        public static Tetromino CurTetro { get; private set; }
        public static bool running { get; private set; }

        public static bool paused { get; set; }

        // TODO how ...? 1) no class called BlockGrid, 2) Grid is static 
        //private static Grid blockGrid;
        private static Tetromino NextTetro;
        private static Random rnd;

        public static void Update()
        {
            //TODO if curLevel has changed
            //CurTetro has no speed as of now, but up speed
        }

        public static void Draw()
        {
            CurTetro.Draw();
            NextTetro.Draw();
        }

        public static void NewGame()
        {
            Grid.ClearGrid();
            ScoreManager.Clear();
            rnd = new Random(DateTime.Now.Millisecond);
            CurTetro = TetrominoFactory.Instance().GetRandShape(5, 30, rnd.Next(0, 7));
            NextTetro = TetrominoFactory.Instance().GetRandShape(17, 26, rnd.Next(0, 7));
            Player.CurTetro = CurTetro;
            running = true;
        }

        public static void EndGame()
        {
            //TODO: Grid.cs line 92 calls EndGame when RegisterBlocks reads lines over rows
            running = false;
        }


        public static void PauseGame()
        {
            paused = true;
        }

        public static void UnPauseGame()
        {
            paused = false;
        }

        public static void GetNextTetro()
        {
            CurTetro = NextTetro;
            CurTetro.Move(5, 30);
            NextTetro = TetrominoFactory.Instance().GetRandShape(17, 26, rnd.Next(0, 7));
        }
    }
}
