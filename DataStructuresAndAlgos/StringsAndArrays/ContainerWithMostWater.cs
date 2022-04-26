using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ContainerWithMostWater
{
    [Test]
    public void Test_Container()
    {
        var input = new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
        var result = 49;

        
        var input2 = new int[] {1, 2,4,3};
        var result2 = 4;

        Assert.That(result, Is.EqualTo(ContainerMaxVol(input)));
        Assert.That(result2, Is.EqualTo(ContainerMaxVol(input2)));
    }

    
    /// <summary>
    /// two pointers at both ends
    /// At every point, move the smaller height inward as that has the most opportunity to increment volume
    /// keep a maximum by calculating volume at the current stage
    /// return at the end
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    
    private int ContainerMaxVol(int[] height)
    {
        int i = 0, j = height.Length - 1;
        var maxVolume = 0;

        while (i < j)
        {
            maxVolume = Math.Max(maxVolume, GetVolume(i, j, height));
            if (height[j] < height[i]) j--;
            else i++;
        }

        return maxVolume;
    }

    private int GetVolume(int i, int j, int[] height)
    {
        return Math.Min(height[i], height[j]) * (j - i);
    }

}