namespace DataStructuresAndAlgos.StringsAndArrays;

public class MaxProductSubarray
{
    public int MaxProduct(int[] nums)
    {
        int result = 0;
        int max_so_far = nums[0];
        int min_so_far = nums[0];

        for (int i=1;i<nums.Length;i++)
        {
            int curr = nums[i];
            int temp_max = Math.Max(curr, Math.Max(curr * max_so_far, curr * min_so_far));
            min_so_far = Math.Min(curr, Math.Min(curr * max_so_far, curr * min_so_far));

            max_so_far = temp_max;
            result = Math.Max(max_so_far, result);
        }

        return result;
    }
}