namespace SMÜ;

public class Versicherter(string name, int alter, int versicherungsmonate)
{
    public event EventHandler Pension;

    public string Name { get; init; } = name;
    public int Alter { get; private set; } = alter;
    public int Versicherungsmonate { get; private set; } = versicherungsmonate;

    public void GeburtstagFeiern()
    {
        Alter++;
        OnPension();
    }
    public void Arbeiten()
    {
        Versicherungsmonate++;
        OnPension();
    }

    private void OnPension()
    {
        if (Alter >= 65 || Versicherungsmonate >= 480)
        {
            Pension?.Invoke(this, EventArgs.Empty);
        }
    }
}