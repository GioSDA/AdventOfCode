public class Day5 : Day
{
    public override object SolvePartOne(String input)
    {
        string[] splitInput = input.Split(newline);

        int stackLine = StackLine(splitInput);
        int stackCount = StackCount(splitInput[stackLine]);

        List<Stack<char>> supplyStacks = ParseInput(stackLine, stackCount, splitInput);

        for (int i = stackLine + 2; i < splitInput.Length; i++)
        {
            string line = splitInput[i];
            string[] splitLine = line.Split(" ");

            int amount = int.Parse(splitLine[1]);
            int from = int.Parse(splitLine[3]);
            int to = int.Parse(splitLine[5]);

            for (int j = 0; j < amount; j++)
            {
                supplyStacks[to - 1].Push(supplyStacks[from - 1].Pop());
            }
        }

        string answer = "";
        for (int i = 0; i < stackCount; i++)
        {
            answer += supplyStacks[i].Peek();
        }

        return answer;
    }

    public override object SolvePartTwo(string input)
    {
        string[] splitInput = input.Split(newline);

        int stackLine = StackLine(splitInput);
        int stackCount = StackCount(splitInput[stackLine]);

        List<Stack<char>> supplyStacks = ParseInput(stackLine, stackCount, splitInput);

        for (int i = stackLine + 2; i < splitInput.Length; i++)
        {
            string line = splitInput[i];
            string[] splitLine = line.Split(" ");

            int amount = int.Parse(splitLine[1]);
            int from = int.Parse(splitLine[3]);
            int to = int.Parse(splitLine[5]);

            List<char> characters = new List<char>(amount);

            for (int j = 0; j < amount; j++)
            {
                characters.Add(supplyStacks[from - 1].Pop());
            }

            for (int j = amount - 1; j >= 0; j--)
            {
                supplyStacks[to - 1].Push(characters[j]);
            }
        }

        string answer = "";
        for (int i = 0; i < stackCount; i++)
        {
            answer += supplyStacks[i].Peek();
        }

        return answer;
    }

    public List<Stack<char>> ParseInput(int stackLine, int stackCount, string[] splitInput)
    {
        List<Stack<char>> supplyStacks = new List<Stack<char>>(stackCount);

        //populate list with empty stacks
        for (int i = 0; i < stackCount; i++)
        {
            supplyStacks.Add(new Stack<char>());
        }

        //populate stacks
        for (int i = stackLine - 1; i >= 0; i--)
        {
            string line = splitInput[i];
            for (int j = 1; j < line.Length; j += 4)
            {
                if (line[j] == ' ') continue;
                supplyStacks[(j - 1) / 4].Push(line[j]);
            }
        }

        return supplyStacks;
    }

    public int StackLine(String[] splitInput)
    {
        for (int i = 0; i < splitInput.Length; i++)
        {
            string line = splitInput[i];
            if (line.Contains('1'))
            {
                return i;
            }
        }

        return -1;
    }

    public int StackCount(String input)
    {
        string[] splitInput = input.Split("   ");
        return int.Parse(splitInput[splitInput.Length - 1]);
    }
}