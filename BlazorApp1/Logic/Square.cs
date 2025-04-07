namespace BlazorApp1;

public enum MinesweeperSq
{
    None,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Bomb
}
public class Square
{
    public MinesweeperSq Value { get; set; }
    public bool IsCovered { get; set; } = true;
    
}