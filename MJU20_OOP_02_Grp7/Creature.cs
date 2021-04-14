using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    abstract class Creature
    {
        protected int Hp { get; set; }
        protected Point Position { get; set; }

        public Creature(int hp, Point position)
        {
            Hp = hp;
            Position = position;
        }

        public abstract void GetHp();
        public abstract void GetPosition();
    }
}
