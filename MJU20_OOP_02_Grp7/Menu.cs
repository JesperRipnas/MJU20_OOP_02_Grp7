using System;
using System.Text.RegularExpressions;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Represents the main menu of the game.
    /// </summary>
    public class Menu
    {
        private int select;

        private string[] options;

        private string subTitle;

        public Menu(string[] options, string subTitle)
        {
            this.options = options;
            this.subTitle = subTitle;
        }

        public Menu()
        {
            string[] standardoption = { "Start", "Difficulty", "Score", "How To Play", "Exit"};

            this.options = standardoption;
            this.subTitle = "";
        }



        /// <summary>
        /// Runs the main menu until the user makes a choice from the available options.
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            GameControls input;
            select = 0;
            //display menu
            UI.MainMenu(subTitle);

            do
            {

                UI.DrawOptions(options, select);

                input = Input.GameInput(GameControls.MenuControls);

                //update select
                if (input == GameControls.MenuUp)
                {
                    --select;
                }
                else if (input == GameControls.MenuDown)
                {
                    ++select;
                }

                if (select >= options.Length)
                {
                    select = 0;
                }
                else if (select <= -1)
                {
                    select = options.Length - 1;
                }
            } while (input != GameControls.MenuSelect);

            return select;
        }

        /// <summary>
        /// Takes a string and validate that it only contains letters (a-ö/A-Ö), numbers (0-9) or _
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns a bool value based on if input string is following the rules or not</returns>
        public static bool CheckPlayerName(string input)
        {
            if(input.Length >= 3)
            {
                if (Regex.IsMatch(input, @"^[a-öA-Ö0-9_]+$")) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }
    }
}