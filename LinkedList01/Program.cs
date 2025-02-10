// See https://aka.ms/new-console-template for more information

using LList;
MyLinkedList x = new MyLinkedList();
x.InsertFront(new Node(1));
x.InsertFront(new Node(2));
x.InsertFront(new Node(3));
x.Append(new Node(1));
Console.WriteLine(x.ToString());