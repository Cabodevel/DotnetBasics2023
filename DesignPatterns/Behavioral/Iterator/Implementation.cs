namespace Iterator;

/// <summary>
/// Iterator
/// </summary>
public interface IPeopleIterator
{
    bool IsDone { get; }

    Person CurrentItem { get; }

    Person First();

    Person Next();
}

/// <summary>
/// Aggregate
/// </summary>
public interface IPeopleCollection
{
    IPeopleIterator CreateIterator();
}

public class Person
{
    public Person(string name, string country)
    {
        Name = name;
        Country = country;
    }

    public string Name { get; set; }
    public string Country { get; set; }
}

/// <summary>
/// ConcreteIterator
/// </summary>
public class PeopleIterator : IPeopleIterator
{
    private PeopleCollection _peopleCollection;
    private int _current = 0;

    public PeopleIterator(PeopleCollection collection)
    {
        _peopleCollection = collection;
    }

    public bool IsDone
    {
        get { return _current >= _peopleCollection.Count; }
    }

    public Person CurrentItem
    {
        get
        {
            return _peopleCollection
                .OrderBy(p => p.Name).ToList()[_current];
        }
    }

    public Person First()
    {
        _current = 0;
        return _peopleCollection
            .OrderBy(p => p.Name).ToList()[_current];
    }

    public Person Next()
    {
        _current++;
        if(!IsDone)
        {
            return _peopleCollection
                .OrderBy(p => p.Name).ToList()[_current];
        }
        else
        {
            return null;
        }
    }
}

/// <summary>
/// ConcreteAggregate
/// </summary>
public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator()
    {
        return new PeopleIterator(this);
    }
}