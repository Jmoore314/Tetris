using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.team_4
{
    static class ScoreManager
    {
        public static int TotalScore { get; private set; }
        public static int CurrentLevel { get; private set; }
        public static int TotalLinesCleared { get; private set; }

        private static void DisplayScore()
        {
            String score = String.Format("Total score = {0}", TotalScore);
            Console.WriteLine(score);
        }

        private static void DisplayLevel()
        {
            String currentLevelString = String.Format("Current level = {0}", CurrentLevel);
            Console.WriteLine(currentLevelString);
        }

        private static void DisplayLinesCleared()
        {
            String totalLinesClearedString = String.Format("Total lines cleared = {0}", TotalLinesCleared);
            Console.WriteLine(totalLinesClearedString);
        }


        public static void Clear()
        {
            TotalScore = CurrentLevel = TotalLinesCleared = 0;
        }
        public static void CalculateHardDrop(int deltaY)
        //The design doc originally indicated this method would take in two int
        //parameters, one of which was int currentLevel.  However, since currentLevel
        //is already part of this class definition, we have access to it be default
        //and do not need to pass it as a parameter.
        {
            TotalScore += deltaY * (CurrentLevel + 1);
        }


        //The design doc originally indicated this method would take in two int
        //parameters, one of which was int currentLevel.  However, since currentLevel
        //is already part of this class definition, we have access to it be default
        //and do not need to pass it as a parameter.
        public static void CalculateLineClear(int linesCleared)
        {
            switch (linesCleared)
            {
                case 1:
                    TotalScore += 40 * (CurrentLevel + 1);
                    TotalLinesCleared += 1;
                    CalculateLevel(TotalLinesCleared, CurrentLevel);
                    break;
                case 2:
                    TotalScore += 100 * (CurrentLevel + 1);
                    TotalLinesCleared += 2;
                    CalculateLevel(TotalLinesCleared, CurrentLevel);
                    break;
                case 3:
                    TotalScore += 300 * (CurrentLevel + 1);
                    TotalLinesCleared += 3;
                    CalculateLevel(TotalLinesCleared, CurrentLevel);
                    break;
                case 4:
                    TotalScore += 1200 * (CurrentLevel + 1);
                    TotalLinesCleared += 4;
                    CalculateLevel(TotalLinesCleared, CurrentLevel);
                    break;
            }
        }

        private static void CalculateLevel(int lineNum, int level)
        {
            CurrentLevel = lineNum / 10;
        }
    }
}