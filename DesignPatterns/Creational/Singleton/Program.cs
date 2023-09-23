namespace Singleton;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Singleton pattern");

        var instance1 = Logger.Instance;
        var instance2 = Logger.Instance;

        instance1.Log("Message from instance 1");
        instance2.Log("Message from instance 2");
        Console.WriteLine("Are same instance = {0}", instance1 == instance2);

        Console.WriteLine("Thread safe logger singleton");

        var tsinstance1 = ThreadSafeLogger.Instance;
        var tsinstance2 = ThreadSafeLogger.Instance;

        tsinstance1.Log("Message from ThreadSafeLogger 1");
        tsinstance2.Log("Message from ThreadSafeLogger 2");

        Console.WriteLine("ThreadSafeLogger Are same instance = {0}", tsinstance1 == tsinstance2);
    }
}