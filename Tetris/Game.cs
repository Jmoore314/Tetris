using System;
using System.Diagnostics;
using Tetris.team_4;

namespace Tetris
{
    class Tetris : Azul.Game
    {
        // Data: --------------------------------------------

            // Audio: ---------------------------------------
            IrrKlang.ISoundEngine AudioEngine = null;

            IrrKlang.ISound music = null;
            public float vol_delta = 0.005f;

            IrrKlang.ISoundSource srcShoot = null;
            IrrKlang.ISound sndShoot = null;

            float volume = .2f;
        private float levelsToDoubleSpeed = 10f;

            // Font: ----------------------------------------
            Azul.Texture pFont;

            // Demo: ----------------------------------------
            GameStats stats;

        //to prevent pause being pressed too much
        public static int pauseCount = 0;


        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Tetris Framework");
            this.SetWidthHeight(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Audio
            //---------------------------------------------------------------------------------------------------------

            // Create the Audio Engine
            AudioEngine = new IrrKlang.ISoundEngine();

            // Play a sound file
            music = AudioEngine.Play2D("theme.wav",true);
            music.Volume = volume;
            
            // Resident loads
            srcShoot = AudioEngine.AddSoundSourceFromFile("shoot.wav");
            sndShoot = AudioEngine.Play2D(srcShoot, false, false, false);
            sndShoot.Stop();

            //---------------------------------------------------------------------------------------------------------
            // Setup Font
            //---------------------------------------------------------------------------------------------------------

            // Font - texture
            pFont = new Azul.Texture("consolas20pt.tga");
            Debug.Assert(pFont != null);

            GlyphMan.AddXml("Consolas20pt.xml", pFont);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            

            //---------------------------------------------------------------------------------------------------------
            // Demo variables
            //---------------------------------------------------------------------------------------------------------

            stats = new GameStats();
            GameManager.NewGame();

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Snd update - Need to be called once a frame
            AudioEngine.Update();

            //-----------------------------------------------------------
            // Input Test
            //-----------------------------------------------------------

            // InputTest.KeyboardTest();
            // InputTest.MouseTest();

            //-----------------------------------------------------------
            // Sound Experiments
            //-----------------------------------------------------------

            // Adjust music theme volume

            music.PlaybackSpeed = 1.0f + ScoreManager.CurrentLevel/ levelsToDoubleSpeed;
            //--------------------------------------------------------
            // object updates
            //--------------------------------------------------------

            if (GameManager.paused)
            {
                music.Stop();
                if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_P) && pauseCount >=10)
                {
                    GameManager.UnPauseGame();
                    music = AudioEngine.Play2D("theme.wav", true);
                    music.Volume = volume;
                    pauseCount = 0;
                }
                else
                {
                    pauseCount++;
                }
            }
            else
            {
                if (GameManager.running)
                {
                    Player.Update();
                    GameManager.Update();
                    stats.SetScore(ScoreManager.TotalScore);
                    stats.SetLevelNum(ScoreManager.CurrentLevel);
                    stats.SetLineCount(ScoreManager.TotalLinesCleared);
                }
                else
                {
                    music.Stop();
                    if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ENTER))
                    {
                        GameManager.NewGame();
                        music = AudioEngine.Play2D("theme.wav", true);
                        music.Volume = volume;
                    }
                }
            }

            
            //--------------------------------------------------------
            // Keyboard test
            //--------------------------------------------------------

            // Quick hack to have a one off call.
            // you need to release the keyboard between calls 
#if false
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ENTER) && prevEnterKey == 0)
            {
                prevEnterKey = Azul.AZUL_KEY.KEY_ENTER;
                sndShoot = AudioEngine.Play2D(srcShoot, false, false, false);
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ENTER))
                {
                    prevEnterKey = 0;
                }
            } 
#endif

            //--------------------------------------------------------
            // Stats test
            //--------------------------------------------------------

            
        }


        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // Draw sprite with texture
           //Player.CurTetro.Draw();
            // Update background
            SOM.DrawBackground();

            if (GameManager.paused)
            {
                SOM.DrawStringsPause(stats);
            }
            else
            {
                if (GameManager.running) SOM.DrawStringsRunning(stats);
                else SOM.DrawStringsGameOver(stats);
            }

            GameManager.Draw();
            Grid.Draw();
            // Test play field
            

#if false
            // Cycle all the tetris pieces
            if (count < 2 * 10)
            {
                Shape.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, Shape.Orientation.ORIENT_0);

                Shape.drawLine(3, 3, Shape.Orientation.ORIENT_0);
                Shape.drawL1(5, 8, Shape.Orientation.ORIENT_0);
                Shape.drawL2(5, 14, Shape.Orientation.ORIENT_0);
                Shape.drawT(5, 19, Shape.Orientation.ORIENT_0);
                Shape.drawZ1(5, 23, Shape.Orientation.ORIENT_0);
                Shape.drawZ2(5, 28, Shape.Orientation.ORIENT_0);
                Shape.drawSquare(8, 4, Shape.Orientation.ORIENT_0);
            }
            else if (count < 2 * 20)
            {
                Shape.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, Shape.Orientation.ORIENT_1);

                Shape.drawLine(3, 3, Shape.Orientation.ORIENT_1);
                Shape.drawL1(5, 8, Shape.Orientation.ORIENT_1);
                Shape.drawL2(5, 14, Shape.Orientation.ORIENT_1);
                Shape.drawT(5, 19, Shape.Orientation.ORIENT_1);
                Shape.drawZ1(5, 23, Shape.Orientation.ORIENT_1);
                Shape.drawZ2(5, 28, Shape.Orientation.ORIENT_1);
                Shape.drawSquare(8, 4, Shape.Orientation.ORIENT_1);
            }
            else if (count < 2 * 30)
            {
                Shape.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, Shape.Orientation.ORIENT_2);

                Shape.drawLine(3, 3, Shape.Orientation.ORIENT_2);
                Shape.drawL1(5, 8, Shape.Orientation.ORIENT_2);
                Shape.drawL2(5, 14, Shape.Orientation.ORIENT_2);
                Shape.drawT(5, 19, Shape.Orientation.ORIENT_2);
                Shape.drawZ1(5, 23, Shape.Orientation.ORIENT_2);
                Shape.drawZ2(5, 28, Shape.Orientation.ORIENT_2);
                Shape.drawSquare(8, 4, Shape.Orientation.ORIENT_2);
            }
            else
            {
                Shape.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, Shape.Orientation.ORIENT_3);

                Shape.drawLine(3, 3, Shape.Orientation.ORIENT_3);
                Shape.drawL1(5, 8, Shape.Orientation.ORIENT_3);
                Shape.drawL2(5, 14, Shape.Orientation.ORIENT_3);
                Shape.drawT(5, 19, Shape.Orientation.ORIENT_3);
                Shape.drawZ1(5, 23, Shape.Orientation.ORIENT_3);
                Shape.drawZ2(5, 28, Shape.Orientation.ORIENT_3);
                Shape.drawSquare(8, 4, Shape.Orientation.ORIENT_3);
            } 
#endif

         
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

