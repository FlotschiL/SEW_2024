using Iterator;
ConcreteAggregate aggregate = new ConcreteAggregate();
aggregate.Add("Item A");
aggregate.Add("Item B");
aggregate.Add("Item C");

IIterator iterator = aggregate.CreateIterator();

while (iterator.HasNext())
{
    Console.WriteLine(iterator.Next());
}
