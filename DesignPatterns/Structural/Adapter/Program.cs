namespace Adapter;

internal class Program
{
    private static void Main(string[] args)
    {
        ICityAdapter adapter = new CityAdapter();

        var city = adapter.GetCity();

        Console.WriteLine("{0}, {1}", city.FullName, city.Inhabitants);
    }
}