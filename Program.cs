using AdventOfCode;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

var solutions = Assembly.GetAssembly(typeof(SolutionBase))
    .GetTypes()
    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(SolutionBase)))
    .Select(x => (SolutionBase)Activator.CreateInstance(x))
    .OrderBy(x => x?.SolutionName);

foreach (var solution in solutions)
{
    try
    {
        solution?.LogSolution();
        Console.WriteLine();
    }
    catch (Exception e) {
        Console.WriteLine();
    }
}