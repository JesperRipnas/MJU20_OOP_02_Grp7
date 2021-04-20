using System;

namespace MJU20_OOP_02_Grp7
{
    public class Menu
    {
        private int select;

        private string[] options;

        private string subTitle;

        private string title;

        public Menu(string[] options, string subTitle, string title) //new menu
        {
            this.options = options;
            this.subTitle = subTitle;
            this.title = title;
        }
        public Menu(string[] options, string subTitle)
        {
            this.options = options;
            this.subTitle = subTitle;
            title = @"                                                                   ,;             .,                                                              ,;           
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
        }

        public Menu() // creates the main menu
        {
            string[] standardoption = { "Start", "Difficulty", "Score", "Options", "Exit" };

            this.options = standardoption;
            this.subTitle = "";

            this.title = @"                                                                   ,;             .,                                                              ,;
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
        }

        private void MainMenu()
        {
            Console.SetWindowSize(160, 40);
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(subTitle);
            Console.WriteLine();
            Console.WriteLine();
            DrawOptions();
        }

        private void DrawOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

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
                Console.WriteLine($"{selcar} {options[i]}");
                Console.WriteLine();
            }
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            select = 0;

            do
            {
                //display menu
                Console.Clear();
                MainMenu();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //update select
                if (keyPressed == ConsoleKey.W)
                {
                    --select;
                }
                else if (keyPressed == ConsoleKey.S)
                {
                    ++select;
                }

                if (select == options.Length)
                {
                    select = 0;
                }
                if (select == -1)
                {
                    select = options.Length - 1;
                }
            } while (keyPressed != ConsoleKey.Enter);

            return select;
        }

        public static void GameOverOverlay()
        {
            
            string gameOverString =  @" 
             @@@@@@@   @@@@@@  @@@@@@@@@@  @@@@@@@@       @@@@@@  @@@  @@@ @@@@@@@@ @@@@@@@
            !@@       @@!  @@@ @@! @@! @@! @@!           @@!  @@@ @@!  @@@ @@!      @@!  @@@
            !@! @!@!@ @!@!@!@! @!! !!@ @!@ @!!!:!        @!@  !@! @!@  !@! @!!!:!   @!@!!@!
            :!!   !!: !!:  !!! !!:     !!: !!:           !!:  !!!  !: .:!  !!:      !!: :!!
             :: :: :   :   : :  :      :   : :: :::       : :. :     ::    : :: :::  :   : :";
            string endString = @$"

                                                Score: {Game.player.PlayerScore}

                                 Press any key to get to the main menu..";
            Console.SetWindowSize(104, 15);
            Console.SetBufferSize(104, 15);
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(gameOverString);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(endString);
            Console.ReadKey();
        }
    }
}