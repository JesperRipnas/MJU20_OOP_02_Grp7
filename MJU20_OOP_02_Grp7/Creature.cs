using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    public abstract class Creature
    {
        public int Hp { get; private set; }
        public Point Position { get; private set; }
        public char Symbol { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Creature(int hp, Point position, char symbol, ConsoleColor color)
        {
            Hp = hp;
            Position = position;
            Symbol = symbol;
            Color = color;
        }

        public void Damage(int dmg)
        {
            Hp -= dmg;
        }

        public void Heal(int heal)
        {
            Hp += heal;
        }

        public void Move(Point movement)
        {
            Position += movement;
        }
    }
}
