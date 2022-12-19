using System.Linq.Expressions;

public class Day11 : Day
{
    public override object SolvePartOne(string input)
    {
        List<Monkey> monkeys = new List<Monkey>();
        string[] splinput = input.Split(newline);

        for (int i = 0; i < splinput.Length; i++) splinput[i] = splinput[i].Trim();

        //Parse input
        for (int i = 0; i < splinput.Length; i++)
        {
            if (splinput[i].StartsWith("Monkey"))
            {
                //set up numbers
                i++;
                List<long> items = new List<long>(splinput[i].Substring(15).Split(",").Length);
                foreach (string num in splinput[i].Substring(15).Split(","))
                {
                    num.Trim();
                    items.Add(int.Parse(num));
                }

                //set up operation
                i++;
                string symbol = splinput[i].Split(" ")[4];
                string number = splinput[i].Split(" ")[5];
                string operation = symbol + " " + number;

                //set up test
                i++;
                int testNum = int.Parse(splinput[i].Split(" ")[3]);

                //true monkey
                i++;
                int trueMonkey = int.Parse(splinput[i].Split(" ")[5]);

                //false monkey
                i++;
                int falseMonkey = int.Parse(splinput[i].Split(" ")[5]);

                monkeys.Add(new Monkey(items, operation, testNum, trueMonkey, falseMonkey));
            }
        }

        //Monkey business
        for (int i = 0; i < 20; i++)
        {
            foreach (Monkey monkey in monkeys)
            {
                int items = monkey.items.Count;

                for (int j = 0; j < items; j++)
                {
                    monkey.inspections++;
                    //do operation
                    if (monkey.operation.StartsWith("+"))
                    {
                        if (monkey.operation.Contains("old")) monkey.items[0] += monkey.items[0];
                        else monkey.items[0] += int.Parse(monkey.operation.Split(" ")[1]);
                    }
                    else if (monkey.operation.StartsWith("*"))
                    {
                        if (monkey.operation.Contains("old")) monkey.items[0] *= monkey.items[0];
                        else monkey.items[0] *= int.Parse(monkey.operation.Split(" ")[1]);
                    }

                    monkey.items[0] /= 3;

                    if (monkey.items[0] % monkey.test == 0)
                    {
                        monkeys[monkey.trueMonkey].items.Add(monkey.items[0]);
                        monkey.items.RemoveAt(0);
                    }
                    else
                    {
                        monkeys[monkey.falseMonkey].items.Add(monkey.items[0]);
                        monkey.items.RemoveAt(0);
                    }
                }
            }
            monkeys.ForEach(n => Console.Write(n.inspections + " "));
            Console.Write("\n");
        }

        monkeys = monkeys.OrderByDescending(n => n.inspections).ToList();
        return monkeys[0].inspections * monkeys[1].inspections;
    }

    public override object SolvePartTwo(string input)
    {
        List<Monkey> monkeys = new List<Monkey>();
        string[] splinput = input.Split(newline);

        for (int i = 0; i < splinput.Length; i++) splinput[i] = splinput[i].Trim();

        //Parse input
        for (int i = 0; i < splinput.Length; i++)
        {
            if (splinput[i].StartsWith("Monkey"))
            {
                //set up numbers
                i++;
                List<long> items = new List<long>(splinput[i].Substring(15).Split(",").Length);
                foreach (string num in splinput[i].Substring(15).Split(","))
                {
                    num.Trim();
                    items.Add(int.Parse(num));
                }

                //set up operation
                i++;
                string symbol = splinput[i].Split(" ")[4];
                string number = splinput[i].Split(" ")[5];
                string operation = symbol + " " + number;

                //set up test
                i++;
                int testNum = int.Parse(splinput[i].Split(" ")[3]);

                //true monkey
                i++;
                int trueMonkey = int.Parse(splinput[i].Split(" ")[5]);

                //false monkey
                i++;
                int falseMonkey = int.Parse(splinput[i].Split(" ")[5]);

                monkeys.Add(new Monkey(items, operation, testNum, trueMonkey, falseMonkey));
            }
        }

        int commonMultiple = 1;
        foreach (Monkey monkey in monkeys) commonMultiple *= monkey.test;

        //Monkey business
        for (int i = 0; i < 10000; i++)
        {
            foreach (Monkey monkey in monkeys)
            {
                int items = monkey.items.Count;

                for (int j = 0; j < items; j++)
                {
                    monkey.inspections++;
                    monkey.items[0] %= commonMultiple;

                    //do operation
                    if (monkey.operation.StartsWith("+"))
                    {
                        if (monkey.operation.Contains("old")) monkey.items[0] += monkey.items[0];
                        else monkey.items[0] += int.Parse(monkey.operation.Split(" ")[1]);
                    }
                    else if (monkey.operation.StartsWith("*"))
                    {
                        if (monkey.operation.Contains("old")) monkey.items[0] *= monkey.items[0];
                        else monkey.items[0] *= int.Parse(monkey.operation.Split(" ")[1]);
                    }
                    if (monkey.items[0] % monkey.test == 0)
                    {
                        monkeys[monkey.trueMonkey].items.Add(monkey.items[0]);
                        monkey.items.RemoveAt(0);
                    }
                    else
                    {
                        monkeys[monkey.falseMonkey].items.Add(monkey.items[0]);
                        monkey.items.RemoveAt(0);
                    }

                }
            }
        }

        monkeys = monkeys.OrderByDescending(n => n.inspections).ToList();
        return monkeys[0].inspections * monkeys[1].inspections;
    }


    class Monkey
    {
        public List<long> items { get; set; }
        public string operation { get; set; }
        public int test { get; set; }
        public int trueMonkey { get; set; }
        public int falseMonkey { get; set; }

        public long inspections { get; set; }

        public Monkey(List<long> items, string operation, int test, int trueMonkey, int falseMonkey)
        {
            this.items = items;
            this.operation = operation;
            this.test = test;
            this.trueMonkey = trueMonkey;
            this.falseMonkey = falseMonkey;
            this.inspections = 0;
        }
    }

}