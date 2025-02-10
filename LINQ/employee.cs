namespace ScottQuery;

class employee
{
    public int id { get; set; }
    public string name { get; set; }
    public string job { get; set; }
    public int? parent_id { get; set; }
    public DateTime hire_date { get; set; }
    public int salary { get; set; }
    public int? commission { get; set; }
    public int dept_id { get; set; }
    
    public override string ToString()
    {
        return $"{id}, {name}, {job}, {parent_id}, {hire_date.ToShortDateString()}, {salary}, {commission}, {dept_id}";
    }
}