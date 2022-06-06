using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal class ConditionsTree
    {
        // список станів дошки
        //public List<Queens> Conditions { get; set; }
        public Queens Root { get; set; }
        
        // конструктор
        /*public ConditionsTree()
        {
            Conditions = new List<Queens>();
        }*/

        // додавання нового стану
        public Queens AddCondition(int[,] board, Queens node, int vertexNum = 0)
        {
            if(node == null)
                return new Queens(board, vertexNum);
            else
            {
                //if(/*якась перевірка*/)
                //{
                    for(int i = 0; i < node.Successors.Count; i++)
                    {
                        node.Successors[i] = AddCondition(board, node.Successors[i], ++vertexNum);
                    }
                //}
            }
            return node;
        }


    }
}
