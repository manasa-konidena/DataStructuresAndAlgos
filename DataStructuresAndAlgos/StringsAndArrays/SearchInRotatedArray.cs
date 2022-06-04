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

    /// <summary>
    /// CHeck if the left half is sorted, if yes check that target is in the range and search there
    /// if not, check if the target is in between mid and end, if yes search there
    /// if not, search in left
    /// </summary>
    /// <param name="target"></param>
    /// <param name="nums"></param>
    /// <returns></returns>
    private int SearchInRotatedSortedArray(int target, int[] nums)
    {
        int start = 0, end = nums.Length - 1;
        
        while(start <= end)
        {
            int mid = start + (end - start) / 2;
            if(target == nums[mid]) return mid;
            if(nums[mid] >= nums[start])
            {
                if(target < nums[mid] && target >= nums[start]) end = mid - 1;
                else start = mid + 1;
            }
            else
            {
                if(target > nums[mid] && target <= nums[end]) start = mid + 1;
                else end = mid - 1;
            }
        }
    
        return -1;
    }
}