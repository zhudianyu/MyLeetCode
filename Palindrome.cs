//*************************************************************************
//	创建日期:	2019/8/20 20:17:21
//	文件名称:	Palindrome
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
    public class Palindrome
    {
 
        public void TestNum()
        {
          int n = NumSquares(12);
     
        }
        public int NumSquares(int n)
        {
            //正整数不包含0 所以f[0] = 0
            //f[n] 表示表示完全平方数的个数
            //f[i] = f[i-j*j] + 1   &&0<j<=i
            int[] f = new int[n+1];
            f[0] = 0;
            for(int i = 1;i<=n;i++)
            {
                f[i] = int.MaxValue;
                for(int j = 1;j*j<=i;j++)
                {
                    if(f[i]<f[i-j*j]+1 )
                    {
                        f[i] = f[i - j * j] + 1;
                    }
                }
            }
            return f[n];
        }
   
        public static void TestMinCut()
        {
            string test = "aab";
            int str = MinCut(test);
            System.Console.WriteLine(str);
        }

        public static void TestPalinDrome()
        {
            string test = "cbbd";
            string str = LongestPalindrome(test);
            System.Console.WriteLine(str);
        }
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            int n = s.Length;
            char[] sArray = s.ToCharArray();

            bool[,] f = new bool[n, n];
            for(int i = 0;i<n;i++)
            {
                for(int j = 0;j<n;j++)
                {
                    if(i == j)
                    {
                        f[i, j] = true;
                    }
                    else
                    {
                        f[i, j] = false;
                    }
                }
            }
            //如果f[i][j]是回文那么 i+1 ,j-1 一定是回文  因为i有i+1得来 所以动态规划 i要从n取值
            int maxLen = 0;
            string resStr = string.Empty;
            for (int i = n; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {

                    if (sArray[i] == sArray[j] && (j - i < 2 || (f[i + 1, j - 1])))
                    {
                        f[i, j] = true;
                        if (j + 1 - i > maxLen)
                        {
                            maxLen = j + 1 - i;
                            resStr = s.Substring(i, maxLen);
                        }

;
                    }
                   


                }
            }
            return resStr;
        }
        /*
         给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。

返回符合要求的最少分割次数。

示例:

输入: "aab"
输出: 1
解释: 进行一次分割就可将 s 分割成 ["aa","b"] 这样两个回文子串。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/palindrome-partitioning-ii
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
             */
        public static int MinCut(string s)
        {//初始条件：空串可以被分成0个回文串
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            char[] str = s.ToCharArray();
            int n = s.Length;
            int[] f = new int[n + 1];
            f[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                f[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    //f[j]+1 && 
                    int len = i - j ;
                    string subStr = s.Substring(j, len);
                    if (IsPalin(subStr))
                    {
                        f[i] = Math.Min(f[i], f[j] + 1);
                    }
                }
            }
            return f[n] - 1;
        }
        
        static bool IsPalin(string s)
        {
            char[] c = s.ToCharArray();
            int n = c.Length;
            if (n == 0)
            {
                return true;
            }
            int i = 0, j = n - 1;
            while (i <= j)
            {
                if (c[i] == c[j])
                {

                    i++;
                    j--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}

