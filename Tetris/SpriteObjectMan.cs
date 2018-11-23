using System;

namespace Tetris
{
    static class SOM  // SpriteObjecManager i.e. SOM
    {
        static public void DrawStringsRunning(GameStats stats)
        {
            int levels = stats.GetLevelNum();
            int lines = stats.GetLineCount();
            int score = stats.GetScore();

            SpriteFont LevelLabel = new SpriteFont("Level " + levels, 280, 300);
            SpriteFont LineslLabel = new SpriteFont("Lines " + lines, 280, 275);
            SpriteFont ScoreLabel = new SpriteFont("Score " + score, 280, 250);
            SpriteFont rotate = new SpriteFont("Rotate Z, X   ", 280, 200);
            SpriteFont move = new SpriteFont("Move arrow keys ", 280, 175);

            move.Draw();
            rotate.Draw();
            LevelLabel.Draw();
            LineslLabel.Draw();
            ScoreLabel.Draw();
        }

        static public void DrawStringsGameOver(GameStats stats)
        {
            int levels = stats.GetLevelNum();
            int lines = stats.GetLineCount();
            int score = stats.GetScore();
            SpriteFont gameover = new SpriteFont("Game Over", 280, 375);// 1.0f, 0.1f, 0.1f);
            SpriteFont pressEnter = new SpriteFont("new game enter", 280, 350);
            SpriteFont LevelLabel = new SpriteFont("Level " + levels, 280, 300);
            SpriteFont LineslLabel = new SpriteFont("Lines " + lines, 280, 275);
            SpriteFont ScoreLabel = new SpriteFont("Score " + score, 280, 250);
            SpriteFont rotate = new SpriteFont("Rotate Z, X   ", 280, 200);
            SpriteFont move = new SpriteFont("Move arrow keys ", 280, 175);

            move.Draw();
            rotate.Draw();
            gameover.Draw();
            pressEnter.Draw();
            LevelLabel.Draw();
            LineslLabel.Draw();
            ScoreLabel.Draw();
        }

        static public void DrawStringsPause(GameStats stats)
        {
            int levels = stats.GetLevelNum();
            int lines = stats.GetLineCount();
            int score = stats.GetScore();
            SpriteFont pause = new SpriteFont("PAUSED", 280, 400);// 1.0f, 0.1f, 0.1f);
            SpriteFont toUnpause = new SpriteFont("TO UNPAUSE", 280, 350);
            SpriteFont pressP = new SpriteFont("Press P", 280, 325);
            SpriteFont LevelLabel = new SpriteFont("Level " + levels, 280, 275);
            SpriteFont LineslLabel = new SpriteFont("Lines " + lines, 280, 250);
            SpriteFont ScoreLabel = new SpriteFont("Score " + score, 280, 225);


            pause.Draw();
            toUnpause.Draw();
            pressP.Draw();
            LevelLabel.Draw();
            LineslLabel.Draw();
            ScoreLabel.Draw();

        }

        static public void DrawInternal(int xPos, int yPos, DrawColor.Shade inColor)
        {
            // This is draw in painted order
            // Draw the color big box first, then the inside..
            Azul.SpriteSolidBox smallBlock = new Azul.SpriteSolidBox(new Azul.Rect(xPos, yPos, Constants.BOX_SIZE - 4, Constants.BOX_SIZE - 4),
                                                                     DrawColor.getColor(inColor));
            smallBlock.Update();

            Azul.SpriteSolidBox bigBlock = new Azul.SpriteSolidBox(new Azul.Rect(xPos, yPos, Constants.BOX_SIZE, Constants.BOX_SIZE),
                                                                   DrawColor.getColor(DrawColor.Shade.COLOR_GREY));
            bigBlock.Update();

            // Draw
            bigBlock.Render();
            smallBlock.Render();
        }

        public static void DrawBox(int xPos, int yPos, DrawColor.Shade inColor)
        {
            // This is draw in painted order
            // Draw the color big box first, then the inside.
            int x = (xPos + 1) * Constants.BOX_SIZE + Constants.BOX_SIZE_HALF;
            int y = (yPos + 1) * Constants.BOX_SIZE + Constants.BOX_SIZE_HALF;

            DrawInternal(x, y, inColor);
        }

        static public void DrawPreviewWindow(int xPos, int yPos, int sizeX, int sizeY, DrawColor.Shade inColor, DrawColor.Shade outColor)
        {
            // This is draw in painted order
            // Draw the color big box first, then the inside..

            Azul.SpriteSolidBox smallBlock = new Azul.SpriteSolidBox(new Azul.Rect(xPos, yPos, sizeX - 4, sizeY - 4),
                                                                     DrawColor.getColor(inColor));
            smallBlock.Update();

            Azul.SpriteSolidBox bigBlock = new Azul.SpriteSolidBox(new Azul.Rect(xPos, yPos, sizeX, sizeY),
                                                                   DrawColor.getColor(DrawColor.Shade.COLOR_GREY));
            bigBlock.Update();

            // draw
            bigBlock.Render();
            smallBlock.Render();
        }

        static public void DrawBackground()
        {
            int i;

            // Draw the bottom Bar
            int start_x = Constants.BOX_SIZE_HALF;

            for (i = 0; i < 12; i++)
            {
                DrawInternal(start_x + i * Constants.BOX_SIZE, Constants.BOX_SIZE_HALF, DrawColor.Shade.COLOR_DK_GREY);
            }

            // Draw the left and right bar
            start_x = 11 * Constants.BOX_SIZE + Constants.BOX_SIZE_HALF;

            for (i = 0; i < 31; i++)
            {
                DrawInternal(start_x, Constants.BOX_SIZE_HALF + i * Constants.BOX_SIZE, DrawColor.Shade.COLOR_DK_GREY);
                DrawInternal(Constants.BOX_SIZE_HALF, Constants.BOX_SIZE_HALF + i * Constants.BOX_SIZE, DrawColor.Shade.COLOR_DK_GREY);
            }

            // preview window
            DrawPreviewWindow((Constants.PREVIEW_WINDOW_X + 1) * Constants.BOX_SIZE + Constants.BOX_SIZE_HALF,
                               (Constants.PREVIEW_WINDOW_Y + 1) * Constants.BOX_SIZE + Constants.BOX_SIZE_HALF,
                               9 * Constants.BOX_SIZE, 7 * Constants.BOX_SIZE,
                               DrawColor.Shade.COLOR_BACKGROUND_CUSTOM,
                               DrawColor.Shade.COLOR_DK_GREY);
        }
    }
}
