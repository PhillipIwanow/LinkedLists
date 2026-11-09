namespace DataStructures;


class Program
{
    static void Main(string[] args)
    {
        var list = new LinkedList();
        list.AddNodeToEnd(5);
        list.AddNodeToEnd(2);
        list.AddNodeToEnd(9);
        list.AddNodeToEnd(1);
        list.AddNodeToEnd(5);
        list.AddNodeToEnd(2);
        list.AddNodeToEnd(10);
        list.AddNodeToFront(0);
        list.PrintList();
        list.MergeSort();
        Console.WriteLine("===Sorted====");
        list.PrintList();     
    }
}
