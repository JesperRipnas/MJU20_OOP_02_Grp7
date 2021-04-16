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
        public static ConsoleKey Readkey()
        {
            List<ConsoleKey> key = new List<ConsoleKey>();
            key.Add(ConsoleKey.NoName);
            while (Console.KeyAvailable)
            {
                key.Add(Console.ReadKey(true).Key);
            }
            return key[key.Count - 1];
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