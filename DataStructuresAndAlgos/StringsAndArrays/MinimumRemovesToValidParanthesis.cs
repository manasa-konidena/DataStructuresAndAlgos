using System.Text;
using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class MinimumRemovesToValidParanthesis
{
    [Test]
    public void Test_RemovesToValidParanthesis()
    {
        var input = "lee(t(c)o)de)";
        var output = "lee(t(c)o)de";
        
        Assert.That(RemoveToValidParanthesis(input), Is.EqualTo(output));
    }

    private string RemoveToValidParanthesis(string s)
    {
        HashSet<int> removeIndices = new HashSet<int>();
        HashSet<char> lefts = new HashSet<char> {'{', '(', '['};
        HashSet<char> rights = new HashSet<char> {'}', ')', ']'};
        Dictionary<char, char> mapParanthesis = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['},
        };
        
        Stack<(char, int)> stack = new Stack<(char, int)>();

        for (int i = 0; i < s.Length; i++)
        {
            if(lefts.Contains(s[i])) stack.Push((s[i], i));
            else if(rights.Contains(s[i]))
            {
                if (stack.Count <= 0) 
                {
                    removeIndices.Add(i);
                    continue;
                }
                
                var topMost = stack.Peek();
                if (mapParanthesis[s[i]] == topMost.Item1) stack.Pop();
                else removeIndices.Add(i);
            }
        }

        while (stack.Count != 0)
        {
            removeIndices.Add(stack.Pop().Item2);
        }

        var outputStr = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (!removeIndices.Contains(i)) outputStr.Append(s[i]);
        }

        return outputStr.ToString();
    }
}