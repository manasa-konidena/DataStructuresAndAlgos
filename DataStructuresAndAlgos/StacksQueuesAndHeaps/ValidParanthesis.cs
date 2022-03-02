using System.Collections;
using NUnit.Framework;

namespace DataStructuresAndAlgos.StacksQueuesAndHeaps;

public class ValidParanthesis
{
    
    [Test]
    public void Test_ValidParanthesis()
    {
        var input = "([{}])";
        Assert.IsTrue(IsValid(input));
        input = "(])}";
        Assert.IsFalse(IsValid(input));
    }
    
    private bool IsValid(string s)
    {

        Stack<char> stackForlefts = new Stack<char>();
        HashSet<char> lefts = new HashSet<char> {'{', '(', '['};
        HashSet<char> rights = new HashSet<char> {'}', ')', ']'};
        Dictionary<char, char> mapParanthesis = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['},
        };


        foreach (var c in s)
        {
            if (lefts.Contains(c)) stackForlefts.Push(c);
            else
            {
                if (stackForlefts.Count == 0) return false;
                var fromStack = stackForlefts.Pop();
                if (fromStack != mapParanthesis[c]) return false;
            }
        }

        return stackForlefts.Count == 0;
    }
}