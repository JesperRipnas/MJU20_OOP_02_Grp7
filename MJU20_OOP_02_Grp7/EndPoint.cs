using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Represents the end point of the level.
    /// </summary>
    public class EndPoint : Entity
    {
        // TODO: Implement score for making the level here?
        public EndPoint(Point position, char symbol = 'ῼ', ConsoleColor color = ConsoleColor.Magenta) : base(position, symbol, color)
        {
            
        }
    }
}
