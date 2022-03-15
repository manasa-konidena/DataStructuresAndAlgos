using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class RemoveElements
{
    [Test]
    public void Test_RemoveElements()
    {
        var input = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 6, 3, 4, 5, 6});
        var output = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4, 5});
        Assert.That(ListNode.PrintLinkedList(output), Is.EqualTo(ListNode.PrintLinkedList(RemoveGivenVals(input, 6))));
    }

    private ListNode RemoveGivenVals(ListNode head, int val)
    {
        ListNode prev = null;
        ListNode result = head;
        
        while (head != null)
        {
            if (head.val == val)
            {
                if (prev == null)
                {
                    head = head.next;
                    result = head;
                    continue;
                }
                prev.next = head.next;
                head = head.next;
            }
            else
            {
                prev = head;
                head = head.next;
            }
        }

        return result;
    }
}