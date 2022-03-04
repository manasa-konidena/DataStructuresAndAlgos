using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MergeTwoSortedArraysInPlace
{
    [Test]
    public void Test_MergeSortedArraysInPlace()
    {
        // TODO: add legit test cases
        Assert.IsTrue(true);
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n) 
    {
        
        int i = m-1;
        int j = n-1;
        int k = m+n-1;
        
        while(i >= 0 && j >= 0)
        {
            if(nums1[i] < nums2[j])
            {
                nums1[k] = nums2[j];
                j--;
                k--;
            }
            else
            {
                nums1[k] = nums1[i];
                i--;
                k--; 
            }
        }
        
        while(i >= 0)
        {
            nums1[k] = nums1[i];
            i--;
            k--;
        }
        
        while(j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }
    }
}