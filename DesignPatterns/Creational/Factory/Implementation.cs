//FactoryMethod
//Target: Create objects of concrete type without specify exact class

namespace Factory;

//abstract class or interface that declare all operations that all concrete types must implement
public interface IDiscountFactory
{
    DiscountService CreateDiscountService();
}

//Abstract Creator
//Declares the factory method/props to return by concrete creator
public abstract class DiscountService
{
    public abstract int DiscountPercentage { get; }

    public override string ToString() => GetType().Name;
}

#region Concrete creators

//Concrete creator
//Overrides the factory creator to change the return result
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

//Concrete creator
//Overrides the factory creator to change the return result
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

#endregion Concrete creators

//Return different concrete creator for each IDiscountFactory implementation

#region Implementations of IDiscountFactory

public class CountryDiscountFactory : IDiscountFactory
{
    private readonly string _countryIdentifier;

    public CountryDiscountFactory(string countryIdentifier) => _countryIdentifier = countryIdentifier;

    public DiscountService CreateDiscountService() => new CountryDiscountService(_countryIdentifier);
}

public class CodeDiscountFactory : IDiscountFactory
{
    private readonly string _code;

    public CodeDiscountFactory(string code) => _code = code;

    public DiscountService CreateDiscountService() => new CodeDiscountService(_code);
}

#endregion Implementations of IDiscountFactory