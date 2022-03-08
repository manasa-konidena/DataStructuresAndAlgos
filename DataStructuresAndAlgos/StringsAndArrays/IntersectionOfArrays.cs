using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class IntersectionOfArrays
{
    [Test]
    public void Test_Intersect()
    {
        var input1 = new int[] {1, 2, 34, 5, 6, 7};
        var input2 = new int[] {7,34,90};

        CollectionAssert.AreEquivalent(new int[] {7, 34}, Intersect(input1, input2));
    }

    public int[] Intersect(int[] nums1, int[] nums2)
    {

        var mapForFirst = new Dictionary<int, int>();

        foreach (var num in nums1)
        {
            if (mapForFirst.TryGetValue(num, out var count)) mapForFirst[num] = count + 1;
            else mapForFirst.Add(num, 1);
        }

        var resultLenght = nums1.Length > nums2.Length ? nums2.Length : nums1.Length;
        
        var result = new List<int>();
        int i = 0;
        foreach (var num in nums2)
        {
            if (mapForFirst.TryGetValue(num, out var countInFirst))
            {
                if(countInFirst <= 0) continue;
                
                result.Add(num);
                i++;
                mapForFirst[num] = countInFirst - 1;
            }
        }

        return result.ToArray();

    }
}