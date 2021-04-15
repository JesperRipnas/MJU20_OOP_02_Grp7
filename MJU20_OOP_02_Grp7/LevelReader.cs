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
        /// Takes the file name of a textfile inside the levels folder, 
        /// splits it into a 2D array of chars and returns the array.
        /// Creates any entities in the level and puts the into
        /// Entity.entities.
        /// </summary>
        public static char[,] LoadLevel(string fileName)
        {
            // Delcare necessary variables
            Enemy.activeEnemies = new List<Enemy>();
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
            // TODO: Kanske göra casen snyggare så dessa slipper hårdkodas?
            Point position = new Point(column, row);
            if (Enemy.enemyTypes.ContainsKey(symbol))
            {
                Enemy.activeEnemies.Add(new Enemy(symbol, position, Enemy.enemyTypes[symbol]));
            } else if(symbol == '@')
            {

            }

            // Place the new entitiy in the entitiy list

        }
    }
}
