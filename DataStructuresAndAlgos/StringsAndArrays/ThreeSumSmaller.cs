using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ThreeSumSmaller
{
    [Test]
    public void Test_ThreeSumToZero()
    {
        var input = new int[] {3, 1, 0, -2};
        var result = GetThreeSumSmaller(input, 4);
        
        Assert.That(result, Is.EqualTo(3));
    }

    
    
    public int GetThreeSumSmaller(int[] nums, int target) {
        Array.Sort(nums);

        var total = 0;

        if (nums.Length < 3) return 0;

        int i = 0, j = 1, k = nums.Length - 1;

        while (i < nums.Length - 2)
        {
            while (j < k)
            {
                if (nums[i] + nums[j] + nums[k] < target)
                {
                    total += k - j;
                    j++;
                }
                else k--;
            }

            i++;
            j = i + 1;
            k = nums.Length - 1;
        }

        return total;
    }
    
    private class CustomListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> throuple1, IList<int> throuple2)
        {
            var x = throuple1.OrderBy(i => i);
            var y = throuple2.OrderBy(i => i);
            return Enumerable.SequenceEqual(x, y);
        }

        public int GetHashCode(IList<int> throuple)
        {
            string code = String.Join(",", throuple.OrderBy(i => i));
            return code.GetHashCode();
        }
    }
}