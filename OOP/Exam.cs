using OOP;

namespace OOP;

public class Exam
{
    public event EventHandler Passed;
    
    public event EventHandler Failed;
    
    public List<Subject> Marks = new List<Subject>();
    public Person? Person;
    private int _counter;
    private int _failCounter;
    
    public void Examine(string subjectName, int grade)
    {
        bool containsSubject = false;
        foreach (var subject in Marks)
        {
            if (subject.Description == subjectName)
            {
                subject.Grade = grade;
                OnFinish(grade);
                containsSubject = true;
            }
        }
        if (!containsSubject)
        {
            throw new ApplicationException();//"Unknown subject"
        }
        
    }

    private void OnFinish(int grade)
    {
        _counter++;
        if (_counter == Marks.Count)
        {
            if (_failCounter > 0)
            {
                OnFinish();
            }
            else
            {
                OnFinish();
            }
        }
        if (grade == 5)
        {
            _failCounter++;
        }
        Passed?.Invoke((Person), EventArgs.Empty); 
        Failed?.Invoke((Person), EventArgs.Empty);
    }
    private void OnFinish()
    {
        
        
    }
}

public class PassedOrFailedEventArgs(Person person) : EventArgs
{
    public Person Person { get; set; } = person;
}