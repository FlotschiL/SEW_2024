// See https://aka.ms/new-console-template for more information

using BruteForceZebrarätsel;

Console.WriteLine("Hello, World!");
List<House> houses = new List<House>(); 
int max = 5;
for (int i = 0; i < max; i++)
{
    for (int j = 0; j < max; j++)
    {
        for (int k = 0; k < max; k++)
        {
            for (int l = 0; l < max; l++)
            {
                for (int m = 0; m < max; m++)
                {
                    for (int n = 0; n < max; n++)
                    {
                        houses.Add(new House([i, j, k, l, m, n]));
                    }
                }
            }
        }
    }
}

Console.WriteLine(houses.Count);
//2
houses.RemoveAll(
    h => h.Color != Color.rot && h.Nation==Nation.Engländer);
houses.RemoveAll(
    h => h.Color == Color.rot && h.Nation!=Nation.Engländer);
//3
houses.RemoveAll(
    h => h.Animal != Animal.Hund && h.Nation==Nation.Spanier);
houses.RemoveAll(
    h => h.Animal == Animal.Hund && h.Nation!=Nation.Spanier);
//4
houses.RemoveAll(
    h => h.Drink == Drink.Kaffee && h.Color!=Color.grün);
houses.RemoveAll(
    h => h.Drink != Drink.Kaffee && h.Color==Color.grün);
//5
houses.RemoveAll(
    h => h.Drink == Drink.Tee && h.Nation!=Nation.Ukrainer);
houses.RemoveAll(
    h => h.Drink != Drink.Tee && h.Nation==Nation.Ukrainer);
//6
houses.RemoveAll(
    h => h.ID == 5 && h.Color == Color.weiß);
//7
houses.RemoveAll(
    h => h.Cigarette == Cigarette.OldGold&& h.Animal!=Animal.Schnecken);
houses.RemoveAll(
    h => h.Cigarette != Cigarette.OldGold&& h.Animal==Animal.Schnecken);
//8
houses.RemoveAll(
    h => h.Cigarette == Cigarette.Kools&& h.Color != Color.gelb);
houses.RemoveAll(
    h => h.Cigarette != Cigarette.Kools&& h.Color == Color.gelb);
//9
houses.RemoveAll(
    h => h.ID != 3&& h.Drink == Drink.Milch);
houses.RemoveAll(
    h => h.ID == 3&& h.Drink != Drink.Milch);
//10
houses.RemoveAll(
    h => h.ID == 1 && h.Nation!=Nation.Norweger);
houses.RemoveAll(
    h => h.ID != 1 && h.Nation==Nation.Norweger);
//11
for (var index = 0; index < houses.Count; index++)
{
    var house = houses[index];
    if(house.Cigarette==Cigarette.Chesterfield)
        houses.RemoveAll(
        h => h.Animal != Animal.Fuchs
        && h.ID == house.ID + 1 && h.ID == house.ID - 1);
}

//12
//13
houses.RemoveAll(
    h => h.Cigarette != Cigarette.LuckyStrike&& h.Drink == Drink.Orangensaft);
houses.RemoveAll(
    h => h.Cigarette == Cigarette.LuckyStrike&& h.Drink != Drink.Orangensaft);
//14
houses.RemoveAll(
    h => h.Cigarette != Cigarette.Parliaments&& h.Nation == Nation.Japaner);
houses.RemoveAll(
    h => h.Cigarette == Cigarette.Parliaments&& h.Nation != Nation.Japaner);
//15
Console.WriteLine(houses.Count);





/*for (var index = 0; index < houses.Count; index++)
{
    var h = houses[index];
    if (h is not { Color: Color.rot, Nation: Nation.Engländer }
        or{ Nation: Nation.Spanier, Animal: Animal.Hund }
        or { Drink: Drink.Kaffee, Color: Color.grün }
        or {Nation:Nation.Ukrainer, Drink:Drink.Tee}
        or {Color:Color.grün,:})
    {
        houses.RemoveAt(index);
        continue;
    }

}
*/