using OOP;
Exam first = new Exam{Person = new Person{FirstName = "John", LastName = "Doe"}, 
    Marks = new List<Subject>(){new Subject { Description = "AM" }, new Subject { Description = "D" },new Subject { Description = "INSY" }}};

Exam second = new Exam{Person = new Person{FirstName = "Jane", LastName = "Doe"}, 
    Marks = new List<Subject>(){new Subject { Description = "AM" }, new Subject { Description = "E" },new Subject { Description = "INSY" }}};

Exam third = new Exam{Person = new Person{FirstName = "Susie", LastName = "Sorglos"}, 
    Marks = new List<Subject>(){new Subject { Description = "AM" }, new Subject { Description = "E" },new Subject { Description = "SEW" }}};

first.Passed+=Passed; first.Failed += Failed;
second.Passed+=Passed; second.Failed += Failed;
third.Passed+=Passed; third.Failed += Failed;

first.Examine("AM",2);
first.Examine("D",2);
first.Examine("INSY",4);

second.Examine("AM",1);

third.Examine("AM",2);
third.Examine("E",2);
third.Examine("SEW",5);

try { second.Examine("AM",2); } catch (Exception e) { Console.WriteLine(e.Message); }
try { second.Examine("D",1); } catch (Exception e) { Console.WriteLine(e.Message); }
try { second.Examine("E",7); } catch (Exception e) { Console.WriteLine(e.Message); }

void Passed(object sender, EventArgs e){
    Console.WriteLine((sender as Person) + " has passed");
}
void Failed(object sender, EventArgs e){
    Console.WriteLine((sender as Person) + " has failed");
}