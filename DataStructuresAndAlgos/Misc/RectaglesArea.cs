namespace DataStructuresAndAlgos.Misc;

// https://leetcode.com/problems/rectangle-area/
public class RectaglesArea
{
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) {
        
        var firstRectArea = Math.Abs(ax1 - ax2) * Math.Abs(ay2 - ay1);
        var secondRectArea = Math.Abs(bx1 - bx2) * Math.Abs(by2 - by1);
        
        int overlap = 0;
        int left = Math.Max(ax1, bx1);
        int right = Math.Min(ax2, bx2);
        int top = Math.Min(ay2, by2);
        int bottom = Math.Max(ay1, by1);
        
        if(left < right && top > bottom)
        {
            overlap = (right - left) * (top - bottom);
        }
        
        
        return firstRectArea + secondRectArea - overlap;
        
    }
}