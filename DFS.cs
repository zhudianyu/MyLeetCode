//*************************************************************************
//	创建日期:	2019/9/26 18:02:07
//	文件名称:	DFS
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
    class DFS
    {
        static public void TestComsum()
        {
            int[] array = new int[] { 2, 3, 6, 7 };
            combinationSum(array, 7);
        }
        static public void TestRmoveDuplicates()
        {
            int[] array = new int[] { 2,2,3,6,6,7, 3, 6, 7 };
            var res = RemoveDuplicates(array);
            foreach(var n in res)
            {
                Console.WriteLine(n);
            }
        }
        static public IList<IList<int>> combinationSum(int[] candidates, int target)
        {
            // write your code here
            List<IList<int>> result = new List<IList<int>>();
            if(candidates == null ||candidates.Length == 0||target == 0)
            {
                return result;
            }
            CombinaSumHelper(result, new List<int>(), candidates, 0, target);
            return result;
        }
        static int[] RemoveDuplicates(int[] candidates)
        {
            //去重算法 
            //1.先排序
            Array.Sort(candidates);
            //2. 两个指针
            int index = 0;
            for(int i = 0;i<candidates.Length;i++)
            {
                if(candidates[index] != candidates[i])
                {
                    index++;
                    candidates[index] = candidates[i];
                }
            }
            int[] nums = new int[index + 1];
            for(int i = 0;i<index+1;i++)
            {
                nums[i] = candidates[i];
            }
            return nums;
        }
        static void CombinaSumHelper(List<IList<int>> reslut ,List<int> sub, int[] candidates,int index, int target)
        {
            int tempTarget = target;
            for (int i = 0; i < sub.Count; i++)
            {
                tempTarget -= sub[i];
            }
            if (tempTarget == 0)
            {
                List<int> temp = new List<int>(sub);
             
                reslut.Add(temp);
                return;
            }
            else if(tempTarget < 0)
            {
                return;
            }
            else
            {
                for (int i = index; i < candidates.Length; i++)
                {
                    sub.Add(candidates[i]);
                    CombinaSumHelper(reslut, sub, candidates, i, target);
                    sub.RemoveAt(sub.Count - 1);
                }
            }
            
         

        }
       
    }
    public class SolveNQueen
    {
        //深度优先搜索
        //列是colum 行是row  行是横着的 “行”是横着的两个杠  “列”右侧竖着的两个杠
        List<string> GetString(List<int> cols)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < cols.Count; i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < cols.Count; j++)
                {
                    if (j == cols[i])
                    {
                        str.Append("Q");
                    }
                    else
                    {
                        str.Append(".");
                    }
                }
                res.Add(str.ToString());
            }
            return res;
        }
        //同行 同列 对角线
        bool IsValid(List<int> cols, int colum)
        {
            int l = cols.Count;
            for (int rowIndex = 0; rowIndex < cols.Count; rowIndex++)
            {
                //同行不判断 否则没结果
//                 if (colum == i)
//                 {
//                     return false;
//                 }
                int v = cols[rowIndex];
                if (v == colum)
                {
                    return false;
                }
                if (rowIndex + v == l + colum)
                {
                    return false;
                }
                if (rowIndex - v == l - colum)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="cols">cols的索引是行数 值是列数  保存第n行的第几列是皇后</param>
        /// <param name="n"></param>
        void Search(List<IList<string>> result, List<int> cols, int n)
        {
            if (cols.Count == n)
            {
                result.Add(GetString(cols));
                return;
            }
            //判断一行的每一个元素
            for (int colIndex = 0; colIndex < n; colIndex++)
            {
                if (!IsValid(cols, colIndex))
                {
                    continue;
                }
                cols.Add(colIndex);
                Search(result, cols, n);
                //如果当前格子 不能放置n个皇后 则移除当前格子 回到上一行 判断下一个格子 
                cols.RemoveAt(cols.Count - 1);
            }

        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> result = new List<IList<string>>();
            if (n == 0)
            {
                return result;
            }
            Search(result, new List<int>(), n);
            return result;

        }
    }

    public class SubSets
    {
        /*
         给定一个可能包含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
         说明：解集不能包含重复的子集。
         */
         public static void TestSubSets()
        {
            int[] testData = new int[] { 1, 2, 2 };
            SubsetsWithDup(testData);
        }
        static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            Array.Sort(nums);
            SubSetHelper(results, new List<int>(), 0, nums);
            return results;
        }
        static void SubSetHelper(List<IList<int>> results,List<int> subResult,int startIndex,int[] nums)
        {
            results.Add(new List<int>(subResult));

            for(int i = startIndex;i<nums.Length;i++)
            {
                //去重  先排序
                /*
                 假设 数据为 [1,2,2]  重复子集为[1,2] (2)[1,2']  我们选择第一个为结果，那么当碰到
                 （2）的结果的时候 我们要判断是否已经加入子集 判断当前值是否和上一位相等 
                 即nums[i] == nums[i-1]并且第i-1个数没被加入集合 通过i和startindex比较
                 递归循环的理解 
                 循环就是把 以某几个元素开始的 开头的子集全部加入 一个循环内的子集的个数是相同的 
                 每递归一层 子集内元素的个数会增加一个
                 */
                 if(i>0 && nums[i] == nums[i-1]&&i>startIndex)
                {
                    continue;
                }
                subResult.Add(nums[i]);
                SubSetHelper(results, subResult, i + 1, nums);
                //回溯
                subResult.RemoveAt(subResult.Count - 1);
            }
        }
    }

    public  class PartitionString
    {
        public void Test()
        {
            var res = Partition("aab");
        }
        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> results = new List<IList<string>>();
            if(string.IsNullOrEmpty(s))
            {
                return results;
            }
            PalindromeHelper(results, new List<string>(), 0, s);
            return results;

        }
        //可以理解为划分型 组合问题 如果有n个字符串 则有2^(n-1)次方的可能
        void PalindromeHelper(List<IList<string>> results,List<string> subList,int startIndx,string src)
        {
            //递归出口 划分的位置等于字符长度时 依然是递归的外层循环
            if(startIndx == src.Length)
            {
                results.Add(new List<string>(subList));
                return;
            }

      
            for(int i = startIndx;i<src.Length;i++)
            {
                string str = src.Substring(startIndx, i-startIndx+1);
                if(IsPalindrome(str.ToCharArray()))
                {
                    subList.Add(str);
                    PalindromeHelper(results, subList, i + 1, src);
                    subList.RemoveAt(subList.Count - 1);
                }
                else
                {
                    continue;
                }
            }
        }
        bool IsPalindrome(char[] str)
        {
            if(str.Length == 0)
            {
                return true;
            }
            char[] ss = str;
            int len = ss.Length;
            int start = 0, end = len - 1;
            while(start<=end)
            {
                if(ss[start] != ss[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
    }
    /// <summary>
    /// 全排列
    /// </summary>
    public class AllPermute
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            if(nums == null ||nums.Length == 0)
            {
                return results;
            }
            Array.Sort(nums);
            bool[] visit = new bool[nums.Length];
            PermuteHelper(results, new List<int>(), nums, visit);
            return results;
        }
        void PermuteHelper(List<IList<int>> results, List<int> sub, int[] nums, bool[] visit)
        {
            if (sub.Count == nums.Length)
            {
                results.Add(new List<int>(sub));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (visit[i])
                {
                    continue;
                }
                //去重判断是重点
                if (i != 0 && nums[i] == nums[i - 1] && !visit[i - 1])
                {
                    continue;
                }
                sub.Add(nums[i]);
                visit[i] = true;
                PermuteHelper(results, sub, nums, visit);
                //回溯 要还原状态
                sub.RemoveAt(sub.Count - 1);
                visit[i] = false;
            }
        }
    }

}
