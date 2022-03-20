using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class TwoSumII
{
    [Test]
    public void Test_TwoSumSorted()
    {
        var input = new int[] {2, 7, 11, 15};
        var target = 9;
        
        CollectionAssert.AreEquivalent(TwoSum(input, target), new int[]{1, 2});
    }
    
    public int[] TwoSum(int[] numbers, int target)
    {
        var start = 0;
        var end = numbers.Length - 1;

        while (start < end)
        {
            if (numbers[start] + numbers[end] < target)
            {
                start++;
            }
            else if (numbers[start] + numbers[end] > target)
            {
                end--;
            }
            else
            {
                return new int[] {start+1 , end+1};
            }
        }

        return new int[]{};
    }
}