using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MoveZeroes
{
    [Test]
    public void Test_MoveZeroes()
    {
        var input = new int[] {0, 1, 0, 3, 12};
        var output = new int[] {1, 3, 12, 0, 0};
        MoveZeroesInArray(input);
        CollectionAssert.AreEquivalent(input, output);
    }
    
    private void MoveZeroesInArray(int[] nums)
    {
        int slow = 0, fast = 0;

        foreach (int num in nums)
        {
            if (num != 0)
            {
                nums[slow] = nums[fast];
                slow++;
                fast++;
            }
            else
            {
                fast++;
            }
        }

        while (slow < nums.Length)
        {
            nums[slow] = 0;
            slow++;
        }
    }

}