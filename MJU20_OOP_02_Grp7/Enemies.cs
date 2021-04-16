﻿using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public struct EnemyStats
    {
        public int Hp, Dmg;
        public ConsoleColor Color;

        public EnemyStats(int hp, int dmg, ConsoleColor color)
        {
            Hp = hp;
            Dmg = dmg;
            Color = color;
        }
    }

    public class Enemy : Creature
    {
        static public List<Enemy> activeEnemies;

        static public Dictionary<char, EnemyStats> enemyTypes = new Dictionary<char, EnemyStats>()
        {
            {'Q', new EnemyStats(3,1, ConsoleColor.DarkYellow)},
            {'ö', new EnemyStats(7,3, ConsoleColor.DarkGreen)},
            {'i', new EnemyStats(30, 10, ConsoleColor.DarkMagenta)}
        };
        public Enemy(char symbol, Point position, EnemyStats stats) : base(stats.Hp, stats.Dmg, position, symbol, stats.Color) { }

        public static void MoveAround() {
            Random random = new Random(DateTime.Now.Millisecond);

            foreach(Enemy enemy in activeEnemies)
            {
                Point direction;
                int newDirection = random.Next(4);

                switch (newDirection)
                {
                    case 0:
                        direction = new Point(1, 0);
                        break;
                    case 1:
                        direction = new Point(-1, 0);
                        break;
                    case 2:
                        direction = new Point(0, 1);
                        break;
                    default:
                        direction = new Point(0, -1);
                        break;

                }
                enemy.Move(direction);
            }
        }
    }
}