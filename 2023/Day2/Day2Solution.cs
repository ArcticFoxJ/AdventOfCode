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

            Dictionary<int, Dictionary<string, int>> gameCounts = games.ToDictionary(
                x => int.Parse(Regex.Match(x, @"Game (?<id>\d*):").Groups["id"].Value),
                x => colors.ToDictionary(
                    c => c, 
                    c =>
                    {
                        var colorGroups = Regex.Matches(x, string.Format(@"\D*(?<count>\d+) (?<color>{0})", $"{string.Join('|', colors)}"));
                        return colorGroups.Where(y => y.Groups["color"].Value == c).Select(y => int.Parse(y.Groups["count"].Value)).Max();
                    })
            );

            return gameCounts.Where(x => x.Value.All(y => y.Value <= cubeTotals[y.Key])).Sum(x => x.Key); //2617
        }

        protected override int Part2(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
