public class Day3 : Day
{
    public override object SolvePartOne(String input)
    {
        int points = 0;

        foreach (string rucksack in input.Split(newline))
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < rucksack.Length / 2; i++)
            {
                set.Add(rucksack[i]);
            }

            for (int i = rucksack.Length / 2; i < rucksack.Length; i++)
            {
                int size = set.Count;
                set.Remove(rucksack[i]);
                //subtract 96 if a-z (1-26) and 38 if A-Z (27-54)
                if (size != set.Count) points += (rucksack[i] > 96 ? rucksack[i] - 96 : rucksack[i] - 38);
            }
        }

        return points;
    }

    public override object SolvePartTwo(String input)
    {
        int points = 0;
        string[] rucksacks = input.Split(newline);

        for (int i = 0; i < rucksacks.Length; i += 3)
        {
            HashSet<char> a = GetBadges(rucksacks[i]);
            HashSet<char> b = GetBadges(rucksacks[i + 1]);
            HashSet<char> c = GetBadges(rucksacks[i + 2]);

            foreach (char key in a)
            {
                if (b.Contains(key) && c.Contains(key)) points += (key > 96 ? key - 96 : key - 38);
            }
        }

        return points;
    }

    private HashSet<char> GetBadges(string rucksack)
    {
        HashSet<char> set = new HashSet<char>();
        for (int i = 0; i < rucksack.Length; i++)
        {
            set.Add(rucksack[i]);
        }

        return set;
    }
}