﻿using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public struct ItemStats
    {
        public int Heal, AttackUp;
        public ConsoleColor Color;

        public ItemStats(int heal, int attackUp, ConsoleColor color)
        {
            Heal = heal;
            AttackUp = attackUp;
            Color = color;
        }
    }

    public class Item : Entity
    {
        static public List<Item> activeItems = new List<Item>();
        static public Dictionary<char, ItemStats> itemTypes = new Dictionary<char, ItemStats>()
        {
            {'♥', new ItemStats(25, 0, ConsoleColor.Red)},
            {'ʇ', new ItemStats(0, 2, ConsoleColor.Gray)}
        };

        public Item(char symbol, Point position, ItemStats stats) : base(position, symbol, stats.Color)
        {
        }
    }
}