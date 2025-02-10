// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks.Dataflow;
using ScottQuery;

employees scottemployees = new employees();
scottemployees.Load(@"C:\Users\MainUserFlo\RiderProjects\SEW_2024\TestSolution\Semester1\LINQ\emps.csv");
depts depts = new depts();
depts.Load(@"C:\Users\MainUserFlo\RiderProjects\SEW_2024\TestSolution\Semester1\LINQ\depts.csv");

// 1
var query1 = from employee in scottemployees
    select employee;
    
//query1.ToList().ForEach(item => Console.WriteLine(item));
query1.PrintToConsole();

// 2
var query2 = from employee in scottemployees
where employee.dept_id == 10
select employee;

//query2.ToList().ForEach(item => Console.WriteLine(item));
query2.PrintToConsole();

// 3
var query3 = from employee in scottemployees
    where employee.job == "CLERK"
    select new{employee.name, employee.job, employee.salary};

//query3.ToList().ForEach(item => Console.WriteLine(item));
query3.PrintToConsole();

// 4
var query4 = from employee in scottemployees
where employee.dept_id != 10
select employee;

//query4.ToList().ForEach(item => Console.WriteLine(item));
query4.PrintToConsole();

// 5

var query5 = from employee in scottemployees
    where employee.commission > employee.salary
    select employee;

//query5.ToList().ForEach(item => Console.WriteLine(item));
query5.PrintToConsole();

var query6 = from employee in scottemployees
where employee.hire_date == new DateTime(1981, 12, 3)
select employee;

//query6.ToList().ForEach(item => Console.WriteLine(item));
query6.PrintToConsole();

var query7 = from employee in scottemployees
where employee.salary < 1250 || employee.salary > 1600
select employee;

//query7.ToList().ForEach(item => Console.WriteLine(item));
query7.PrintToConsole();

var query8 = from employee in scottemployees
where employee.job != "MANAGER" && employee.job != "PRESIDENT"
select employee;

//query8.ToList().ForEach(item => Console.WriteLine(item));
query8.PrintToConsole();

var query9 = from employee in scottemployees
where employee.name[2] == 'A'
select employee;

//query9.ToList().ForEach(item => Console.WriteLine(item));
query9.PrintToConsole();

var query10 = from employee in scottemployees
where employee.commission != null
select new{employee.id,employee.name, employee.job};
query10.PrintToConsole();
//query10.ToList().ForEach(item => Console.WriteLine(item));
var query11 = from employee in scottemployees
    join dept in depts on employee.dept_id equals dept.DEPTNO
    where dept.LOC == "NEW YORK"
        select new{queryNO = "query11", employee.id, employee.name, employee.job};
query11.PrintToConsole();