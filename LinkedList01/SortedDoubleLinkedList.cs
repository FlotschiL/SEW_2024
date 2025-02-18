namespace LList;

public class SortedDoubleLinkedList : MyDoubleLinkedList
{
    public void Insert(DoubleNode toInsert)
    {
        if (head == null)
        {
            base.InsertFront(toInsert);
            return;
        }

        if (toInsert.Value < head.Value)
        {
            InsertFront(toInsert);
            return;
        }
        DoubleNode tmp = head;
        while (tmp.Next != null && toInsert.Value > tmp.Next.Value)
        {
            tmp = tmp.Next;
        }   
        toInsert.Next = tmp.Next;
        toInsert.Prev = tmp;
        tmp.Next = toInsert;
        if (toInsert.Next != null)
        {
            toInsert.Next.Prev = tmp;
        }
        else
        {
            tail = toInsert;
        }
        
    }
}