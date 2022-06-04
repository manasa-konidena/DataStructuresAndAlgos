using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace DataStructuresAndAlgos.Graphs;

public class Minesweeper
{
    [Test]
    public void Test_UpdateBoard()
    {
        var result = UpdateBoardDFS(new char[][]
        {
            new char[] {'E', 'E', 'E', 'E', 'E'}, new char[] {'E', 'E', 'M', 'E', 'E'},
            new char[] {'E', 'E', 'E', 'E', 'E'}, new char[] {'E', 'E', 'E', 'E', 'E'}
        }, new int[] {3, 0});
    }


    /// <summary>
    /// If the val is M, make it X and return
    /// if the val is E, check adjacent mines
    /// if no adjacent mines, add the adjacent cells to the queue to check next
    /// once all is done return board
    /// </summary>
    /// <param name="board"></param>
    /// <param name="click"></param>
    /// <returns></returns>
    public char[][] UpdatedBoardBFS(char[][] board, int[] click) {
        var clickQueue = new Queue<int[]>();
        clickQueue.Enqueue(click);
        

        while(clickQueue.Count != 0)
        {
            var currClick = clickQueue.Dequeue();
            int row = currClick[0];
            int col = currClick[1];
            
            if(board[row][col] == 'M')
            {
                board[row][col] = 'X';
                return board;
            }
            
            if(board[row][col] == 'E')
            {
                int countOfMines = getAdjacentCountOfMinesAndAddClicks(row, col, board);

                if (countOfMines == 0)
                {
                    board[row][col] = 'B';
                    enqueueNext(row, col, clickQueue, board);
                }
                else board[row][col] = countOfMines.ToString()[0];
            }
            
        }
        
        return board;
         
    }

    private void enqueueNext(int row, int col, Queue<int[]> clickQueue, char[][] board)
    {
        int i=0,j=0;
        int currRow = 0, currCol = 0;
        while(i < 3)
        {
            if(i == 0) currRow = row;
            if(i == 1) currRow = row - 1;
            if(i == 2) currRow = row + 1;
            while(j < 3)
            {
                if(j == 0) currCol = col;
                if(j == 1) currCol = col - 1;
                if(j == 2) currCol = col + 1;
                
                if(currRow >= 0 && currCol >= 0 && 
                   currRow < board.Length && currCol < board[0].Length && 
                   !(currRow == row && currCol == col))
                {
                    clickQueue.Enqueue(new int[]{currRow, currCol});
                }
                j++;
            }
            i++;
            j = 0;
        }
    }
    
    private int[,] visited;
    public char[][] UpdateBoardDFS(char[][] board, int[] click)
    {
        visited = new int[board.Length, board[0].Length];
        int row = click[0], col = click[1];
        if (board[row][col] == 'M')
        {
            board[row][col] = 'X';
            return board;
        }

        if (board[row][col] == 'E')
        {
            DFS(row, col, board);
        }

        return board;

    }

    private void DFS(int row, int col, char[][] board)
    {
        if (row >= 0 && col >= 0 &&
            row < board.Length && col < board[0].Length && visited[row, col] != 1)
        {
            visited[row, col] = 1;
            if (board[row][col] == 'E')
            {
                var countOfMines = getAdjacentCountOfMinesAndAddClicks(row, col, board);

                board[row][col] = countOfMines == 0 ? 'B' : countOfMines.ToString()[0];

                if (countOfMines == 0)
                {
                    ExploreAdjacents(row, col, board);
                }
            }
        }
    }

    private void ExploreAdjacents(int row, int col, char[][] board)
    {
        int i=0,j=0;
        int currRow = 0, currCol = 0;
        while(i < 3) 
        {
            if(i == 0) currRow = row;
            if(i == 1) currRow = row - 1;
            if(i == 2) currRow = row + 1;
            while(j < 3)
            {
                if(j == 0) currCol = col;
                if(j == 1) currCol = col - 1;
                if(j == 2) currCol = col + 1;
                
                if(currRow >= 0 && currCol >= 0 && 
                   currRow < board.Length && currCol < board[0].Length && visited[currRow, currCol] != 1)
                {
                    DFS(currRow, currCol, board);
                }
                j++;
            }
            i++;
            j = 0;
        }
    }
    
    
    private int getAdjacentCountOfMinesAndAddClicks(int row, int col, char[][] board)
    {
        int countOfMines = 0;
        int i=0,j=0;
        int currRow = 0, currCol = 0;
        while(i < 3)
        {
            if(i == 0) currRow = row;
            if(i == 1) currRow = row - 1;
            if(i == 2) currRow = row + 1;
            while(j < 3)
            {
                if(j == 0) currCol = col;
                if(j == 1) currCol = col - 1;
                if(j == 2) currCol = col + 1;
                
                if(currRow >= 0 && currCol >= 0 && 
                   currRow < board.Length && currCol < board[0].Length && 
                   !(currRow == row && currCol == col))  
                {
                    if(board[currRow][currCol] == 'M') countOfMines++;
                }
                j++;
            }
            i++;
            j = 0;
        }
        
        return countOfMines;
    }
}