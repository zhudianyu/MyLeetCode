//*************************************************************************
//	创建日期:	2019/9/10 19:05:45
//	文件名称:	Graph
//  创 建 人:   zhudianyu	
//  Email   :   1462415060@qq.com
//	版权所有:	obexx
//	说    明:	
//*************************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Algorithm
{
    public class Graph
    {
        #region 验证图是否是树
        public Dictionary<int, HashSet<int>> InitGraph(int n, int[][] edges)
        {
            Dictionary<int, HashSet<int>> g = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                g.Add(i, new HashSet<int>());
            }
            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0];
                int v = edges[i][1];
                g[u].Add(v);
                g[v].Add(u);
            }
            return g;
        }
        public bool ValidTree(int n, int[][] edges)
        {
            //判断图是否为树 判断边是否等于 顶点个数减一 如果有环的话 n-1 != edges.length
            //判断是否能访问所有节点
            if (n == 0)
            {
                return false;
            }
            if (n - 1 != edges.Length)
            {
                return false;
            }

            Dictionary<int, HashSet<int>> g = InitGraph(n, edges);
            Queue<int> queue = new Queue<int>();
            HashSet<int> hash = new HashSet<int>();

            queue.Enqueue(0);
            hash.Add(0);
            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                var set = g[node];
                foreach (var e in set)
                {
                    if (hash.Contains(e))
                    {
                        continue;
                    }
                    hash.Add(e);
                    queue.Enqueue(e);
                }
            }
            return hash.Count == n;

        }
        #endregion

        #region clone graph
        public class UndirectedGraphNode
        {
            public int label;
            public List<UndirectedGraphNode> neighbors;
            public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
        };
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
            {
                return null;
            }
            Queue<UndirectedGraphNode> nodeQueue = new Queue<UndirectedGraphNode>();
            nodeQueue.Enqueue(node);
            Dictionary<int, UndirectedGraphNode> nodeDic = new Dictionary<int, UndirectedGraphNode>();
            Dictionary<int, UndirectedGraphNode> newGraphNodeDic = new Dictionary<int, UndirectedGraphNode>();
            while (nodeQueue.Count != 0)
            {
                var root = nodeQueue.Dequeue();
                UndirectedGraphNode newNode = new UndirectedGraphNode(root.label);
                if (!nodeDic.ContainsKey(root.label))
                {
                    nodeDic.Add(root.label, root);
                    newGraphNodeDic.Add(root.label, newNode);
                    //这个for循环一定要写在判断nodedic的里面 否则死循环
                    foreach (var n in root.neighbors)
                    {
                        if (n != null)
                        {
                            nodeQueue.Enqueue(n);
                        }
                    }
                }

            }

            foreach (var n in newGraphNodeDic)
            {
                var newNode = n.Value;
                var oldNode = nodeDic[n.Key];

                foreach (var nb in oldNode.neighbors)
                {
                    UndirectedGraphNode newNeightor = newGraphNodeDic[nb.label];
                    newNode.neighbors.Add(newNeightor);
                }
            }

            UndirectedGraphNode rootNode = newGraphNodeDic[node.label];

            return rootNode;
            // write your code here
        }

        public UndirectedGraphNode SearchNode(List<UndirectedGraphNode> graph,
                                         Dictionary<UndirectedGraphNode, int> values,
                                         UndirectedGraphNode node,
                                         int target)
        {
            // write your code here
            Queue<UndirectedGraphNode> queue = new Queue<UndirectedGraphNode>();
            queue.Enqueue(node);
            HashSet<UndirectedGraphNode> nodeSet = new HashSet<UndirectedGraphNode>();
            while (queue.Count != 0)
            {
                UndirectedGraphNode root = queue.Dequeue();
                int v = values[root];
                nodeSet.Add(root);
                if (v == target)
                {
                    return root;
                }
                else
                {
                    foreach (var n in root.neighbors)
                    {
                        if (!nodeSet.Contains(n))
                        {
                            queue.Enqueue(n);
                        }
                    }
                }

            }
            return null;

        }
        #endregion

        #region topsort
        public class DirectedGraphNode
        {
            public int label;
            public List<DirectedGraphNode> neighbors;
            public DirectedGraphNode(int x) { label = x; neighbors = new List<DirectedGraphNode>(); }

        }
        public List<DirectedGraphNode> TopSort(List<DirectedGraphNode> graph)
        {
            List<DirectedGraphNode> list = new List<DirectedGraphNode>();
            if (graph == null)
            {
                return list;
            }
            Dictionary<DirectedGraphNode, int> ingreeDic = new Dictionary<DirectedGraphNode, int>();
            foreach (var n in graph)
            {
                ingreeDic.Add(n, 0);
            }
            Queue<DirectedGraphNode> queue = new Queue<DirectedGraphNode>();
            foreach (var n in graph)
            {
                foreach (var nb in n.neighbors)
                {
                    if (ingreeDic.ContainsKey(nb))
                    {
                        int v = ingreeDic[nb];
                        ingreeDic[nb] = v + 1;
                    }

                }
            }
            //要考虑 多个入度为0的节点
            foreach (var n in ingreeDic)
            {
                if (n.Value == 0)
                {

                    list.Add(n.Key);
                    queue.Enqueue(n.Key);
                }
            }
            while (queue.Count != 0)
            {
                DirectedGraphNode node = queue.Dequeue();
                foreach (var n in node.neighbors)
                {
                    int val = ingreeDic[n];
                    val = val - 1;
                    ingreeDic[n] = val;
                    if (val == 0)
                    {
                        list.Add(n);
                        queue.Enqueue(n);
                    }
                }
            }
            return list;
        }
        #endregion
        public static void TestSchedule()
        {
            int[][] array = new int[1][];
            array[0] = new int[2] { 1, 0 };

            bool b = CanFinish(2, array);
            Console.WriteLine("testschedule :" + b);
        }
        static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (prerequisites == null || prerequisites.Length == 0)
            {
                return true;
            }
            Dictionary<int, List<int>> nodeRequire = new Dictionary<int, List<int>>();
            Dictionary<int, int> inDegreeDic = new Dictionary<int, int>();
            for (int i = 0; i < numCourses; i++)
            {
                inDegreeDic.Add(i, 0);
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int[] a = prerequisites[i];
                if (a.Length == 0 || a == null)
                {
                    continue;
                }

                List<int> requireList = null;
                if (!nodeRequire.TryGetValue(a[a.Length - 1], out requireList))
                {
                    requireList = new List<int>();

                    nodeRequire.Add(a[a.Length - 1], requireList);
                }

                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (!requireList.Contains(a[j]))
                    {
                        requireList.Add(a[j]);
                    }
                    int degree = inDegreeDic[a[j]];
                    inDegreeDic[a[j]] = degree + 1;
                }
            }
            Queue<int> queue = new Queue<int>();
            foreach (var d in inDegreeDic)
            {
                if (d.Value == 0)
                {
                    queue.Enqueue(d.Key);
                }
            }
            int count = 0;
            while (queue.Count != 0)
            {
                int val = queue.Dequeue();
                count++;
                List<int> req = null;
                if (nodeRequire.TryGetValue(val, out req))
                {
                    foreach (var n in req)
                    {
                        int de = inDegreeDic[n];
                        de = de - 1;
                        inDegreeDic[n] = de;
                        if (de == 0)
                        {
                            queue.Enqueue(n);
                        }
                    }
                }

            }
            return numCourses == count;
        }
        //求岛屿数量
        static int NumIsLands(bool[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visit = new bool[m, n];
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] && !visit[i, j])
                    {
                        count++;
                        BfsIsland(grid, visit, i, j);

                    }
                }
            }
            return count;
        }
        static void BfsIsland(bool[][] gird, bool[,] visit, int sx, int sy)
        {
            int[] deltaX = new int[] { 1, -1, 0, 0 };
            int[] deltaY = new int[] { 0, 0, 1, -1 };
            Queue<int> xq = new Queue<int>();
            Queue<int> yq = new Queue<int>();
            visit[sx, sy] = true;
            int m = gird.Length;
            int n = gird[0].Length;
            xq.Enqueue(sx);
            yq.Enqueue(sy);
            while (xq.Count != 0)
            {
                int xp = xq.Dequeue();
                int yp = yq.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = xp + deltaX[i];
                    int y = yp + deltaY[i];
                    if (x > 0 && x < m && y > 0 && y < n && !visit[x, y])
                    {
                        visit[x, y] = true;
                        if (gird[x][y])
                        {
                            xq.Enqueue(x);
                            yq.Enqueue(y);
                        }
                    }
                }
            }
        }

        public class Point
        {
           public  int x;
            public int y;
            Point() { x = 0; y = 0; }
            public Point(int a, int b) { x = a; y = b; }
        }

        public int KnightShortestPath(bool[][] grid, Point source, Point destination)
        {
            // write your code here
            if(grid == null||grid.Length == 0||grid[0].Length == 0)
            {
                return -1;
            }
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] v = new bool[m,n];
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(source);
            v[source.x, source.y] = true;

            if(source.x == destination.x && source.y == destination.y)
            {
                return 0;
            }
            int[] dx = new int[] { 1, 1, -1, -1, 2, 2, -2, -2 };
            int[] dy = new int[] { 2, -2, 2, -2, 1, -1, 1, -1 };
            int num = 0;
            while(q.Count != 0)
            {
                num++;
                int size = q.Count;
                for(int i = 0;i<size;i++)
                {
                    Point p = q.Dequeue();
                    
                    for(int j = 0;j<8;j++)
                    {
                        int x = p.x + dx[j];
                        int y = p.y + dy[j];
                        if (x >= 0 && x < m && y >= 0 && y < n && !grid[x][y]&&!v[x,y])
                        {
                            if(x == destination.x&& y == destination.y)
                            {
                                return num;          
                            }
                            q.Enqueue(new Point(x, y));
                            v[x, y] = true;
                        }
                    }
                }


            }
            return -1;
        }
    }
}