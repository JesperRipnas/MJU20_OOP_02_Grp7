using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MJU20_OOP_02_Grp7
{
    public class Player : Creature
    {
        public int PlayerScore { get; private set; }
        public int PlayerLives { get; private set; }

        public Player(int hp, int dmg, Point position, char symbol, ConsoleColor color) : base(hp, dmg, position, symbol, color)
        {
            PlayerScore = 0;
        }

        public int GetPlayerScore()
        {
            return PlayerScore;
        }
        public int GetPlayerLives()
        {
            return PlayerLives;
        }
        //Move player position
        public void MovePlayer(ConsoleKey input)
        {
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        Move(new Point(0, -1));
                        break;

                    case ConsoleKey.RightArrow:
                        Move(new Point(+1, 0));
                        break;

                    case ConsoleKey.DownArrow:
                        Move(new Point(0, +1));
                        break;

                    case ConsoleKey.LeftArrow:
                        Move(new Point(-1, 0));
                        break;
                        
                }
            
        }    
    }
}
