﻿using System;

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

        public int GetPlayerScore()
        {
            return PlayerScore;
        }

        public int GetPlayerLives()
        {
            return PlayerLives;
        }
        public string Activate(Enemy enemy)
        {
            return $"You did {Dmg} damage to {enemy.Symbol}";
        }

        //Move player position
        public void MovePlayer(GameControls input)
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

        public void AddPlayerScore(int score)
        {
            PlayerScore += score;
        }
    }
}