public class Day9 : Day
{
    public override object SolvePartOne(string input)
    {
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        Coordinates head = new Coordinates(0, 0);
        Coordinates tail = new Coordinates(0, 0);

        foreach (string line in input.Split(newline))
        {
            char direction = line.Split(" ")[0][0];
            int amount = int.Parse(line.Split(" ")[1]);

            for (int i = 0; i < amount; i++)
            {
                visited.Add(tail.ToTuple());

                //Move head based on direction
                switch (direction)
                {
                    case 'R': head.x++; break;
                    case 'L': head.x--; break;
                    case 'U': head.y++; break;
                    case 'D': head.y--; break;
                }

                //Check all positions that tail could be
                int xDif = head.x - tail.x;
                int yDif = head.y - tail.y;

                if (Math.Abs(xDif) <= 1 && Math.Abs(yDif) <= 1) continue; //Touching
                else if (xDif <= -2 && yDif == 0) tail.x--; //Same row/column
                else if (xDif >= 2 && yDif == 0) tail.x++;
                else if (xDif == 0 && yDif <= -2) tail.y--;
                else if (xDif == 0 && yDif >= 2) tail.y++;
                else if (xDif <= -1 && yDif <= -1) //Diagonal
                {
                    tail.x--; tail.y--;
                }
                else if (xDif >= 1 && yDif <= -1)
                {
                    tail.x++; tail.y--;
                }
                else if (xDif <= -1 && yDif >= 1)
                {
                    tail.x--; tail.y++;
                }
                else if (xDif >= 1 && yDif >= 1)
                {
                    tail.x++; tail.y++;
                }
            }
        }

        visited.Add(tail.ToTuple());

        return visited.Count();
    }

    public override object SolvePartTwo(string input)
    {
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        List<Coordinates> knots = new List<Coordinates>();
        for (int i = 0; i < 10; i++) knots.Add(new Coordinates(0, 0));

        foreach (string line in input.Split(newline))
        {
            char direction = line.Split(" ")[0][0];
            int amount = int.Parse(line.Split(" ")[1]);

            for (int i = 0; i < amount; i++)
            {
                visited.Add(knots[9].ToTuple());

                //Move head based on direction
                switch (direction)
                {
                    case 'R': knots[0].x++; break;
                    case 'L': knots[0].x--; break;
                    case 'U': knots[0].y++; break;
                    case 'D': knots[0].y--; break;
                }

                for (int j = 1; j < 10; j++) //Simulate all knots
                {
                    //Check all positions that knot could be
                    int xDif = knots[j - 1].x - knots[j].x;
                    int yDif = knots[j - 1].y - knots[j].y;

                    if (Math.Abs(xDif) <= 1 && Math.Abs(yDif) <= 1) continue; //Touching
                    else if (xDif <= -2 && yDif == 0) knots[j].x--; //Same row/column
                    else if (xDif >= 2 && yDif == 0) knots[j].x++;
                    else if (xDif == 0 && yDif <= -2) knots[j].y--;
                    else if (xDif == 0 && yDif >= 2) knots[j].y++;
                    else if (xDif <= -1 && yDif <= -1) //Diagonal
                    {
                        knots[j].x--; knots[j].y--;
                    }
                    else if (xDif >= 1 && yDif <= -1)
                    {
                        knots[j].x++; knots[j].y--;
                    }
                    else if (xDif <= -1 && yDif >= 1)
                    {
                        knots[j].x--; knots[j].y++;
                    }
                    else if (xDif >= 1 && yDif >= 1)
                    {
                        knots[j].x++; knots[j].y++;
                    }
                }
            }
        }

        visited.Add(knots[9].ToTuple());

        return visited.Count();
    }

    class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Tuple<int, int> ToTuple()
        {
            return Tuple.Create(x, y);
        }
    }
}