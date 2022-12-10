string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day8 day8 = new Day8();
Console.WriteLine(day8.SolvePartOne(input));
Console.WriteLine(day8.SolvePartTwo(input));