
using MongoDB.Bson;
using Newtonsoft.Json;

var manager = new MongoManager("mongodb://localhost:27017", "SEW", "test");
Console.WriteLine("reset? press y");
if (Console.ReadKey(true).Key == ConsoleKey.Y)
{
    manager.DeleteAllAsync();
    await manager.CreateSampleData(
        @"C:\Users\MainUserFlo\Downloads\first-names.txt",
        @"C:\Users\MainUserFlo\Downloads\last-names.txt"
    );
}
/*var people = await manager.GetAllAsync();
foreach (var person in people)
    Console.WriteLine(JsonConvert.SerializeObject(person, Formatting.Indented));*/
Dictionary<string, object?> Person = new Dictionary<string, object?>(){
{"Name", null},
{"LastName", null},
{"Age", null},
{"Gender", null}

};
string? input;
foreach (var prop in Person)
{
    do
    {
        Console.WriteLine($"Enter {prop.Key}:");
        Person[prop.Key] = Console.ReadLine();
    }
    while(Person[prop.Key] == null);
}
await manager.InsertAsync(Person);