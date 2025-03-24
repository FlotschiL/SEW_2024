namespace BlazorApp1;

public class VierGewinnt : IGame
{
    public int[,] Field = new int[6, 7];
    //1 is player 1; -1 is player 2;
    //0 is nothing
    public int Turn = 1;
    public GameState GameState = GameState.Going;
    public string this[int x, int y]
    {
        get
        {
            if (Field[y, x] == 0) return "\0"; // Empty space
            return Field[y, x] == 1 ? "X" : "O";
        }
    }

    public string? Winner { get; }
    public string? NextPlayer { get; }
    public void Set(int col, int row)
    {
        Set(col);
    }
    public void Set(int col)
    {
        if (GameState != GameState.Going) return; // Game already over

        // Find the lowest empty row in the selected column
        for (int row = 5; row >= 0; row--)
        {
            if (Field[row, col] == 0)
            {
                Field[row, col] = Turn; // Place piece
                Turn = Turn == 1 ? -1 : 1; // Switch turn
                return;
            }
        }
    }
    private void CheckForWinner()
    {
        // Check all win conditions: Horizontal, Vertical, Diagonal
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                int player = Field[row, col];
                if (player == 0) continue; // Skip empty cells

                // Check right
                if (col + 3 < 7 && player == Field[row, col + 1] && player == Field[row, col + 2] && player == Field[row, col + 3])
                {
                    GameState = player == 1 ? GameState.Player1Wins : GameState.Player2Wins;
                    return;
                }

                // Check down
                if (row + 3 < 6 && player == Field[row + 1, col] && player == Field[row + 2, col] && player == Field[row + 3, col])
                {
                    GameState = player == 1 ? GameState.Player1Wins : GameState.Player2Wins;
                    return;
                }

                // Check diagonal (\)
                if (row + 3 < 6 && col + 3 < 7 && player == Field[row + 1, col + 1] && player == Field[row + 2, col + 2] && player == Field[row + 3, col + 3])
                {
                    GameState = player == 1 ? GameState.Player1Wins : GameState.Player2Wins;
                    return;
                }

                // Check diagonal (/)
                if (row - 3 >= 0 && col + 3 < 7 && player == Field[row - 1, col + 1] && player == Field[row - 2, col + 2] && player == Field[row - 3, col + 3])
                {
                    GameState = player == 1 ? GameState.Player1Wins : GameState.Player2Wins;
                    return;
                }
            }
        }
    }
}