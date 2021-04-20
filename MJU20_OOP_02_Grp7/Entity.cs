using System;
using System.Collections.Generic;
using System.Timers;

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
                things.Add(Game.endPoint);
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
                        Item item = ((Item)collider);
                        // Calculate item score
                        Game.player.AddPlayerScore(item.Score);
                        // acticivate item
                        UI.EventMessageList.Add(item.Activate());
                        Item.activeItems.Remove(item);
                    }
                    else if (collider is Enemy)
                    {
                        // if player walks into player do damage to player
                        Game.player.Damage(((Enemy)collider).Dmg);
                        return;
                    }
                    else if (collider is EndPoint)
                    {
                        Game.NextLevel();
                        return;
                    }
                    //else if (collider is Trap)
                }
                else if (sender is Enemy)
                {
                    // if enemy walks into anything other than player abort movement
                    if (collider is Player)
                    {
                        Game.player.Damage(((Enemy)sender).Dmg);
                        UI.EventMessageList.Add(((Enemy)sender).Activate());
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
                        enemy.Damage(Game.player.Dmg);
                        UI.EventMessageList.Add(Game.player.Activate(enemy));
                        Point tempEnemyPosition = enemy.Position + area;
                        if (Game.Map[tempEnemyPosition.X, tempEnemyPosition.Y] == ' ')
                        {
                            enemy.Position += area;
                        }
                        tempEnemy = enemy;
                    }
                }
                if(tempEnemy != null)
                {
                    if (tempEnemy.Hp <= 0)
                    {
                        Game.player.AddPlayerScore(tempEnemy.Score);     // Add score for killing enemy
                        Enemy.activeEnemies.Remove(tempEnemy);
                        UI.EventMessageList.Add($"Enemy {tempEnemy.Symbol} died!, you recieved {tempEnemy.Score} points");
                    }
                }
            }
        }
    }
}