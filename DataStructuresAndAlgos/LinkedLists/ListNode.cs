using System.Globalization;
using System.Text;
using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class ListNode
{
    [Test]
    public void Test_LLImplementation()
    {
        // Test making a new list
        var newLl = ConvertArrayToLinkedList(new int[] {1, 2, 3, 5});
        Console.WriteLine(PrintLinkedList(newLl));
    }

    public ListNode? next { get; set; }
    public int val { get; set; }

    public ListNode()
    {
    }

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.next = next;
        this.val = val;
    }

    public static string PrintLinkedList(ListNode? node)
    {
        if (node == null) return "No data in the linked list";
        
        var stringBuilder = new StringBuilder();

        while (node.next != null)
        {
            stringBuilder.Append($"{node.val}->");
            node = node.next;
        }

        stringBuilder.Append(node.val);

        return stringBuilder.ToString();
    }

    public static ListNode? ConvertArrayToLinkedList(int[] inputArray)
    {
        if (inputArray.Length == 0) return null;
        var node = new ListNode(val: inputArray[0]);
        var returnNode = node;

        for (int i=1;i<inputArray.Length; i++)
        {
            node.next = new ListNode(inputArray[i]);
            node = node.next;
        }

        return returnNode;
    }
}