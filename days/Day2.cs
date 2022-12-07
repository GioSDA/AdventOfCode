public class Day2 : Day
{

    public override object SolvePartOne(String input)
    {
        int points = 0;

        foreach (string instruction in input.Split(newline))
        {
            //subtracting by 64 converts A,B,C to 1,2,3
            //subtracting by 87 converts X,Y,Z to 1,2,3
            points += instruction[2] - 87;

            if ((instruction[0] - 64) == (instruction[2] - 87) % 3 + 1) points += 0; //lose

            if ((instruction[0] - 64) == (instruction[2] - 87)) points += 3; //tie

            if ((instruction[0] - 64) % 3 + 1 == (instruction[2] - 87)) points += 6; //win
        }

        return points;
    }

    public override object SolvePartTwo(String input)
    {
        int points = 0;

        foreach (string instruction in input.Split(newline))
        {
            int a = points;
            //subtracting by 88 convert X,Y,Z to 0,1,2
            points += (instruction[2] - 88) * 3;

            int num = instruction[0] - 64;

            if (instruction[2] == 'X') points += (num + 1) % 3 + 1; //lose

            if (instruction[2] == 'Y') points += num; //tie

            if (instruction[2] == 'Z') points += num % 3 + 1; //win
        }

        return points;
    }
}