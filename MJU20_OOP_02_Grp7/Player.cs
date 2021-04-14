using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    public class Player : Creature
    {
        public int PlayerScore { get; private set; }
        public int PlayerLives { get; private set; }

        public Player(int hp, Point position, char symbol, ConsoleColor color, int playerScore, int playerLives) : base(hp, position, symbol, color)
        {
            PlayerScore = playerScore;
            PlayerLives = playerLives;
        }

        public int GetPlayerScore()
        {
            return PlayerScore;
        }
        public int GetPlayerLives()
        {
            return PlayerLives;
        }
    }
}
