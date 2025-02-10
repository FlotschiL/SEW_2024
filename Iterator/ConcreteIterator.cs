namespace Iterator;

public class ConcreteIterator : IIterator
{
    private ConcreteAggregate aggregate;
    private int index = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }

    public bool HasNext()
    {
        return index < aggregate.Count;
    }

    public string Next()
    {
        if (HasNext())
        {
            return aggregate[index++];
        }
        return null;
    }
}