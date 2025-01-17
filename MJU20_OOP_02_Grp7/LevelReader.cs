﻿using System;
using System.Collections.Generic;
using System.IO;

namespace MJU20_OOP_02_Grp7
{
    public class LevelReader
    {
        // Path to the levels folder
        public static string DirectoryPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\MJU20_OOP_02_Grp7\")) + @"Levels\";

        /// <summary>
        /// Takes the file name of a textfile inside the levels folder,
        /// splits it into a 2D array of chars and returns the array.
        /// Creates any entities in the level and puts the into
        /// Entity.entities.
        /// </summary>
        public static char[,] LoadLevel(string fileName)
        {
            // Delcare necessary variables
            string filePath = DirectoryPath + fileName;
            char[,] returnArr;
            int columns = 0;
            int rows = 0;

            try
            {
                string[] fileLines = File.ReadAllLines(filePath);       // Open text file
                rows = fileLines.Length;
                columns = fileLines[0].Length;
                returnArr = new char[columns, rows];        // Create the array

                for (int y = 0; y < rows; y++) //Loop through all characters in the file
                {
                    for (int x = 0; x < columns; x++)
                    {
                        if (fileLines[y][x] != ' ')
                        {
                            if (CreateEntity(fileLines[y][x], x, y))
                            {
                                returnArr[x, y] = ' ';
                                continue;
                            }
                        }
                        returnArr[x, y] = fileLines[y][x];
                    }
                }
            }
            catch (Exception e)
            {
                UI.Print(e.Message);
                throw;
            }

            return returnArr;
        }

        /// <summary>
        /// Takes a char, checks what entity is represented by this char and creates a new entity of that type,
        /// with position of [row][column].
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>A bool representing if the symbol should render statically or not.</returns>
        public static bool CreateEntity(char symbol, int row, int column)
        {
            Point position = new Point(row, column);
            if (Enemy.EnemyTypes.ContainsKey(symbol))
            {
                Enemy.ActiveEnemies.Add(new Enemy(symbol, position, Enemy.EnemyTypes[symbol]));
                return true;
            }
            else if (symbol == 'ῼ')     // This is the end point
            {
                Game.endPoint = new EndPoint(position);
                return true;
            }
            else if (symbol == '@')     // This is the player
            {
                Game.SetPlayerPosition(position);
                return true;
            }
            else if (Item.itemTypes.ContainsKey(symbol))
            {
                Item.activeItems.Add(new Item(symbol, position, Item.itemTypes[symbol]));
                return true;
            }
            return false;
        }
    }
}