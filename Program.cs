string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day11 day11 = new Day11();
Console.WriteLine(day11.SolvePartOne(input));
Console.WriteLine(day11.SolvePartTwo(input));