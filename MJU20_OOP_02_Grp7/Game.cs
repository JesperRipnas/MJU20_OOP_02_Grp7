using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace MJU20_OOP_02_Grp7
{
    public class Game
    {
        public static bool GameOver { get; set; }
        public static char[,] Map { get; private set; }

        public static Player player;
        public static EndPoint endPoint;
        public static int currentLevel = 0;

        private static string levelName = "Level";
        private static int _tick = 0;
        private static int _updateRate = 500;
        // string that will contain the root folder of the projekt folder
        private static string DefaultFolder = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + @"scores\";

        public static void Start()
        {
            GameOver = false;
            UI.SetWindowTitle("MazeCrawler");
            string playerName;
            
            MainMenu();
            
            do
            {
                UI.PlayerName();
                playerName = Input.ReadString();
            } while (!(Menu.CheckPlayerName(playerName)));

            player = new Player(playerName, 100, 1, new Point(0, 0), '@', ConsoleColor.Green);
            
            Timer updateTimer = new System.Timers.Timer(_updateRate);
            updateTimer.Elapsed += Update;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;

            NextLevel();
            while (!GameOver)
            {
                
            }
            updateTimer.Elapsed -= Update; // unsubscribe to event when loop dies
            SaveScore(); // Save PlayerScore to file
            UI.DrawGameOver(player.PlayerScore);
            ResetGameVariables();
            Start();
        }

        public static void NextLevel()
        {
            // clearing current level data
            Enemy.activeEnemies = new List<Enemy>();
            Item.activeItems = new List<Item>();
          
            UI.SetUISize(80, 40);
            player.AddPlayerScore(currentLevel * 100);
            currentLevel++;
            Map = LevelReader.LoadLevel($"{levelName}{currentLevel}.txt");
        }

        public static void ResetGameVariables()
        {
            Game.player.PlayerScore = 0;
            currentLevel = 0;
        }

        // Method we call each time the OnTimedEvent get triggered (atm every 100 ms)
        private static void Update(Object source, ElapsedEventArgs e)
        {
            GameControls input = Input.GameInput(GameControls.PlayerControls);
            if (player.Hp <= 0)
            {
                Game.GameOver = true;
                return;
            }

            if (input != GameControls.None)
            {
                player.ControlPlayer(input);
            }

            Enemy.MoveAround(player);
            RunUI();
            _tick++;
        }

        public static void RunUI()
        {
            List<Entity> entities = new List<Entity>();
            entities.AddRange(Enemy.activeEnemies);
            entities.AddRange(Item.activeItems);
            entities.Add(endPoint);
            UI.DrawScreen(Map, player, entities.ToArray());
        }

        public static void SetPlayerPosition(Point position)
        {
            player.Position = position;
        }
        public static int GetTick()
        {
            return _tick;
        }

        public static Dictionary<string, int> CreateHighScore()
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
                UI.Print(e.Message);
                return playerScores;
            }
        }

        public static void SaveScore()
        {
            /// <summary>
            /// Creates a directory named "scores" in root folder if it isnt already exsisting.
            /// If file with the player name already exist, open that file and store the old scores.
            /// Then print old scores + new score to same file
            /// If file doesnt exist, just write the new score to file
            /// </summary>

            DateTime today = DateTime.Today;
            string _fullPath = DefaultFolder + Game.player.PlayerName.ToLower() + ".txt";
            try
            {
                if (!Directory.Exists(DefaultFolder))
                {
                    Directory.CreateDirectory(DefaultFolder);
                }
                if (!File.Exists(_fullPath))
                {
                    File.WriteAllText(_fullPath, today.ToString("d") + " " + Game.player.PlayerScore.ToString() + " Points");
                }
                else
                {
                    var scores = new List<string>();
                    string currentScore = today.ToString("d") + " " + Game.player.PlayerScore.ToString() + " Points";
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
                UI.Print(e.ToString());
            }
        }

        public static void MainMenu()
        {
            string[] options = { "Start", "Difficulty", "Score", "How To Play", "Exit" };

            switch (Menu.MainMenu(options))
            {
                case 0:
                    //starts game
                    break;
                case 1:
                    DifficultyMenu();
                    break;
                case 2:
                    UI.DrawScoreMenu();
                    break;
                case 3:
                    HowToPlay();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        private static void DifficultyMenu()
        {
            string[] options = { "EASY", "NORMAL", "HARD", "INSANE" };

            switch (Menu.MainMenu(options))
            {
                case 0:
                    //EASY
                    break;
                case 1:
                    //NORMAL
                    break;
                case 2:
                    //HARD
                    break;
                case 3:
                    //INSANE
                    break;
                default:
                    break;
            }

            MainMenu();

        }

        private static void HowToPlay()
        {
            UI.DrawHowToPlay();
            MainMenu();
        }

        
    }
}