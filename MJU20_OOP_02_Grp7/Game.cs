using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using System.Timers;

namespace MJU20_OOP_02_Grp7
{
    public class Game
    {
        public bool GameOver { get; set; }
        public string PlayerName { get; set; }  
        public int PlayerScore { get; private set; }    
        public static bool PlayerExist { get; set;}
        private Player player;         
        // string that will contain the root folder of the projekt folder
        private static string DefaultFolder = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\")) + @"scores\";

        public Game()
        {
            this.GameOver = false;
            this.PlayerName = "Test";
            this.PlayerScore = 2;
        }
        public void Start()
        {
            Title = "MazeCrowler";

            Timer aTimer = new System.Timers.Timer(100);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            GameOver = true; // change for live

            while(!GameOver){}
            aTimer.Elapsed -= OnTimedEvent; // unsubscribe to event when loop dies
            SaveScore(); // Save PlayerScore to file
        }
        // Method we call each time the OnTimedEvent get triggered (atm every 100 ms)
        private void Update()
        {
            
        }
        // Event that will trigger based on aTimer ms interval
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Update();
        }
        private void SaveScore()
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
                if(!File.Exists(_fullPath))
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