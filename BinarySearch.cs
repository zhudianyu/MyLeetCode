//*************************************************************************
//	创建日期:	2019/9/2 16:12:05
//	文件名称:	BinarySearch
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
    //循环结束条件 start+1 <end 永远是  找last pos 避免死循环 【start <end] [2,2]
    // mid = (end - start)/2+start 防止（end+start) /2 越界
    //double check
    class BinarySearch
    {
        public static void TestBSFindMini()
        {
            int[] nums = new int[] { 1,2};
         
          //  Console.WriteLine(res);
        }
        public static void TestSearchMatrix()
        {
            int[,] testArray = new int[1, 0] { { } }; 
                //new int[2, 3] { { 1, 4, 5 },{ 6, 7, 8 } };
            bool ret = SearchMatrix(testArray, 1);
            Console.WriteLine("search matrix result: " + ret);
        }
        int FindFirstTarget(int[] nums,int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            int start = 0, end = nums.Length - 1;
            while(start+1<end)
            {
                int mid = (end - start) / 2 + start;
                if(nums[mid] > target)
                {
                    end = mid;
                }
                else if(nums[mid] == target)
                {
                    
                    end = mid;
                }
                else
                {
                    start = mid;
                }

            }
            if(nums[start] == target)
            {
                return start;
            }
            if(nums[end] == target)
            {
                return end;
            }
            return -1;
        }
        public static int FindMiniInRSA(int[] nums)
        {
            if(nums == null||nums.Length == 0)
            {
                return -1;
            }
            int start = 0, end = nums.Length - 1;
            int target = nums[end];
       
            while(start+1< end)
            {
                int mid = (end - start) / 2 + start;
                 if(nums[mid]>target)
                {
                    start = mid;
                }
                 else
                {
                    end = mid;
                }
            }

            return Math.Min(nums[start], nums[end]);
    
        }
        public static int FindTargetInRSA(int[] nums,int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            int index = 0;// FindMiniIndex(nums);
           int res = FindTarget(nums, 0, index, target);
            if(res != -1)
            {
                return res;
            }
            int res2 = FindTarget(nums, index, nums.Length - 1, target);
            return res2;
        }
        static bool SearchMatrix(int[,] matrix,int target)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return false;
            }
            if ( matrix.GetLength(0) == 0||matrix.GetValue(0)== null)
            {
                return false;
            }
            int m = matrix.Rank;
            int t = matrix.Length;
            int start = 0, end = m - 1;
            while(start+1<end)
            {
                int mid = (end - start) / 2 + start;
                int k = matrix.GetLength(mid) - 1;
                if (target > matrix[mid, 0])
                {
                    start = mid;
                }
                else if(target <matrix[mid,0])
                {
                    end = mid;
                }
                else if(target == matrix[mid,0])
                {
                    return true;
                }
            }
            int cur = start;
        
            if(target >= matrix[end,0])
            {
                cur = end;
            }
            start = 0;
         
            end = matrix.GetLength(cur) - 1;
            while(start+1<end)
            {
                int mid = (end - start) / 2 + start;
                if (target > matrix[cur,mid])
                {
                    start = mid;
                }
                else if(target < matrix[cur,mid])
                {
                    end = mid;
                }
                else
                {
                    return true;
                }
            }
            if(target == matrix[cur,start]||target == matrix[cur,end])
            {
                return true;
            }
            return false;
        }
        public static int FindTarget(int[] nums ,int start,int end,int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
       

            while (start + 1 < end)
            {
                int mid = (end - start) / 2 + start;
                if (nums[mid] > target)
                {
                    end = mid;
                }
                else if (nums[mid] == target)
                {
                    return mid;
                }
                else
                {
                    start = mid;
                }
            }
            if (nums[start] == target)
            {
                return start;
            }
            else if (nums[end] == target)
            {
                return end;
            }
            else
            {
                return -1;
            }

        }

        public static void TestFindPeak()
        {
            int[] testData = new int[] { 1, 2, 1, 2, 3, 1 };
            int index = FindPeak(testData);
            Console.WriteLine(index);
        }
        //寻找峰值 至少3个数
        public static int FindPeak(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;

            }

            int n = nums.Length - 1;
            if (n == 0)
            {
                return 0;
            }

            int start = 0, end = n;
            while (start + 1 < end)
            {
                int mid = (end - start) / 2 + start;
                int left = mid - 1, right = mid + 1;
                if (nums[mid] > nums[left] && nums[mid] > nums[right])
                {
                    return mid;
                }
                if (nums[mid] > nums[left])
                {
                    start = mid;
                }
                if (nums[mid] < nums[left])
                {
                    end = mid;
                }
          

            }
            if (nums[start] > nums[end])
            {
                return start;
            }
            else
            {
                return end;
            }

        }
    }
}
