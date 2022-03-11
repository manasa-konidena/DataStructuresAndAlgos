using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class BinarySearch
{
    [Test]
    public void Test_BinarySearch()
    {

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
}