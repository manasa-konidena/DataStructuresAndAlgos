using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ContainsDuplicate
{
    [Test]
    public void Test_ContainsDuplicate()
    {
        var input = new int[] { 1,2,3,1};
        Assert.IsTrue(DoesContainDupe(input));
        
    }

    private bool DoesContainDupe(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();
        
        foreach(var num in nums)
        {
            if(!set.Add(num)) return true;
        }
        
        return false;
    }
}