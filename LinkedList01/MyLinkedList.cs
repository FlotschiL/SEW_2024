using System.Text;

namespace LList;

public class MyLinkedList
{
    public Node head;

    public void InsertFront(Node newNode)
    {
        newNode.Next = head;
        head = newNode;
    }

    public void Append(Node newNode)
    {
        if (head == null)
        {
            InsertFront(newNode);
            return;
        }
        Node? help = head; // when head null then use newNode as start
        while (help?.Next != null)
        {
            help = help.Next;
        }
        help.Next = newNode;
    }

    public void AppendRecursive(Node where, Node newNode)
    {
        if (where == null)
        {
            InsertFront(newNode);
            return;
        }
        if (where.Next == null)
        {
            where.Next = newNode;
        }
        else
        {
            AppendRecursive(where.Next, newNode);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        Node? current = head;
        while (current != null)
        {
            sb.Append(current);
            current = current.Next;
        }
        return sb.ToString();
    }
}