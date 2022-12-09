string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day5 day5 = new Day5();
Console.WriteLine(day5.SolvePartOne(input));
Console.WriteLine(day5.SolvePartTwo(input));