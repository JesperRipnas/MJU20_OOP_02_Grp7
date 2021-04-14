using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MJU20_OOP_02_Grp7
{
    public class LevelReader
    {
        // Path to the levels folder
        public static string directoryPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\MJU20_OOP_02_Grp7\")) + @"Levels\";
        
        /// <summary>
        /// Takes the fileName of a textfile inside the levels folder, 
        /// splits it into a 2D array of chars and returns the array.
        /// </summary>
        public static char[,] LoadLevel(string fileName)
        {
            // Delcare necessary variables
            string filePath = directoryPath + fileName;
            char[,] returnArr;
            int columns = 0;
            int rows = 0;

            try
            {
                string[] fileLines = File.ReadAllLines(filePath);       // Open text file
                rows = fileLines.Length;
                columns = fileLines[0].Length;
                returnArr = new char[rows, columns];        // Create the array

                for (int i = 0; i < fileLines.Length; i++)      //Loop through all characters in the file
                { 
                    for (int j = 0; j < fileLines[i].Length; j++)
                    {
                        if(fileLines[i][j] != ' ' && fileLines[i][j] != '#')
                        {
                            CreateEntity(fileLines[i][j], i, j);
                        }
                        returnArr[i, j] = fileLines[i][j];
                    }                    
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
        public static void CreateEntity(char symbol, int row, int column)
        {
            Point position = new Point(column, row);

            switch (symbol)
            {
                case ('%'):
                    // Skapa en orc med position row, column

                    break;
                case ('@'):
                    if (Game.PlayerExists == false)
                    {
                        // NYI Skapa det nya playerobjektet om vi inte redan har något
                        // Player player = new Player();
                    }
                    else
                    {
                        // Sätt playerpositionen till positionen av row, column
                    }

                    break;
            }

            // Place the new entitiy in the entitiy list

        }
    }
}
