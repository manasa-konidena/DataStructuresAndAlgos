using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class ReverseLinkedList
{

    [Test]
    public void Test_ReverseLL()
    {
        var inputLl = Node.ConvertArrayToLinkedList(new int[] {1, 2, 3, 4});
        var outputLl = Node.ConvertArrayToLinkedList(new int[] {4, 3, 2, 1});
        
        Assert.That(Node.PrintLinkedList(outputLl), Is.EqualTo(Node.PrintLinkedList((ReverseLl(inputLl)))));
    }
    
    private Node? ReverseLl(Node? node)
    {
        Node? prev = null, curr = node, nex = null;

        while (curr != null)
        {
            nex = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = nex;
        }

        return prev;
    }

}