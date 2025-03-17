using System.IO;
using System.Text.Json;

Console.WriteLine("Hello, World!");
string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
string filename = System.IO.Path.Combine(path, "semester.json");
/*List<string> items = new List<string>(){"Flotschi", "Maxi", "Bergi"};
string json = JsonSerializer.Serialize(items);
File.WriteAllText(filename, json);*/
string json = System.IO.File.ReadAllText(filename);
List<string>? jsonList = System.Text.Json.JsonSerializer.Deserialize<List<string>>(json);
foreach (var jsonItem in jsonList)
{
    Console.WriteLine(jsonItem);
}
//addition