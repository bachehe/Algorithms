using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class SlidingWindow
    {
        public static int MaxProfit(int[] prices)
        {
            int res = 0, profit = 0, buy = 0;
            int sell = 1;

            while (sell < prices.Length)
            {
                profit = prices[sell] - prices[buy];
                if (profit <= 0)
                    buy = sell;
                else
                {
                    if (profit > res) res = profit;
                }

                sell++;
            }
            Console.WriteLine(res);
            return res;
        }
    }
}
