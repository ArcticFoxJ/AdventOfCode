using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day4
{
    internal class Day4Solution : SolutionBase
    {
        private class GameData(int id, int[] winningNumbers, int[] chosenNumbers)
        {
            public readonly int Id = id;
            public readonly int[] WinningNumbers = winningNumbers;
            public readonly int[] ChosenNumbers = chosenNumbers;
        }

        protected override int Part1(string[] tickets)
        {
            var data = tickets.Select(x =>
            {
                var id = int.Parse(Regex.Match(x, @"Card(\s+)(?<id>\d*):").Groups["id"].Value);
                var parts = x.Split(':')[1].Split('|').Select(y => y.Split(' ').Where(z => !string.IsNullOrEmpty(z)).Select(z => int.Parse(z)).ToArray()).ToArray();
                return new GameData(id, parts[0], parts[1]);
            });

            int totalScore = 0;
            foreach (var part in data)
            {
                totalScore += Convert.ToInt32(Math.Pow(2, part.ChosenNumbers.Where(x => part.WinningNumbers.Contains(x)).Count() - 1));
            }

            return totalScore; //20829
        }

        protected override int Part2(string[] tickets)
        {
            tickets = [
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
            ];

            throw new NotImplementedException();
        }
    }
}
