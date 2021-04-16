using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    public struct TrapStats
    {
        public int Dmg;
        public ConsoleColor Color;

        public TrapStats(int dmg, ConsoleColor color)
        {
            Dmg = dmg;
            Color = color;
        }
    }

    public class Trap : Entity
    {
        static public List<Trap> activeTraps = new List<Trap>();
        static public Dictionary<char, TrapStats> trapTypes = new Dictionary<char, TrapStats>()
        {
            {'·', new TrapStats(25, ConsoleColor.DarkGray)}
        };

        public Trap(char symbol, Point position, TrapStats stats) : base(position, symbol, color)
        {

        }
    }
}
