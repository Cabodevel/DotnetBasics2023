namespace Factory;

public abstract class DiscountService
{
    public abstract int DiscountPercentage { get; }

    public override string ToString() => GetType().Name;
}

public class CountryDiscountService : DiscountService
{
    private readonly string _countryIdentifier;

    public CountryDiscountService(string countryIdentifier)
    {
        _countryIdentifier = countryIdentifier;
    }

    public override int DiscountPercentage
    {
        get => _countryIdentifier switch
        {
            "ES" => 25,
            "GB" => 5,
            _ => 0
        };
    }
}

public class CodeDiscountService : DiscountService
{
    private readonly string _code;

    private readonly Dictionary<string, int> _validCodes = new()
    {
        { "e6d4e6ba-74f4-4407-a7b9-bc7121801207", 15 }
    };

    public CodeDiscountService(string code)
    {
        _code = code;
    }

    public override int DiscountPercentage
    {
        get => _validCodes.ContainsKey(_code) ? _validCodes[_code] : 0;
    }
}

public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

public class CountryDiscountFactory : DiscountFactory
{
    private readonly string _countryIdentifier;

    public CountryDiscountFactory(string countryIdentifier) => _countryIdentifier = countryIdentifier;

    public override DiscountService CreateDiscountService() => new CountryDiscountService(_countryIdentifier);
}

public class CodeDiscountFactory : DiscountFactory
{
    private readonly string _code;

    public CodeDiscountFactory(string code) => _code = code;

    public override DiscountService CreateDiscountService() => new CodeDiscountService(_code);
}