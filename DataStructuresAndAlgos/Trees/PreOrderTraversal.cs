using NUnit.Framework;

namespace DataStructuresAndAlgos.Trees;

public class PreOrderTraversal
{
    [Test]
    public void Test_PreOrder()
    {
        
    }

    /// <summary>
    /// When the root is first printed followed by left and then right
    /// </summary>
    public  List<int> PreOrder(TreeNode? root)
    {
        var output = new List<int>();
        var stack = new Stack<TreeNode>();

        if (root == null) return output;
        
        stack.Push(root);
        while (stack.Count != 0)
        {
            var inStack = stack.Pop();
            output.Add(inStack.val);
            if (inStack.right != null) stack.Push(inStack.right);
            if (inStack.left != null) stack.Push(inStack.left);
        }

        return output;
    }

    private List<int> PreOrderRecursive(TreeNode root)
    {
        var result = new List<int>();

        PreOrderHelper(root, result);
        return result;
    }

    private void PreOrderHelper(TreeNode root, List<int> result)
    {
        if(root == null) return;
        result.Add(root.val);
        PreOrderHelper(root.left, result);
        PreOrderHelper(root.right, result);
    }
}