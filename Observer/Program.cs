using System.Threading.Channels;
using Observer;
Teacher macho = new Teacher();
Student Ismail = new Student(){Name = "Ismail"};
Student Zwöfa = new Student(){Name="Zwöfa"};
macho.Register(Ismail);
macho.Register(Zwöfa);

macho.Teach(State.Insy);

macho.Unregister(Zwöfa);
macho.Teach(State.Free);
