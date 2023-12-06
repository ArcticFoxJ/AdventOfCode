using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day2
{
    internal class Day2Solution : SolutionBase
    {
        private string[] colors => ["red", "green", "blue"];

        protected override int Part1(string[] games)
        {
            var cubeTotals = new Dictionary<string, int>()
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 }
            };

            return GetMaxColorCounts(games)
            .Where(x => x.Value.All(y => y.Value <= cubeTotals[y.Key]))
            .Sum(x => x.Key); //2617
        }

        protected override int Part2(string[] games)
        {
            return GetMaxColorCounts(games)
            .Select(x => x.Value.Aggregate(1, (a, b) => a * b.Value))
            .Sum(); //59795
        }

        private Dictionary<int, Dictionary<string, int>> GetMaxColorCounts(string[] games)
            => games.ToDictionary(
                x => int.Parse(Regex.Match(x, @"Game (?<id>\d*):").Groups["id"].Value),
                x => colors.ToDictionary(
                    c => c,
                    c => Regex.Matches(x, string.Format(@"\D*(?<count>\d+) (?<color>{0})", $"{string.Join('|', colors)}"))
                        .Where(y => y.Groups["color"].Value == c)
                        .Select(y => int.Parse(y.Groups["count"].Value))
                        .Max()
                    )
            );
    }
}
