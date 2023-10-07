namespace Composite;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Composite";
        var root = new Directory("root", 0);
        Console.WriteLine("Initial root size {0}", root.GetSize());
        var topLevelFile = new Composite.File("toplvl.txt", 100);
        var topLevelDir1 = new Directory("tl1", 4);
        var topLevelDir2 = new Directory("tl2", 4);

        root.Add(topLevelFile);
        root.Add(topLevelDir1);
        root.Add(topLevelDir2);

        var subLevelFile = new Composite.File("sublvl1.txt", 200);
        var subLevelFile2 = new Composite.File("sublvl2.txt", 150);

        topLevelDir2.Add(subLevelFile);
        topLevelDir2.Add(subLevelFile2);

        Console.WriteLine(topLevelDir2.GetSize());
        Console.WriteLine(topLevelDir1.GetSize());
        Console.WriteLine("End root size {0}", root.GetSize());
    }
}