using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class ThreeSumReturnTriplets
{
    [Test]
    public void Test_ThreeSumToZero()
    {
        var input = new int[] {-1, 0, 1, 2, -1, -4};
        var result = new List<List<int>> {new List<int>(){-1, -1, 2}, new List<int>(){-1, 0, 1}};

        var resultWithOne = ThreeSum(input);
        var resultWithNew = ThreeSumUsingTwoSum(input);

        var input2 = new int[] {1, 2, -2, -1};
        var resultWithOne2 = ThreeSum(input2);
        var resultWithNew2 = ThreeSumUsingTwoSum(input2);
    }
    
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        HashSet<IList<int>> resultSet = new HashSet<IList<int>>(new CustomListComparer());
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) break;
            if(i > 0 && nums[i] == nums[i - 1]) continue;
            
            int j = i + 1;
            int k = nums.Length - 1;

            if (j > nums.Length - 1) break;

            var target = 0 - nums[i];

            while (j < nums.Length - 1 && k > i)
            {
                if (j == k) break;
                
                if (nums[j] + nums[k] == target)
                {
                    if (!resultSet.Contains(new List<int>() {nums[i], nums[j], nums[k]}))
                    {
                        resultSet.Add(new List<int>(){ nums[i], nums[j], nums[k]});
                    }
                    j++;
                    k--;
                }
                
                else if (nums[j] + nums[k] > target) k--;
                else j++;
            }
        }

        return resultSet.ToList();

    }

    private IList<IList<int>> ThreeSumUsingTwoSum(int[] nums)
    {
        Array.Sort(nums);
        
        HashSet<IList<int>> resultSet = new HashSet<IList<int>>(new CustomListComparer());
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) break;
            if(i > 0 && nums[i] == nums[i - 1]) continue;

            var target = 0 - nums[i];
            var twoSumRes = TwoSum(nums, i+1, target);

            foreach (var res in twoSumRes)
            {
                resultSet.Add(new List<int> {nums[i], res[0], res[1]});
            }
        }

        return resultSet.ToList();

    }
    
    private List<List<int>> TwoSum(int[] numbers, int start, int target)
    {

        var result = new List<List<int>>();
        var end = numbers.Length - 1;

        while (start < end)
        {
            if (numbers[start] + numbers[end] < target)
            {
                start++;
            }
            else if (numbers[start] + numbers[end] > target)
            {
                end--;
            }
            else
            {
                result.Add(new List<int>(){numbers[start] , numbers[end]});
                start++;
                end--;
            }
        }

        return result;

    }


    public class CustomListComparer : IEqualityComparer<IList<int>>
    {
        public bool Equals(IList<int> throuple1, IList<int> throuple2)
        {
            var x = throuple1.OrderBy(i => i);
            var y = throuple2.OrderBy(i => i);
            return Enumerable.SequenceEqual(x, y);
        }

        public int GetHashCode(IList<int> throuple)
        {
            string code = String.Join(",", throuple.OrderBy(i => i));
            return code.GetHashCode();
        }
    }

}