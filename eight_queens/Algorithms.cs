using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal static class Algorithms
    {
        /*public class Graph
        {           
            private List<int>[] adj;
            public int VerticesNum { get; set; }

            public Graph(int vertNum)
            {
                VerticesNum = vertNum;
                adj = new List<int>[vertNum];
                for (int i = 0; i < vertNum; i++)
                    adj[i] = new List<int>();
            }

            public void AddEdge(int vert, int newVert)
            {
                adj[vert].Add(newVert);
            }
        }*/

        public static void LDFS(TreeNode tree, ChessBoard node, ChessBoard parent)
        {
            bool flag = true;

            for (int i = 0; i < tree.children.Count; i++)
            {
                ChessBoard current = tree.children[i];

                if(current != parent)
                {
                    flag = false;
                    LDFS(tree, current, node);
                }
            }

            if (flag)
            {
                if (ChessBoard.IsResult(node))
                {
                    
                }
            }
        }
        
        public static void BFS(TreeNode tree)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(tree);
            while (queue.Count > 0)
            {
                tree = queue.Dequeue();

                if (ChessBoard.IsResult(tree))
                {
                    
                }

                for (int i = 0; i < tree.children.Count; i++)
                {
                    if(tree.children[i] != null)
                        queue.Enqueue(tree.children[i]);                    
                }
            }


        }

        public static void IDS()
        {

        }
    }
}
