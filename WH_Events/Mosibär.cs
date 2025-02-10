namespace ConsoleApp3;

public class Mosibär
{
    public delegate int Rechner(int a, int b, ref List<int> list);
    //private event Rechner myrechner;
    public static void Main(string[] args)
    {        
        List<int> res = new List<int>();       
        Rechner myRechner = Addiere;
        myRechner += Subtrahiere;        
        myRechner += Multipliziere;        
        myRechner += Dividiere;        
        myRechner(10, 2, ref res);
        foreach (var VARIABLE in res)
        {
            Console.WriteLine(VARIABLE);
        }
    }

    static int Addiere(int a, int b, ref List<int> list)
    {
        list.Add(a+b);
        return a + b;
    }
    static int Subtrahiere(int a, int b, ref List<int> list)    {        list.Add(a-b);        return a - b;    }
    static int Multipliziere(int a, int b, ref List<int> list)    {        list.Add(a*b);        return a * b;    }
    static int Dividiere(int a, int b, ref List<int> list)    {        list.Add(a/b);        return a / b;    }
    
}
