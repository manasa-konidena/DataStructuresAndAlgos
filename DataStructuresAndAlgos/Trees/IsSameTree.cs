namespace DataStructuresAndAlgos.Trees;

public class IsSameTree
{
    private bool SameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p != null && q == null) return false;
        if (p == null && q != null) return false;
        if (p.val == q.val && SameTree(p.left, q.left) &&
            SameTree(p.right, q.right)) return true;
        return false;
    }
}