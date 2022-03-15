using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class RemoveDuplicates
{
    [Test]
    public void Test_RemoveDupesWhenSorted()
    {
        var input = ListNode.ConvertArrayToLinkedList(new int[] {1, 1, 2, 2, 3, 4, 5, 5, 6, 6, 7, 7});
        var output = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4, 5, 6, 7});
        
        Assert.That(ListNode.PrintLinkedList(output), Is.EqualTo(ListNode.PrintLinkedList(output)));

    }

    private ListNode RemoveDupesFromSortedLl(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null)
        {
            if (slow.val == fast.val)
            {
                fast = fast.next;
                if (fast == null) slow.next = fast;
            }
            else
            {
                slow.next = fast;
                slow = fast;
            }
        }

        return head;
    }
}