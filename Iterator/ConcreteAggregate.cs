namespace Iterator;

public class ConcreteAggregate : IAggregate
{
    private List<string> items = new List<string>();

    public void Add(string item)
    {
        items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public string this[int index] => items[index];
    public int Count => items.Count;
}