using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Holds all allowed game controls.
    /// </summary>
    public enum GameControls
    {
        None,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        Attack,
        Hotbar1,
        Hotbar2,
        PauseMenu,
        PlayerControls,
        MenuUp,
        MenuDown,
        MenuSelect,
        MenuControls
    }

    /// <summary>
    /// Represents an input from the player coming from the keyboard.
    /// </summary>
    public class Input
    {
        private static Dictionary<ConsoleKey, inputEvent> _events = new Dictionary<ConsoleKey, inputEvent>();
        
        public delegate void inputEvent(ConsoleKey key);



        /// <summary>
        /// Lets user input a string and returns it
        /// </summary>
        /// <returns>the string that was input by the user</returns>
        public static string ReadString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// NEW
        /// Links the input key to the method
        /// </summary>
        /// <param name="input">ConsoleKey that triggers</param>
        /// <param name="e">Method that gets invoked by the input</param>
        public static void AddInput(ConsoleKey input, inputEvent e){
            _events.Add(input, e);
        }

        /// <summary>
        /// NEW
        /// Removes a specific input from the event list
        /// </summary>
        /// <param name="input">ConsoleKey that should be removed from list</param>
        public static void RemoveInput(ConsoleKey input)
        {
            _events.Remove(input);
        }

        /// <summary>
        /// NEW
        /// Clears all of the current inputs,
        /// </summary>
        public static void PurgeInput()
        {
            _events.Clear();
        }

        /// <summary>
        /// NEW
        /// Checks the event list for a matching input
        /// and invokes method that was added via AddInput
        /// </summary>
        public static void ReadInput()
        {
            ConsoleKey input = ConsoleKey.NoName;
            if (_events.ContainsKey(input))
            {
                _events[input].Invoke(input);
            }
        }

        /// <summary>
        /// OLD
        /// Returns a GameControls within the controleset that is pased.
        /// </summary>
        /// <param name="controleset">The set of controls that is expected in return</param>
        /// <returns>Returns a GameControls based on if a key was pressed</returns>
        public static GameControls GameInput(GameControls controleset)
        {
            GameControls input = GameControls.None;

            if (controleset == GameControls.PlayerControls)
            {
                switch (Readkey())
                {
                    case ConsoleKey.W:
                        input = GameControls.MoveUp;
                        break;

                    case ConsoleKey.S:
                        input = GameControls.MoveDown;
                        break;

                    case ConsoleKey.A:
                        input = GameControls.MoveLeft;
                        break;

                    case ConsoleKey.D:
                        input = GameControls.MoveRight;
                        break;

                    case ConsoleKey.Spacebar:
                        input = GameControls.Attack;
                        break;

                    case ConsoleKey.Escape:
                        input = GameControls.PauseMenu;
                        break;

                    default:
                        break;
                }
            }
            else if (controleset == GameControls.MenuControls)
            {
                switch (Readkey())
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        input = GameControls.MenuUp;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        input = GameControls.MenuDown;
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        input = GameControls.MenuSelect;
                        break;

                    default:
                        break;
                }
            }

            return input;
        }
        
        /// <summary>
        /// Reads all of the ConsoleKeys in the input stack
        /// </summary>
        /// <returns>the last key in the ConsoleKey stack</returns>
        private static ConsoleKey Readkey()
        {
            ConsoleKey key;
            key = ConsoleKey.NoName;
            while (Console.KeyAvailable)
            {
                key = Console.ReadKey(true).Key;
            }
            return key;
        }
    }
}