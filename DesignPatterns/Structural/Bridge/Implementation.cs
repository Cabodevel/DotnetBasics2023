namespace Bridge;

public interface ICoupon
{
    public abstract int CouponValue { get; }
}

public abstract class Menu
{
    protected readonly ICoupon _coupon;

    protected Menu(ICoupon coupon) => _coupon = coupon;

    public abstract int CalculatePrice();
}

public class MainMenu : Menu
{
    public MainMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice() => 20 - _coupon.CouponValue;
}

public class NoCoupon : ICoupon
{
    public int CouponValue => 0;
}

public class TwoCoupon : ICoupon
{
    public int CouponValue => 2;
}