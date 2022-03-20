using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MinimumInRotatedSortedArray
{
    [Test]
    public void Test_MinInRotatedArray()
    {
        var input = new int[] {3, 4, 5, 1, 2};
        Assert.That(MinInRotatedArray(input), Is.EqualTo(1));
        
        var input2 = new int[] {3, 4, 5, 6, 0, 1, 2};
        Assert.That(MinInRotatedArray(input2), Is.EqualTo(0));
        
        var input3 = new int[] {11, 13, 15, 17};
        Assert.That(MinInRotatedArray(input3), Is.EqualTo(11));
    }

    private int MinInRotatedArray(int[] nums)
    {
        return MinInRotatedArrayRecursive(nums, 0, nums.Length - 1);
    }

    private int MinInRotatedArrayRecursive(int[] inputArray, int start, int end)
    {
        if (start == end) return inputArray[start];
        if (inputArray[start] < inputArray[end]) return inputArray[start];
        
        var mid = (start + end) / 2;
        if (inputArray[mid] > inputArray[mid + 1]) return inputArray[mid + 1];
        
        if (inputArray[start] > inputArray[mid]) return MinInRotatedArrayRecursive(inputArray, start, mid);
        else return MinInRotatedArrayRecursive(inputArray, mid + 1, end);

    }
}