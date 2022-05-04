using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class DisappearingNumbersInArray
{
    [Test]
    public void Test_DisappearedNumbers()
    {
        CollectionAssert.AreEquivalent(new int[]{5, 6}, FindDisappearedNumbers(new int[]{4, 3, 2, 7, 8, 2, 3, 1}));
    }
    
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var currNum = Math.Abs(nums[i]);
            if(nums[currNum - 1] < 0) continue;
            nums[currNum - 1] *= -1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] > 0) result.Add(i + 1);
        }

        return result;

    }
}