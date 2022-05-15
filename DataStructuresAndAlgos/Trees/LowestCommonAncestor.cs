namespace DataStructuresAndAlgos.Trees;

public class LowestCommonAncestor
{
    private TreeNode _lca;
    
    public TreeNode FindLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        DFSTree(root, p, q);
        return _lca;
    }

    private bool DFSTree(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null) return false;

        int left = DFSTree(root.left, p, q) ? 1 : 0;
        int right = DFSTree(root.right, p, q) ? 1 : 0;

        int mid = (root == p || root == q) ? 1 : 0;

        if (mid + left + right >= 2) _lca = root;

        return (mid + left + right >= 1);
    }
}