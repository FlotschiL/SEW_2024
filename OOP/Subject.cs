namespace OOP;

public class Subject
{
    private int? _grade;

    public int? Grade
    {
        get { return _grade; }
        set
        {
            if (_grade != null)
            {
                throw new Exception("Grade already set");
            }
            if (value >= 1 && value <= 5)
            {
                _grade = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();//"Grade must be between 1 and 5"
            }
        }
    }
    public string? Description { get; set; }
    
}