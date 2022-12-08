string input = File.ReadAllText("Input.txt").TrimEnd().ReplaceLineEndings();

Day1 day1 = new Day1();
Console.WriteLine(day1.SolvePartOne(input));
Console.WriteLine(day1.SolvePartTwo(input));