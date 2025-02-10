namespace ScottQuery;

public class depts : List<dept>
{
    public void Load(string file)
    {
        using (StreamReader sr = new StreamReader(file))
        {
            while (sr.Peek() > 0)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                Add(new dept
                {
                    DEPTNO = Convert.ToInt32(values[0]), DNAME = values[1], LOC = values[2]
                });
            }
        }
    }

}

public class dept
{
    public int DEPTNO;
    public string DNAME;
    public string LOC;
}