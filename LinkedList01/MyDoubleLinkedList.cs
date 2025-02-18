using System.Text;

namespace LList;

public class MyDoubleLinkedList
{
    public DoubleNode? head;
    public DoubleNode? tail;
    public void InsertFront(DoubleNode newNode)
    {
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            head.Prev = newNode;
            newNode.Next = head;
            head = newNode;
        }
    }
    
    public void Append(DoubleNode newNode)
    {
        if (tail == null)
        {
            tail = newNode;
            head = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }
    

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DoubleNode? current = head;
        while (current != null)
        {
            sb.Append(current);
            current = current.Next;
        }
        return "null <-> " + sb.ToString() + "null";
    }
    public string ToStringReverse()
    {
        StringBuilder sb = new StringBuilder();
        DoubleNode? current = tail;
        while (current != null)
        {
            sb.Append(current);
            current = current.Prev;
        }
        return "null <-> " + sb.ToString() + "null";
    }
}