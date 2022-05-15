using NUnit.Framework;

namespace DataStructuresAndAlgos.StringsAndArrays;

public class BreakPalindromeAndReturn
{
    [Test]
    public void Test_BreakPalindrome()
    {
        var result = BreakPalindrome("abccba");
    }
    
    public string BreakPalindrome(string palindrome) {
        if(palindrome.Length == 1) return "";
        var palindromeChars = palindrome.ToCharArray();
        
        for(int i = 0; i < palindrome.Length/2; i++)
        {
            if(palindromeChars[i] != 'a') 
            {
                palindromeChars[i] = 'a';
                return new string(palindromeChars);
            }
        }
        
        palindromeChars[palindrome.Length - 1] = 'b';
        
        return new string(palindromeChars);
    }
}