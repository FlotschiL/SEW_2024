using Leet_Code;
Solution x = new Solution();
/*List<int> list1 = new List<int>(){9};
List<int> list2 = new List<int>(){9};
ListNode NodeHelper(List<int> list, int i)
{
    if (i <= 0)
    {
        return new ListNode(list[i]);
    }
    return new ListNode(list[i], NodeHelper(list, --i));
}

ListNode root1 = NodeHelper(list1, list1.Count-1);
ListNode root2 = NodeHelper(list2, list2.Count-1);
//ListNode root2 = NodeHelper(4);*/
//FindMedianSortedArrays(new List<int>(){1,2,3,4,5}.ToArray(), new List<int>(){6,7,8,9,10,11,12,13,14,15,16,17}.ToArray())
Console.WriteLine(x.MaxArea([1,8,6,2,5,4,8,3,7]));
