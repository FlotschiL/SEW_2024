namespace Observer;

public class Student : Observer
{
    public Teacher myTeacher { get; set; }
    public string Name{get; init; }
    public override void Update()
    {
        Console.WriteLine(Name + ":" + myTeacher.GetCurrentState());
    }
}//was er grad gesagt hat is a blödsinn. 1 Subject n Oberserver. nicht anders keine n zu n beziwhung