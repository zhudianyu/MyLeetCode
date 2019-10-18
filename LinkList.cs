//*************************************************************************
//	创建日期:	2019/9/25 18:06:29
//	文件名称:	LinkList
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
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class LinkList
    {
        public static void TestRKList()
        {
            LinkList ll = new LinkList();
            ListNode head = new ListNode(1);
            ListNode cur = head;
            for(int i = 2;i<6;i++)
            {
                cur.next = new ListNode(i);
                cur = cur.next;
            }
            head = ReverseKGroup(head, 2);
        }
        static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }
            ListNode dummy = new ListNode(0);

            dummy.next = head;
            ListNode n = dummy;
            while(n != null)
            {
                n = Revese(n, k);
            }

            return dummy.next;
        }
        static ListNode Revese(ListNode head, int k)
        {
            ListNode preNode = head;
            ListNode n1 = head.next;
            if(n1 == null)
            {
                return null;
            }
            ListNode kNode = preNode;

            for (int i = 0; i < k; i++)
            {
                if(kNode == null)
                {
                    return null;
                }
                kNode = kNode.next;
            }
            if(kNode == null)
            {
                return null;
            }
            ListNode kPlus = kNode.next;
            ListNode cur = n1;
            while(cur != kPlus)
            {
                ListNode temp = cur.next;
                cur.next = preNode;
                preNode = cur;
                cur = temp;
            }
            head.next = preNode;
            n1.next = kPlus;
            return n1;
        }
    }
}
