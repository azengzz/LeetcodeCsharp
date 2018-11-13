using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T70_ClimbStairs
    {
    /*
        You are climbing a stair case. It takes n steps to reach to the top.
        Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        Note: Given n will be a positive integer.

        Example 1:
        Input: 2
        Output: 2
        Explanation: There are two ways to climb to the top.
        1. 1 step + 1 step
        2. 2 steps

        Example 2:
        Input: 3
        Output: 3
        Explanation: There are three ways to climb to the top.
        1. 1 step + 1 step + 1 step
        2. 1 step + 2 steps
        3. 2 steps + 1 step
    */

        public T70_ClimbStairs()
        {
        }

        public int ClimbStairs(int n)
        {
            if (n < 2) return 1;

            int totalNum = 0;
            int last2 = 1;
            int last1 = 1;
            for (int i = 2; i <= n; i++)
            {
                totalNum = last2 + last1;
                last2 = last1;
                last1 = totalNum;
            }

            return totalNum;
        }
    }
}


/*
    仔细一想，这是一个组合数的问题。如果一个数由N个2和M个1的和组成，则这些2和1有
    C(N+M, N) 种组合。于是，可以列出这个数的所有2和1的组合，分别求出组合数然后求和。
    如：对于数字5，它可以由0个2和5个1组成，或1个2和3个1组成，或2个2和1个1组成。所以组合数之和（从数字2的的角度看）为C(5,0) + C(4,1) + C(3,2) = 8。
    从数字1的角度看结果也一样，为C(5,5) + C(4,3) + C(3,1) = 8。

    直接将这个思路转换为算法有一个问题。当数字比较大（甚至不用很大，40以上就够了）时，组合数计算时用到阶乘会超出int型的范围。

    再观察所有的组合数之和，会发现它们是斐波那契数列。于是题目变成了写斐波那契数列的算法。
 */
