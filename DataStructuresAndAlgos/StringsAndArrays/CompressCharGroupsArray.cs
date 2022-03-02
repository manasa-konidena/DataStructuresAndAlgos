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
        int slow = 0, fast = 0, curCharCount = 0;

        while (fast < chars.Length)
        {
            if (chars[slow] == chars[fast])
            {
                curCharCount++;
                fast++;
            }
            else
            {
                if (curCharCount == 1)
                {
                    slow++;
                }
                else
                {
                    var curCountString = curCharCount.ToString();
                    int i = 0;
                    while (i < curCountString.Length)
                    {
                        slow++;
                        chars[slow] = curCountString[i];
                        i++;
                    }

                    slow++;
                    chars[slow] = chars[fast];
                }

                curCharCount = 0;
            }
        }

        if (curCharCount == 1)
        {
            return slow + 1;
        }
        
        if (curCharCount != 0)
        {
            var curCountString = curCharCount.ToString();
            int i = 0;
            while (i < curCountString.Length)
            {
                slow++;
                chars[slow] = curCountString[i];
                i++;
            }
        }

        return slow + 1;
    }
}