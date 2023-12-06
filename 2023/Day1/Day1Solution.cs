using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day1
{
    internal class Day1Solution : SolutionBase
    {
        protected override int Part1(string[] amendedCalibrationValues)
        {
            var total = 0;
            if(amendedCalibrationValues != null)
            {
                foreach (var amendedCalibrationValue in amendedCalibrationValues)
                {
                    var digits = amendedCalibrationValue.Where(char.IsDigit);
                    total += int.Parse($"{digits.First()}{digits.Last()}");
                }
            }
            return total;
        }

        private static readonly string[] numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        private class DigitIndex(int index, string number)
        {
            public int Index { get; } = index;
            public string Number { get; } = number;
        }

        protected override int Part2(string[] amendedCalibrationValues)
        {
            var total = 0;
            if (amendedCalibrationValues != null)
            {
                foreach (var amendedCalibrationValue in amendedCalibrationValues)
                {
                    var digits = new List<DigitIndex>();

                    for(var i=0; i<amendedCalibrationValue.Length; i++)
                    {
                        if (char.IsDigit(amendedCalibrationValue[i]))
                        {
                            digits.Add(new DigitIndex(i, amendedCalibrationValue[i].ToString()));
                        }
                    }

                    foreach (var number in numbers)
                    {
                        foreach (Match match in Regex.Matches(amendedCalibrationValue, number).Cast<Match>())
                        {
                            digits.Add(new DigitIndex(match.Index, Array.FindIndex(numbers, y => y == number).ToString()));
                        }
                    }

                    digits = [.. digits.OrderBy(x => x.Index)];
                    total += int.Parse($"{digits.First().Number}{digits.Last().Number}");
                }
            }
            return total;
        }
    }
}