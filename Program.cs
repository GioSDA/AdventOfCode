string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day9 day9 = new Day9();
Console.WriteLine(day9.SolvePartOne(input));
Console.WriteLine(day9.SolvePartTwo(input));