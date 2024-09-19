using System.Diagnostics;

namespace FriendsLib;

public class Friends : List<Friend>
{
    private string _file;
    public void Load(string file)
    {
        _file=file;
        StreamReader sr = new StreamReader(file);
        
       while (sr.Peek()>0){
            string line = sr.ReadLine();
            string[] elements = line.Split(";");
            DateTime date = DateTime.ParseExact(elements[3], "dd.MM.yyyy", null);
            this.Add(new Friend(elements[0], elements[1], elements[2], date));
       }
       sr.Close();
    }

    public void SaveToFile()
    {
        string content = "";
        StreamWriter sw = new StreamWriter(_file);
        sw.Write("");
        foreach (var friend in this)
        {
            content += friend.FirstName + ";";
            content += friend.LastName + ";";
            content += friend.Hobbies + ";";
            content += friend.BirthDay.ToString("dd.MM.yyyy") + ";";
            sw.WriteLine(content);
            content = "";
        }
        sw.Close();
    }
}