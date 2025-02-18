namespace LList;

public class DoubleNode(int val)
{
    public int Value { get; set; } = val;
    public DoubleNode? Next { get; set; }
    public DoubleNode? Prev { get; set; }
    
    public override string ToString()
    {
        return Value.ToString() + " <-> ";
    }
}