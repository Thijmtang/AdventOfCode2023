using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace AdventOfCode2023.Utils
{
    public static  class FileUtils
    {
        public static List<String>ReadPuzzleFile(int day)
        {
            var result = new List<String>();
            char ds = Path.DirectorySeparatorChar;
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + ds + "AdventOfCode" + ds;


            string path = filePath + ds + "PuzzleInput" +
                          ds + "day-" + day;


            try
            {
                StreamReader sr = new StreamReader(path);

                string line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    result.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return result;
        }
    }
}
