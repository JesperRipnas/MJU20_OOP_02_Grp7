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
        Hotbar1,
        Hotbar2,
        OpenMenu,
        PlayerControls
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

        public static GameControls GameInput()
        {
            GameControls input = GameControls.None;
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

                default:
                    break;
            }
            return input;
        }
    }
}