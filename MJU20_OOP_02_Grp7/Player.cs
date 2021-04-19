using System;

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
        public void MovePlayer(GameControls input)
        {
            switch (input)
            {
                case GameControls.MoveUp:
                    Move(new Point(0, -1), this);
                    break;

                case GameControls.MoveRight:
                    Move(new Point(+1, 0), this);
                    break;

                case GameControls.MoveDown:
                    Move(new Point(0, +1), this);
                    break;

                case GameControls.MoveLeft:
                    Move(new Point(-1, 0), this);
                    break;
                case GameControls.Attack:
                    Attack();
                    break;
            }
        }

        public void AddPlayerScore(int score)
        {
            PlayerScore += score;
        }
    }
}