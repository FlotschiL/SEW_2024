namespace Trees;
//geordneter bin baum
public class MyElement(int val)
{
    public int val { get; set; } = val;
    public MyElement left { get; set; }
    public MyElement right { get; set; }
    public override string ToString()
    {
        return val.ToString();
    }
}
public class MyBinaryTree
{
    public MyElement Root = null;

    public void Insert(MyElement element)
    {
        if (Root == null)
        {
            Root = element;
            return;
        }
        else
        {
            Insert(Root, element);
        }
        
    }
    private void Insert2(MyElement? current, MyElement element)
    {
        if (current?.left == null && element.val < current?.val)
        {
            current.left = element;
        }
        else if(current?.right == null && element.val >= current?.val)
        {
            current.right = element;
        }
        else
        {
            Insert2(element.val < current?.val ? current.left : current?.right, element);
        }
    }

    public MyElement FindLowest() => FindLowest(Root);
    private MyElement FindLowest(MyElement start)
    {
        MyElement current = start;
        while (current.left != null)
        {
            current = current.left;
        }
        return current;
    }
    public MyElement FindBiggest() => FindBiggest(Root);
    private MyElement FindBiggest(MyElement start)
    {
        MyElement current = start;
        while (current.right != null)
        {
            current = current.right;
        }
        return current;
    }
    
    public MyElement Find(int value) => Find(Root, value);

    private MyElement Find(MyElement current, int value)
    {
        if (current == null)
        {
            return null;
        }

        if (current.val == value)
            return current;
        if (value < current.val)
            return Find(current.left, value);
        else
            return Find(current.right, value);
    }

    public MyElement Delete(int value) 
    {
        Root = Delete(Root, value);
        return Root;
    }

    private MyElement Delete(MyElement current, int value)
    {
        if (current == null)
        {
            return null;
        }
        //find the element to delete
        if (value < current.val)
        {
            current.left = Delete(current.left, value);
        }
        else if (value > current.val)
        {
            current.right = Delete(current.right, value);
        }
        else//if not smaller or larger, then found:
        {
            // Case 1 & 2: one or no child
            if (current.left == null)
            {
                return current.right;
            }
            else if (current.right == null)
            {
                return current.left;
            }

            // Case 3: two children
            MyElement temp = FindLowest(current.right);

            current.val = temp.val;
            current.right = Delete(current.right, temp.val);
        }
        return current;
    }
    private MyElement Insert(MyElement current, MyElement element)
    {
        if(current == null)return element;
        else
        {
            if (element.val < current.val)
            {
                current.left = Insert(current.left, element);
            }else if (element.val >= current.val)
            {
                current.right = Insert(current.right, element);
            }
        }
        return current;
    }
    public void InOrder() => InOrder(Root);
    private void InOrder(MyElement element)
    {
        if(element == null)return;
        InOrder(element.left);
        Console.Write(element.val + " ");
        InOrder(element.right);
    }
}