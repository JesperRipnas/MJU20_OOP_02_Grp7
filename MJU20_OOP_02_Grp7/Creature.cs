using System;

namespace MJU20_OOP_02_Grp7
{
    public abstract class Creature : Entity
    {
        public int Hp { get; private set; }
        public int Dmg { get; private set; }

        public Creature(int hp, int dmg, Point position, char symbol, ConsoleColor color) : base(position, symbol, color)
        {
            Hp = hp;
            Dmg = dmg;
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