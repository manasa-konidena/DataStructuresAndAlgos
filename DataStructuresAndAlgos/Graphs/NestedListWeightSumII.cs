using DataStructuresAndAlgos.StringsAndArrays;

namespace DataStructuresAndAlgos.Graphs;

/// <summary>
/// TC :O(N) where N is the sum of number of integers + number of lists
/// SC : O(N) as well to have the stack space to put each of the number and list
/// </summary>
public class NestedListWeightSumII
{
    public int DepthSumInverse(IList<NestedInteger> nestedList) {
        // Caclulate max Depth
        int maxDepth = MaxDepth(nestedList);
        return CalculateWeightedSum(maxDepth, 1, nestedList);
    }

    private int MaxDepth(IList<NestedInteger> nestedList)
    {
        int maxDepth = 1;
        foreach (var nested in nestedList)
        {
            if (!nested.IsInteger())
            {
                maxDepth = Math.Max(maxDepth, 1 + MaxDepth(nested.GetList()));
            }
        }

        return maxDepth;
    }

    private int CalculateWeightedSum(int maxDepth, int depth, IList<NestedInteger> nestedList)
    {
        int currSum = 0;

        foreach (var nested in nestedList)
        {
            if (nested.IsInteger()) currSum += nested.GetInteger() * (maxDepth - depth + 1);
            else
            {
                currSum += CalculateWeightedSum(maxDepth, depth + 1, nested.GetList());
            }
        }

        return currSum;
    }
}