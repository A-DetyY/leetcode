/*(Hard)
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

You may assume nums1 and nums2 cannot be both empty.
*/

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        double ret;

        if (nums1.Length == 0)
        {
            if (nums2.Length % 2 == 1)
            {
                ret = nums2[(int)(nums2.Length / 2)];
            }
            else
            {
                ret = (nums2[(int)(nums2.Length / 2) - 1] + nums2[(int)(nums2.Length / 2)]) / 2.0;
            }
            return ret;
        }
        if (nums2.Length == 0)
        {
            if (nums1.Length % 2 == 1)
            {
                ret = nums1[(int)(nums1.Length / 2)];
            }
            else
            {
                ret = (nums1[(int)(nums1.Length / 2) - 1] + nums1[(int)(nums1.Length / 2)]) / 2.0;
            }
            return ret;
        }

        if(nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length, n = nums2.Length;
        int imin = 0, imax = m;
        int i = 0, j = 0;
        double max_left = 0, min_right = 0;

        while(imin <= imax)
        {
            i = (int)((imin + imax) / 2);
            j = (int)((m + n + 1) / 2) - i;

            if(i<m && j>0 && nums1[i] < nums2[j - 1])
            {
                imin = i + 1;
            }
            else if(i>0 && j<n && nums1[i - 1] > nums2[j])
            {
                imax = i - 1;
            }
            else
            {
                if (i == 0)
                {
                    max_left = nums2[j - 1];
                }
                else if (j == 0)
                {
                    max_left = nums1[i - 1];
                }
                else
                {
                    max_left = nums1[i - 1] > nums2[j - 1] ? nums1[i - 1] : nums2[j - 1];
                }
                break;
            }
        }

        if((m+n)%2 == 1)
        {
            return max_left;
        }

        if (i == m)
        {
            min_right = nums2[j];
        }
        else if (j == n)
        {
            min_right = nums1[i];
        }
        else
        {
            min_right = nums1[i] < nums2[j] ? nums1[i] : nums2[j];
        }
        return (max_left + min_right) / 2.0;
    }
}

// 128  ms,  53.60%
// 27.6 MB,  95.13%
