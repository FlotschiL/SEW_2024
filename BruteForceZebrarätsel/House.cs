namespace BruteForceZebrarätsel;

public class House(int[] nums)
{
    public int ID { get; set; } = nums[0];
    public Color Color { get; set; } = (Color)nums[1];
    public Drink Drink { get; set; } = (Drink)nums[1];
    public Animal Animal { get; set; } = (Animal)nums[1];
    public Nation Nation { get; set; } = (Nation)nums[1];
    public Cigarette Cigarette { get; set; } = (Cigarette)nums[1];
}

public enum Color
{
    rot, grün, weiß, gelb, blau
}
public enum Drink
{
    Kaffee, Tee, Milch, Orangensaft, Wasser
}
public enum Animal
{
    Hund, Schnecken, Fuchs, Pferd, Zebra
}
public enum Nation
{
    Engländer, Spanier, Ukrainer, Norweger, Japaner
}
public enum Cigarette
{
    OldGold, Kools, Chesterfield, LuckyStrike, Parliaments
}