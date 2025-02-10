namespace Observer;

public enum State{Sew,Insy,Free}
public class Teacher : Subject
{
    State currentState = State.Insy;
    private List<Observer> observers = new List<Observer>();
    public override void Register(Observer observer)
    {
        (observer as Student).myTeacher = this;
        observers.Add(observer);
    }

    public override void Notify(Observer observer)
    {
        observer.Update();
    }

    public void Teach(State state)
    {
        currentState = state;
        foreach (var student in observers)
        {
            Notify(student);
        }
    }
    public override State GetCurrentState()
    {
        return currentState;
    }
}