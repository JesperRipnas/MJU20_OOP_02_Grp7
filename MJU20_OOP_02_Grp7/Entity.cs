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
            Enemy tempEnemy = null;
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
        public void Attack()
        {
            List<Point> playerArea = new List<Point>();
            playerArea.Add(new Point(0, 1));
            playerArea.Add(new Point(0, -1));
            playerArea.Add(new Point(1, 0));
            playerArea.Add(new Point(-1, 0));
            playerArea.Add(new Point(-1, -1));
            playerArea.Add(new Point(-1, 1));
            playerArea.Add(new Point(1, 1));
            playerArea.Add(new Point(1, -1));

            foreach(Point area in playerArea)
            {
                Point tempPosition = Position + area;
                Enemy tempEnemy = null;
                foreach (Enemy enemy in Enemy.activeEnemies)
                {
                    if (enemy.Position == tempPosition)
                    {
                        enemy.Damage(1);
                        tempEnemy = enemy;
                    }
                }
                if(tempEnemy != null)
                {
                    if (tempEnemy.Hp <= 0)
                    {
                        Enemy.activeEnemies.Remove(tempEnemy);
                    }
                }
            }
        }
    }
}