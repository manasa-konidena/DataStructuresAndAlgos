using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class CompressCharGroupsArray
{
    [Test]
    public void Test_Compress()
    {
        var input = new char[] {'a', 'a', 'b', 'b', 'c', 'c', 'c'};
        var outputArrayLength = input.Length - 1;

        Assert.That(outputArrayLength, Is.EqualTo(Compress(input)));
    }

    private int Compress(char[] chars)
    {
        int slow = 0,fast = 0, currCount = 0;
        
        while(fast < chars.Length)
        {
            if(chars[slow] == chars[fast])
            {
                fast++;
                currCount++;
            }
            else
            {
                if(currCount > 1)
                {
                    var currCountStr = currCount.ToString();
                    int i = 0;
                    while(i < currCountStr.Length)
                    {
                        slow++;
                        chars[slow] = currCountStr[i];
                        i++;
                    }   
                }
                slow++;
                chars[slow] = chars[fast];
                
                currCount = 0;
            }
        }
        
        if(currCount > 1)
        {
            var currCountStr = currCount.ToString();
            int i = 0;
            while(i < currCountStr.Length)
            {
                slow++;
                chars[slow] = currCountStr[i];
                i++;
            }   
        }
        
        return slow + 1;
    }
}