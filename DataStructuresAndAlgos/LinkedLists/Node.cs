using System.Globalization;
using System.Text;
using NUnit.Framework;

namespace DataStructuresAndAlgos.LinkedLists;

public class Node
{
    [Test]
    public void Test_LLImplementation()
    {
        // Test making a new list
        var newLl = ConvertArrayToLinkedList(new int[] {1, 2, 3, 5});
        Console.WriteLine(PrintLinkedList(newLl));
    }

    public Node? Next { get; set; }
    public int Val { get; set; }

    public Node()
    {
    }

    public Node(int val = 0, Node? next = null)
    {
        Next = next;
        Val = val;
    }

    public static string PrintLinkedList(Node? node)
    {
        if (node == null) return "No data in the linked list";
        
        var stringBuilder = new StringBuilder();

        while (node.Next != null)
        {
            stringBuilder.Append($"{node.Val}->");
            node = node.Next;
        }

        stringBuilder.Append(node.Val);

        return stringBuilder.ToString();
    }

    public static Node? ConvertArrayToLinkedList(int[] inputArray)
    {
        if (inputArray.Length == 0) return null;
        var node = new Node(val: inputArray[0]);
        var returnNode = node;

        for (int i=1;i<inputArray.Length; i++)
        {
            node.Next = new Node(inputArray[i]);
            node = node.Next;
        }

        return returnNode;
    }
}