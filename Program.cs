string input = File.ReadAllText("Input.txt");

Day2 day2 = new Day2();
Console.WriteLine(day2.SolvePartOne(input));
Console.WriteLine(day2.SolvePartTwo(input));