public class Day6 : Day
{
    public override object SolvePartOne(string input)
    {
        Queue<char> characters = new Queue<char>();

        for (int i = 0; i < input.Length; i++)
        {
            characters.Enqueue(input[i]);

            if (characters.Count >= 4)
            {
                if (!HasDuplicateCharacters(characters.ToArray())) return i + 1;
                characters.Dequeue();
            }
        }

        return 0;
    }

    public override object SolvePartTwo(string input)
    {
        Queue<char> characters = new Queue<char>();

        for (int i = 0; i < input.Length; i++)
        {
            characters.Enqueue(input[i]);

            if (characters.Count >= 14)
            {
                if (!HasDuplicateCharacters(characters.ToArray())) return i + 1;
                characters.Dequeue();
            }
        }

        return 0;
    }

    public Boolean HasDuplicateCharacters(char[] input)
    {
        HashSet<char> characters = new HashSet<char>();
        for (int i = 0; i < input.Length; i++)
        {
            characters.Add(input[i]);
        }

        return characters.Count != input.Length;
    }
}