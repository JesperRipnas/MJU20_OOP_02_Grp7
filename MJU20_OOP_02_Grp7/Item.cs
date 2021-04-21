using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Holds stats for the class Item.
    /// </summary>
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

    /// <summary>
    /// Represents an Item inside the world. Inherits from <c>Entity</c>.
    /// </summary>
    public class Item : Entity
    {
        private int _heal, _attackUp;
        public int Score;
        static public List<Item> activeItems = new List<Item>();
        static public Dictionary<char, ItemStats> itemTypes = new Dictionary<char, ItemStats>()
        {
            {'♥', new ItemStats(25, 0, 0, ConsoleColor.Red)},
            {'ʇ', new ItemStats(0, 2, 0, ConsoleColor.Gray)},
            {'∆', new ItemStats(0, 0, 100, ConsoleColor.Yellow)}
        };

        public Item(char symbol, Point position, ItemStats stats) : base(position, symbol, stats.Color)
        {
            _heal = stats.Heal;
            _attackUp = stats.AttackUp;
            Score = stats.Score * Game.CurrentLevel;
        }
        /// <summary>
        /// Activates the items specialization.
        /// </summary>
        /// <returns>A string containing information about what specialization the item had.</returns>
        public string Activate()
        {
            if (Score > 0) return $"You picked up an item giving you {Score} points";
            if (_heal > 0)
            {
                Game.player.Heal(_heal);
                return $"You healed for {_heal} HP";
            }
            if (_attackUp > 0) Game.player.SetDamage(_attackUp); return $"You upgraded your attack power to {Game.player.Dmg}";
        }
    }
}