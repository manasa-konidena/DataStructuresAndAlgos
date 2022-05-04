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


    /// <summary>
    /// Take two pointers and move one n times
    /// Then move both and when the second ones hits the end return the val at first
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    private ListNode RemoveNthFromEndRevision(ListNode head, int n)
    {
        ListNode first = head;
        ListNode second = head;
        ListNode toReturn = head;
        ListNode prev = null;

        int distanceBetweenTwo = 0;

        while (second != null)
        {
            if (distanceBetweenTwo == n)
            {
                prev = first;
                first = first.next;
                second = second.next;
            }
            else
            {
                second = second.next;
                distanceBetweenTwo++;
            }
        }
        
        if(prev == null) return toReturn.next;
        
        prev.next = first.next;
        
        return toReturn;




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