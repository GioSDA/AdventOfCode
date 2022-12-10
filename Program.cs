string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day7 day7 = new Day7();
Console.WriteLine(day7.SolvePartOne(input));
Console.WriteLine(day7.SolvePartTwo(input));