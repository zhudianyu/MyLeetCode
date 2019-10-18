using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{//
    //dynamic programming 
    class DP
    {
        /*
         
             假如有一排房子，共 n 个，每个房子可以被粉刷成红色、蓝色或者绿色这三种颜色中的一种，你需要粉刷所有的房子并且使其相邻的两个房子颜色不能相同。

当然，因为市场上不同颜色油漆的价格不同，所以房子粉刷成不同颜色的花费成本也是不同的。每个房子粉刷成不同颜色的花费是以一个 n x 3 的矩阵来表示的。

例如，costs[0][0] 表示第 0 号房子粉刷成红色的成本花费；costs[1][2] 表示第 1 号房子粉刷成绿色的花费，以此类推。请你计算出粉刷完所有房子最少的花费成本。

注意：

所有花费均为正整数。

示例：

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/paint-house
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
             */
        //记录设油漆前i栋房子并且房子i-1是红色、蓝色、绿色的最小花费分别为f[i][0],   f[i][1], f[i][2]
        public static int MinCost(int[][] costs)
        {
            int m = costs.Length;
            if (m == 0)
            {
                return 0;
            }
            int n = costs[0].Length;
            int[,] f = new int[m + 1, 3];
            f[0, 0] = f[0, 1] = f[0, 2] = 0;
            for (int i = 1; i <= m; i++)
            {

                f[i, 0] = Math.Min(f[i - 1, 1], f[i - 1, 2]) + costs[i - 1][0];
                f[i, 1] = Math.Min(f[i - 1, 0], f[i - 1, 2]) + costs[i - 1][1];
                f[i, 2] = Math.Min(f[i - 1, 1], f[i - 1, 0]) + costs[i - 1][2];

            }
            int minCost = Math.Min(f[m, 0], f[m, 1]);
            minCost = Math.Min(f[m, 2], minCost);
            return minCost;

        }


        public static int NumDecodings(string s)
        {
            char[] strArray = s.ToCharArray();
            int[] f = new int[strArray.Length+1];
            if (strArray.Length == 0)
            {
                return 0;
            }
            f[0] = 1;
            for (int i = 1;i<=strArray.Length;i++)
            {
              //  f[i] = 0;
                int t = strArray[i - 1] - '0';
                if(t>=1&&t<=9)
                {
                    f[i] += f[i - 1];
                }
                if(i >= 2)
                {
                    t = (strArray[i - 2] - '0') * 10 + (strArray[i - 1] - '0');
                    if(t>=10&&t<=26)
                    {
                        f[i] += f[i - 2];
                    }
                }
               
            }
            return f[strArray.Length];
        }

        /*
         
            假如有一排房子，共 n 个，每个房子可以被粉刷成 k 种颜色中的一种，你需要粉刷所有的房子并且使其相邻的两个房子颜色不能相同。

当然，因为市场上不同颜色油漆的价格不同，所以房子粉刷成不同颜色的花费成本也是不同的。每个房子粉刷成不同颜色的花费是以一个 n x k 的矩阵来表示的。

例如，costs[0][0] 表示第 0 号房子粉刷成 0 号颜色的成本花费；costs[1][2] 表示第 1 号房子粉刷成 2 号颜色的成本花费，以此类推。请你计算出粉刷完所有房子最少的花费成本。

注意：

所有花费均为正整数。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/paint-house-ii
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
             */
        public static int MinCostII(int[][] costs)
        {
            if(costs == null || costs.Length == 0)
            {
                return 0;
            }
            int n = costs.Length;
            int k = costs[0].Length;
            //f 表示n个房子的最小花费 因为是n个房子 所以我们申请n+1的长度，第0个房子不存在 n-1 
            //假设f的长度为i 那么i-1表示第n个房子
            int[,] f = new int[n + 1, k];
            for(int i = 0;i<k;i++)
            {
                f[0, i] = 0;
            }
     
            for(int i = 1;i<n+1;i++)
            {
                for(int j = 0;j<k;j++)
                {
                    f[i, j] = costs[i - 1][ j];
                    int temp = int.MaxValue;
                    for (int c = 0;c<k;c++)
                    {
                        if(c != j)
                        {
                            f[i, j] =Math.Min(temp, f[i - 1, c] + costs[i - 1][j]);
                            temp = f[i, j];
                        }

                    }
                }
            }
            int res = int.MaxValue;
            for(int i = 0;i<k;i++)
            {
                res = Math.Min(f[n, i], res);
            }
            return res;
        }
    }
}
