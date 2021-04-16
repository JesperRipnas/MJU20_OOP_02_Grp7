using System;
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
            {'ö', new EnemyStats(7,3, ConsoleColor.DarkCyan)},
            {'i', new EnemyStats(30, 10, ConsoleColor.DarkMagenta)}
        };

        public Enemy(char symbol, Point position, EnemyStats stats) : base(stats.Hp, stats.Dmg, position, symbol, stats.Color)
        {
        }
    }
}