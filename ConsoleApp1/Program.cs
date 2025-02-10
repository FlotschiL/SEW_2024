using ConsoleApp1;

string input = "9 3 1 6 5 -2 4 -7 8 9";
MainManager manager = new MainManager();
manager.Load(input);
manager.Evaluate();
Console.WriteLine(manager.OutputPairs());

class program
{
    public delegate void MainDelegate();
    public static event MainDelegate test1; 
    public static MainDelegate test2 = (() => Console.Write("penis"));
    public static void Main(string[] args)
    {
        test2 += () => Console.Write("penis");
        test1.Invoke();
        test2.Invoke();
    }
}
//program.test1.Invoke();
//program.test2.Invoke();


