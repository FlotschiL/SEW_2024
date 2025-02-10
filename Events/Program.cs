using OOP;
Person1 flo = new Person1("flo", 17);
flo.GrownUp += Celebrate;
flo.Inform += Inform;

Console.WriteLine(flo);

flo.Ageing();
Console.WriteLine(flo);

void Celebrate(string message )
{
    Console.WriteLine("Ein Grund zum Feiern! " + message);
}
void Inform(object sender, EventArgs e)
{
    Console.WriteLine($"Ein Grund zum Feiern! {(sender as Person1).Name}"+
                      $" jubelt {(e as GrownUpEventArgs).Message}");
}