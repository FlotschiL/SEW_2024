namespace ExamTest;
using OOP;
public class Tests
{
    Exam first = new Exam{Person = new Person{FirstName = "John", LastName = "Doe"}, 
        Marks = new List<Subject>(){
            new Subject { Description = "AM" }, 
            new Subject { Description = "D" },
            new Subject { Description = "INSY" }}};

    Exam second = new Exam{Person = new Person{FirstName = "Jane", LastName = "Doe"}, 
        Marks = new List<Subject>(){
            new Subject { Description = "AM" }, 
            new Subject { Description = "E" },
            new Subject { Description = "INSY" }}};

    private Exam third;
    [SetUp]
    public void Setup()
    {
        third =new Exam{Person = new Person{FirstName = "Susie", LastName = "Sorglos"}, 
            Marks = new List<Subject>(){
                new Subject { Description = "AM" }, 
                new Subject { Description = "E" },
                new Subject { Description = "SEW" }}};
    }

    [Test]
    public void Exception1()
    {
        second.Examine("AM", 1);
        Assert.Throws<Exception>(() => second.Examine("AM", 2));
    }
    [Test]
    public void Exception2()
    {
        Assert.Throws<ApplicationException>(() => second.Examine("D", 1));
    }
    [Test]
    public void Exception3()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => second.Examine("E", 7));
    }
}