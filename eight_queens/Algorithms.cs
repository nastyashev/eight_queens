using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    public static class Algorithms
    {
        public class Graph
        {
            public LinkedList<int>[] adj;
            public int Size { get; set; }
        }

        public static void LDFS()
        {

        }
        
        
        public static void BFS(Graph graph, int start)
        {
            bool[] visited = new bool[graph.Size];
            for (int i = 0; i < graph.Size; i++)
            {
                visited[i] = false;
            }

            


        }

        public static void IDS()
        {

        }
    }
}
