namespace DataStructuresAndAlgos.StringsAndArrays;

public class MissingNumber
{
    public int FindMissingNumber(int[] nums) {
        
        var numberOfNums = nums.Length;
        
        var expectedSum = ((numberOfNums)*(numberOfNums + 1))/2;
        
        var actualSum = 0;
        
        foreach(var num in nums) actualSum += num;
        
        return expectedSum - actualSum;
        
    }
}