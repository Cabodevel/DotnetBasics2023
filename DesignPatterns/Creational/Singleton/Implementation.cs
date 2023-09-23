namespace Singleton;

public class Logger
{
    private static Logger _instance;

    protected Logger()
    {
    }

    public static Logger Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class ThreadSafeLogger
{
    private static readonly Lazy<ThreadSafeLogger> _threadSafeInstance =
        new Lazy<ThreadSafeLogger>(() => new ThreadSafeLogger());

    protected ThreadSafeLogger()
    {
    }

    public static ThreadSafeLogger Instance
    {
        get => _threadSafeInstance.Value;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}