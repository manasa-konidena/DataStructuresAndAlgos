using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MoveZeroes
{
    [Test]
    public void Test_MoveZeroes()
    {
        CollectionAssert.AreEquivalent(new int[2]{1, 2}, MoveZeroesInArray(new int[1]{1}));
    }

    private int[] MoveZeroesInArray(int[] nums)
    {
        return new int[2] {1, 2};
    }

}