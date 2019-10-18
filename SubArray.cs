//*************************************************************************
//	创建日期:	2019/9/17 17:44:55
//	文件名称:	SubArray
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
    class SubArray
    {
        public static void TestFindUnSortSubArray()
        {
            int[] a = new int[] {1,2,3,4 };
            int n = FindUnsortedSubarray(a);
            Console.WriteLine(n);
        }
        static int FindUnsortedSubarray(int[] nums)
        {
            if(nums == null || nums.Length < 2)
            {
                return 0;
            }
       
            int begin = 0,end = nums.Length;
            for(int i = 0;i<nums.Length-1;i++)
            {
                if(nums[i+1]<nums[i])
                {
                    begin = i;
                    break;
                }
            }
            if(begin == 0)
            {
                return 0;
            }
            for(int i = nums.Length - 1;i>0;i--)
            {
                if(nums[i]<nums[i-1])
                {
                    end = i;
                    break;
                }
            }
            if (end <= begin)
            {
                return 0;
            }
            return end - begin+1;
        }
    }
}
