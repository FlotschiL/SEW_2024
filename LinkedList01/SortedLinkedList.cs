namespace LList;

public class SortedLinkedList:MyLinkedList
{
    public void Insert(Node toInsert)
    {
        if (head == null)
        {
            base.InsertFront(toInsert);
            return;
        }
        Node tmp = head;
        while (tmp.Next != null && toInsert.Value > tmp.Next.Value)
        {
            tmp = tmp.Next;
        }   
        toInsert.Next = tmp.Next;
        tmp.Next = toInsert;

    }
}