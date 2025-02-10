namespace ConsoleApp1;

public class Pair : IComparable
{
    public int X { get; set; }
    public int Y { get; set; }

    public int CompareTo(object obj)
    {
        Pair other = (Pair)obj;
        if (X == other.X)
            return 0;
        if (X < other.X)
            return -1;
        else
            return 1;
    }
    public Pair(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return X + " " + Y;
    }
}