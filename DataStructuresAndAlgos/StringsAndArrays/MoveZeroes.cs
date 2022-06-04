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
    
    /// <summary>
    /// Take two pointers
    /// Move the faster one when the element is zero
    /// When you hit a non zero element, move the element to the slow pointer
    /// move both pointers and then continue
    ///
    /// Essentially, every non zero you encounter, you are placing it in place of an
    /// earlier found zero
    /// </summary>
    /// <param name="nums"></param>
    /// TC - O(N)
    /// SC - O(1)
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