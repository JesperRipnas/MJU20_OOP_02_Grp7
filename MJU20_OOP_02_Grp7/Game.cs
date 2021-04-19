using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
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
        public static EndPoint endPoint;
        public static bool loadNextLevel = true;
        private static string levelName = "Level";
        public static int currentLevel = 0;
        private static int _tick = 0;

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

            //MainMenu();
            //Console.Clear();
            //Console.Write("Player Name: ");
            //PlayerName = Console.ReadLine();

            player = new Player(100, 1, new Point(0, 0), '@', ConsoleColor.Green);
            

            Timer updateTimer = new System.Timers.Timer(500);
            updateTimer.Elapsed += Update;
            updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
            loadNextLevel = true;
            NewLevel();
            
            while (!GameOver)
            {

            }
            updateTimer.Elapsed -= Update; // unsubscribe to event when loop dies
            SaveScore(); // Save PlayerScore to file
        }

        public static void NewLevel()
        {
            Map = null;
            //Menu.LoadingScreen();
            UI.SetUISize(80, 40);
            //player.AddPlayerScore(currentLevel * 100);
            currentLevel++;
            Map = LevelReader.LoadLevel($"{levelName}{currentLevel}.txt");
            loadNextLevel = false;
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

            List<Entity> entities = new List<Entity>();
            entities.AddRange(Enemy.activeEnemies);
            entities.AddRange(Item.activeItems);
            entities.Add(endPoint);
            UI.DrawScreen(Map, player, entities.ToArray());
            _tick++;
        }

        public static void SetPlayerPosition(Point position)
        {
            player.Position = position;
        }
        public static int GetTick()
        {
            return _tick;
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

        private static void MainMenu()
        {
            Menu mainMenu = new Menu();

            switch (mainMenu.Run())
            {
                case 0:
                    //start game
                    break;
                case 1:
                    difficultyMenu();
                    break;
                case 2:
                    ScoreMenu();
                    break;
                case 3:
                    //options
                    break;
                case 4:
                    //exit
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        private static void difficultyMenu()
        {
            string[] options = { "EASY", "NORMAL", "HARD", "INSANE" };
            Menu difficulty = new Menu(options, "  Difficulty");

            switch (difficulty.Run())
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

        private static void ScoreMenu()
        {
            Console.Clear();
            //score
            Dictionary<string, int> scores = CreateHighScore();

            Console.WriteLine("Scores");
            Console.WriteLine();

            foreach (KeyValuePair<string, int> entry in scores)
            {
                // do something with entry.Value or entry.Key
                Console.Write(entry.Key);
                for (int i = 0; i < 40 - entry.Key.Length; i++)
                {
                    Console.Write(".");
                }
                Console.WriteLine(entry.Value);
            }

            Console.ReadKey();
            MainMenu();

        }
    }
}