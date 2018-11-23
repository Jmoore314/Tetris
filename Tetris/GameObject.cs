using System;

namespace Tetris
{
    class GameStats
    {
        // data
        private int levelNum;
        private int lineCount;
        private int gameScore;

        public GameStats()
        {
            this.levelNum = 0;
            this.lineCount = 0;
            this.gameScore = 0;
        }

        public int GetLevelNum()
        {
            return this.levelNum;
        }

        public void SetLevelNum(int level)
        {
            this.levelNum = level;
        }

        public int GetLineCount()
        {
            return this.lineCount;
        }

        public void SetLineCount(int line)
        {
            this.lineCount = line;
        }

        public int GetScore()
        {
            return this.gameScore;
        }

        public void SetScore(int score)
        {
            this.gameScore = score;
        }


    }
}
