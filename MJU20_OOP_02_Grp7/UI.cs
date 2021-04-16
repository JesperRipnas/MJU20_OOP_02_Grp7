using System;

namespace MJU20_OOP_02_Grp7
{
    public class UI
    {
        // view window size
        public static int height;

        public static int width;

        public static void SetUISize(int x, int y)
        {
            width = x;
            height = y - 5;
            Console.SetWindowSize(x, y);
            Console.SetBufferSize(x, y);
        }

        public static void DrawScreen(char[,] map, Player player, Entity[] entities)
        {
            DrawMap(map, player.Position);
            DrawEntities(entities);
            DrawPlayer(player);
            DrawUI(player);
        }

        private static void DrawUI(Player player)
        {
            Console.SetCursorPosition(5, height + 1);
            Console.WriteLine($"HP: {player.Hp}");
            // not yet implemented
            //Console.SetCursorPosition(5, _height + 2);
            //Console.WriteLine($"Energy: {player.Energy}");
        }

        private static void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(width / 2, height / 2);
            Console.ForegroundColor = player.Color;
            Console.Write(player.Symbol);
        }

        private static void DrawEntities(Entity[] entities)
        {
            foreach (Creature entity in entities)
            {
                Console.SetCursorPosition(entity.Position.X, entity.Position.Y);
                Console.ForegroundColor = entity.Color;
                Console.Write(entity.Symbol);
            }
        }

        private static void DrawMap(char[,] map, Point playerPosition)
        {
            string background = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int mapX = playerPosition.X - (width / 2) + x;
                    int mapY = playerPosition.Y - (height / 2) + y;
                    if (mapX < 0 || mapY < 0 || mapX >= map.GetLength(0) || mapY >= map.GetLength(1))
                    {
                        background += " ";
                    }
                    else
                    {
                        background += map[mapX, mapY];
                    }
                }
                background += "\n";
            }
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(background);
        }
    }
}