using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using BlazorApp1.Pages;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1;

public class MineManager
{
    private GameState _gameState = GameState.Going;
    public Square[,] Field { get; } = new Square[15, 15];

    private readonly Tuple<int, int>[] _checkHelper = new Tuple<int, int>[]
    {
        new Tuple<int, int>(-1, -1),
        new Tuple<int, int>(0, 1),
        new Tuple<int, int>(1, 1),
        new Tuple<int, int>(1, 0),
        new Tuple<int, int>(1, -1),
        new Tuple<int, int>(0, -1),
        new Tuple<int, int>(-1, 1),
        new Tuple<int, int>(-1, 0),
    };
    public MineManager()
    {
        for (var index0 = 0; index0 < Field.GetLength(0); index0++)
        {
            for (var index1 = 0; index1 < Field.GetLength(1); index1++)
            {
                Square item = new Square
                {
                    Value = MinesweeperSq.None
                };
                Field[index0, index1] = item;
            }
        }
        PlaceMines(10);
        GenerateField();
    }
    public string this[int x, int y]
    {
        get
        {
            if(!Field[x,y].IsMarked)
                return Field[x, y].IsCovered ? " " : Field[x, y].Value.ToString();
            else
            {
                return "Marked";
            }
        }
    }

    public void ToggleMark(int x, int y)//single click
    {
        Field[x, y].IsMarked = !Field[x, y].IsMarked;
    }
    
    public string? Winner
    {
        get
        {
            return _gameState.ToString();
        }
    }

    public void Set(int col, int row)
    {
        if (Field[col, row].IsCovered)
        {
            Field[col, row].IsCovered = false;
            UncoverSquares(new Tuple<int, int>(col, row));
            if (Field[col, row].Value == MinesweeperSq.Bomb)
            {
                _gameState = GameState.Lost;
                return;
            }

        }
    }
    private void UncoverSquares(Tuple<int, int > pos)
    {
        Field[pos.Item1, pos.Item2].IsCovered = false;
        foreach (var helppos in _checkHelper)
        {
            Tuple<int, int> check = new (helppos.Item1 + pos.Item1, helppos.Item2 + pos.Item2);
            if (IsInBounds(check.Item1, check.Item2) && Field[check.Item1, check.Item2].IsCovered)
            {
                Field[check.Item1, check.Item2].IsCovered = false;
                if(Field[check.Item1, check.Item2].Value == MinesweeperSq.None)
                    UncoverSquares(check);
            }
        }
    }
    private void PlaceMines(int ammount)
    {
        Random rnd = new Random();
        while (ammount > 0)
        {
            var (x, y) = (rnd.Next(0, Field.GetLength(0)), 
                rnd.Next(0, Field.GetLength(1)));
            if (Field[x, y].Value != MinesweeperSq.Bomb)
            {
                Field[x, y].Value = MinesweeperSq.Bomb;
                ammount--;
            }
        }
    }

    private void GenerateField()
    {
        for (var index0 = 0; index0 < Field.GetLength(0); index0++)
        {
            for (var index1 = 0; index1 < Field.GetLength(1); index1++)
            {
                var item = Field[index0, index1];
                if (item.Value == MinesweeperSq.None)
                {
                    item.Value = (MinesweeperSq)MineCount(index0, index1);
                }
            }
        }

    }
    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < Field.GetLength(0) && y >= 0 && y < Field.GetLength(0);
    }
    private int MineCount(int x, int y)
    {
        int count = 0;
        foreach (var item in _checkHelper)
        {
            if (IsInBounds(x + item.Item1, y + item.Item2) &&
                Field[x + item.Item1, y + item.Item2].Value == MinesweeperSq.Bomb)
            {
                count++;
            }
        }
        return count;
    }
}
