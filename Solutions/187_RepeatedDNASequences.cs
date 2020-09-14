/*(Medium)
All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, 
for example: "ACGAATTCCG". When studying DNA, 
it is sometimes useful to identify repeated sequences within the DNA.

Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.

Example:

Input: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"

Output: ["AAAAACCCCC", "CCCCCAAAAA"]
*/

public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        int L = 10, n = s.Length;
        if (n <= L)
        {
            return new List<string>();
        }

        int a = 4, aL = (int) Math.Pow(a, L);
        
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        dictionary.Add('A', 0);
        dictionary.Add('C', 1);
        dictionary.Add('G', 2);
        dictionary.Add('T', 3);
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = dictionary[s[i]];
        }

        int h = 0;
        HashSet<string> output = new HashSet<string>();
        HashSet<int> hashSet = new HashSet<int>();
        for (int i = 0; i < n - L + 1; i++)
        {
            if (i != 0)
            {
                h = h * a - nums[i - 1] * aL + nums[i + L - 1];
            }
            else
            {
                for (int j = 0; j < L; j++)
                {
                    h = h * a + nums[j];
                }
            }

            if (hashSet.Contains(h))
            {
                output.Add(s.Substring(i, L));
            }

            hashSet.Add(h);
        }
        return new List<string>(output);
    }
}

// 316 ms,  32.98%
// 36.3MB,  86.17%
