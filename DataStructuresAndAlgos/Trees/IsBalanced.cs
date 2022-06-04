namespace DataStructuresAndAlgos.Trees;

public class IsBalanced
{
    public bool CheckIsBalanced(TreeNode root)
    {
        if (root == null) return true;
        if (Math.Abs(HeightOfTree(root.left) - HeightOfTree(root.right)) <= 1 
            && CheckIsBalanced(root.left) && CheckIsBalanced(root.right)) return true;
        return false;
    }

    private int HeightOfTree(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + Math.Max(HeightOfTree(root.left), HeightOfTree(root.right));
    }

    public bool IsBalancedDFS(TreeNode root)
    {
        return DFSHeight(root) != -1;
    }

    public int DFSHeight(TreeNode root)
    {
        if (root == null) return 0;
        int left = DFSHeight(root.left);
        if (left == -1) return -1;
        int right = DFSHeight(root.right);
        if (right == -1) return -1;

        if (Math.Abs(left - right) > 1) return -1;
        return 1 + Math.Max(left, right);

    }
}