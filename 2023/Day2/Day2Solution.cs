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

            var possibleIdTotal = 0;
            var gameCounts = new Dictionary<int, IDictionary<string, int>>();
            foreach (var game in games)
            {
                var gameData = game.Split(':');
                var gameId = int.Parse(gameData[0].Replace("Game ", ""));
                var maxCounts = colors.ToDictionary(x => x, x => 0);
                gameCounts.Add(gameId, maxCounts);

                var gameCubes = gameData[1].Split(';');
                foreach (var cubeGroup in gameCubes)
                {
                    var matches = Regex.Matches(cubeGroup, string.Format(@"\D*(?<count>\d+) (?<color>{0})", $"{string.Join('|', colors)}"));
                    foreach(Match match in matches)
                    {
                        var color = match.Groups["color"].Value;
                        var count = int.Parse(match.Groups["count"].Value);
                        gameCounts[gameId][color] = gameCounts[gameId][color] > count ? gameCounts[gameId][color] : count;
                    }
                }
            }

            foreach (var gameCount in gameCounts)
            {
                var validGame = true;
                foreach(var colorCount in gameCount.Value)
                {
                    if(colorCount.Value > cubeTotals[colorCount.Key])
                    {
                        validGame = false;
                    }
                }
                if(validGame)
                {
                    possibleIdTotal += gameCount.Key;
                }
            }

            return possibleIdTotal; //2617
        }

        protected override int Part2(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
