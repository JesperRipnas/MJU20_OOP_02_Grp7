using System;
using System.Text.RegularExpressions;

namespace MJU20_OOP_02_Grp7
{
    /// <summary>
    /// Represents the main menu of the game.
    /// </summary>
    public class Menu
    {
        private int select;

        private string[] options;

        private string subTitle;

        private string titleLogo = @"                                                                   ,;             .,                                                              ,;           
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

        public Menu(string[] options, string subTitle, string title) //new menu
        {
            this.options = options;
            this.subTitle = subTitle;
            this.titleLogo = title;
        }
        public Menu(string[] options, string subTitle)
        {
            this.options = options;
            this.subTitle = subTitle;
        }

        public Menu() // creates the main menu
        {
            string[] standardoption = { "Start", "Difficulty", "Score", "How To Play", "Exit"};

            this.options = standardoption;
            this.subTitle = "";
        }



        /// <summary>
        /// Runs the main menu until the user makes a choice from the available options.
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            GameControls input;
            select = 0;
            //display menu
            UI.MainMenu(titleLogo, subTitle);

            do
            {

                UI.DrawOptions(options, select);

                input = Input.GameInput(GameControls.MenuControls);

                //update select
                if (input == GameControls.MenuUp)
                {
                    --select;
                }
                else if (input == GameControls.MenuDown)
                {
                    ++select;
                }

                if (select >= options.Length)
                {
                    select = 0;
                }
                else if (select <= -1)
                {
                    select = options.Length - 1;
                }
            } while (input != GameControls.MenuSelect);

            return select;
        }

        /// <summary>
        /// Takes a string and validate that it only contains letters (a-ö/A-Ö), numbers (0-9) or _
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns a bool value based on if input string is following the rules or not</returns>
        public static bool CheckPlayerName(string input)
        {
            if(input.Length >= 3)
            {
                if (Regex.IsMatch(input, @"^[a-öA-Ö0-9_]+$")) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }
    }
}