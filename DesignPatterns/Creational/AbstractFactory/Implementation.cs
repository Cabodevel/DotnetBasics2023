namespace AbstractFactory;

//Abstract factory interface
public interface IShoppingCartPurchaseFactory
{
    IDiscountService CreateDiscountService();

    IShippingCostsService CreateShippingCostsService();
}

#region Services interfaces

public interface IDiscountService
{
    int DiscountPercentage { get; }
}

public interface IShippingCostsService
{
    decimal ShippingCosts { get; }
}

#endregion Services interfaces

#region Services implementations

public class SpainDiscountService : IDiscountService
{
    public int DiscountPercentage => 30;
}

public class GermanyDiscountService : IDiscountService
{
    public int DiscountPercentage => 25;
}

public class SpainShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 10.50M;
}

public class GermanyShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 8.50M;
}

#endregion Services implementations

#region Abstract factory impl

public class SpainShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService() => new SpainDiscountService();

    public IShippingCostsService CreateShippingCostsService() => new SpainShippingCostsService();
}

public class GermanyShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService() => new GermanyDiscountService();

    public IShippingCostsService CreateShippingCostsService() => new GermanyShippingCostsService();
}

#endregion Abstract factory impl

//Client class with factory interface
public class ShoppingCartClient
{
    private readonly IDiscountService _discountService;
    private readonly IShippingCostsService _shippingCostsService;
    private readonly int _orderCosts = 200;

    public ShoppingCartClient(IShoppingCartPurchaseFactory factory)
    {
        _discountService = factory.CreateDiscountService();
        _shippingCostsService = factory.CreateShippingCostsService();
    }

    public void CalculateCosts()
    {
        var total = _orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts;
        Console.WriteLine("Total costs: {0}", total);
    }
}