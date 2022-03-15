using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class ReverseLinkedList
{

    [Test]
    public void Test_ReverseLL()
    {
        var inputLl = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4});
        var outputLl = ListNode.ConvertArrayToLinkedList(new int[] {4, 3, 2, 1});
        
        Assert.That(ListNode.PrintLinkedList(outputLl), Is.EqualTo(ListNode.PrintLinkedList((ReverseLl(inputLl)))));
    }
    
    private ListNode? ReverseLl(ListNode? node)
    {
        ListNode? prev = null, curr = node, nex = null;

        while (curr != null)
        {
            nex = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nex;
        }

        return prev;
    }

}