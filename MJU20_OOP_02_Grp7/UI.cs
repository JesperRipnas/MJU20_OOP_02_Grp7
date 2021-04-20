using System;
using System.Collections.Generic;

namespace MJU20_OOP_02_Grp7
{
    public struct GameMessage
    {
        public string Message;
        public int ClearTick;

        public GameMessage(string message, int clearTick)
        {
            Message = message;
            ClearTick = clearTick;
        }
    }

    public class UI
    {
        public static List<GameMessage> MessageList = new List<GameMessage>();
        // view window size
        public static int height;
        public static int width;
        //private static int _messageCounter;

        public static void SetUISize(int x, int y)
        {
            width = x;
            height = y - 5;
            Console.SetWindowSize(x, y);
            Console.SetBufferSize(x, y);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        public static void DrawScreen(char[,] map, Player player, Entity[] entities)
        {
            Console.CursorVisible = false;
            DrawMap(map, player.Position);
            DrawEntities(entities, player.Position);
            DrawPlayer(player);
            DrawStats(player);
            DrawEnemyHp();
            DrawMessages();
        }
        
        public static void DrawMessages()
        {
            Console.SetCursorPosition(0, 0);

            if (MessageList.Count > 5) MessageList.RemoveAt(0);
            if (MessageList.Count >= 0)
            {
                foreach (var msg in MessageList)
                {
                    if (msg.Message.Contains("took"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(msg.Message);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(msg.Message);
                    }
                }
            }
            if (MessageList.Count > 0)
            {
                if (MessageList[0].ClearTick < Game.GetTick()) MessageList.RemoveAt(0);
                //_messageCounter++;
                //if (_messageCounter == Game.GetTick())
                //{
                //    MessageList.RemoveAt(0);
                //}
            }
        }

        private static void DrawStats(Player player)
        {
            string statsClearer = "";
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    statsClearer += " ";
                }
                statsClearer += "\n";
            }
            Draw(0, height, ConsoleColor.White, statsClearer);
            Draw(5, height + 1, ConsoleColor.Green, $"Player: {Game.player.PlayerName}  HP: {player.Hp}  Attack Power: {Game.player.Dmg}  Points: {Game.player.PlayerScore} Time: {Game.GetTick()/2} seconds");
        }

        public static void DrawEnemyHp()
        {
            int i = 0;
            foreach (Enemy enemy in Enemy.activeEnemies)
            {
                if (enemy.ShowHp)
                {
                    Draw(5, height - i, enemy.Color, $"Enemy {enemy.Symbol} HP: {enemy.Hp}  ");
                }
                i++;
            }
            if (Enemy.activeEnemies.Count == 0)
            {
                Draw(5, height, ConsoleColor.Black, $"                                      ");
            }
        }

        private static void DrawPlayer(Player player)
        {
            Draw(width / 2, height / 2, player.Color, player.Symbol.ToString());
        }

        private static void DrawEntities(Entity[] entities, Point playerPosition)
        {
            foreach (Entity entity in entities)
            {
                Point screenPos = new Point(entity.Position.X + (width / 2) - playerPosition.X, entity.Position.Y + (height / 2) - playerPosition.Y);
                if (screenPos.X >= 0 && screenPos.X < width && screenPos.Y >= 0 && screenPos.Y < height)
                {
                    Draw(screenPos.X, screenPos.Y, entity.Color, entity.Symbol.ToString());
                }

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
            Draw(0, 0, ConsoleColor.White, background);
        }

        private static void Draw(int left, int top, ConsoleColor color, string output)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = color;
            Console.WriteLine(output);
        }
    }
}