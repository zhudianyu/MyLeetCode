//*************************************************************************
//	创建日期:	2019/9/5 17:42:29
//	文件名称:	Sort
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
    class MySort
    {
        //快速排序 
        /* 先整体有序再局部有序
         分治思想
         找到 p 条件是 <=p  && >= p
         left<=right not <
         a[left] <p not <=
         */
        public static void TestQuickSort()
        {
            int[] nums = new int[] { 4, 5, 3, 6, 8, 9, 1, 0, 7, 2, 10 };
            QuickSort(nums);
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
        }
        #region quicksort
        static void QuickSort(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            QuickSortHelper(nums, 0, nums.Length - 1);
        }
        static void QuickSortHelper(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int left = start, right = end;

            int pivot = nums[(start + end) / 2];
            //因为在循环过程中 nums[pivot]的值是会被交换的 所以不可以在循环里面取值
            while (left <= right)
            {
                while (left <= right && nums[left] < pivot)
                {
                    left++;
                }
                while (left <= right && nums[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    left++;
                    right--;
                }


            }
            QuickSortHelper(nums, start, right);
            QuickSortHelper(nums, left, end);

        }
        #endregion

        #region megresort
        public static void TestMegreSort()
        {
            int[] nums = new int[] { 4, 5, 3, 6, 8, 9, 1, 0, 7, 2, 10 };
            int[] temp = new int[nums.Length];
            MegreSort(nums,0,nums.Length - 1,temp);
     
            Console.WriteLine("megre sort:");
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
        }
        //归并排序 先局部有序 在整体有序
        static void MegreSort(int[] nums, int start, int end, int[] temp)
        {
            if (start >= end)
            {
                return;
            }

            int mid = (end - start) / 2 + start;
            MegreSort(nums, start, mid, temp);
            MegreSort(nums, mid + 1, end, temp);
            Megre(nums, start, end, temp);

        }
        static void Megre(int[] nums, int start, int end, int[] temp)
        {
            int leftStart = start;
            int mid = (end - start) / 2 + start;
            int rightStart = mid + 1;
            int index = leftStart;
            while(leftStart<=mid&&rightStart<=end)
            {
                if(nums[leftStart]<nums[rightStart])
                {
                    temp[index++] = nums[leftStart++];
                   
                }
                else
                {
                    temp[index++] = nums[rightStart++];
                 
                }
            }
            //不要漏掉剩下的数据
            while(leftStart<=mid)
            {
                temp[index++] = nums[leftStart++];
         
            }
            while(rightStart<= end)
            {
                temp[index++] = nums[rightStart++];
            }
            //在合并函数里面赋值回去
            for(int i = start;i<= end;i++)
            {
                nums[i] = temp[i];
            }
        }
        #endregion
    }
}
