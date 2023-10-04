namespace Adapter;

//Target
public interface ICityAdapter
{
    City GetCity();
}

public class CityFromExternalSystem
{
    public CityFromExternalSystem(string name, string nickName, int inhabitants)
    {
        Name = name;
        NickName = nickName;
        Inhabitants = inhabitants;
    }

    public string Name { get; private set; }
    public string NickName { get; private set; }
    public int Inhabitants { get; private set; }
}

//Adaptee
public class ExternalSystem
{
    public CityFromExternalSystem GetCity()
    {
        return new CityFromExternalSystem("City", "'MyCity", 50000);
    }
}

public class City
{
    public City(string fullName, long inhabitants)
    {
        FullName = fullName;
        Inhabitants = inhabitants;
    }

    public string FullName { get; private set; }
    public long Inhabitants { get; private set; }
}

public class CityAdapter : ICityAdapter
{
    public ExternalSystem ExternalSystem { get; private set; } = new ExternalSystem();

    public City GetCity()
    {
        var cityFromExternalSystem = ExternalSystem.GetCity();

        return new City($"{cityFromExternalSystem.Name}-{cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);
    }
}