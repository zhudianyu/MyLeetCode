//*************************************************************************
//	创建日期:	2019/8/19 11:13:44
//	文件名称:	HouseRobber
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
    class HouseRobber
    {
        public static void TestRobber()
        {
            int[] data = new int[] { 1, 2, 3, 1 };
            int r = Rob1(data);
            Console.WriteLine(r);
        }
        public static int Rob1(int[] nums)
        {
            if(nums == null ||nums.Length == 0 )
            {
                return 0;
            }
            int len = nums.Length;
            int[] f = new int[len + 1];
            f[0] = 0; f[1] = nums[0];
        
            for (int i = 2; i <=len; i++)
            {
           
                    f[i] = Math.Max(f[i-1], f[i - 2] + nums[i-1]);
                
            }
            return f[len];
        }
        /*
         你是一个专业的小偷，计划偷窃沿街的房屋，每间房内都藏有一定的现金。这个地方所有的房屋都围成一圈，这意味着第一个房屋和最后一个房屋是紧挨着的。同时，相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。

给定一个代表每个房屋存放金额的非负整数数组，计算你在不触动警报装置的情况下，能够偷窃到的最高金额。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/house-robber-ii
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
             
         */
        public static int Rob2(int[] nums)
        {//环形的 
            
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int len = nums.Length;
            if(len == 1)
            {
                return nums[0];
            }
            int[] data1 = new int[len - 1];
            Array.Copy(nums, 1, data1, 0, len - 1);
            int r1 = Rob1(data1);
            Array.Copy(nums, 0, data1, 0, len - 1);
            int r2 = Rob1(data1);

            return Math.Max(r1,r2);
        }
    }
}
