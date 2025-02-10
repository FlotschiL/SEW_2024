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
        while (tmp.Next != null && (toInsert.Value as IComparable).CompareTo(tmp.Value as IComparable) > 0)
        {
            tmp = tmp.Next;
        }
        //einfügen
    }
}