using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    public abstract class Creature : Entity
    {
        public int Hp { get; private set; }

        public Creature(int hp, Point position, char symbol, ConsoleColor color) : base(position, symbol, color)
        {
            Hp = hp;
        }

        public void Damage(int dmg)
        {
            Hp -= dmg;
        }

        public void Heal(int heal)
        {
            Hp += heal;
        }
    }
}
