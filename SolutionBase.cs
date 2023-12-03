using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal abstract class SolutionBase
    {
        private readonly int Year = 2023;

        protected string SolutionName => Regex.Replace(GetType().Name, "(\\B[A-Z])", " $1");

        protected abstract int Part1(string[] data);
        protected abstract int Part2(string[] data);

        public void LogSolution()
        {
            Console.WriteLine(SolutionName);
            try
            {
                var data = File.ReadAllLines(Path.Combine("TestData", $"{Year}_{GetType().Name}_TestData.txt"));
                Console.WriteLine($"Part 1 = {Part1(data)}");
                Console.WriteLine($"Part 2 = {Part2(data)}");
            }
            catch (IOException e)
            {
                Console.WriteLine("Test Data file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
