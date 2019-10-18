//*************************************************************************
//	创建日期:	2019/9/7 10:36:56
//	文件名称:	BinaryTree
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
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
        public void AddNode(int x, TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            TreeNode cur = root;
            TreeNode parent = null;
            while (true)
            {
                parent = cur;
                int val = cur.val;
                if (x < val)
                {
                    cur = cur.left;
                    if (cur == null)
                    {
                        parent.left = new TreeNode(x);
                        break;
                    }
                }
                else
                {
                    cur = cur.right;
                    if (cur == null)
                    {
                        parent.right = new TreeNode(x);
                        break;
                    }
                }
            }
        }
    }
    class BinaryTree
    {

        public static void TestBinaryTree()
        {
            TreeNode root = new TreeNode(5);
            root.AddNode(3, root);
            root.AddNode(7, root);
            root.AddNode(2, root);
            root.AddNode(4, root);
            root.AddNode(8, root);
            root.AddNode(1, root);


            var l = PostOrderTraversal(root);
            Console.WriteLine("InOrderTraversal :");

            foreach (var n in l)
            {
                Console.WriteLine(n);
            }
        }

        public static void TestSerialize()
        {
            TreeNode root = new TreeNode(5);
            root.AddNode(3, root);
            root.AddNode(7, root);
            root.AddNode(2, root);
            root.AddNode(4, root);
            root.AddNode(8, root);
            root.AddNode(1, root);
            string str = Serizlize(root);
            Console.WriteLine("serialize :" + str);
            TreeNode node = Deserialize(str);
            var l = PostOrderTraversal(root);
            Console.WriteLine("InOrderTraversal :");

            foreach (var n in l)
            {
                Console.WriteLine(n);
            }
        }
        public static List<int> PreOrderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            if (root == null)
            {
                return list;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode top = null;
            stack.Push(root);
            while (stack.TryPop(out top))
            {
                list.Add(top.val);
                if (top.right != null)
                {
                    stack.Push(top.right);
                }
                if (top.left != null)
                {
                    stack.Push(top.left);
                }
            }
            return list;
        }
        //当前节点为空 从栈拿一个，打印，当前向右
        //当前节点不为空，当前压出栈，当前向左
        public static List<int> InOrderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            if (root == null)
            {
                return list;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode top = root;

            while (top != null || stack.Count != 0)
            {

                while (top != null)
                {
                    stack.Push(top);
                    top = top.left;
                }
                top = stack.Pop();
                list.Add(top.val);
                top = top.right;
            }
            return list;
        }
        //用两个栈来实现
        // 前序遍历是 根左右 然后改写成 根右左  然后压入另外一个栈  再输出即可
        public static List<int> PostOrderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            if (root == null)
            {
                return list;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> reslut = new Stack<TreeNode>();
            TreeNode top = root;
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode cur = stack.Pop();
                reslut.Push(cur);
                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }
                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }

            }
            while (reslut.Count != 0)
            {
                list.Add(reslut.Pop().val);
            }
            return list;
        }
        //bfs
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                List<int> subList = new List<int>();
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    TreeNode node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(subList);
            }

            return result;

        }
        //
        public static TreeNode lowestCommonAncestor(TreeNode root, TreeNode A, TreeNode B)
        {
            //使用分治的思想
            if (root == null)
            {
                return null;
            }
            if (root == A || root == B)
            {
                return root;
            }
            TreeNode left = lowestCommonAncestor(root.left, A, B);
            TreeNode right = lowestCommonAncestor(root.right, A, B);
            // write your code here

            if (left != null && right != null)
            {
                return root;
            }
            if (left != null)
            {
                return left;
            }
            if (right != null)
            {
                return right;
            }
            return null;

        }
        public class ResultType
        {
            public bool aExist;
            public bool bExist;
            public TreeNode node;
            public ResultType(TreeNode root, bool a, bool b)
            {
                node = root;
                aExist = a;
                bExist = b;
            }
        }
        public static TreeNode lowestCommonAncestor3(TreeNode root, TreeNode A, TreeNode B)
        {
            ResultType r = LCA3Helper(root, A, B);
            if (r.aExist && r.bExist)
            {
                return r.node;
            }
            return null;
        }
        public static ResultType LCA3Helper(TreeNode root, TreeNode A, TreeNode B)
        {
            if (root == null)
            {
                return new ResultType(null, false, false);
            }

            ResultType left = LCA3Helper(root.left, A, B);
            ResultType right = LCA3Helper(root.right, A, B);
            bool aExist = left.aExist || right.aExist || A == root;
            bool bExist = right.bExist || left.bExist || B == root;
            if (root == A || root == B)
            {
                return new ResultType(root, aExist, bExist);
            }
            if (left.node != null && right.node != null)
            {
                return new ResultType(root, aExist, bExist);
            }
            if (left.node != null)
            {
                return new ResultType(left.node, aExist, bExist);
            }
            if (right.node != null)
            {
                return new ResultType(right.node, aExist, bExist);
            }
            return new ResultType(null, aExist, bExist);
        }

        /*
         设计一个算法，并编写代码来序列化和反序列化二叉树。将树写入一个文件被称为“序列化”，读取文件后重建同样的二叉树被称为“反序列化”。

如何反序列化或序列化二叉树是没有限制的，你只需要确保可以将二叉树序列化为一个字符串，并且可以将字符串反序列化为原来的树结构。
         */
        static string Serizlize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }
         
            List<TreeNode> queue = new List<TreeNode>();
            queue.Add(root);


            for (int i = 0; i < queue.Count; i++)
            {
                TreeNode node = queue[i];
                if (node != null)
                {
                    queue.Add(node.left);
                    queue.Add(node.right);
                }
            }


            StringBuilder str = new StringBuilder( "{");
            str.Append( queue[0].val);
            for (int i = 1; i < queue.Count; i++)
            {
                TreeNode node = queue[i];
                if (node != null)
                {
                    str.Append(",");
                    str.Append(node.val);
                }
                else
                {
                    str.Append( ",#");
                }
            }
            string endStr = str.ToString();
            while (endStr.EndsWith("#"))
            {
                endStr = endStr.Substring(0, endStr.Length - 2);
            }
            endStr += "}";
            return endStr;


        }

        static TreeNode Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            string str = data.Substring(1, data.Length - 1);
            str = str.Substring(0, str.Length - 1);
            string[] val = str.Split(",");
            TreeNode root = new TreeNode(int.Parse(val[0]));
            List<TreeNode> queue = new List<TreeNode>();
            queue.Add(root);
            int n = 0;
            bool isLeft = true;
            for (int i = 1; i < val.Length; i++)
            {
                TreeNode curNode = queue[n];
                string ch = val[i];
                if (isLeft)
                {

                    if (ch != "#")
                    {
                        TreeNode node = new TreeNode(int.Parse(val[i]));
                        queue.Add(node);

                        curNode.left = node;

                    }
                }
                else
                {
                    if (ch != "#")
                    {
                        TreeNode node = new TreeNode(int.Parse(val[i]));
                        queue.Add(node);
                        curNode.right = node;
                    }
                    n++;
                }
                isLeft = !isLeft;
            }

            return root;
        }
    }

}
