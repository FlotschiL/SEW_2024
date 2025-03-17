namespace FriendsLibSQL;

public class Friend(string firstName, string lastName, string hobbies, DateTime birthDay)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Hobbies { get; set; } = "notImplemented";
    public DateTime BirthDay { get; set; } = birthDay;
    
  
    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}