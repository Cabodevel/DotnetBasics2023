namespace Builder;

internal class Program
{
    private static void Main(string[] args)
    {
        var garage = new Garage();
        var bmw = new BmwBuilder();
        var mini = new MiniBuilder();

        garage.Construct(bmw);
        garage.Construct(mini);

        Console.WriteLine(bmw.Car.ToString());
        Console.WriteLine(mini.Car.ToString());
    }
}