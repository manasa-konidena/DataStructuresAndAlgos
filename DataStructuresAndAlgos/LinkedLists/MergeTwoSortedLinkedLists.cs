using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class MergeTwoSortedLinkedLists
{
    [Test]
    public void Test_Merging()
    {
        var n1 = ListNode.ConvertArrayToLinkedList(new int[] {1, 2, 4});
        var n2 = ListNode.ConvertArrayToLinkedList(new int[] {1, 3, 4});

        var result = ListNode.ConvertArrayToLinkedList(new[] {1, 1, 2, 3, 4, 4});
        
        Assert.That(ListNode.PrintLinkedList(result), Is.EqualTo(ListNode.PrintLinkedList(MergeTwoSortedListsRevision(n1, n2))));
    }

    private ListNode MergeTwoSortedListsRevision(ListNode n1, ListNode n2)
    {
        ListNode res = new ListNode();
        ListNode tempRes = res;

        while (n1 != null && n2 != null)
        {
            if (n1.val <= n2.val)
            {
                res.next = n1;
                n1 = n1.next;
            }
            else
            {
                res.next = n2;
                n2 = n2.next;
            }
            
            res = res.next;
        }

        while (n1 != null)
        {
            res.next = n1;
            n1 = n1.next;
            res = res.next;
        }

        while (n2 != null)
        {
            res.next = n2;
            n2 = n2.next;
            res = res.next;
        }

        return tempRes.next;
    }
    
    private ListNode MergeTwoSortedHeads(ListNode n1, ListNode n2)
    {
        ListNode result = new ListNode();
        ListNode tempRes = result;

        while (n1 != null && n2 != null)
        {
            if (n1.val <= n2.val)
            {
                tempRes.next = n1;
                n1 = n1.next;
                tempRes = tempRes.next;
            }
            else
            {
                tempRes.next = n2;
                n2 = n2.next;
                tempRes = tempRes.next;
            }
        }

        while (n1 != null)
        {
            tempRes.next = n1;
            n1 = n1.next;
            tempRes = tempRes.next;
        }

        while (n2 != null)
        {
            tempRes.next = n2;
            n2 = n2.next;
            tempRes = tempRes.next;
        }

        return result.next;
    }
}