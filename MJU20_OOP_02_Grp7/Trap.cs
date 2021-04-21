using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Holds information about the Trap.
    /// </summary>
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
    /// <summary>
    /// Represents a trap inside the world. Inherits from <c>Entity</c>
    /// </summary>
    public class Trap : Entity
    {
        static public List<Trap> ActiveTraps = new List<Trap>();
        static public Dictionary<char, TrapStats> TrapTypes = new Dictionary<char, TrapStats>()
        {
            {'·', new TrapStats(25, ConsoleColor.DarkGray)}
        };

        public Trap(char symbol, Point position, TrapStats stats) : base(position, symbol, stats.Color)
        {

        }
    }
}
