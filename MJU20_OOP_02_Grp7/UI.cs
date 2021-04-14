using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public class UI
    {
        // view window size
        private static int _height;
        private static int _width;

        public UI(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public void DrawScreen(char[,] map, Player player, Creature[] entities)
        {
            DrawMap(map, player.Position);
            DrawEntities(entities);
            DrawPlayer(player);
            DrawUI(player);
        }

        private static void DrawUI(Player player)
        {
            Console.SetCursorPosition(5, _height + 1);
            Console.WriteLine($"HP: {player.Hp}");
            // not yet implemented
            //Console.SetCursorPosition(5, _height + 2);
            //Console.WriteLine($"Energy: {player.Energy}");
        }

        private static void DrawPlayer(Player player)
        {
            
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.ForegroundColor = player.Color;
            Console.Write(player.Symbol);
        }

        private static void DrawEntities(Creature[] entities)
        {
            foreach (Creature entity in entities)
            {
                Console.SetCursorPosition(entity.Position.X, entity.Position.Y);
                Console.ForegroundColor = entity.Color;
                Console.Write(entity.Symbol);
            }
        }

        private void DrawMap(char[,] map, Point playerPosition)
        {
            string background = "";
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    background += map[playerPosition.X - (_width / 2) + x, playerPosition.Y - (_height / 2) + y];
                }
                background += "\n";
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(background);
        }
    }
}