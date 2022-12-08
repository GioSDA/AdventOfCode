string input = File.ReadAllText("Input.txt").TrimEnd();

Day3 day3 = new Day3();
Console.WriteLine(day3.SolvePartOne(input));
Console.WriteLine(day3.SolvePartTwo(input));