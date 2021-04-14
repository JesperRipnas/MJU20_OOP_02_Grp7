using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    public class Rat : Creature
    {
        public Rat(Point position) : base(3, 1, position, 'Q', ConsoleColor.DarkYellow)
        {

        }
    }

    public class Goblin : Creature
    {
        public Goblin(Point position) : base(7, 3, position, 'ö', ConsoleColor.DarkCyan)
        {

        }
    }
}
