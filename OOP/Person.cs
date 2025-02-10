namespace OOP;

public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}