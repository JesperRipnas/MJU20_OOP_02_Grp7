using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using static System.Console;

namespace MJU20_OOP_02_Grp7
{
    public class Game
    {
        public static bool GameOver { get; set; }
        public static string PlayerName { get; set; }
        public static int PlayerScore { get; private set; }
        public static bool PlayerExists { get; set; }
        public static char[,] Map { get; private set; }

        public static Player player;
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

            player = new Player(100, 1, new Point(0, 0), '@', ConsoleColor.Green);
            UI.SetUISize(80, 40);

            Timer updateTimer = new System.Timers.Timer(500);
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
            GameControls input = Input.GameInput(GameControls.PlayerControls);

            if (input != GameControls.None)
            {
                player.MovePlayer(input);
            }

            Enemy.MoveAround(player);

            Entity[] entities = new Entity[Enemy.activeEnemies.Count + Item.activeItems.Count];
            Array.Copy(Enemy.activeEnemies.ToArray(), entities, Enemy.activeEnemies.Count);
            Array.Copy(Item.activeItems.ToArray(), 0, entities, Enemy.activeEnemies.Count, Item.activeItems.Count);
            UI.DrawScreen(Map, player, entities);
        }

        public static void SetPlayerPosition(Point position)
        {
            player.Position = position;
        }

        private static Dictionary<string, int> CreateHighScore()
        {
            /// <summary>
            /// Reads all .txt files in the scores folder
            /// To avoid errors, it will create a scores folder in root if not already created
            /// Gather the name of the file (player) + the highest score in that file
            /// Adds a string of highest point for the player + player name to a List
            /// Sorts the list in desending order by score
            /// </summary>
            Dictionary<string, int> playerScores = new Dictionary<string, int>();
            try
            {
                if (!Directory.Exists(DefaultFolder))
                {
                    Directory.CreateDirectory(DefaultFolder);
                }
                foreach (string file in Directory.EnumerateFiles(DefaultFolder, "*.txt"))
                {
                    List<int> personalScores = new List<int>();
                    string[] text = File.ReadAllLines(file);
                    foreach (var line in text)
                    {
                        string[] word = line.Split(' ');
                        personalScores.Add(Convert.ToInt32(word[1]));
                    }
                    personalScores.Sort();
                    personalScores.Reverse();
                    playerScores.Add(Path.GetFileNameWithoutExtension(file), personalScores[0]);
                }
                var sortedPlayerScores = playerScores.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);

                return sortedPlayerScores;
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return playerScores;
            }
        }

        private static void SaveScore()
        {
            /// <summary>
            /// Creates a directory named "scores" in root folder if it isnt already exsisting.
            /// If file with the player name already exist, open that file and store the old scores.
            /// Then print old scores + new score to same file
            /// If file doesnt exist, just write the new score to file
            /// </summary>

            DateTime today = DateTime.Today;
            string _fullPath = DefaultFolder + PlayerName.ToLower() + ".txt";
            try
            {
                if (!Directory.Exists(DefaultFolder))
                {
                    Directory.CreateDirectory(DefaultFolder);
                }
                if (!File.Exists(_fullPath))
                {
                    File.WriteAllText(_fullPath, today.ToString("d") + " " + PlayerScore.ToString() + " Points");
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