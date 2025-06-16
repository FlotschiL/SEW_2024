// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
//Erkennen von Properties aus bekannter Klasse  
Person person1 = new Person { Id = 1, Name = "hugo", Age = 22};
foreach (var propertyInfo in typeof(Person).GetProperties())
{
    Console.WriteLine(propertyInfo.GetValue(person1));
}
foreach (var propertyInfo in typeof(Person).GetFields())
{
    Console.WriteLine(propertyInfo.GetValue(person1));
}
foreach (var propertyInfo in typeof(Person).GetMembers())
{
    Console.WriteLine(propertyInfo.Name);
}
class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Alter;
}