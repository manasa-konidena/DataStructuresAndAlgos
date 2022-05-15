namespace DataStructuresAndAlgos.StringsAndArrays;

public class FindMaxConsecutiveOnes
{
    public int GetFindMaxConsecutiveOnes(int[] nums) {
        int result = 0;
        int lastZeroFound = 0;
        int numZeroes = 0;
        int start = 0, end = 0;
        while(end < nums.Length)
        {
            if(nums[end] == 1) end++;
            else
            {
                numZeroes++;
                if(numZeroes > 1)
                {
                    result = Math.Max(result, end - start);
                    start = lastZeroFound + 1;
                    numZeroes = 1;
                    
                }
                lastZeroFound = end;
                end++;
            }
        }
        
        
        if(numZeroes <= 1) result = Math.Max(result, end - start);
        return result;
    }
}