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
    }
}
