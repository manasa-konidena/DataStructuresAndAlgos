using NUnit.Framework;

namespace DataStructuresAndAlgos.DyanamicProgramming;

public class BuyAndSellStock
{
    [Test]
    public void Test_MaxProfit()
    {
        var input = new int[] {7, 1, 5, 3, 6, 4};
        
        Assert.That(MaxProfit(input), Is.EqualTo(5));
    }
    
    public int MaxProfit(int[] prices)
    {
        var t_i10 = 0;
        var t_i11 = Int32.MinValue;

        foreach (var price in prices)
        {
            t_i10 = Math.Max(t_i10, t_i11 + price);
            t_i11 = Math.Max(t_i11, 0 - price);
        }

        return t_i10;

    }
}