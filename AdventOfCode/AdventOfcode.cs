using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class AdventOfcode
    {
        public static int sumCalibrationValues(List<string> input)
        {
            int sum = 0;
            
            foreach (string line in input)
            {
                int first = 0;
                int last = 0;


                foreach (char c in line)
                {
                    if (!System.Char.IsDigit(c))
                    {
                        continue;
                    }

                    if (first == 0)
                    {
                        first = int.Parse(c.ToString());
                    }


                    last = int.Parse(c.ToString());
                }

                int combo = int.Parse($"{first}{last}");

                sum += combo;

            }

            return sum;
        }


        public static int sumPossibleBagGaneIds(List<string> input, Dictionary<string, int> bagContent)
        {
            int sum = 0;

            foreach (string line in input)
            {
                var inputLine = line.Split(":");
                
                int gameId = int.Parse(inputLine[0].Split(" ")[1]);

                var gameContent = inputLine[1];

                // Subsets of pulled cubes
                var subsets = gameContent.Split(";");
                bool possible = true;


                // Composition: {amount Color}, {amount Color}; {amount Color}, {amount Color}

                foreach (var subset in subsets)
                {

                    // Composition: {amount Color}, {amount Color}, 
                    var cubesSubset = subset.Split(",");
                    
                    foreach (var clrSetPair in cubesSubset)
                    {
                        // Composition: amount Color
                        var content = clrSetPair.Substring(1).Split(" ");
                        
                        string color = content[1];
                        int amount = int.Parse(content[0]);


                        
                        if (bagContent[color] < amount)
                        {
                            possible = false;
                        }
                    
                    }
                }

                if (possible)
                {
                    sum += gameId;
                }


            }

            return sum;
        }


        public static int getLowestNumberOfCubes(List<string> input, Dictionary<string, int> bagContent)
        {
            int sum = 0;

            foreach (string line in input)
            {
                var inputLine = line.Split(":");
                var gameContent = inputLine[1];

                // Subsets of pulled cubes
                var subsets = gameContent.Split(";");
                bool possible = true;


                // Composition: {amount Color}, {amount Color}; {amount Color}, {amount Color}
                var minimalCubesRequired = new Dictionary<string, int>()
                {
                    { "red", 0 },
                    { "blue", 0 },
                    { "green", 0 },
                };


                foreach (var subset in subsets)
                {

                    // Composition: {amount Color}, {amount Color}, 
                    var cubesSubset = subset.Split(",");

                    foreach (var clrSetPair in cubesSubset)
                    {
                        // Composition: amount Color
                        var content = clrSetPair.Substring(1).Split(" ");

                        string color = content[1];
                        int amount = int.Parse(content[0]);



                        if (minimalCubesRequired[color] == 0 || minimalCubesRequired[color] < amount)
                        {
                            minimalCubesRequired[color] = amount;
                        }

                    }
                }

                int cubePower = minimalCubesRequired["red"] * minimalCubesRequired["blue"] *
                                minimalCubesRequired["green"];


              
                sum += cubePower;


            }

            return sum;
        }
    }
}
