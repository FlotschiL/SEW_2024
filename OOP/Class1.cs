namespace OOP;

public class Person1(string name = "", int age = 0)
{
    public delegate void WhatToTell(string message);

    public event WhatToTell GrownUp;

    public delegate void PleaseTellMe(object sender, EventArgs message);

    public event PleaseTellMe Inform;

    public string Name { get; init; } = name;
    public int Age { get; private set; } = age;

    public void Ageing()
    {
        Age++;
        if (Age == 18)
        {
            OnGrownUp();
        }
    }

    public void OnGrownUp()
    {
        GrownUp?.Invoke($"{Name} jubelt: Juhuu ich bin erwachsen");
        Inform.Invoke(this, new GrownUpEventArgs { Message = "Juuhuu ich bin erwachsen" });
    }

    public override string ToString()
    {
        return Name + ": " + Age;
    }
}

public class GrownUpEventArgs : EventArgs
    {
        public string Message { get; init; }
    }