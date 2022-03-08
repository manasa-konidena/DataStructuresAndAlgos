using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ProductOfArrayExceptSelf
{
    [Test]
    public void Test_ProductExceptSelf()
    {
        var input = new int[] {1, 2, 3, 4};

        var output = ProductExceptSelf_SpaceComplexityImp(input);
        CollectionAssert.AreEquivalent(output, new int[] {24, 12, 8, 6});
    }

    /// <summary>
    /// Compute the product of all lefts and rights to each element in two separate arrays
    /// the resultant array is the product of left and rights
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] leftProducts = new int[nums.Length];
        int[] rightProducts = new int[nums.Length];

        leftProducts[0] = rightProducts[nums.Length - 1] = 1;

        int i = 1, j = nums.Length - 2;

        while (i < nums.Length && j >= 0)
        {
            leftProducts[i] = leftProducts[i - 1] * nums[i - 1];
            rightProducts[j] = rightProducts[j + 1] * nums[j + 1];
            i++;
            j--;
        }

        i = 0;
        int[] result = new int[nums.Length];
        while (i < nums.Length)
        {
            result[i] = leftProducts[i] * rightProducts[i];
            i++;
        }

        return result;
    }
    
    /// <summary>
    /// Instead of using two new arrays, use the resultant array to first compute left products
    /// for each element
    /// Iterate through the array again with a 1 initialized "right" and compute right product and
    /// the result on the fly
    /// </summary>
    public int[] ProductExceptSelf_SpaceComplexityImp(int[] nums)
    {
        int[] result = new int[nums.Length];

        result[0] = 1;
        int i = 1;
        while (i < nums.Length)
        {
            result[i] = result[i - 1] * nums[i - 1];
            i++;
        }

        int right = 1;
        i = nums.Length - 1;
        
        while (i >= 0)
        {
            result[i] *= right;
            right *= nums[i];
            i--;
        }

        return result;
    }
}