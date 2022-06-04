namespace DataStructuresAndAlgos.Graphs;

public class WallsAndGates
{
    public void FillWallsAndGates(int[][] rooms) {
        var bfsQueue = new Queue<(int, int)>();
        
        
        
        var directions = new int[][]{new int[2]{0, 1}, new int[2]{0, -1}, new int[2]{1, 0}, new int[2]{-1, 0}};
        
        var rows = rooms.Length;
        if(rows == 0) return;
        
        var cols = rooms[0].Length;
        
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(rooms[i][j] == 0) bfsQueue.Enqueue((i, j));
            }
        }
        
        while(bfsQueue.Count != 0)
        {
            var currNode = bfsQueue.Dequeue();
            var currRow = currNode.Item1;
            var currCol = currNode.Item2;
            foreach(var dir in directions)
            {
                var row = currRow + dir[0];
                var col = currCol + dir[1];
                if(row < 0 || col < 0 || row >= rows || col >= cols || rooms[row][col] != Int32.MaxValue)
                {
                    continue;
                }
                
                rooms[row][col] = rooms[currRow][currCol] + 1;
                bfsQueue.Enqueue((row, col));
            }
        }
    }
}