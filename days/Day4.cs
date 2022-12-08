public class Day4 : Day
{
    public override object SolvePartOne(string input)
    {
        int total = 0;

        foreach (string section in input.Split(newline))
        {
            int start1 = int.Parse(section.Split(",")[0].Split("-")[0]);
            int end1 = int.Parse(section.Split(",")[0].Split("-")[1]);
            int start2 = int.Parse(section.Split(",")[1].Split("-")[0]);
            int end2 = int.Parse(section.Split(",")[1].Split("-")[1]);

            if ((start1 <= start2 && end1 >= end2) || (start2 <= start1 && end2 >= end1)) total++;
        }

        return total;
    }

    public override object SolvePartTwo(string input)
    {
        int total = 0;

        foreach (string section in input.Split(newline))
        {
            int start1 = int.Parse(section.Split(",")[0].Split("-")[0]);
            int end1 = int.Parse(section.Split(",")[0].Split("-")[1]);
            int start2 = int.Parse(section.Split(",")[1].Split("-")[0]);
            int end2 = int.Parse(section.Split(",")[1].Split("-")[1]);

            if ((end1 >= start2 && end2 >= end1) || (end2 >= start1 && end1 >= end2)) total++;
        }

        return total;
    }
}