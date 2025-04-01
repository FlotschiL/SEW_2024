using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;

namespace BlazorApp1;

public class MineManager :  IGame
{
    public char[,] Field = new char[15, 15];//col row
    protected char EmptyCell = '\0';
    //1 is player 1; -1 is player 2;
    //0 is nothing
    public char Turn = 'X';
    public GameState GameState = GameState.Going;
    private List<Point> Flags = new ();
    public MineManager()
    {
        Debug.Write("Connect4");
        for (var index0 = 0; index0 < Field.GetLength(0); index0++)
        for (var index1 = 0; index1 < Field.GetLength(1); index1++)
        {
            var item = Field[index0, index1];
            item = EmptyCell;
        }
        Debug.Write("Finished");
    }
    public string this[int x, int y]
    {
        get
        {
            Debug.Write("GETTER");
            return Field[x, y].ToString();
        }
    }

    

    public string? Winner { get; private set; } = "No Winner / Draw";
    public string? NextPlayer => Turn.ToString();

    public void Set(int col, int row)
    {
        if (Field[col, row] == EmptyCell)
        {
            Field[col, row] = Turn;
            Turn = Turn == 'X' ? 'O' : 'X';
            Flags.Add(new Point(col, row));
            //Winner = CheckWinner();
            //Debug.WriteLine(CheckWinner());
            
        }
    }

    private bool IsInField(int col, int row)
    {
        return (col < Field.GetLength(0) && row < Field.GetLength(1));
    }
}
