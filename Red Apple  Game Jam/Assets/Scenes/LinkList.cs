using UnityEngine;

public class LinkList : MonoBehaviour
{
    private SinglyLinkedList sll;

    private void Start()
    {
        sll = new SinglyLinkedList();
        InputValues();
            
    }

    void InputValues()
    {
       //Input
        sll.head = new SinglyLinkedList.ListNode(10);

        SinglyLinkedList.ListNode second = new SinglyLinkedList.ListNode(11);
        SinglyLinkedList.ListNode third = new SinglyLinkedList.ListNode(12);
        SinglyLinkedList.ListNode fourth = new SinglyLinkedList.ListNode(13);
        SinglyLinkedList.ListNode fifth = new SinglyLinkedList.ListNode(14);
        SinglyLinkedList.ListNode sixth = new SinglyLinkedList.ListNode(14);


        //Assignning 
        sll.head.next = second;
        second.next = third;
        third.next = fourth;
        fourth.next = fifth;
        fifth.next = sixth;
       
        //sll.Display();
        //sll.InsertNode(2, 1);
        //sll.Display();
      //  sll.DeleteChainNode(5,sll.head);
     //   sll.Display();
        //sll.DeleteMiddleNode(3, sll.head);
        //sll.Display();
        //sll.ReverseElement();
        //sll.Display();

        //sll.LastElement(2);
        //sll.Display();

        sll.RemoveDuplicates();
        sll.Display();
    }
}

public class SinglyLinkedList
{
    public ListNode head;

    public class ListNode
    {
        public int data;
        public ListNode next;

        public ListNode(int data)
        {
            this.data = data;
            this.next = null;
        }


    }
    public void InsertNode(int position, int data)
    {
        ListNode node = new ListNode(data);

        if (position == 1)
        {
            node.next = head;
            head = node;
        }
        else
        {
            ListNode previous = head;
            int count = 1;
            while (count < position - 1)
            {
                previous = previous.next;
                count++;
            }

            ListNode current = previous.next;
            node.next = current;
            previous.next = node;

        }
        Debug.Log("AfterInsertion" + "new Value : " + node.data);
      
       

    }
    public void Display()
    {
        ListNode current = head;
        string logLine = "";

        while (current != null)
        {
            logLine += current.data + "----> ";
            current = current.next;
        }

        Debug.Log(logLine + "Null");
    }
    public void DeleteChainNode(int position ,ListNode node)
    {
        ListNode currentNode = node;
        ListNode previousNode = null;
        if(head ==null)
        {
            return;
        }
        if (position ==1)
        {
            head = null;
            node = node.next;
            head = node;
            return;
        }
        
        else
        {

            int count = 1;
            while (count <= position )
            {
                previousNode = currentNode;
                currentNode = currentNode.next;
                count++;
              
            }
            previousNode.next = null;
          
        }
        Debug.Log("New value of Head :" + head.data);
        Debug.Log("Chain Node Deletion");
    }
    public void DeleteMiddleNode(int position, ListNode node)
    {
        ListNode currentNode = node;
       
        
        if (head == null)
        {
            return;
        }
        if (position == 1)
        {
            head = null;
            node = node.next;
            head = node;
            return;
        }

        else
        {

            int count = 1;
            while (count <= position-1)
            {
               
               
                currentNode = currentNode.next;
                count++;

            }
            ListNode previous = currentNode.next;
            currentNode.next = previous.next;
          
           
          
        }
       
        Debug.Log("Middle Node Deletion");
       
    }

    public void ReverseElement()
    {
        ListNode current = head;
        ListNode previous = null;
        ListNode next = null;

        while (current != null)
        {
            next = current.next; // Store next node
            current.next = previous; // Reverse current node's pointer
            previous = current; // Move pointers one position ahead
            current = next;
        }
        head = previous; 
        Debug.Log("Reverse Element");
      
    }

    public void LastElement(int lastPos)
    {
        ListNode current = head;
        ListNode previous = head;
        int count = 0;

        while(count < lastPos)
        {

            current = current.next;
            count++;
        }
        while(current != null)
        {

            current = current.next;
            previous = previous.next;

        }
        head = previous;
        Debug.Log("ElementfromEnd found :" + head.data);
       
    }

    public void RemoveDuplicates()
    {
        ListNode current = head;



        while (current != null && current.next != null)
        {

            if (current.data == current.next.data )

            {
                current.next = current.next.next;

            }

            else
            {
                current = current.next;
            }
        }
        head = current;
    }
}





