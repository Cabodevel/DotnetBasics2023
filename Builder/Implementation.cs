//Builder pattern
//Target: build different representations with same construction code

using System.Text;

namespace Builder;

public class Car
{
    private readonly List<string> _parts = new();
    private readonly string _carType;

    public Car(string carType)
    {
        _carType = carType;
    }

    public void AddPart(string part)
    {
        _parts.Add(part);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Car of type {_carType} has parts: ");

        foreach(var part in _parts)
        {
            sb.AppendLine(part);
        }

        return sb.ToString();
    }
}

public abstract class CarBuilder
{
    public CarBuilder(string carType)
    {
        Car = new Car(carType);
    }

    public Car Car { get; private set; }

    public abstract void BuildEngine();

    public abstract void BuildFrame();
}

public class MiniBuilder : CarBuilder
{
    public MiniBuilder() : base("Mini")
    {
    }

    public override void BuildEngine() => Car.AddPart("Engine: 1600 TDI 150Cv");

    public override void BuildFrame() => Car.AddPart("Frame: 3 door, compact");
}

public class BmwBuilder : CarBuilder
{
    public BmwBuilder() : base("BMW")
    {
    }

    public override void BuildEngine() => Car.AddPart("Engine: 2000 V8");

    public override void BuildFrame() => Car.AddPart("Frame: 5 door, sedan");
}

//Director
public class Garage
{
    public Garage()
    {
    }

    public void Construct(CarBuilder builder)
    {
        builder.BuildEngine();
        builder.BuildFrame();
    }
}