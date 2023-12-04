using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Utils
{
    public class Day3Utils
    {
        public static bool isPartNumber (int y, int x, List<String> field)
        {
            int startX = Math.Max(0, x - 1);
            int endX = Math.Min(x + 1, field[y].Length - 1);
            int startY = Math.Max(0, y - 1);
            int endY = Math.Min(y + 1, field.Count - 1);


            for (int row = startY; row <= endY; row++)
            {
                for (int col = startX; col <= endX; col++)
                {
                    // Number has a symbol which is adjacent to it.
                    if (charIsSymbol(field[row][col]))
                    {
                        return true;
                    }

                }

            }

            return false;
        }


        private static bool charIsSymbol(char c)
        {
            return !(char.IsDigit(c) || c == '.');
        }


    }
}
