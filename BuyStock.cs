//*************************************************************************
//	创建日期:	2019/8/19 13:53:02
//	文件名称:	BuyStock
//  创 建 人:   zhudianyu	
//  Email   :   1462415060@qq.com
//	版权所有:	obexx
//	说    明:	
//*************************************************************************
using System;
using System.Collections.Generic;
using System.Text;


namespace Algorithm
{
    class BuyStock
    {
        public int MaxProfit(int[] prices)
        {
            if(prices == null||prices.Length == 0)
            {
                return 0;
            }
            int len = prices.Length;
            int minPrice = int.MaxValue;
            int maxPro = 0;
            for(int i = 1;i<len;i++)
            {
              
                if(minPrice > prices[i-1])
                {
                    minPrice = prices[i - 1];
                }
                if(maxPro < prices[i] - minPrice)
                {
                    maxPro = prices[i] - minPrice;
                }
                
            }
            return maxPro;
        }

        public int MaxProfit2(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }
            int len = prices.Length;
            int maxPro = 0;
            for (int i = 1; i < len; i++)
            {

                if(prices[i] > prices[i - 1])
                {
                    maxPro += prices[i] - prices[i - 1];
                }

            }
            return maxPro;
        }



    }
}
