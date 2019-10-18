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
}
