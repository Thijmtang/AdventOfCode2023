namespace AdventOfCode.Models
{
    public class ScratchCard
    {
        public int Id { get; private set; }
        public HashSet<string> WinningNumbers { get; private set; }
        public HashSet<string> CardNumbers { get; private set; }
        public ScratchCard(int id, HashSet<string> winningNumbers, HashSet<string> cardNumbers)
        {
            Id = id;
            WinningNumbers = winningNumbers;
            CardNumbers = cardNumbers;
        }

        public HashSet<int> getWonCards()
        {
            var result = new HashSet<int>();

            int wins = 0;
            foreach (var number in CardNumbers)
            {
                if (!WinningNumbers.Contains(number))
                {
                    continue;
                }

                wins++;
            }

            for (int i = 0; i < wins; i++)
            {
                result.Add(i + (Id + 1));
            }

            return result;
        }

    }
}
