using System;
using System.Collections.Generic;

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

        public void Move(Point movement, object sender)
        {
            //Wall collision check
            Point tempPosition = Position + movement;
            if (Game.Map[tempPosition.X, tempPosition.Y] == ' ')
            {
                object collider = null;
                
                List<object> things = new List<object>();
                things.Add(Game.player);
                things.AddRange(Item.activeItems);
                things.AddRange(Enemy.activeEnemies);
                //things.AddRange(Traps.activeTraps);
                // Check for items/traps/enemies

                foreach (Entity thing in things)
                {
                    if (thing.Position == tempPosition)
                    {
                        collider = thing;
                    }
                }

                if (sender is Player)
                {
                    // check what the player collided with
                    if (collider is Item)
                    {
                        // acticivate item
                        UI.EventMessageList.Add(((Item)collider).Activate());
                        Item.activeItems.Remove((Item)collider);
                    }
                    else if (collider is Enemy)
                    {
                        // if player walks into player do damage to player
                        Game.player.Damage(((Enemy)collider).Dmg);
                        return;
                    }
                    // else if (collide is Trap)
                }
                else if (sender is Enemy)
                {
                    // if enemy walks into anything other than player abort movement
                    if (collider is Player)
                    {
                        UI.EventMessageList.Add(((Enemy)sender).Activate());
                        Game.player.Damage(((Enemy)sender).Dmg);
                    }
                    if (collider is object)
                    {
                        return;
                    }
                }

                Position += movement;
            }
        }
    }
}