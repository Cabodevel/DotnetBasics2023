namespace Decorator;

internal class Program
{
    private static void Main(string[] args)
    {
        var statsDecorator = new StatisticsDecorator(new CloudMailService());
        var databaseDecorator = new DatabaseDecorator(new OnPremisesMailService());

        statsDecorator.SendMail("stats message");

        databaseDecorator.SendMail("Hello DB");
        databaseDecorator.SendMail("New DB message");
    }
}