namespace AbstractFactory;

internal class Program
{
    private static void Main(string[] args)
    {
        var spainClient = new ShoppingCartClient(new SpainShoppingCartPurchaseFactory());
        var germanyClient = new ShoppingCartClient(new GermanyShoppingCartPurchaseFactory());

        Console.WriteLine("Costs for Spain:");
        spainClient.CalculateCosts();
        Console.WriteLine("Costs for Germany:");
        germanyClient.CalculateCosts();
    }
}