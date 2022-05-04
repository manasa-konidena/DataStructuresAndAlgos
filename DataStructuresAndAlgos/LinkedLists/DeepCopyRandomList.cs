namespace DataStructuresAndAlgos.LinkedLists;

public class DeepCopyRandomList
{
    public Node CopyRandomList(Node head)
    {
        var nodeToNewNodeDict = new Dictionary<Node, Node>();
        var res = new Node(0);
        var tempRes = res;

        int i = 0;
        while (head != null)
        {
            // if the head was already recreated
            if (head != null && nodeToNewNodeDict.TryGetValue(head, out var newHead))
            {
                tempRes.next = newHead;
            }
            else // If the head was never created
            {
                tempRes.next = new Node(head.val);
                nodeToNewNodeDict.Add(head, tempRes.next);
            }
            
            // If the head's random node was already recreated
            if (head.random != null && nodeToNewNodeDict.TryGetValue(head.random, out var newRandom))
            {
                tempRes.next.random = newRandom;
            }
            else // Create the random node and add it to the dict
            {
                tempRes.next.random = head.random == null ? null : new Node(head.random.val);
                if(head.random != null) nodeToNewNodeDict.Add(head.random, tempRes.next.random);
            }

            head = head.next;
            tempRes = tempRes.next;
        }

        return res.next;
    }
    
}

public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}