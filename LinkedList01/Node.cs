namespace LList;

public class Node(object val)
{
    public object? Value { get; init; } = val;
    public Node? Next { get; set; }
    public override string ToString()
    {
        if (Next is null)
        {
            return Value?.ToString() + " -> null";
        }
        return Value?.ToString() + " -> ";
    }
}