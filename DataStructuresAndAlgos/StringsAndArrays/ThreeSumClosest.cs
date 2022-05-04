namespace DataStructuresAndAlgos.StringsAndArrays;

public class ThreeSumClosest
{
    public int GetThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);

        int minDiff = Int32.MaxValue;
        int sum = 0;

        int i = 0, j = 1, k = nums.Length - 1;

        while (i < nums.Length - 2)
        {
            while (j < k)
            {
                int currSum = nums[i] + nums[j] + nums[k];
                int diff = Math.Abs(nums[i] + nums[j] + nums[k] - target);
                
                if (currSum == target)
                {
                    return currSum;
                }
                else if(currSum > target)
                {
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        sum = currSum;
                    }
                    k--;
                }
                else
                {
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        sum = currSum;
                    }
                    j++;
                }
            }

            i++;
            j = i + 1;
            k = nums.Length - 1;
        }

        return sum;
    }
}