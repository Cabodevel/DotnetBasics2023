namespace Factory;

internal class Program
{
    private static void Main(string[] args)
    {
        var factories = new List<IDiscountFactory>
        {
            new CodeDiscountFactory("e6d4e6ba-74f4-4407-a7b9-bc7121801207"),
            new CountryDiscountFactory("ES")
        };

        factories.ForEach(f => Console.WriteLine($"{f} discount: {f.CreateDiscountService().DiscountPercentage}%"));
    }
}