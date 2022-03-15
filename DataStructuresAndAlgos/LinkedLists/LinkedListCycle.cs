using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class LinkedListCycle
{
    [Test]
    public void Test_LinkedListCycle()
    {
        
        
    }

    private bool HasLinkedListCycle(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true;
        }

        return false;
    }

}