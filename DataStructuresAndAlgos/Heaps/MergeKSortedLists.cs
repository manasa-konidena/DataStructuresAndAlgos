using C5;
using DataStructuresAndAlgos.LinkedLists;
using NUnit.Framework;

namespace DataStructuresAndAlgos.Heaps;

public class MergeKSortedLists
{
    [Test]
    public void Test_MergeKLists()
    {
        var lists = new ListNode[3]
        {
            ListNode.ConvertArrayToLinkedList(new int[] {1, 4, 5}),
            ListNode.ConvertArrayToLinkedList(new int[] {1, 3, 4}), 
            ListNode.ConvertArrayToLinkedList(new int[] {2, 6})
        };

        var result = MergeKLists(lists);
        
        Assert.That(ListNode.PrintLinkedList(result), Is.EqualTo(ListNode.PrintLinkedList(ListNode.ConvertArrayToLinkedList(new int[]{1,1,2,3,4,4,5,6}))));
        Assert.That(ListNode.PrintLinkedList(MergeKLists(new ListNode[0])), Is.EqualTo(ListNode.PrintLinkedList(ListNode.ConvertArrayToLinkedList(new int[0]))));

    }

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        
        var minHeap = new PriorityQueue<(int, int), int>();
        var result = new ListNode();
        var tempRes = result;

        for (int i = 0; i < lists.Length; i++)
        {
            if(lists[i] == null) continue;
            minHeap.Enqueue((i, lists[i].val), lists[i].val);
        }
        
        while (minHeap.Count != 0)
        {
            var currLowest = minHeap.Dequeue();
            
            tempRes.next = new ListNode(currLowest.Item2);
            tempRes = tempRes.next;

            lists[currLowest.Item1] = lists[currLowest.Item1].next;
            
            if(lists[currLowest.Item1] != null) minHeap.Enqueue((currLowest.Item1, lists[currLowest.Item1].val), lists[currLowest.Item1].val);
        }

        return result.next;
    }
}