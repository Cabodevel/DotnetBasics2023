namespace Facade;

public class OrderService
{
    public bool HasEnoughOrders(int customerId)
    {
        //Testing purpose
        return customerId > 5;
    }
}

public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId)
    {
        //Testing purpose
        return customerId > 8 ? 10 : 20;
    }
}

public class DayOfTheWeekFactorService
{
    public double CalculateDayOfTheWeekFactor() =>
        DateTime.UtcNow.DayOfWeek switch
        {
            DayOfWeek.Saturday => 0.8,
            DayOfWeek.Sunday => 0.8,
            _ => 1.2
        };
}

public class DiscountFacade
{
    //Add DI When configure Container
    private readonly OrderService _orderService = new();

    private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
    private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

    public double CalculateDiscountPercentage(int customerId)
    {
        if(!_orderService.HasEnoughOrders(customerId))
        {
            return 0;
        }

        return _customerDiscountBaseService.CalculateDiscountBase(customerId)
            * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
    }
}