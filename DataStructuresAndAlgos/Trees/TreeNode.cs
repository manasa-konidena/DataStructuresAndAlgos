using System.Text;
using DataStructuresAndAlgos.LinkedLists;
using NUnit.Framework;

namespace DataStructuresAndAlgos.Trees;

public class TreeNode
{
    public TreeNode? left { get; set; }
    public TreeNode? right { get; set; }
    public int val { get; set; }

    public TreeNode()
    {
    }

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.left = left;
        this.right = right;
        this.val = val;
    }
}