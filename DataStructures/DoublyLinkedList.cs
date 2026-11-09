namespace DataStructures;

class DoublyNode
{
    public int data;
    public DoublyNode next;
    public DoublyNode prev;
    
    public DoublyNode(int data)
    {
        this.data = data;
    }
}


public class DoublyLinkedList
{
    private DoublyNode head;
    private DoublyNode tail;
    private int count;
    
    public int Count => count;

    public void AddNodeToFront(int data)
    {
        var node = new DoublyNode(data);

        if (head == null)
        {
            tail = node;
            head = node;
        }
        else
        {
            node.next = head;
            head.prev = node;
            head = node;
        }

        count++;
    }
    public void AddNodeToLast(int data)
    {
        var node = new DoublyNode(data);

        if (head == null)
        {
            head = node;
            tail = node;

        }
        else
        {
            tail.next = node;
            node.prev = tail;
            tail = node;
        }
        count++;
    }
    
    public bool RemoveNodeByValue(int data)
    {
        if (head == null)
        {
            return false;
        }

        if (head.data == data)
        {
            head = head.next;
            if (head == null) tail = null;
            else head.prev = null;
            count--;
            return true;
        }
        DoublyNode runner = head;
        while (runner.next != null)
        {
            if (runner.next.data == data)
            {
                if (runner.next == tail) tail = runner;
                runner.next = runner.next.next;
                if (runner.next != null)
                {
                    runner.next.prev = runner;
                }
                count--;
                return true;
            }
            runner = runner.next;
        }

        return false;
    }

    public void Reverse()
    {
        DoublyNode runner = head;
        while (runner != null)
        {
            var temp = runner.next;
            runner.next = runner.prev;
            runner.prev = temp;
            runner = temp;
        }
        var oldhead = head;
        head = tail;
        tail = oldhead;
    }
    
    public bool Contains(int data)
    {
        DoublyNode runner = head;
        while (runner != null)
        {
            if (runner.data == data)
            {
                return true;
            }
            runner = runner.next;
        }

        return false;
    }
    
    public void PrintForwar()
    {
        DoublyNode runner = head;
        while (runner != null)
        {
            Console.WriteLine(runner.data);
            runner = runner.next;
        }
    }

    public void PrintBackwards()
    {
        DoublyNode runner = tail;
        while (runner != null)
        {
            Console.WriteLine(runner.data);
            runner = runner.prev;
        }
    }
   
    
}