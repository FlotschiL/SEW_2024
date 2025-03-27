using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;

namespace BlazorApp1;

public class Connect5_Flags : IGame
{
    public char[,] Field = new char[15, 15];//col row
    protected char EmptyCell = '\0';
    //1 is player 1; -1 is player 2;
    //0 is nothing
    public char Turn = 'X';
    public GameState GameState = GameState.Going;
    private List<Point> Flags = new ();
    public Connect5_Flags()
    {
        Debug.Write("Connect4");
        for (var index0 = 0; index0 < Field.GetUpperBound(0); index0++)
        for (var index1 = 0; index1 < Field.GetUpperBound(1); index1++)
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
            Debug.WriteLine("added points");
            Winner = CheckWinner();
            Debug.WriteLine(Winner);
            
        }
    }

    public string CheckWinner()
    {
        foreach (var flag in Flags)
        {
            string? w = HorizontalWinner(flag.X, flag.Y);
            //if (w == null) w = VerticalWinner(flag.X, flag.Y);
            //if (w == null) w = DiagonalWinner1();
            //if (w == null) w = DiagonalWinner2();
            if (w == null)
                return "No Winner / Draw";
        }


        return null;
    }
    private bool IsInField(int col, int row)
    {
        return (col < Field.GetUpperBound(0) && row < Field.GetUpperBound(1));
    }

    protected string? HorizontalWinner(int col, int row)
    {
        char player = Field[col, row];
        if (player == EmptyCell)
        {
            return null;
        }
        for (var i = col; i <= Field.GetUpperBound(0) && i <= col + 4; i++)
        {
            Debug.WriteLine($"({i}|{row})");
            if (player != Field[i, row])
            {
                return null;
            }
        }
        for (var i = col; i >= 0 && i >= col - 4; i++)
        {
            if (player != Field[i, row])
            {
                return null;
            }
        }
        return $"Winner: {player} (---)";
    }

    protected string? VerticalWinner(int col, int row)
    {
        
        return null;
    }

    protected string? DiagonalWinner1() // Checks diagonals from bottom-left to top-right
    {
        for (int y = 5; y < 15; y++) // Start from row 3 to ensure enough space upwards
        {
            for (int x = 0; x <= 10; x++) // Only check up to column 3
            {
                char player = Field[x, y];
                if (player != EmptyCell &&
                    player == Field[x + 1, y - 1] &&
                    player == Field[x + 2, y - 2] &&
                    player == Field[x + 3, y - 3] &&
                    player == Field[x + 4, y - 4])
                {
                    return $"Winner: {player} (Diagonal /)";
                }
            }
        }
        return null;
    }

    protected string? DiagonalWinner2() // Checks diagonals from top-left to bottom-right
    {
        for (int y = 0; y <= 10; y++) // Only check up to row 2
        {
            for (int x = 0; x <= 10; x++) // Only check up to column 3
            {
                char player = Field[x, y];
                if (player != EmptyCell &&
                    player == Field[x + 1, y + 1] &&
                    player == Field[x + 2, y + 2] &&
                    player == Field[x + 3, y + 3] &&
                    player == Field[x + 4, y + 4])
                {
                    return $"Winner: {player} (Diagonal \\)";
                }
            }
        }
        return null;
    }
}
