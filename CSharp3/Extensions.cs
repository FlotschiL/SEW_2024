namespace CSharp3;

public static class MyExtensions
{
    public static void Main(string[] args)
    {
        //integer is a sealed class
        Console.WriteLine(3.isEven()); // Integer um isEven erweitert
        Console.WriteLine(4.isEven());
    }

    /*class MyInteger : int
    {
        bool isEven(int value)
        {
            return value % 2 == 0;
        }
    }*/
    public static bool isEven(this int number)
    {
        return number % 2 == 0;
    }

}