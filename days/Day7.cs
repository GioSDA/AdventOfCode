public class Day7 : Day
{
    //this took me two hours i am sorry for the bad code
    public override object SolvePartOne(string input)
    {
        Directory currentDir = new Directory("/", null);
        List<Directory> dirs = new List<Directory>();

        foreach (string line in input.Split(newline))
        {
            if (line == "$ cd /") continue;

            //check for user input
            if (line.StartsWith("$ cd"))
            {
                if (!dirs.Contains(currentDir)) dirs.Add(currentDir); //add directory when directory is changed
                if (line.Split(" ")[2] == "..") currentDir = currentDir.parent;
                else currentDir = currentDir.directories.Find(n => n.name == line.Split(" ")[2]);
            }
            else if (line.StartsWith("$")) continue;
            else
            {
                if (line.StartsWith("dir"))
                {
                    List<Directory> directories = currentDir.directories;
                    directories.Add(new Directory(line.Split(" ")[1], currentDir));
                    currentDir.directories = directories;
                }
                else
                {
                    currentDir.size += int.Parse(line.Split(" ")[0]);
                }
            }
        }

        if (!dirs.Contains(currentDir)) dirs.Add(currentDir); //add directory when directory is changed

        int totalSize = 0;
        foreach (Directory dir in dirs)
        {
            if (dir.size <= 100000)
            {
                int trueSize = dir.TrueSize();
                if (trueSize <= 100000)
                {
                    totalSize += trueSize;
                }
            }
        }

        return totalSize;
    }
    public override object SolvePartTwo(string input)
    {
        Directory currentDir = new Directory("/", null);
        List<Directory> dirs = new List<Directory>();

        foreach (string line in input.Split(newline))
        {
            if (line == "$ cd /") continue;

            //check for user input
            if (line.StartsWith("$ cd"))
            {
                if (!dirs.Contains(currentDir)) dirs.Add(currentDir); //add directory when directory is changed
                if (line.Split(" ")[2] == "..") currentDir = currentDir.parent;
                else currentDir = currentDir.directories.Find(n => n.name == line.Split(" ")[2]);
            }
            else if (line.StartsWith("$")) continue;
            else
            {
                if (line.StartsWith("dir"))
                {
                    List<Directory> directories = currentDir.directories;
                    directories.Add(new Directory(line.Split(" ")[1], currentDir));
                    currentDir.directories = directories;
                }
                else
                {
                    currentDir.size += int.Parse(line.Split(" ")[0]);
                }
            }
        }

        if (!dirs.Contains(currentDir)) dirs.Add(currentDir); //add directory when directory is changed

        int used = dirs.Find(n => n.name == "/").TrueSize();
        int needed = 30000000 - (70000000 - used);
        int min = int.MaxValue;
        foreach (Directory dir in dirs)
        {
            int trueSize = dir.TrueSize();
            if (trueSize >= needed && trueSize < min) min = trueSize;
        }

        return min;
    }

    class Directory
    {
        public Directory? parent { get; set; }
        public string name { get; set; }
        public List<Directory> directories { get; set; }
        public int size { get; set; }

        public Directory(string name, Directory? parent)
        {
            this.directories = new List<Directory>();
            this.name = name;
            this.parent = parent;
            this.size = 0;
        }

        public int TrueSize()
        {
            int trueSize = this.size;

            foreach (Directory dir in directories)
            {
                trueSize += dir.TrueSize();
            }

            return trueSize;
        }
    }
}