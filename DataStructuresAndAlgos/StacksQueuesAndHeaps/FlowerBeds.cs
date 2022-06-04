namespace DataStructuresAndAlgos.StacksQueuesAndHeaps;

public class FlowerBeds
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int count = 0;
        

        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                bool emptyLeft = i == 0 || flowerbed[i - 1] == 0;
                bool emptyRight = i == flowerbed.Length - 1 || flowerbed[i + 1] == 0;

                if (emptyLeft && emptyRight)
                {
                    flowerbed[i] = 1;
                    count++;
                    if (count >= n) return true;
                }
            }
        }

        return count >= n;

    }
}