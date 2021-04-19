using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public struct ItemStats
    {
        public int Heal, AttackUp, Score;
        public ConsoleColor Color;

        public ItemStats(int heal, int attackUp, int score, ConsoleColor color)
        {
            Heal = heal;
            AttackUp = attackUp;
            Score = score;
            Color = color;
        }
    }

    public class Item : Entity
    {
        static public List<Item> activeItems = new List<Item>();
        static public Dictionary<char, ItemStats> itemTypes = new Dictionary<char, ItemStats>()
        {
            {'♥', new ItemStats(25, 0, 0, ConsoleColor.Red)},
            {'ʇ', new ItemStats(0, 2, 0, ConsoleColor.Gray)},
            {'∆', new ItemStats(0, 0, 100, ConsoleColor.Yellow)}
        };

        public Item(char symbol, Point position, ItemStats stats) : base(position, symbol, stats.Color)
        {
        }

        public int CalculateScore(char symbol)
        {
            int returnScore = itemTypes[symbol].Score * Game.currentLevel;

            return returnScore;
        }
    }
}