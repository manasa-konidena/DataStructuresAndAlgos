using DataStructuresAndAlgos.StringsAndArrays;

namespace DataStructuresAndAlgos.Graphs;

public class NestedWeightedSum
{
    public int DepthSum(IList<NestedInteger> nestedList) {
        return calculateSumWithDepth(nestedList, 1);
        
    }
    
    
    private int calculateSumWithDepth(IList<NestedInteger> nestedList, int depth)
    {
        int currSum = 0;

        foreach (var nested in nestedList)
        {
            if (nested.IsInteger()) currSum += depth * nested.GetInteger();
            else
            {
                currSum += calculateSumWithDepth(nested.GetList(), depth + 1);
            }
        }

        return currSum;
    }
}