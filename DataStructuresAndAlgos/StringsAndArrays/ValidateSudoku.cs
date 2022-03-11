using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ValidateSudoku
{
    [Test]
    public void Test_ValidSudoku()
    {
        var input = new char[][]{new char[]{'5','3','.','.','7','.','.','.','.'}
            ,new char[]{'6','.','.','1','9','5','.','.','.'}
            ,new char[]{'.','9','8','.','.','.','.','6','.'}
            ,new char[]{'8','.','.','.','6','.','.','.','3'}
            ,new char[]{'4','.','.','8','.','3','.','.','1'}
            ,new char[]{'7','.','.','.','2','.','.','.','6'}
            ,new char[]{'.','6','.','.','.','.','2','8','.'}
            ,new char[]{'.','.','.','4','1','9','.','.','5'}
            ,new char[]{'.','.','.','.','8','.','.','7','9'}};
        
        Assert.IsTrue(IsValidSudoku(input));
        Assert.IsTrue(IsValidSudokuUsingArrays(input));
    }



    public bool IsValidSudoku(char[][] board)
    {
        HashSet<char>[] storeForRows = new HashSet<char>[board.Length];
        HashSet<char>[] storeForColumns = new HashSet<char>[board.Length];
        HashSet<char>[] storeForBoxes = new HashSet<char>[board.Length];

        for (int i = 0; i < board.Length; i++)
        {
            storeForRows[i] = new HashSet<char>();
            storeForColumns[i] = new HashSet<char>();
            storeForBoxes[i] = new HashSet<char>();
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if(board[i][j].Equals('.')) continue;
                if (!storeForRows[i].Add(board[i][j])) return false;
                if (!storeForColumns[j].Add(board[i][j])) return false;
                var boxIndex = (i / 3) * 3 + j / 3;
                
                if (!storeForBoxes[boxIndex].Add(board[i][j])) return false;
            }   
        }


        return true;
    }
    
    // Faster
    public bool IsValidSudokuUsingArrays(char[][] board)
    {
        int[][] storeForRows = new int[board.Length][];
        int[][] storeForColumns = new int[board.Length][];
        int[][] storeForBoxes = new int[board.Length][];

        for (int i = 0; i < board.Length; i++)
        {
            storeForRows[i] = new int[board.Length];
            storeForColumns[i] = new int[board.Length];
            storeForBoxes[i] = new int[board.Length];
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if(board[i][j].Equals('.')) continue;
                if (!Int32.TryParse(board[i][j].ToString(), out var num))
                {
                    return false;
                }

                if (storeForRows[i][num - 1] == 1) return false;
                storeForRows[i][num - 1] = 1;
                
                if (storeForColumns[j][num - 1] == 1) return false;
                storeForColumns[j][num - 1] = 1;

                var boxIndex = (i / 3) * 3 + j / 3;
                
                if (storeForBoxes[boxIndex][num - 1] == 1) return false;
                storeForBoxes[boxIndex][num - 1] = 1;
                
            }   
        }


        return true;
    }
}