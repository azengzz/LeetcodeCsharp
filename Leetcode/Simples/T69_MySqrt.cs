using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    /*
     * Implement int sqrt(int x).
     * Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
     * Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
     * 
     * Example 1:
     * Input: 4
     * Output: 2
     * 
     * Example 2:
     * Input: 8
     * Output: 2
     * Explanation: The square root of 8 is 2.82842..., and since 
     * the decimal part is truncated, 2 is returned.
     */

    public class T69_MySqrt
    {
        public T69_MySqrt()
        {
        }

        public int MySqrt(int x)  //!要考虑数字太大时溢出的问题！
        {
            if (x < 2) return x;

            int left = 0, right = x;
            int middle = 0;

            while (left != right )
            {
                middle = (left + right) / 2;
                if (middle > x / middle)    //直接middle * middle可能会溢出
                {
                    right = middle;
                }
                else if (middle < x / middle)
                {
                    left = middle;
                }
                else break;

                if ((left + 1 == right) && (left < x / left) && (right > x / right))
                {
                    middle = left;
                    left = right;
                    break;
                }
            } 

            return middle;
        }
    }
}
