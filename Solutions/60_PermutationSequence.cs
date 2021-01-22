/*(Hard)
The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.
*/

public class Solution {
    public String GetPermutation(int n, int k)
    {
        int[] factorial = new int[n];
        factorial[0] = 1;
        for (int i = 1; i < n; i++)
            factorial[i] = factorial[i - 1] * i;
        --k;
        StringBuilder ans = new StringBuilder();
        int[] valid = new int[n + 1];
        for (int i = 0; i <= n; i++)
            valid[i] = 1;

        for (int i = 1; i <= n; i++)
        {
            int order = k / factorial[n - i] + 1;
            for (int j = 1; j <= n; j++)
            {
                order -= valid[j];
                if (order == 0)
                {
                    ans.Append(j);
                    valid[j] = 0;
                    break;
                }
            }

            k %= factorial[n - i];
        }

        return ans.ToString();
    }
}

// 100 ms,  31.43%
// 22.7MB,  77.14%
