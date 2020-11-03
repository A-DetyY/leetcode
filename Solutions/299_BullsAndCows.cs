/*(Medium)
You are playing the Bulls and Cows game with your friend.

You write down a secret number and ask your friend to guess what the number is. 
When your friend makes a guess, you provide a hint with the following info:

The number of "bulls", which are digits in the guess that are in the correct position.
The number of "cows", which are digits in the guess 
that are in your secret number but are located in the wrong position. 
Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.

The hint should be formatted as "xAyB", 
where x is the number of bulls and y is the number of cows. 
Note that both secret and guess may contain duplicate digits.
*/

public class Solution {
    public string GetHint(string secret, string guess) {
        int len = secret.Length;
        int[] AstatusList = new int[len];
        int[] BstatusList = new int[len];
        int ACount = 0, BCount = 0;
        for (int i = 0; i < len; i++)
        {
            if (secret[i] == guess[i])
            {
                ACount++;
                AstatusList[i] = 1;
                BstatusList[i] = 1;
            }
        }

        for (int i = 0; i < len; i++)
        {
            if (AstatusList[i] > 0)
                continue;
            char c = guess[i];
            for (int j = 0; j < len; j++)
            {
                if (BstatusList[j] > 0)
                    continue;
                if (secret[j] == c)
                {
                    BstatusList[j] = 2;
                    BCount++;
                    break;
                }
            }
        }

        return String.Format("{0}A{1}B", ACount, BCount);
    }
}

// 96  ms,  32.77%
// 24.8MB,  12.91%
