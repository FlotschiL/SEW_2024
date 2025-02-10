namespace ConsoleApp3;
public class Program1
{
    public static void asdf(string[] args)
    {
        /*if (args[0] == "+")
        {
            int ret = 0;
            foreach (var item in args)
            {
                if (item != "+")
                {
                    ret+=int.Parse(item);
                }
            }

            Console.WriteLine(ret);
        }*/
        foreach (var VARIABLE in args)
        {
            Console.WriteLine(VARIABLE);
        }
    }
}