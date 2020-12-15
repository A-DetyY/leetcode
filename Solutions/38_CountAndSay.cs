/*(Easy)
The count-and-say sequence is a sequence of digit strings defined by the recursive formula:
countAndSay(1) = "1"
countAndSay(n) is the way you would "say" the digit string from countAndSay(n-1), 
which is then converted into a different digit string.
To determine how you "say" a digit string, 
split it into the minimal number of groups 
so that each group is a contiguous section all of the same character. 
Then for each group, say the number of characters, then say the character. 
To convert the saying into a digit string, 
replace the counts with a number and concatenate every saying.
Given a positive integer n, return the nth term of the count-and-say sequence.
*/

public class Solution {
    public string CountAndSay(int n)
    {
        int head = 0, tail = 0;
        int count = 0, pos = 0;
        StringBuilder prev = new StringBuilder("1");
        StringBuilder cur = new StringBuilder();
        for (int i = 2; i <= n; i++)
        {
            head = 0;
            for (pos = 0; pos < prev.Length; pos++)
            {
                if (prev[pos] != prev[head])
                {
                    count = pos - head;
                    cur.Append(count);
                    cur.Append(prev[head]);
                    head = pos;
                }
            }
            count = prev.Length - head;
            cur.Append(count);
            cur.Append(prev[prev.Length - 1]);

            prev = cur;
            cur = new StringBuilder();
        }
        return prev.ToString();
    }
}

// 92  ms,  94.88%
// 23.8MB,  62.45%
