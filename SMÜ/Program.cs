using System.Resources;
using System.Threading.Channels;
using SMÜ;

Versicherter a = new Versicherter("a", 61, 478);
Versicherter b = new Versicherter("b", 63, 390);
a.Pension += wurscht;
b.Pension += wurscht;

a.Arbeiten();
a.Arbeiten();
b.GeburtstagFeiern();
b.GeburtstagFeiern();

void wurscht(object o, EventArgs e)
{
    Console.WriteLine((o as Versicherter).Name);
}