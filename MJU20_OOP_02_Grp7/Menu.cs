using System;
using System.Text.RegularExpressions;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Represents the main menu of the game.
    /// </summary>
    public class Menu
    {

        /// <summary>
        /// Runs the main menu until the user makes a choice from the available options.
        /// </summary>
        /// <returns></returns>
        public static int MainMenu(string[] options)
        {
            GameControls input;
            int select = 0;
            //display menu
            UI.DrawTitleLogo(26);

            do
            {

                UI.DrawOptions(19 ,options, select);

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