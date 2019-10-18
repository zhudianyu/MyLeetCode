//*************************************************************************
//	创建日期:	2019/8/31 16:45:23
//	文件名称:	BackPack
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
    class BackPack
    {
        public static void TestBackPackOne()
        {
            int[] A = new int[] { 828, 125, 740, 724, 983, 321, 773, 678, 841, 842, 875, 377, 674, 144, 340, 467, 625, 916, 463, 922, 255, 662, 692, 123, 778, 766, 254, 559, 480, 483, 904, 60, 305, 966, 872, 935, 626, 691, 832, 998, 508, 657, 215, 162, 858, 179, 869, 674, 452, 158, 520, 138, 847, 452, 764, 995, 600, 568, 92, 496, 533, 404, 186, 345, 304, 420, 181, 73, 547, 281, 374, 376, 454, 438, 553, 929, 140, 298, 451, 674, 91, 531, 685, 862, 446, 262, 477, 573, 627, 624, 814, 103, 294, 388};
            int num = backPackOne(5000,A);
            Console.WriteLine(num);
        }
        public static void TestBackPackV()
        {
            //             int[] A = new int[] { 828, 125, 740, 724, 983, 321, 773, 678, 841, 842, 875, 377, 674, 144, 340, 467, 625, 916, 463, 922, 255, 662, 692, 123, 778, 766, 254, 559, 480, 483, 904, 60, 305, 966, 872, 935, 626, 691, 832, 998, 508, 657, 215, 162, 858, 179, 869, 674, 452, 158, 520, 138, 847, 452, 764, 995, 600, 568, 92, 496, 533, 404, 186, 345, 304, 420, 181, 73, 547, 281, 374, 376, 454, 438, 553, 929, 140, 298, 451, 674, 91, 531, 685, 862, 446, 262, 477, 573, 627, 624, 814, 103, 294, 388 };
            //             int num = BackPackV(5000, A);
            int[] A = new int[] { 1, 2, 3, 3, 7 };
            int num = BackPackV(7, A);
            Console.WriteLine(num);
        }
        public  static int backPackOne(int m, int[] A)
        {
            int n = A.Length;
            if(n == 0||m == 0)
            {
                return 0;
            }
            // write your code here
            bool[,] f = new bool[n+1, m+1];
            f[0, 0] = true;
            for(int i = 1;i<=m;i++)
            {
                f[0, i] = false;
            }
            int maxNum = 0;
            for(int i = 1;i<=n;i++)
            {
                for(int j = 0;j<=m;j++)
                {
                    if (j>=A[i-1])
                    {
                        f[i, j] = (f[i -1 , j] || f[i - 1, j - A[i - 1]]);
                    }
                    else
                    {
                        f[i, j] = f[i - 1, j];
                    }
                }

            }
            for(int i = 0;i<=m;i++)
            {
                if(f[n,i])
                {
                    maxNum = i;
                }
            }
            return maxNum;
        }
        /*
         • 题意: • 给定N个正整数：A0,A1, …, AN-1 • 一个正整数Target
• 求有多少种组合加起来是Target
• 每个Ai
只能用一次
             
         */
        public static int BackPackV(int m,int[] A)
        {
            //f[i][w] 表示i个物品能组成m的组合
            int n = A.Length;
            if(n == 0)
            {
                return 0;
            }
            int[,] f = new int[n + 1, m+1];
            f[0, 0] = 1;
            for(int i = 1;i<m;i++)
            {
                f[0, i] = 0;
            }
            for(int i = 1;i<=n;i++)
            {
                for(int w = 0;w<=m;w++)
                {
                    if(w>=A[i-1])
                    {
                        f[i, w] = f[i - 1, w - A[i - 1]] + f[i - 1, w];
                    }
                    else
                    {
                        f[i, w] = f[i - 1, w];
                    }
                }
            }

            return f[n,m];
           
        }
    }
}
