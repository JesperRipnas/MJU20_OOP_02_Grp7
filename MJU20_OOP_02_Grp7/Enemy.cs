using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public struct EnemyStats
    {
        public int Hp, Dmg, ChaseRange;
        public ConsoleColor Color;

        public EnemyStats(int hp, int dmg, int chaseRange, ConsoleColor color)
        {
            Hp = hp;
            Dmg = dmg;
            ChaseRange = chaseRange;
            Color = color;
        }
    }

    public class Enemy : Creature
    {
        private int chaseRange;
        private bool hasChased;

        static public List<Enemy> activeEnemies = new List<Enemy>();
        static public Dictionary<char, EnemyStats> enemyTypes = new Dictionary<char, EnemyStats>()
        {
            {'Q', new EnemyStats(3, 1, 3, ConsoleColor.DarkYellow)},
            {'ö', new EnemyStats(7, 3, 3, ConsoleColor.DarkGreen)},
            {'i', new EnemyStats(30, 10, 3, ConsoleColor.DarkMagenta)}
        };
        public Enemy(char symbol, Point position, EnemyStats stats) : base(stats.Hp, stats.Dmg, position, symbol, stats.Color)
        {
            chaseRange = stats.ChaseRange;
            hasChased = false;
        }

        public int CalculateScore()
        {
            int returnScore = (Dmg + Hp) * Game.currentLevel /* - time elapsed*/;

            return returnScore;
        }

        public static void MoveAround(Player player)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            foreach (Enemy enemy in activeEnemies)
            {
                Point direction = new Point(0, 0);
                if (enemy.Position.Distance(player.Position, out Point relativePos) < enemy.chaseRange)
                {
                    // to prevent enemies sticking like glue only chase every other update
                    if (enemy.hasChased)
                    {
                        enemy.hasChased = false;
                    }
                    else
                    {
                        // Move towards player
                        if (Math.Abs(relativePos.X) <= Math.Abs(relativePos.Y))
                        {
                            if (relativePos.Y < 0)
                            {
                                direction = new Point(0, -1);
                            }
                            else
                            {
                                direction = new Point(0, 1);
                            }

                        }
                        else
                        {
                            if (relativePos.X < 0)
                            {
                                direction = new Point(-1, 0);
                            }
                            else
                            {
                                direction = new Point(1, 0);
                            }
                        }
                        enemy.hasChased = true;
                    }
                    
                }
                else
                {
                    // Move in a random direction
                    int newDirection = random.Next(5);

                    switch (newDirection)
                    {
                        case 0:
                            direction = new Point(1, 0);
                            break;

                        case 1:
                            direction = new Point(-1, 0);
                            break;

                        case 2:
                            direction = new Point(0, 1);
                            break;

                        case 3:
                            direction = new Point(0, -1);
                            break;

                        default:
                            continue;
                    }
                }

                enemy.Move(direction, enemy);
            }
        }
    }
}