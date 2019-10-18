using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // BinarySearch.TestBSFindMini();
            //BinarySearch.TestSearchMatrix();
            //BinarySearch.TestFindPeak();
            //  MySort.TestMegreSort();
            // BinaryTree.TestSerialize();
            //Graph.TestSchedule();
            //  SubArray.TestFindUnSortSubArray();
            // LinkList.TestRKList();
            //             SolveNQueen s = new SolveNQueen();
            //             s.SolveNQueens(4);
            // DFS.TestRmoveDuplicates();
            SubSets.TestSubSets();
        }
        static void TestDecodeAlpaha()
        {
            int n = DP.NumDecodings("0");
            Console.WriteLine("string num: " + n);
        }
        static void TestMainCost2()
        {
            int[][] costs = new int[3][]
    {
                new int [3]{ 17,2,17 },
                new int [3]{ 16,16,5 },
               new int [3] { 14, 3, 19 }

    };
            int[][] costs2 = new int[1][]
{
                new int [1]{ 8 },
            

};
            int n = DP.MinCostII(costs);
            Console.WriteLine("mincost2: " + n);
        }
        static void TestMainCost()
        {
            int[][] costs = new int[3][]
    {
                new int [3]{ 17,2,17 },
                new int [3]{ 16,16,5 },
               new int [3] { 14, 3, 19 }
               
    };

            int n = DP.MinCost(costs);
            Console.WriteLine("mincost: " + n);
        }
        static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if(obstacleGrid.Length == 0)
            {
                return 0;
            }
            int m = obstacleGrid.Length;

            int n = obstacleGrid[0].Length;
            int[,] f = new int[m,n];
            if(obstacleGrid[m-1][n-1] == 1)
            {
                return 0;
            }
            if(obstacleGrid[0][0] == 1)
            {
                return 0;

            }
            else
            {
                f[0,0] = 1;
            }
       //先求第一行
       for(int i = 1;i<m;i++)
            {
                f[i, 0] = (obstacleGrid[i][0] == 1 ? 0 : f[i - 1, 0]);
            }
       for(int j = 1;j<n;j++)
            {
                f[0, j] = (obstacleGrid[0][j] == 1 ? 0 : f[0, j - 1]);
            }
            for (int i = 1;i<m;i++)
            {
                for(int j = 1;j<n;j++)
                {
                    if(obstacleGrid[i][j] == 1)
                    {
                        f[i,j] = 0;
                    }
                    else
                    {
                 
                            f[i, j] = f[i - 1, j] + f[i, j - 1];
                        
                    }
                }
            }
            return f[m-1,n-1];
        }
        static int UniquePaths(int m, int n)
        {
            int[,] f = new int[m,n];
            f[0, 0] = 1;
            for(int i = 0;i<m;i++)
            {
                for(int j = 0;j<n;j++)
                {
                    if(i == 0||j == 0)
                    {
                        f[i, j] = 1;
                       
                    }
                    else
                    {
                        f[i, j] = f[i - 1, j] + f[i, j - 1];
                    }
                  
                }
            }
            return f[m-1, n-1];
        }
        static int CoinChange(int[] coins,int amount)
        {
            int coinNum = amount+1;

            int[] dp = new int[amount + 1];
            Array.Fill(dp, coinNum);
            dp[0] = 0;
            for(int i = 1;i<=amount;i++)
            {
                for(int j = 0;j<coins.Length;j++)
                {
                    if(coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
               
                }
            }

            if(dp[amount]> amount)
            {
                return -1;
            }
            return dp[amount];
        }
    }
}
