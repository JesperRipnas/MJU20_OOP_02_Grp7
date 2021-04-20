using System;

namespace MJU20_OOP_02_Grp7
{
    public abstract class Creature : Entity
    {
        public int Hp { get; private set; }
        public int Dmg { get; private set; }
        public bool ShowHp { get; set; }

        public Creature(int hp, int dmg, Point position, char symbol, ConsoleColor color) : base(position, symbol, color)
        {
            Hp = hp;
            Dmg = dmg;
            ShowHp = false;
        }

        public void Damage(int dmg)
        {
            Hp -= dmg;
        }

        public void Heal(int heal)
        {
            Hp += heal;
        }
        public void SetDamage(int newDamage)
        {
            Dmg += newDamage;
        }
    }
}