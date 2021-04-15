using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using System.Timers;

namespace MJU20_OOP_02_Grp7
{
    public class Game
    {
        public static bool GameOver { get; set; }
        public static string PlayerName { get; set; }
        public static int PlayerScore { get; private set; }
        public static bool PlayerExists { get; set; }
        public static char[,] Map { get; private set; }

        private static Player player;
        private static bool loadNextLevel = false;
        private static string levelName = "Level";
        private static int currentLevel = 0;

        // string that will contain the root folder of the projekt folder
        private static string DefaultFolder = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + @"scores\";

        public Game()
        {

        }
        public static void Start()
        {
            GameOver = false;
            PlayerName = "Test";
            PlayerScore = 2;
            Title = "MazeCrawler";

            player = new Player(100, 1, new Point(0, 0), '@', ConsoleColor.Green, 0, 1);
            UI.SetUISize(80, 40);

            Timer updateTimer = new System.Timers.Timer(100);
            updateTimer.Elapsed += Update;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
            loadNextLevel = true;

            

            while (!GameOver)
            {
                if (loadNextLevel)
                {
                    currentLevel++;
                    Map = LevelReader.LoadLevel($"{levelName}{currentLevel}.txt");
                    loadNextLevel = false;
                }
            }
            updateTimer.Elapsed -= Update; // unsubscribe to event when loop dies
            SaveScore(); // Save PlayerScore to file
        }
        // Method we call each time the OnTimedEvent get triggered (atm every 100 ms)
        private static void Update(Object source, ElapsedEventArgs e)
        {
            ConsoleKey input = Input.Readkey();
            //player.Controll(input);
            
            UI.DrawScreen(Map, player, new Entity[0]);
        }

        public static void SetPlayerPosition(Point position)
        {
            player.Position = position;
        }
        private static void SaveScore()
        {
            /*
            If file with the player name already exist, open that file and store the old scores.
            Then print old scores + new score to same file

            If file doesnt exist, just write the new score to file
            */
            DateTime today = DateTime.Today;
            string _fullPath = DefaultFolder + PlayerName.ToLower() + ".txt";
            try
            {
                if (!File.Exists(_fullPath))
                {
                    File.WriteAllText(_fullPath, today.ToString("d") + " " + PlayerScore.ToString() + " Points");
                    WriteLine("Saved highscore to " + _fullPath);
                }
                else
                {
                    var scores = new List<string>();
                    string currentScore = today.ToString("d") + " " + PlayerScore.ToString() + " Points";
                    scores.Add(currentScore);
                    scores.AddRange(File.ReadAllLines(_fullPath));

                    File.WriteAllText(_fullPath, string.Empty); // write an empty string to file to clear old content

                    using (StreamWriter w = File.AppendText(_fullPath))
                    {
                        foreach (var score in scores)
                        {
                            w.WriteLine(score.ToString());
                        }
                        w.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}