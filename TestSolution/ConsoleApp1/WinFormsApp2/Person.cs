namespace WinFormsApp2;

public class Person(string firstName = "", string lastName = "", DateTime bday = new DateTime(), string placeofBirth = "", string hobby = "")
{
    public string? FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public DateTime DateOfBirth { get; set; } = bday;
    public string? PlaceOfBirth { get; set; } = placeofBirth;
    public string? Hobby { get; set; } = hobby;
    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}