using System.Text;

public class Day10 : Day
{
    public override object SolvePartOne(string input)
    {
        int x = 1;
        int cycles = 0;
        int signalStrength = 0;

        foreach (string line in input.Split(newline))
        {
            cycles++;

            if ((cycles - 20) % 40 == 0 && cycles <= 220)
            {
                signalStrength += (x * cycles);
            }

            if (line.StartsWith("addx"))
            {
                cycles++;

                if ((cycles - 20) % 40 == 0 && cycles <= 220)
                {
                    signalStrength += (x * cycles);
                }

                x += int.Parse(line.Split(" ")[1]);
            }

        }

        return signalStrength;
    }

    public override object SolvePartTwo(string input)
    {
        int x = 2; //lol works
        int cycles = 0;
        StringBuilder image = new StringBuilder("", 250);

        foreach (string line in input.Split(newline))
        {
            cycles++;

            if (x - 1 == cycles % 40 || x == cycles % 40 || x + 1 == cycles % 40) image.Append("░"); //diff characters for visibility
            else image.Append("▓");

            if (cycles % 40 == 0) image.Append(newline);

            if (line.StartsWith("addx"))
            {
                cycles++;

                if (x - 1 == cycles % 40 || x == cycles % 40 || x + 1 == cycles % 40) image.Append("░");
                else image.Append("▓");

                if (cycles % 40 == 0) image.Append(newline);

                x += int.Parse(line.Split(" ")[1]);
            }

        }

        return image;
    }
}