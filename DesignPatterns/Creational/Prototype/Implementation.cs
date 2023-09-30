using System.Text.Json;
using System.Text.Json.Serialization;

namespace Prototype;

//prototype
public abstract class Person
{
    public abstract string Name { get; set; }

    public abstract Person Clone();

    public abstract Person DeepClone();
}

public class Manager : Person
{
    [JsonConstructor]
    public Manager(string name)
    {
        Name = name;
    }

    public override string Name { get; set; }

    public override Person Clone() => (Person)MemberwiseClone();

    public override Person DeepClone()
    {
        var jsonString = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<Manager>(jsonString);
    }
}

public class Employee : Person
{
    [JsonConstructor]
    public Employee(Manager manager, string name)
    {
        Manager = manager;
        Name = name;
    }

    public Manager Manager { get; set; }
    public override string Name { get; set; }

    public override Person Clone() => (Person)MemberwiseClone();

    public override Person DeepClone()
    {
        var jsonString = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<Employee>(jsonString);
    }
}