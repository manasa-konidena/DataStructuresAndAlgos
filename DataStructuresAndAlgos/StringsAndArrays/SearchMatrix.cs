using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class SearchMatrix
{
    [Test]
    public void Test_SearchMatrix()
    {
        var array = new int[] {3, 6, 7, 9, 10, 12};
        var array2 = new int[] {3, 6, 7, 9, 10, 12, 13};
        var array3 = new int[] {3, 6};
        
        Assert.That(BinarySearchInArray(0, 5, array, 6), Is.EqualTo(1));
        Assert.That(BinarySearchInArray(0, 6, array2, 6), Is.EqualTo(1));
        Assert.That(BinarySearchInArray(0, 1, array3, 6), Is.EqualTo(1));
        
        Assert.That(BinarySearchInArray(0, 5, array, 5), Is.EqualTo(-1));
        Assert.That(BinarySearchInArray(0, 6, array2, 11), Is.EqualTo(-1));
        Assert.That(BinarySearchInArray(0, 1, array3, 4), Is.EqualTo(-1));
        
    }
    
    public bool SearchMatrixForNumber(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        if (matrix[rows - 1][cols - 1] < target) return false;
        if (matrix[0][0] > target) return false;
        
        // Binary search for the row and then binary search in the row
        var row = SearchForArray(0, rows - 1, matrix, target);

        if (row == -1) return false;

        var elementInRow = BinarySearchInArray(0, cols - 1, matrix[row], target);

        if (elementInRow == -1) return false;

        return true;

    }

    private int SearchForArray(int begin, int end, int[][] matrix, int target)
    {
        
        if (begin == end)
        {
            if (matrix[begin][matrix[0].Length - 1] >= target && matrix[begin][0] <= target) return begin;
            return -1;
        }

        var left = SearchForArray(begin, begin + (end - begin) / 2, matrix, target);
        var right = SearchForArray(begin + (end - begin) / 2 + 1, end, matrix, target);
        return left >= 0 ? left : right;
    }

    private int BinarySearchInArray(int begin, int end, int[] rowArray, int target)
    {
    {
        if (begin == end)
        {
            return rowArray[begin] == target ?  begin : -1;
        }

        if (target > rowArray[end]) return -1;
        if (target < rowArray[begin]) return -1;

        var left = BinarySearchInArray(begin, begin + (end - begin) / 2, rowArray, target);
        var right = BinarySearchInArray(begin + (end - begin) / 2 + 1, end , rowArray, target);

        return left >= 0 ? left : right;

    }

}