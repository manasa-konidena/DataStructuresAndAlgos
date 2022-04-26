using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class TwoSum
{
    [Test]
    public void Test_TwoSum()
    {
        var input = new int[] {2, 7, 11, 15};
        var target = 9;
        var output = new int[] {1, 0};
        CollectionAssert.AreEquivalent(output, TwoSumToTarget(input, target));


        CollectionAssert.AreEquivalent(new int[] {5, 11},
            TwoSumToTarget(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1}, 11));
    }

    /// <summary>
    /// Create a hashmap of int, int -> target and index
    /// Go through the nums array
    /// Find num in the hashmap
    /// If found, return the indices [num index, the value from hashmap]
    /// If not, put that target - num  and the indexes
    /// </summary>
    private int[] TwoSumToTarget(int[] nums, int target)
    {
        Dictionary<int, int> targetToIndex = new Dictionary<int, int>();

        for (int i=0 ;i<nums.Length;i++)
        {
            if (targetToIndex.TryGetValue(nums[i], out var indexWithDiff))
            {
                return new int[] {i, indexWithDiff};
            }
            
            targetToIndex[target - nums[i]] =  i;
        }

        return null;

    }
}  