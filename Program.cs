string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day10 day10 = new Day10();
Console.WriteLine(day10.SolvePartOne(input));
Console.WriteLine(day10.SolvePartTwo(input));