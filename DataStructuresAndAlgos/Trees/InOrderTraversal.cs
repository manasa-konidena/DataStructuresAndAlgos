namespace DataStructuresAndAlgos.Trees;

public class InOrderTraversal
{
    public List<int> InOrder(TreeNode? root)
    {
        var stack = new Stack<TreeNode>();
        var result = new List<int>();

        if (root == null) return result;

        TreeNode? currNode = root;

        while (stack.Count != 0 || currNode != null)
        {
            if (currNode != null)
            {
                stack.Push(currNode);
                currNode = currNode.left;
            }
            else
            {
                currNode = stack.Pop();
                result.Add(currNode.val);
                currNode = currNode.right;
            }
        }

        return result;


    }
}