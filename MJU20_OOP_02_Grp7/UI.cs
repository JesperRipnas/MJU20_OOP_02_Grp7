using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public class UI
    {
        private int _height;
        private int _width;
        private char[,] window;

        public static Dictionary<string, char> objects = new Dictionary<string, char> {
            {"Life", '♥'},
            {"Wall", '#'},
            {"Door", '∏'}
        };

        public UI(int height, int width)
        {
            _height = height;
            _width = width;
            window = new char[width, height];
        }

        public void DrawScreen(Player player, Creature[] entities)
        {
            DrawBackground();
            DrawEntities(entities);
            DrawPlayerUI(player);
        }

        private static void DrawPlayerUI(Player player)
        {
            Console.WriteLine(player.HP);
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

        private void DrawBackground()
        {
            string background = "";
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    background += window[x, y];
                }
                background += "\n";
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(background);
        }
    }
}