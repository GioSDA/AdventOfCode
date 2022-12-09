string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day6 day6 = new Day6();
Console.WriteLine(day6.SolvePartOne(input));
Console.WriteLine(day6.SolvePartTwo(input));