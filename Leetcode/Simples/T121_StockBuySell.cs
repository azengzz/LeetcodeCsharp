using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T121_StockBuySell
    {
        public T121_StockBuySell()
        {
        }

        //T121 一个数组表示一段时间内股票每日价格，问在这段时间内完成一次交易（买入卖出）能得到的最大利润
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;

            int minIdex = 0;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < prices[minIdex])
                {
                    minIdex = i;
                }
                else if (prices[i] - prices[minIdex] > maxProfit)
                {
                    maxProfit = prices[i] - prices[minIdex];
                }
            }
            return maxProfit;
        }

        //T122 一个数组表示一段时间内股票每日价格，问在这段时间内完成多次交易（买入卖出）能得到的最大利润
        //注意必须先卖出后才能买入
        public int MaxProfit_MultipleTransactions(int[] prices)
        {
            //把每日股票价格画成折线图。则多次交易的最大利润是折线图上所有斜率为正的线段的和s
            if (prices == null) return 0;

            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] - prices[i - 1] > 0)
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }
    }
}
