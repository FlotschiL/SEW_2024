using Trees;
MyBinaryTree tree = new MyBinaryTree();
Random rand = new Random();
for (int i = 0; i < 30; i++)
{
    tree.Insert(new MyElement(rand.Next(1,1000)));
    tree.Insert(new MyElement(i));
}

tree.Insert(new MyElement(55));
tree.Insert(new MyElement(27));
tree.Insert(new MyElement(28));
tree.Insert(new MyElement(13));
tree.Insert(new MyElement(59));
tree.Insert(new MyElement(54));
tree.Insert(new MyElement(99));
tree.InOrder();
Console.WriteLine("\n-------------------------");
//Console.WriteLine("\n" + tree.FindLowest().val);
//Console.WriteLine(tree.FindBiggest().val);

Console.WriteLine(tree.Find(55));
Console.WriteLine(tree.Delete(55));
Console.WriteLine(tree.Find(55));
tree.InOrder();
//Console.WriteLine(tree.Delete(tree.Root, tree.Root.left.right.val));