public class Day1 : Day
{
    public override object SolvePartOne(String input)
    {
        int max = 0;
        foreach (string elf in input.Split(newline + newline))
        {
            int curr = 0;

            foreach (string calories in elf.Split(newline))
            {
                curr += int.Parse(calories);
            }

            if (curr > max) max = curr;
        }

        return max;
    }

    public override object SolvePartTwo(String input)
    {
        List<int> elves = new List<int>();
        foreach (string elf in input.Split(newline + newline))
        {
            int curr = 0;

            foreach (string calories in elf.Split(newline))
            {
                curr += int.Parse(calories);
            }

            elves.Add(curr);
        }

        elves.Sort();
        elves.Reverse();
        return elves[0] + elves[1] + elves[2];
    }
}