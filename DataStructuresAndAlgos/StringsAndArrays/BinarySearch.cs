using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class BinarySearch
{
    [Test]
    public void Test_BinarySearch()
    {
        var input = new int[] {1, 2, 3, 4, 5, 6};
        var input2 = new int[] {1, 2, 3, 4, 5};

        Assert.That(BinarySearchRevision(input, 0, 5, 3), Is.EqualTo(2));
        Assert.That(BinarySearchRevision(input2, 0, 4, 3), Is.EqualTo(2));
        Assert.That(BinarySearchRevision(input, 0, 5, 11), Is.EqualTo(-1));
        Assert.That(BinarySearchRevision(input, 0, 5, -5), Is.EqualTo(-1));
    }

    private int BinarySearchRecursive(int begin, int end, int[] array, int target)
    {
        if (begin > end) return -1;
        int mid = (begin + end) / 2;
        if (target < array[mid]) return BinarySearchRecursive(begin, mid, array, target);
        if (target > array[mid]) return BinarySearchRecursive(mid + 1, end, array, target);
        if (target == array[mid]) return mid;
        return -1;
    }


    private int BinarySearchRevision(int[] inputArr, int start, int end, int target)
    {
        if (start == end) return inputArr[start] == target ? start : -1;
        var mid = (start + end) / 2;
        if (target <= inputArr[mid]) return BinarySearchRevision(inputArr, start, mid, target);
        else return BinarySearchRevision(inputArr, mid + 1, end, target);

    }
}