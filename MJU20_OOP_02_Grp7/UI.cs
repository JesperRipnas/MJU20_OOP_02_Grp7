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
        public static int Height;
        public static int Width;
        private const int _statsHeight = 5;

        private const string _titleLogo = @"
                                                                        ,;             .,                                                              ,;           
                                                                      f#i             ,Wt j.                                                  i      f#i j.         
                 ..       :           ..                            .E#t             i#D. EW,                   ..           ;               LE    .E#t  EW,        
                ,W,     .Et          ;W,      ,##############Wf.   i#W,             f#f   E##j                 ;W,         .DL              L#E   i#W,   E##j       
               t##,    ,W#t         j##,       ........jW##Wt     L#D.            .D#i    E###D.              j##, f.     :K#L     LWL     G#W.  L#D.    E###D.     
              L###,   j###t        G###,             tW##Kt     :K#Wfff;         :KW,     E#jG#W;            G###, EW:   ;W##L   .E#f     D#K. :K#Wfff;  E#jG#W;    
            .E#j##,  G#fE#t      :E####,           tW##E;       i##WLLLLt        t#f      E#t t##f         :E####, E#t  t#KE#L  ,W#;     E#K.  i##WLLLLt E#t t##f   
           ;WW; ##,:K#i E#t     ;W#DG##,         tW##E;          .E#L             ;#G     E#t  :K#E:      ;W#DG##, E#t f#D.L#L t#K:    .E#E.    .E#L     E#t  :K#E: 
          j#E.  ##f#W,  E#t    j###DW##,      .fW##D,              f#E:            :KE.   E#KDDDD###i    j###DW##, E#jG#f  L#LL#G     .K#E        f#E:   E#KDDDD###i
        .D#L    ###K:   E#t   G##i,,G##,    .f###D,                 ,WW;            .DW:  E#f,t#Wi,,,   G##i,,G##, E###;   L###j     .K#D          ,WW;  E#f,t#Wi,,,
       :K#t     ##D.    E#t :K#K:   L##,  .f####Gfffffffffff;        .D#;             L#, E#t  ;#W:   :K#K:   L##, E#K:    L#W;     .W#G            .D#; E#t  ;#W:  
       ...      #G      .. ;##D.    L##, .fLLLLLLLLLLLLLLLLLi          tt              jt DWi   ,KK: ;##D.    L##, EG      LE.     :W##########Wt     tt DWi   ,KK: 
                j          ,,,      .,,                                                              ,,,      .,,  ;       ;@      :,,,,,,,,,,,,,.                  ";

        private const string _gameOverLogo = @" 
             @@@@@@@   @@@@@@  @@@@@@@@@@  @@@@@@@@       @@@@@@  @@@  @@@ @@@@@@@@ @@@@@@@
            !@@       @@!  @@@ @@! @@! @@! @@!           @@!  @@@ @@!  @@@ @@!      @@!  @@@
            !@! @!@!@ @!@!@!@! @!! !!@ @!@ @!!!:!        @!@  !@! @!@  !@! @!!!:!   @!@!!@!
            :!!   !!: !!:  !!! !!:     !!: !!:           !!:  !!!  !: .:!  !!:      !!: :!!
             :: :: :   :   : :  :      :   : :: :::       : :. :     ::    : :: :::  :   : :";

        public static void SetUISize(int x, int y)
        {
            Width = x;
            Height = y - _statsHeight;
            Console.SetWindowSize(x, y);
            Console.SetBufferSize(x, y);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        public static void MainMenu(string subTitle)
        {
            Console.SetWindowSize(170, 40);
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_titleLogo + "\n\n\n" + subTitle + "\n\n");
        }

        public static void DrawGameOver(int score)
        {
            string endString = @$"
                                                Score: {score}

                                 Press any key to get to the main menu..";
            Console.SetWindowSize(104, 15);
            Console.SetBufferSize(104, 15);
            Console.CursorVisible = false;
            Console.Clear();
            Draw(0, 2, ConsoleColor.Red, _gameOverLogo);
            Draw(0, 10, ConsoleColor.White, endString);
            Input.ReadString();
        }

        public static void DrawOptions(string[] options, int select)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 19);
            for (int i = 0; i < options.Length; i++)
            {
                string selcar;
                if (i == select)
                {
                    selcar = ">>";
                }
                else
                {
                    selcar = "  ";
                }
                Console.WriteLine($"{selcar} {options[i]}\n");
            }
        }

        public static void SetWindowTitle(string s)
        {
            Console.Title = s;
        }

        public static void DrawScoreMenu()
        {
            Console.Clear();
            //score
            Dictionary<string, int> scores = Game.CreateHighScore();

            Console.WriteLine("Scores");
            Console.WriteLine();

            foreach (KeyValuePair<string, int> entry in scores)
            {
                // do something with entry.Value or entry.Key
                Console.Write(entry.Key);
                for (int i = 0; i < 40 - entry.Key.Length; i++)
                {
                    Console.Write(".");
                }
                Console.WriteLine(entry.Value);
            }

            Console.ReadKey();
            Game.MainMenu();

        }

        public static void Print(string s)
        {
            Console.WriteLine(s);
        }

        public static void PlayerName()
        {
            Console.Clear();
            Console.Write("Player Name: ");
        }

        public static void DrawHowToPlay()
        {
            Console.Clear();
            Console.WriteLine("How To Play\n\nUse 'W', 'A' 'S' and 'D' to move the character.\n\nAttack monsters with the 'Space' button.");
            Console.ReadKey();
        }

        public static void DrawScreen(char[,] map, Player player, Entity[] entities)
        {
            Console.CursorVisible = false;
            DrawMap(map, player.Position);
            DrawEntities(entities, player.Position);
            DrawPlayer(player);
            DrawStats(player);
            //DrawEnemyHp();
            DrawMessages();
        }

        public static void DrawMessages()
        {
            Console.SetCursorPosition(0, 0);

            if (MessageList.Count > _statsHeight) MessageList.RemoveAt(0);
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
            for (int y = 0; y < _statsHeight; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    statsClearer += " ";
                }
                statsClearer += "\n";
            }
            Draw(0, Height, ConsoleColor.White, statsClearer);
            Draw(5, Height, ConsoleColor.Green, $"Player: {Game.player.PlayerName}  HP: {player.Hp}  Attack Power: {Game.player.Dmg}  Points: {Game.player.PlayerScore} Time: {Game.GetTick() / 2} seconds");
            int i = 0;
            foreach (Enemy enemy in Enemy.ActiveEnemies)
            {
                if (i < _statsHeight - 1 && enemy.ShowHp)
                {
                    Draw(5, Height + 1 + i, enemy.Color, $"Enemy {enemy.Symbol} HP: {enemy.Hp}  ");
                    if (Game.GetTick() - enemy.ShowHopTick > 20) enemy.ShowHp = false;
                    i++;
                }
            }
        }

        private static void DrawPlayer(Player player)
        {
            Draw(Width / 2, Height / 2, player.Color, player.Symbol.ToString());
        }

        private static void DrawEntities(Entity[] entities, Point playerPosition)
        {
            foreach (Entity entity in entities)
            {
                Point screenPos = new Point(entity.Position.X + (Width / 2) - playerPosition.X, entity.Position.Y + (Height / 2) - playerPosition.Y);
                if (screenPos.X >= 0 && screenPos.X < Width && screenPos.Y >= 0 && screenPos.Y < Height)
                {
                    Draw(screenPos.X, screenPos.Y, entity.Color, entity.Symbol.ToString());
                }

            }
        }

        private static void DrawMap(char[,] map, Point playerPosition)
        {
            string background = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int mapX = playerPosition.X - (Width / 2) + x;
                    int mapY = playerPosition.Y - (Height / 2) + y;
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