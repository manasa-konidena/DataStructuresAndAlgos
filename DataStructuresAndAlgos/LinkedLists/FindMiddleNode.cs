using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class FindMiddleNode
{
    [Test]
    public void Test_FindMiddleNode()
    {
        var input = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4, 5, 6});
        var result = "4";
        
        Assert.That(ListNode.PrintLinkedList(MiddleNode(input)), Is.EqualTo(ListNode.PrintLinkedList(ListNode.ConvertArrayToLinkedList(new int[] {4,5,6}))));
    }

    private ListNode MiddleNode(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}