using System;

namespace MJU20_OOP_02_Grp7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Event for when application is closed down with X or ctrl+c
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Game.Start();
        }
        /// <summary>
        /// Checks if player object is null. If not, saves the score.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            try
            {
                if(Game.player != null) Game.SaveScore();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}