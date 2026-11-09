using System.ComponentModel;

namespace DataStructures;

class LinkedListNode
{
    public int data;
    public LinkedListNode next;

    public LinkedListNode(int x)
    {
        data = x;
        next = null;
    }

}

class LinkedList
{
    private int count;
    LinkedListNode head;
    LinkedListNode tail;
    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }
    public void AddNodeToFront(int data)
    {
        LinkedListNode node = new LinkedListNode(data);
        if (head == null)
        {
            tail = node;
        }
        node.next = head;
        head = node;
        count++;
    }

    public void AddNodeToEnd(int data)
    {
        LinkedListNode node = new LinkedListNode(data);

        if (head == null)
        {
           head = node;
           tail = node;
        }
        else
        {
            tail.next = node;
            tail = node;
        }
        count++;
    }

    public void Insertsion(int data, int index)
    {
        LinkedListNode node = new LinkedListNode(data);
        
        if (index >= count)
        {
            AddNodeToEnd(data);
            return;
        }

        if (index == 0)
        {
            AddNodeToFront(data);
            return;
        }
        else
        {
            LinkedListNode runner = head;
            for (int i = 0; i < index-1; i++)
            {
                runner = runner.next;
            }
            node.next = runner.next;
            runner.next = node;
            count++;
        }
    }
    public void Join(LinkedList lst)
    {
        if (lst.head == null)
        {
            return;
        }

        if (head == null)
        {
            head = lst.head;
            tail = lst.tail;
        }
        else
        {
            tail.next = lst.head;
            tail = lst.tail;
        }

        count += lst.count;
        lst.head = null;
        lst.tail = null;
        lst.count = 0;
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
            count--;
            return true;
        }
        LinkedListNode runner = head;
        while (runner.next != null)
        {
            if (runner.next.data == data)
            {
                if (runner.next == tail) tail = runner;
                runner.next = runner.next.next;
                count--;
                return true;
            }
            runner = runner.next;
        }

        return false;
    }

    public void Reverse()
    {
        LinkedListNode prev = null;
        LinkedListNode curr = head;
        tail = head;
        
        while (curr != null)
        {
            LinkedListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        head = prev;
    }
    public bool Contains(int data)
    {
        LinkedListNode runner = head;
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

    public void PrintList()
    {
        LinkedListNode runner = head;
        while (runner != null)
        {
            Console.WriteLine(runner.data);
            runner = runner.next;
        }
    }
    public void BubbleSort()
    {
    
        if (head == null) return;          // empty list: nothing to sort

        bool swapped = true;
        while (swapped)                    // keep making passes until nothing swaps
        {
            swapped = false;
            LinkedListNode runner = head;

            while (runner.next != null)    // compare runner with the node after it
            {
                if (runner.data > runner.next.data)
                {
                    int temp = runner.data;
                    runner.data = runner.next.data;
                    runner.next.data = temp;
                    swapped = true;
                }
                runner = runner.next;
                
            }
        }
    }

    public void InsertionSort()
    {
        LinkedListNode sorted = null;
        LinkedListNode current = head;

        while (current != null)
        {
            LinkedListNode next = current.next;

            if (sorted == null || current.data <= sorted.data)
            {
                current.next = sorted;
                sorted = current;
            }
            else
            {
                LinkedListNode s = sorted;
                while (s.next != null && s.next.data < current.data)
                {
                    s = s.next;
                }

                current.next = s.next;
                s.next = current;
            }
            current = next;
        }
        head = sorted;
        
        tail = head;
        if (tail != null)
        {
            while (tail.next != null)
            {
                tail = tail.next;
            }
        }

    }

    private LinkedListNode GetMiddle(LinkedListNode start)
    {
        LinkedListNode slow = start;
        LinkedListNode fast = start.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    private LinkedListNode MergeLists(LinkedListNode a, LinkedListNode b)
    {
        LinkedListNode dummy = new LinkedListNode(0);
        LinkedListNode TailPtr = dummy;

        while (a != null && b != null)
        {
            if (a.data <= b.data)
            {
                TailPtr.next = a;
                a = a.next;
            }
            else
            {
                TailPtr.next = b;
                b = b.next;
            }
            TailPtr = TailPtr.next;
        }
        TailPtr.next = (a != null) ? a: b;
        return dummy.next;
    }
    private LinkedListNode MergeSortNodes(LinkedListNode start)
    {
        // base case: 0 or 1 node is already sorted
        if (start == null || start.next == null) return start;

        // split
        LinkedListNode middle = GetMiddle(start);
        LinkedListNode rightStart = middle.next;
        middle.next = null;           

        // sort each half (recursion)
        LinkedListNode left = MergeSortNodes(start);
        LinkedListNode right = MergeSortNodes(rightStart);

        // merge
        return MergeLists(left, right);
    }
    public void MergeSort()
    {
        head = MergeSortNodes(head);

        // fix tail (nodes moved)
        tail = head;
        if (tail != null)
        {
            while (tail.next != null) tail = tail.next;
        }
    }
    
}