using System;

namespace MJU20_OOP_02_Grp7
{
    public class Entity
    {
        public Point Position { get; set; }
        public char Symbol { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Entity(Point position, char symbol, ConsoleColor color)
        {
            Position = position;
            Symbol = symbol;
            Color = color;
        }

        public void Move(Point movement)
        {
            //Wall collision check
            Point tempPosition = Position + movement;
            if (Game.Map[tempPosition.X, tempPosition.Y] ==  ' ')
            {
                Item temp = null;
                // Check for items/tramps/enemies
                foreach(var item in Item.activeItems)
                {
                    if(item.Position == tempPosition)
                    {
                        Game.player.Heal(50);
                        temp = item;
                    }
                }
                if(temp != null)
                {
                    Item.activeItems.Remove(temp);
                }
                Position += movement;
            }
        }
    }
}