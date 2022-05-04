using NUnit.Framework.Interfaces;

namespace DataStructuresAndAlgos.Trees;

public class InvertBinaryTree
{
    public TreeNode InvertTree(TreeNode? root)
    {
        if (root == null) return root;

        var right = InvertTree(root.right);
        var left = InvertTree(root.left);
        
        root.left = right;
        root.right = left;

        return root;

    }
}