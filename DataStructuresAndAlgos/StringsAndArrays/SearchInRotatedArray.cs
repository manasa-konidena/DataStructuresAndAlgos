using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class SearchInRotatedArray
{
    [Test]
    public void Test_SearchInRotatedArray()
    {
        //var output = SearchInRotatedSortedArray(0, new int[] {4, 5, 6, 7, 0, 1, 2});
        
        var output2 = SearchInRotatedSortedArray(1, new int[] {5, 1,3});
    }

    private int SearchInRotatedSortedArray(int searchFor, int[] nums)
    {
        return SearchInRotatedRecursive(searchFor, nums, 0, nums.Length - 1);
    }
    
    private int SearchInRotatedRecursive(int target, int[] nums, int start, int end)
    {
        if (start == end) return target == nums[start] ? start : -1;

        int mid = (start + end) / 2;
        
        // if start > mid and target > mid => check in start - mid
        // if start < mid
        

        if (target >= nums[start] && target <= nums[mid] && nums[start] <= nums[mid])
            return SearchInRotatedRecursive(target, nums, start, mid);
        else return SearchInRotatedRecursive(target, nums, mid + 1, end);
    }
}