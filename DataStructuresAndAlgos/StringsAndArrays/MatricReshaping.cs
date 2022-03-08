using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MatricReshaping
{
    [Test]
    public void Test_MatricReshape()
    {

        var inputMat = new int[2][];
        inputMat[0] = new int[2] {1, 2};
        inputMat[1] = new int[2] {3, 4};
        var output = MatrixReshape(inputMat, 4, 1);
        
        Assert.IsTrue(true);
        
    }

    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {

        if (mat.Length == 0) return mat;
        if (mat.Length * mat[0].Length != r * c) return mat;
        
        var result = new int[r][];
        int k = 0;
        while (k < r)
        {
            result[k] = new int[c];
            k++;
        }
        
        int p = 0, q = 0;
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                result[p][q] = mat[i][j];
                q++;
                if (q == c)
                {
                    q = 0;
                    p++;
                }

            }
        }

        return result;
    }
}