using System;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Models a moving entity in the world.
    /// Inherits from <class><c>Entity</c></class>.
    /// </summary>
    public abstract class Creature : Entity
    {
        public int Hp { get; private set; }
        public int Dmg { get; private set; }
        public bool ShowHp { get; set; }
        public int showHpTick = 0;

        public Creature(int hp, int dmg, Point position, char symbol, ConsoleColor color) : base(position, symbol, color)
        {
            Hp = hp;
            Dmg = dmg;
            ShowHp = false;

        }
        /// <summary>
        /// Takes an int which decrements the Creatures Hp.
        /// </summary>
        /// <param name="dmg"></param>
        public void Damage(int dmg)
        {
            Hp -= dmg;
        }

        /// <summary>
        /// Takes an int which increments the Creatures Hp.
        /// </summary>
        /// <param name="heal"></param>
        public void Heal(int heal)
        {
            Hp += heal;
        }

        /// <summary>
        /// Takes an int and increments the Creatures damage.
        /// </summary>
        /// <param name="newDamage"></param>
        public void SetDamage(int newDamage)
        {
            Dmg += newDamage;
        }
    }
}