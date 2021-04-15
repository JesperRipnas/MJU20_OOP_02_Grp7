using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    public class Input
    {

        public ConsoleKey Readkey()
        {
            List<ConsoleKey> key = new List<ConsoleKey>();
            key.Add(ConsoleKey.NoName);
            while (Console.KeyAvailable)
            {
                key.Add(Console.ReadKey(true).Key);
            }
            return key[key.Count - 1];
        }
    }
}
