﻿using System;
using System.Collections.Generic;
using static System.Console;

namespace MJU20_OOP_02_Grp7
{
    public class UI
    {
        public static List<String> EventMessageList = new List<string>();
        // view window size
        public static int height;

        public static int width;
        private static int _counter;

        public static void SetUISize(int x, int y)
        {
            width = x;
            height = y - 5;
            Console.SetWindowSize(x, y);
            Console.SetBufferSize(x, y);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }
        public static void DrawEventMessages()
        {
            SetCursorPosition(0, 0);

            if (EventMessageList.Count > 5) EventMessageList.RemoveAt(0);
            if (EventMessageList.Count >= 0)
            {
                foreach (var msg in EventMessageList)
                {
                    WriteLine(msg);
                }
            }
            if (EventMessageList.Count > 0)
            {
                _counter++;
                if (_counter % 10 == 0) EventMessageList.RemoveAt(0);
            }
        }

        public static void DrawScreen(char[,] map, Player player, Entity[] entities)
        {
            DrawMap(map, player.Position);
            DrawEntities(entities, player.Position);
            DrawPlayer(player);
            DrawUI(player);
            DrawEventMessages();
        }

        private static void DrawUI(Player player)
        {
            Console.SetCursorPosition(5, height + 1);
            Console.WriteLine($"HP: {player.Hp}  Tick: {Game.GetTick()} Pos: {player.Position.X}.{player.Position.Y} Item pickup counter: {_counter}");
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

        private static void DrawEntities(Entity[] entities, Point playerPosition)
        {
            foreach (Entity entity in entities)
            {
                Console.SetCursorPosition(entity.Position.X + (width / 2) - playerPosition.X, entity.Position.Y + (height / 2) - playerPosition.Y);
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