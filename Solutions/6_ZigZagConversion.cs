/*(Medium)
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
*/

public class Solution {
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        int lowNum = (numRows <= s.Length) ? numRows : s.Length;
        StringBuilder[] resultArray = new StringBuilder[lowNum];
        bool goingDown = false;
        int curRow = 0;

        for (int i = 0; i < lowNum; i++)
        {
            resultArray[i] = new StringBuilder();
        }
        for (int i = 0; i < s.Length; i++)
        {
            resultArray[curRow].Append(s[i]);
            if (curRow == 0 || curRow == lowNum - 1)
            {
                goingDown = !goingDown;
            }
            curRow += goingDown ? 1 : -1;
        }
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < lowNum; i++)
        {
            result.Append(resultArray[i]);
        }

        return result.ToString();
    }
}

// 116 ms,  56.09%
// 26  MB,  99.59%
