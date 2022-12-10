public class Day8 : Day
{
    public override object SolvePartOne(string input)
    {
        string[] lines = input.Split(newline);
        int[,] grid = new int[lines[0].Length, lines.Length];

        //convert input to 2d integer array
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                grid[x, y] = int.Parse(lines[x][y] + "");
            }
        }

        int total = 0;
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {

                if (checkDirections(x, y, grid)) total++;
            }
        }

        return total;
    }

    public override object SolvePartTwo(string input)
    {
        string[] lines = input.Split(newline);
        int[,] grid = new int[lines[0].Length, lines.Length];

        //convert input to 2d integer array
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                grid[x, y] = int.Parse(lines[x][y] + "");
            }
        }

        int max = 0;
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (getScenicScore(x, y, grid) > max) max = getScenicScore(x, y, grid);
            }
        }

        return max;
    }

    public Boolean checkDirections(int x, int y, int[,] grid)
    {
        int num = grid[x, y];

        //Check left
        int tempX = x - 1;
        while (tempX != -1)
        {
            if (grid[tempX, y] >= num) break;
            tempX--;
        }

        if (tempX == -1) return true;

        //Check right
        tempX = x + 1;
        while (tempX != grid.GetLength(1))
        {
            if (grid[tempX, y] >= num) break;
            tempX++;
        }

        if (tempX == grid.GetLength(1)) return true;

        //Check up
        int tempY = y - 1;
        while (tempY != -1)
        {
            if (grid[x, tempY] >= num) break;
            tempY--;
        }

        if (tempY == -1) return true;

        //Check down
        tempY = y + 1;
        while (tempY != grid.GetLength(0))
        {
            if (grid[x, tempY] >= num) break;
            tempY++;
        }

        if (tempY == grid.GetLength(0)) return true;

        return false;
    }

    public int getScenicScore(int x, int y, int[,] grid)
    {
        int num = grid[x, y];
        int total = 1;
        int distance = 0;

        //Check left
        int tempX = x - 1;
        while (tempX != -1)
        {
            distance++;
            if (grid[tempX, y] >= num) break;
            tempX--;
        }

        total *= distance;

        //Check right
        tempX = x + 1;
        distance = 0;
        while (tempX != grid.GetLength(1))
        {
            distance++;
            if (grid[tempX, y] >= num) break;
            tempX++;
        }

        total *= distance;


        //Check up
        int tempY = y - 1;
        distance = 0;
        while (tempY != -1)
        {
            distance++;
            if (grid[x, tempY] >= num) break;
            tempY--;
        }

        total *= distance;


        //Check down
        tempY = y + 1;
        distance = 0;
        while (tempY != grid.GetLength(0))
        {
            distance++;
            if (grid[x, tempY] >= num) break;
            tempY++;
        }

        total *= distance;

        return total;
    }
}