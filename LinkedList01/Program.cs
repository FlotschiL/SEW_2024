// See https://aka.ms/new-console-template for more information

using LList;
MyLinkedList x = new MyLinkedList();
x.InsertFront(new Node(1));
x.InsertFront(new Node(2));
x.InsertFront(new Node(3));
x.Append(new Node(1));

SortedLinkedList l = new SortedLinkedList();
l.Insert(new Node(1));
l.Insert(new Node(5));
l.Insert(new Node(3));

MyDoubleLinkedList l2 = new MyDoubleLinkedList();
l2.InsertFront(new DoubleNode(1));
l2.InsertFront(new DoubleNode(5));
l2.InsertFront(new DoubleNode(6));
l2.InsertFront(new DoubleNode(7)); 
l2.Append(new DoubleNode(1));
l2.Append(new DoubleNode(5));
l2.Append(new DoubleNode(6));
l2.Append(new DoubleNode(7));
/*Console.WriteLine(l2 + " | normal");
Console.WriteLine(l2.ToStringReverse() + " | reverse");*/
SortedDoubleLinkedList l3 = new SortedDoubleLinkedList();
l3.Insert(new DoubleNode(5));
l3.Insert(new DoubleNode(25));
l3.Insert(new DoubleNode(4));
l3.Insert(new DoubleNode(2));
l3.Insert(new DoubleNode(7));
l3.Insert(new DoubleNode(5));
Console.WriteLine(l3);