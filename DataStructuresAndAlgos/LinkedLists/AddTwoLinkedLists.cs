using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class AddTwoLinkedLists
{
    [Test]
    public void Test_AddTwoNumbers()
    {
        var num1 = ListNode.ConvertArrayToLinkedList(new int[] {9, 9, 9, 9, 9, 9, 9});
        var num2 = ListNode.ConvertArrayToLinkedList(new int[] {9, 9, 9, 9});

        AddTwoNumbers(num1, num2);

    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var tempResult = new ListNode();
        var result = tempResult;
        int carryOver = 0;

        while (l1 != null || l2 != null)
        {
            int p = l1 == null ? 0 : l1.val;
            int q = l2 == null ? 0 : l2.val;
            
            int curr = p + q + carryOver;

            if (curr >= 10)
            {
                carryOver = curr / 10;
                tempResult.next = new ListNode(curr % 10);
            }
            else
            {
                carryOver = 0;
                tempResult.next = new ListNode(curr);
            }

            l1 = l1?.next;
            l2 = l2?.next;
            tempResult = tempResult.next;
        }
        
        if(carryOver != 0) tempResult.next = new ListNode(carryOver);
        
        return result.next;
    }
}