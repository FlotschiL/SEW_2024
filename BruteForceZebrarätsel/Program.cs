// See https://aka.ms/new-console-template for more information

using BruteForceZebrarätsel;

Console.WriteLine("Hello, World!");
List<House> houses = new List<House>(); 
int max = typeof(House).GetProperties().Length;
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

foreach (var VARIABLE in houses)
{
    
}