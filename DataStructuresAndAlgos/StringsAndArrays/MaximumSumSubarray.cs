using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MaximumSumSubarray
{
    [Test]
    public void Test_MaxSumSubarray()
    {
        var input = new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4};
        Assert.AreEqual(6, MaxSumSubarray(input) );
    }

    private int MaxSumSubarray(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int currSum = nums[0];
        int maxSum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currSum = Math.Max(currSum + nums[i], nums[i]);
            maxSum = Math.Max(currSum, maxSum);
        }

        return maxSum;


    }
}