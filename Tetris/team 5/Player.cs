using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azul;
using Tetris.team_4;

namespace Tetris
{

    static class Player
    {
        public static Tetromino CurTetro { get; set; }
        private static AZUL_KEY right;
        private static AZUL_KEY left;
        private static AZUL_KEY down;
        private static AZUL_KEY force;
        private static AZUL_KEY z;
        private static AZUL_KEY x;
        private static int unpauseCount = 0;

        public static void Update()
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) && right == 0)
            {
                CurTetro.MoveRight();
                right = AZUL_KEY.KEY_B;
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT))
                {
                    right = 0;
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) && left == 0)
            {
                CurTetro.MoveLeft();
                left = AZUL_KEY.KEY_B;
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT))
                {
                    left = 0;
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_DOWN) && down == 0)
            {
                CurTetro.MoveDown();
                down = AZUL_KEY.KEY_B;
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_DOWN))
                {
                    down = 0;
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE) && force == 0)
            {
                int startingY = CurTetro.position.y;
                CurTetro.ForceDrop(startingY);
                force = AZUL_KEY.KEY_B;
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE))
                {
                    force = 0;
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_Z) && z == 0)
            {
                CurTetro.RotateLeft();
                z = AZUL_KEY.KEY_B;
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_Z))
                {
                    z = 0;
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_X) && x == 0)
            {
                CurTetro.RotateRight();
                x = AZUL_KEY.KEY_B;
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_X))
                {
                    x = 0;
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_P) && GameManager.paused == false && unpauseCount >= 10)
            {
                GameManager.PauseGame();
                unpauseCount = 0;
            }
            else
            {
                unpauseCount++;
            }
            CurTetro.Update();
        }

        public static void TetroCollided()
        {
            GameManager.GetNextTetro();
            CurTetro = GameManager.CurTetro;            
        }
    }
}
