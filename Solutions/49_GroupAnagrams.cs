/*(Medium)
Given an array of strings, group anagrams together.

Example:

Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
Output:
[
  ["ate","eat","tea"],
  ["nat","tan"],
  ["bat"]
]
Note:

All inputs will be in lowercase.
The order of your output does not matter.
*/

public class Solution {
    public string HashKey(string value)
    {
        Hashtable hashtable = new Hashtable();
        for(int i = 0; i < value.Length; i++)
        {
            if(hashtable.ContainsKey(value[i]))
            {
                hashtable[value[i]] = (int)hashtable[value[i]] + 1;
            }
            else
            {
                hashtable.Add(value[i], 1);
            }
        }

        ArrayList tableKeys = new ArrayList(hashtable.Keys);
        tableKeys.Sort();
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < tableKeys.Count; i++)
        {
            string s = string.Format("{0}{1}", tableKeys[i], (int)hashtable[tableKeys[i]]);
            stringBuilder.Append(s);
        }

        return stringBuilder.ToString();
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IList<IList<string>> resList = new List<IList<string>>();
        Hashtable hashTable = new Hashtable();
        int groupIdx = 0;

        for(int i = 0; i < strs.Length; i++)
        {
            string key = HashKey(strs[i]);
            if(hashTable.Contains(key))
            {
                int idx = (int)hashTable[key];
                resList[idx].Add(strs[i]);
            }
            else
            {
                IList<string> groupList = new List<string>();
                groupList.Add(strs[i]);
                resList.Add(groupList);
                hashTable.Add(key, groupIdx);
                groupIdx++;
            }
        }

        return resList;
    }
}

// 568  ms,  7.82 %
// 38.7 MB,  60.09%
