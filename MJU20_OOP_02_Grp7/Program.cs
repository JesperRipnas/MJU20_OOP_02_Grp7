﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;


namespace MJU20_OOP_02_Grp7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game game = new Game();
            //game.Start();

            LevelReader.LoadLevel("TestLevel.txt");
            foreach(var entity in Entity.entities)
            {
                Console.WriteLine(entity.GetType());
                WriteLine(entity.Position);
            }
        }



    }





}
