namespace ScottQuery;

class employees : List<employee>
{
    public void Load(string file)
    {
        using (StreamReader sr = new StreamReader(file))
        {
            while (sr.Peek() > 0)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');

                if (values[3] == "")
                {
                    values[3] = null;
                }
                
                if (values[6] == "")
                {
                    values[6] = null;
                }
                
                Add(new employee
                {
                    id = Convert.ToInt32(values[0]), name = values[1], job = values[2], parent_id = Convert.ToInt32(values[3]),
                    hire_date = Convert.ToDateTime(values[4]), salary = Convert.ToInt32(values[5]), commission = Convert.ToInt32(values[6]),
                    dept_id = Convert.ToInt32(values[7])
                });
            }
        }
    }
}

static class Print
{
    public static void PrintToConsole(this IEnumerable<object> query)
    {
        query.ToList().ForEach(item => Console.WriteLine(item));
    }
}