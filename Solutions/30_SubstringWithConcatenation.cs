/*(Hard)
You are given a string s and an array of strings words of the same length. 
Return all starting indices of substring(s) in s that is a concatenation of each word in words 
exactly once, in any order, and without any intervening characters.

You can return the answer in any order.

 

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]
Output: [0,9]
Explanation: Substrings starting at index 0 and 9 are "barfoo" and "foobar" respectively.
The output order does not matter, returning [9,0] is fine too.
Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
Output: []
Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
Output: [6,9,12]
 

Constraints:

1 <= s.length <= 104
s consists of lower-case English letters.
1 <= words.length <= 5000
1 <= words[i].length <= 30
words[i] consists of lower-case English letters.
*/

public class Solution {
    public IList<int> FindSubstring(string s, string[] words) 
    {
        IList<int> resList = new List<int>();
        int wordNum = words.Length;
        if (wordNum == 0)
            return resList;

        int wordLen = words[0].Length;
        Dictionary<string, int> allWords = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (allWords.ContainsKey(word))
                allWords[word] = allWords[word] + 1;
            else
                allWords[word] = 1;
        }
        
        // 将索引移动分成wordLen类情况
        for (int j = 0; j < wordLen; j++)
        {
            Dictionary<string, int> hasWords = new Dictionary<string, int>();
            int num = 0;	// 记录当前hasWords中有多少个单词，每次移动一个单词长度
            for (int i = j; i < s.Length - wordNum * wordLen + 1; i = i + wordLen)
            {
                bool hasRemoved = false;	// 防止情况三移除后，情况一继续移除
                while (num < wordNum)
                {
                    string word = s.Substring(i + num * wordLen, wordLen);
                    if (allWords.ContainsKey(word))
                    {
                        int value = 0;
                        if (hasWords.ContainsKey(word))
                            value = hasWords[word];
                        hasWords[word] = value + 1;
                        // 出现情况三，遇到符合的单词，但是次数超了
                        if (hasWords[word] > allWords[word])
                        {
                            hasRemoved = true;
                            int removeNum = 0;
                            // 一直移除单词，知道次数符合了
                            while (hasWords[word] > allWords[word])
                            {
                                string firstWord = s.Substring(i + removeNum * wordLen, wordLen);
                                int v = hasWords[firstWord];
                                hasWords[firstWord] = hasWords[firstWord] - 1;
                                removeNum++;
                            }

                            num = num - removeNum + 1;	// 加1是因为外面把当前单词加入到HashMap2中
                            i = i + (removeNum - 1) * wordLen;
                            break;
                        }
                    }
                    else
                    {
                        // 出现情况二，遇到不匹配的单词，直接将i移动到该单词的右边（但其实这里只是移动到了出现问题单词的地方，
                        // 因为最外层有for循环，i还会移动一个单词然后刚好移动到了单词后边）
                        hasWords.Clear();
                        i = i + num * wordLen;
                        num = 0;
                        break;
                    }

                    num++;
                }

                if (num == wordNum)
                {
                    resList.Add(i);
                }
                // 出现情况一，字串完全匹配，我们将上一个字串的第一个单词从HashMap2中移除
                if (num > 0 && !hasRemoved)
                {
                    string firstWord = s.Substring(i, wordLen);
                    int v = hasWords[firstWord];
                    hasWords[firstWord] = v - 1;
                    num = num - 1;
                }
            }
        }

        return resList;
    }
}

// 260 ms,  99.16%
// 33.9MB,  10.08%
