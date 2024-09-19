namespace WinFormsApp2;

public class FriendsManager : List<Person>
{
    private Person[] friends;
    public void GetFriendsFromFile(string path)
    {
        List<Person> tempFriends = new List<Person>();
        StreamReader sr = new StreamReader(path);
        while (sr.Peek() > 0)
        {
            string[] line = sr.ReadLine()?.Split(";") ?? Array.Empty<string>();
            DateTime date = DateTime.ParseExact(line[2], "dd.MM.yyyy", null);
            tempFriends.Add(new Person(line[0], line[1], date, line[3], line[4]));
        }
        sr.Close();
        friends = tempFriends.ToArray();
    }
    
    /*public Person GetFriendByName(string name)
    {
        foreach (var person in Friends)
        {
            if (person.ToString() == name)
            {
                return person;
            }
        }
        throw new Exception("Friend not found");
    }*/
}