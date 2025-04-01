using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;

namespace BlazorApp1;

public class MineManager :  IGame
{
    private Square[,] _field = new Square[15, 15];//col row
    public GameState GameState = GameState.Going;
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
        PlaceMines(10);
        GenerateField();
    }
    public string this[int x, int y]
    {
        get
        {
            Debug.Write("GETTER");
            return _field[x, y].ToString();
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
                item.Value = (MinesweeperSq)MineCount(index0, index1);
            }
        }

    }

    private int MineCount(int x, int y)
    {
        int count = 0;
        foreach (var item in checkHelper)
        {
            if (_field[x + item.Item1, y + item.Item2].Value == MinesweeperSq.Bomb)
            {
                count++;
            }
        }
        return count;
    }
    public string? Winner { get; private set; } = "No Winner / Draw";
    public string? NextPlayer => "asdf";

    public void Set(int col, int row)
    {
        if (!_field[col, row].IsCovered)
        {
            _field[col, row].IsCovered = false;
            if (_field[col, row].Value == MinesweeperSq.Bomb)
            {
                //game aus
            }

        }
    }
    
}
