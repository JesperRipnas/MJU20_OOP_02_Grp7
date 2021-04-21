﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public void Attack()
        {
            //Creates a list of positions around the player to check for enemies
            List<Point> playerArea = new List<Point>();
            playerArea.Add(new Point(0, 1));
            playerArea.Add(new Point(0, -1));
            playerArea.Add(new Point(1, 0));
            playerArea.Add(new Point(-1, 0));
            playerArea.Add(new Point(-1, -1));
            playerArea.Add(new Point(-1, 1));
            playerArea.Add(new Point(1, 1));
            playerArea.Add(new Point(1, -1));

            foreach (Point area in playerArea)
            {
                //Check for enemy in current position
                Point tempPosition = Position + area;
                Enemy tempEnemy = null;
                foreach (Enemy enemy in Enemy.activeEnemies)
                {
                    if (enemy.Position == tempPosition)
                    {
                        enemy.Damage(Game.player.Dmg); //Make damage to enemy
                        enemy.ShowHp = true;
                        enemy.showHpTick = Game.GetTick();
                        //FlickerAsync(enemy);
                        UI.MessageList.Add(new GameMessage(Game.player.Activate(enemy), Game.GetTick() + 10));
                        Point tempEnemyPosition = enemy.Position + area + area;

                        enemy.Move(area, this);  //Move enemy when attacked

                        tempEnemy = enemy;
                    }
                }
                //
                if (tempEnemy != null)
                {
                    if (tempEnemy.Hp <= 0)
                    {
                        Game.player.AddPlayerScore(tempEnemy.Score); // Add score for killing enemy
                        tempEnemy.ShowHp = false; //Remove hp when enemy is dead
                        Enemy.activeEnemies.Remove(tempEnemy); //Remove enemy from list when dead
                        UI.MessageList.Add(new GameMessage($"Enemy {tempEnemy.Symbol} died!, you recieved {tempEnemy.Score} points", Game.GetTick() + 10));
                    }
                }
            }
        }
        //Method to get enemy to flicker when attacked
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