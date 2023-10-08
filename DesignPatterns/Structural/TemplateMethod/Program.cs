namespace TemplateMethod;

internal class Program
{
    private static void Main(string[] args)
    {
        ExchangeMailParser exchangeMailParser = new();
        Console.WriteLine(exchangeMailParser.ParseMailBody("db00176d-167e-4945-9883-ecf936e07adc"));
        Console.WriteLine();

        ApacheMailParser apacheMailParser = new();
        Console.WriteLine(apacheMailParser.ParseMailBody("5088f4c4-79f8-4da0-b187-c81935d905b6"));
        Console.WriteLine();

        EudoraMailParser eudoraMailParser = new();
        Console.WriteLine(eudoraMailParser.ParseMailBody("5609904a-b544-4257-b4d8-cd73514578a5"));
    }
}