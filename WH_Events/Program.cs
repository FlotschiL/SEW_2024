using System.Threading.Channels;
using Microsoft.VisualBasic;
/*
int Addiere(int a, int b){return a+b;}
int Subtrahiere(int a, int b){return a-b;}
Rechner myRechner = Addiere;
Console.WriteLine(myRechner(1,2));
myRechner = Subtrahiere;
Console.WriteLine(myRechner(1,2));
myRechner = delegate(int a, int b){return a*b;};
Console.WriteLine(myRechner(13,2));
myRechner = (a,b) => a/b;
Console.WriteLine(myRechner(13,2));


//delegate muss ganz am schluss sein
public delegate int Rechner(int a, int b);
//stufe 6:
*/