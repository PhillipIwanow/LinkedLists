namespace DataStructures;


class Program
{
    static void Main(string[] args)
    {
        var list = new LinkedList();
        list.AddNodeToEnd(1);
        list.AddNodeToEnd(2);
        list.AddNodeToEnd(3);
        list.AddNodeToEnd(4);
        list.Insertsion(53, 2);
        list.Insertsion(56, 199);
        list.PrintList();
    }
}
