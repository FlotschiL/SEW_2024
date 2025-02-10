namespace Observer;

public abstract class Subject
{
    private List<Observer> observers;
    public abstract void Register(Observer observer);

    public virtual void Unregister(Observer observer)
    {
        observers.Remove(observer);
    }
    public abstract void Notify(Observer observer);
    public abstract State GetCurrentState();

}