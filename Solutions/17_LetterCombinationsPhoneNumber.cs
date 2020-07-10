/*(Medium)
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

Example:

Input: "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
Note:

Although the above answer is in lexicographical order, your answer could be in any order you want.
*/

public class Solution {
    public IList<string> combinations = new List<string>();

    public Hashtable digitToLetters = new Hashtable();

    public void AddDigitLetters(StringBuilder curStr, string digits, int curIndex)
    {
        if (curIndex >= digits.Length)
        {
            combinations.Add(curStr.ToString());
            return;
        }

        char[] letters = (char[])digitToLetters[digits[curIndex]];
        for(int i=0; i<letters.Length; i++)
        {
            AddDigitLetters(curStr.Append(letters[i]), digits, curIndex + 1);
            curStr.Remove(curStr.Length - 1, 1);
        }
    }

    public IList<string> LetterCombinations(string digits)
    {
        digitToLetters.Add('2', new char[] { 'a', 'b', 'c' });
        digitToLetters.Add('3', new char[] { 'd', 'e', 'f' });
        digitToLetters.Add('4', new char[] { 'g', 'h', 'i' });
        digitToLetters.Add('5', new char[] { 'j', 'k', 'l' });
        digitToLetters.Add('6', new char[] { 'm', 'n', 'o' });
        digitToLetters.Add('7', new char[] { 'p', 'q', 'r', 's' });
        digitToLetters.Add('8', new char[] { 't', 'u', 'v' });
        digitToLetters.Add('9', new char[] { 'w', 'x', 'y', 'z' });

        if (digits.Length > 0)
        {
            AddDigitLetters(new StringBuilder(), digits, 0);
        }

        return combinations;
    }
}

// 352  ms,  19.35%
// 31.6 MB,  84.52%
