using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MJU20_OOP_02_Grp7
{
    public class Game
    {
        public static bool GameOver = false;
        public static string PlayerName = "test";
        public static int PlayerScore = 0; 
        private static string DefaultFolder = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + @"scores\";

        public void Start()
        {

            SaveScore();
        }
        private void SaveScore()
        {
            string _fullPath = DefaultFolder + PlayerName + ".txt";
            WriteLine(_fullPath);

            if(!File.Exists(_fullPath))
            {
                File.WriteAllText(_fullPath, PlayerScore.ToString());
                // dastroyer of git
            }
        }
    }
}