using NUnit.Framework;

namespace DataStructuresAndAlgos.DynamicProgramming;

public class BuyAndSellStock
{
    [Test]
    public void Test_MaxProfit()
    {
        var input = new int[] {7, 1, 5, 3, 6, 4};
        
        Assert.That(MaxProfit(input), Is.EqualTo(5));
    }
    
    /// <summary>
    /// Come up with the dp algorithm
    /// t_i10 - One whole transaction done and 0 stocks in hand on ith day
    /// t_i11 - One transaction and one stock in hand on ith day
    /// t_i10 = Max(t_i-110, t_i-111 + prices[i])
    /// t_i11 = Max(t_i-111, t_i-100 - prices[i])
    /// </summary>
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