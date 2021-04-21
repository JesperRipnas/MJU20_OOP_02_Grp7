﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Represents an entity in the world.
    /// </summary>
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

        /// <summary>
        /// Takes a Point representing the direction an entity wants to move
        /// along with the caller of the function. Checks if the entity is
        /// allowed to move to the target square, if so, updates the entitys
        /// position.
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="sender"></param>
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
                        UI.MessageList.Add(new GameMessage(item.Activate(), Game.GetTick() + 10));
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
                        UI.MessageList.Add(new GameMessage(((Enemy)sender).Activate(), Game.GetTick() + 10));
                    }
                    if (collider is object)
                    {
                        return;
                    }
                }
                Position += movement;
            }
        }

        /// <summary>
        /// Takes an enemy and make its color flicker if it takes damage.
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public async Task FlickerAsync(Enemy enemy)
        {
            ConsoleColor enemyColor = enemy.Color;
            for (int i = 0; i < 6; i++)
            {
                enemy.Color = ConsoleColor.Red;
                Game.RunUI();
                await Task.Delay(50);
                enemy.Color = enemyColor;
                Game.RunUI();
            }
        }
    }
}