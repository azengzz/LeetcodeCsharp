using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T88_MergeSortedArrays
    {
        public T88_MergeSortedArrays()
        { }

        /*
            Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

            Note:
            The number of elements initialized in nums1 and nums2 are m and n respectively.
            You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.

            Example:
            Input:
            nums1 = [1,2,3,0,0,0], m = 3
            nums2 = [2,5,6],       n = 3
            Output: [1,2,2,3,5,6]
         */

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int mergeLength = m + n;
            m -= 1;
            n -= 1;
            while (m >= 0 && n >= 0)    //因为两个数组都已排序，故都从后往前看，把比较得到的较大数放到nums1后边多出来的空间中
            {
                nums1[--mergeLength] = nums1[m] > nums2[n] ? nums1[m--] : nums2[n--];
            }
            if (n >= 0)
            {
                for (int i = 0; i <= n; i++)
                {
                    nums1[i] = nums2[i];
                }
            }
        }
    }
}
