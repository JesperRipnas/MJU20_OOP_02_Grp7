using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
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

    public class Input
    {
        private static Dictionary<ConsoleKey, inputEvent> events = new Dictionary<ConsoleKey, inputEvent>();
        
        public delegate void inputEvent(ConsoleKey key);
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

        public static void AddInput(ConsoleKey input, inputEvent e){
            events.Add(input, e);
        }

        public static void RemoveInput(ConsoleKey input)
        {
            events.Remove(input);
        }

        public static void PurgeInput()
        {
            events.Clear();
        }

        public static void ReadInput()
        {
            ConsoleKey input = ConsoleKey.NoName;
            if (events.ContainsKey(input))
            {
                events[input].Invoke(input);
            }
        }

        public static GameControls GameInput(GameControls controlset)
        {
            GameControls input = GameControls.None;

            if (controlset == GameControls.PlayerControls)
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
            else if (controlset == GameControls.MenuControls)
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
    }
}