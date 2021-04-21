﻿using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public class Player : Creature
    {
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public int PlayerLives { get; private set; }

        public Player(string playerName, int hp, int dmg, Point position, char symbol, ConsoleColor color) : base(hp, dmg, position, symbol, color)
        {
            PlayerName = playerName;
            PlayerScore = 0;
        }

        public string Activate(Enemy enemy)
        {
            return $"You did {Dmg} damage to {enemy.Symbol}";
        }

        public void ControlPlayer(GameControls input)
        {
            switch (input)
            {
                case GameControls.MoveUp:
                    Move(new Point(0, -1), this);
                    break;

                case GameControls.MoveRight:
                    Move(new Point(+1, 0), this);
                    break;

                case GameControls.MoveDown:
                    Move(new Point(0, +1), this);
                    break;

                case GameControls.MoveLeft:
                    Move(new Point(-1, 0), this);
                    break;
                case GameControls.Attack:
                    Attack();
                    break;
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

                        enemy.Move(area, this); //Move enemy when attacked

                        tempEnemy = enemy;
                    }
                }
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
        public void AddPlayerScore(int score)
        {
            PlayerScore += score;
        }
    }
}