using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T168_SomeMathProblems
    {
        public T168_SomeMathProblems()
        {
        }

        #region T168 给定一个正整数，返回它在EXCEL表中对应的列名称
        public string ConvertToTitle(int n)
        {            
            string result = "";
            while (n > 0)
            {
                int remainder = n % 26;
                if (remainder == 0)    //余数为0，则商表示有几个26。每个26用Z表示。
                {
                    result = "Z" + result;
                    n = n / 26 - 1;    //减1是因为已经用一个Z表示1个26了。
                }
                else
                {
                    result = ((char)(remainder + 'A' - 1)).ToString() + result;
                    n = n / 26;
                }
            }
            return result;
        }
        #endregion

        #region T169 求一个数组中的众数并返回它。众数是指数值中出现次数大于(n/2)的数。假设所有测试用例的数组都含有众数。
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                }
                else
                {
                    dict[nums[i]]++;
                }
            }

            //如果数组成员个数是偶数，而且只有两种值，而且两种值个数一样多，则
            //数组最后一个成员先不看，比较在它之前哪个值个数比较多
            if (dict.Count == 2)
            {
                int[] keys = dict.Keys.ToArray<int>();
                if (dict[keys[0]] == dict[keys[1]])
                {
                    dict[nums[nums.Length - 1]] -= 1;
                }
            }

            int majority = nums.Length % 2 == 0 ? nums.Length / 2 : (nums.Length + 1) / 2;
            var result = from d in dict where d.Value >= majority select d.Key;
            return result.ToList<int>()[0];

        }
        #endregion

        #region T171 给定一个EXCEL表格中的列名称，返回其对应的列序号

        public int TitleToNumber(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result += (s[s.Length - 1 - i] - 'A' + 1) * (int)Math.Pow(26, i);
            }
            return result;
        }

        #endregion

        #region T172 给定一个整数n，返回n!结果尾数中零的数量

        //此种方法遇到数字一大就不准，数字大还有栈溢出风险------------------------
        //public int TrailingZeroes(int n)
        //{
        //    int count = 0;
        //    Calculate(n, 1, ref count);
        //    return count;
        //}

        //private int Calculate(int start, int end, ref int count)
        //{
        //    if (start == end)
        //    {
        //        return start;
        //    }

        //    int left = Calculate(start, (start + end) / 2 + 1, ref count);
        //    int right = Calculate((start + end) / 2, end, ref count);

        //    int result = left * right;
        //    while (result % 10 == 0)
        //    {
        //        result /= 10;
        //        count++;
        //    }

        //    return result % 10;
        //}

        public int TrailingZeroes(int n)
        {
            /*
             * 每个为整十的结果，都是由若干个2乘以若干个5组成。求出在n个数中有多少个数可以用
             * 5、5的平方、5的立方……表示，则有多少个0
             */
            int quo = 0;   //商数
            int index = 1;  //指数
            int count = 0;
            do
            {                
                quo = n / (int)Math.Pow(5, index);
                count += quo;
                index++;
            } while (quo > 0);

            return count;
        }

        #endregion
    }
}
