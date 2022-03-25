using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class RemoveNthFromLast
{
    [Test]
    public void Test_RemovalNthNode()
    {
        var input = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4, 5});
        var number = 2;

        Console.WriteLine(ListNode.PrintLinkedList(RemoveNthFromEnd(input, 2)));
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        int lengthOfLL = 0;
        var copyOfHead = head;
        var finalCopyOfHead = head;

        while (copyOfHead != null)
        {
            copyOfHead = copyOfHead.next;
            lengthOfLL++;
        }

        int toRemove = lengthOfLL - n;
        int indexCounter = 0;

        if (toRemove == 0) return head.next;
        
        while (finalCopyOfHead != null)
        {
            if (indexCounter == toRemove - 1)
            {
                finalCopyOfHead.next = finalCopyOfHead.next?.next;
            }
            
            finalCopyOfHead = finalCopyOfHead.next;
            indexCounter++;

        }

        return head;

    }
}