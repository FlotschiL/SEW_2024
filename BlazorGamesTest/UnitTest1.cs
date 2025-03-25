namespace BlazorGamesTest;
using BlazorApp1;
public class Tests
{
    private Connect4 con;
    [SetUp]
    public void Setup()
    {
        Connect4 con = new Connect4();
        con.Set(1,6);
        con.Set(1,6);
        con.Set(2,6);
        con.Set(2,6);
        con.Set(3,6);
        con.Set(3,6);
        con.Set(4,6);

    }

    [Test]
    public void Test1()
    {
        //"Winner: {player} (Horizontal)"
        con.Set(4, 6);
    }
}