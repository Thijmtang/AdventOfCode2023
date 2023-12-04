using System.ComponentModel;
using AdventOfCode.Models;
using AdventOfCode.Utils;

namespace AdventOfCode
{
    public static class AdventOfcode
    {
        public static int sumCalibrationValues(List<string> input, bool hiddenDigits = false)
        {
            int sum = 0;

            for (int i = 0; i < input.Count; i++)
            {

                var line = input[i];
                int first = 0;
                int last = 0;

                if (hiddenDigits)
                {
                    line = line.Replace("one", "o1e")
                        .Replace("two", "t2o")
                        .Replace("three", "t3e")
                        .Replace("four", "f4r")
                        .Replace("five", "f5e")
                        .Replace("six", "s6x")
                        .Replace("seven", "s7n")
                        .Replace("eight", "e8t")
                        .Replace("nine", "n9e");
                }

                foreach (char c in line)
                {
                    if (!char.IsDigit(c))
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

                        int amount = int.Parse(content[0]);
                        string color = content[1];



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

        public static int sumPartsNumbers(List<string> input)
        {
            int sum = 0;
            var currentNumber = "";
            var hasPartNumber = false;

            for (int y = 0; y < input.Count; y++)
            {

                for (int x = 0; x < input[y].Length; x++)
                {
                    var c = input[y][x];

                    if (char.IsDigit(c))
                    {
                        currentNumber += c;

                        // Part has already been set, numbers with multiple digits are not within eachother's range
                        if (!hasPartNumber)
                        {
                            hasPartNumber = Day3Utils.isPartNumber(y, x, input);
                        }

                        continue;
                    }

                    // Number was adjacent to a symbol
                    if (hasPartNumber && currentNumber != "")
                    {
                        sum += int.Parse(currentNumber);
                    }

                    // Reset since the digits of the number has ended
                    currentNumber = "";
                    hasPartNumber = false;
                }
            }

            return sum;
        }


        public static int countScratchCardsPoints(List<string> input)
        {
            int sum = 0;

            for (int i = 0; i < input.Count; i++)
            {
                int points = 0;

                var line = input[i].Split(":");
                var cardNumber = line[0];

                var scratchCard = line[1].Split("|");

                // Turn into dictionary to easily access values
                var winningNumbers = new HashSet<String>(scratchCard[1].Split(" "));

                // Tidy up, empty values
                winningNumbers.Remove(" ");
                winningNumbers.Remove("");

                var cardNumbers = scratchCard[0].Split(" ");

                foreach (var number in cardNumbers)
                {
                    if (number == " " || !winningNumbers.Contains(number))
                    { 
                        continue;
                    }

                    if (points == 0)
                    {
                        points = 1;
                        continue;
                    }

                    points *= 2;
                }

                sum += points;
            }


            return sum;
        }

        public static int countWonScratchCards(List<string> input)
        {
            int sum = 0;

            // Create hashmap with all available scratchcards, for easy accessibility
            var scratchCardPile = new Dictionary<int, ScratchCard>();
            var scratchCardCount = new Dictionary<int, int>();

            for (int i = 0; i < input.Count; i++)
            {
                var line = input[i].Split(":");

                var cardNumber = i + 1;
                var scratchCard = line[1].Split("|");

                var winningNumbers = new HashSet<String>(scratchCard[1].Split(" "));

                // Tidy up, empty values
                winningNumbers.Remove(" ");
                winningNumbers.Remove("");

                var cardNumbers = new HashSet<String>(scratchCard[0].Split(" "));

                // Tidy up, empty values
                cardNumbers.Remove(" ");
                cardNumbers.Remove("");

                scratchCardPile[cardNumber] = new ScratchCard(cardNumber, winningNumbers, cardNumbers);
                scratchCardCount[cardNumber] = 1;
            }

            var queue = new Queue<int>();

            foreach (var entry in scratchCardPile)
            {
                var card = entry.Value;
                var cardWinnings = card.getWonCards();

                // Initiate queue for all won cards of current entry
                foreach (var wonCard in cardWinnings)
                {
                    queue.Enqueue(wonCard);
                }

                // Process all cards and each of its card winnings
                while (queue.Count > 0)
                {
                    var cardNumber = queue.Dequeue();
                    var copyCard = scratchCardPile[cardNumber];

                    // Keep track of the ran through card
                    scratchCardCount[cardNumber]++;

                    var copyCardWinnings = copyCard.getWonCards();

                    // No cards won, no need to continue
                    if (copyCardWinnings.Count == 0)
                    {
                        continue;
                    }

                    // Add the winnings to the queue
                    foreach (var wonCard in copyCardWinnings)
                    {
                        queue.Enqueue(wonCard);
                    }
                }
            }

            foreach (var entry in scratchCardCount)
            {
                Console.WriteLine($"Card: {entry.Key} : {entry.Value}*");
                sum += entry.Value;
            }

            return sum;
        }

    }
}
