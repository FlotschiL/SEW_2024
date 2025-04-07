using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using BlazorApp1.Pages;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1;

public class MineManager
{
    private Square[,] _field = new Square[15, 15];//col row
    public GameState GameState = GameState.Going;
    public Square[,] Field { get { return _field; }}
    private Tuple<int, int>[] checkHelper = new Tuple<int, int>[]
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
        for (var index0 = 0; index0 < _field.GetLength(0); index0++)
        {
            for (var index1 = 0; index1 < _field.GetLength(1); index1++)
            {
                Square item = new Square
                {
                    Value = MinesweeperSq.None
                };
                _field[index0, index1] = item;
            }
        }
        PlaceMines(10);
        GenerateField();
    }
    public string this[int x, int y]
    {
        get
        {
            return _field[x, y].IsCovered ? " " : _field[x, y].Value.ToString();
        }
    }

    public void ToggleMark(int x, int y)//single click
    {
        _field[x, y].IsMarked = !_field[x, y].IsMarked;
    }
    private void UncoverSquares(Tuple<int, int > pos)
    {
        _field[pos.Item1, pos.Item2].IsCovered = false;
        foreach (var helppos in checkHelper)
        {
            Tuple<int, int> check = new (helppos.Item1 + pos.Item1, helppos.Item2 + pos.Item2);
            if (IsInBounds(check.Item1, check.Item2) && _field[check.Item1, check.Item2].IsCovered)
            {
                _field[check.Item1, check.Item2].IsCovered = false;
                if(_field[check.Item1, check.Item2].Value == MinesweeperSq.None)
                    UncoverSquares(check);
            }
        }
    }
    private void PlaceMines(int ammount)
    {
        Random rnd = new Random();
        while (ammount > 0)
        {
            var (x, y) = (rnd.Next(0, _field.GetLength(0)), 
                rnd.Next(0, _field.GetLength(1)));
            if (_field[x, y].Value != MinesweeperSq.Bomb)
            {
                _field[x, y].Value = MinesweeperSq.Bomb;
                ammount--;
            }
        }
    }
    public void GenerateField()
    {
        for (var index0 = 0; index0 < _field.GetLength(0); index0++)
        {
            for (var index1 = 0; index1 < _field.GetLength(1); index1++)
            {
                var item = _field[index0, index1];
                if (item.Value == MinesweeperSq.None)
                {
                    item.Value = (MinesweeperSq)MineCount(index0, index1);
                }
            }
        }

    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < _field.GetLength(0) && y >= 0 && y < _field.GetLength(0);
    }
    private int MineCount(int x, int y)
    {
        int count = 0;
        foreach (var item in checkHelper)
        {
            if (IsInBounds(x + item.Item1, y + item.Item2) &&
                _field[x + item.Item1, y + item.Item2].Value == MinesweeperSq.Bomb)
            {
                count++;
            }
        }
        return count;
    }

    public string? Winner
    {
        get
        {
            return GameState.ToString();
        }
    }

    public void Set(int col, int row)
    {
        if (_field[col, row].IsCovered)
        {
            _field[col, row].IsCovered = false;
            UncoverSquares(new Tuple<int, int>(col, row));
            if (_field[col, row].Value == MinesweeperSq.Bomb)
            {
                GameState = GameState.Lost;
                return;
            }

        }
    }
    
}
