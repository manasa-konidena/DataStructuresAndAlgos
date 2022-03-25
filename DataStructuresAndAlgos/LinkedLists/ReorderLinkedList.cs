using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class ReorderLinkedList
{
    [Test]
    public void Test_ReorderLinkedList()
    {
        Reorder(ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4, 5}));
    }

    private ListNode Reorder(ListNode head)
    {
        var node = head;
        
        var stack = new Stack<ListNode>();
        while (node != null)
        {
            stack.Push(node);
            node = node.next;
        }

        node = head;

        while (node != null)
        {
            var nexx = node.next;
            var fromLast = stack.Pop();

            node.next = fromLast;
            fromLast.next = nexx;
            node = nexx;

            if (node != null && node.next == fromLast)
            {
                node.next = null;
                break;
            }
        }

        return head;

    }
}