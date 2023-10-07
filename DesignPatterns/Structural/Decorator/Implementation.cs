using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator;

public interface IMailService
{
    public bool SendMail(string message);
}

public class CloudMailService : IMailService
{
    public bool SendMail(string message)
    {
        Console.WriteLine($"{message} from Cloud service");
        return true;
    }
}

public class OnPremisesMailService : IMailService
{
    public bool SendMail(string message)
    {
        Console.WriteLine($"{message} from on premise service");
        return true;
    }
}

public class MailServiceDecoretorBase : IMailService
{
    private readonly IMailService _mailService;

    public MailServiceDecoretorBase(IMailService mailService) => _mailService = mailService;

    public virtual bool SendMail(string message)
    {
        return _mailService.SendMail(message);
    }
}

public class StatisticsDecorator : MailServiceDecoretorBase
{
    public StatisticsDecorator(IMailService mailService) : base(mailService)
    {
    }

    public override bool SendMail(string message)
    {
        Console.WriteLine("Collecting stats from Statistics Decorator");
        return base.SendMail(message);
    }
}

public class DatabaseDecorator : MailServiceDecoretorBase
{
    private readonly List<string> _messages = new List<string>();

    public DatabaseDecorator(IMailService mailService) : base(mailService)
    {
    }

    public override bool SendMail(string message)
    {
        _messages.Add(message);

        _messages.ForEach(x => Console.WriteLine("DB message: {0}", x));
        return base.SendMail(message);
    }
}