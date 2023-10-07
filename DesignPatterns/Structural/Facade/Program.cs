namespace Facade;

internal class Program
{
    private static void Main(string[] args)
    {
        var facade = new DiscountFacade();

        Console.WriteLine(facade.CalculateDiscountPercentage(1));
        Console.WriteLine(facade.CalculateDiscountPercentage(10));
    }
}