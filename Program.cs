string input = File.ReadAllText("Input.txt").TrimEnd();

Day4 day4 = new Day4();
Console.WriteLine(day4.SolvePartOne(input));
Console.WriteLine(day4.SolvePartTwo(input));