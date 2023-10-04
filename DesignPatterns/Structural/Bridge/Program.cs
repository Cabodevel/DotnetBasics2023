namespace Bridge;

internal class Program
{
    private static void Main(string[] args)
    {
        var mainMenu = new MainMenu(new NoCoupon());
        Console.WriteLine(mainMenu.CalculatePrice());

        var discountMenu = new MainMenu(new TwoCoupon());

        Console.WriteLine(discountMenu.CalculatePrice());
    }
}