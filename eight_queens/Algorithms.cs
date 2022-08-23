﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal class AlgorithmStatistics
    {
        public AlgorithmStatistics(int numberOfCheckedVertices, double operationTime, ChessBoard chessBoard)
        {
            NumberOfCheckedVertices = numberOfCheckedVertices;
            OperationTime = operationTime;
            ChessBoard = chessBoard;
        }

        public ChessBoard ChessBoard { get; set; }
        public int NumberOfCheckedVertices { get; set; }
        public double OperationTime { get; set; }
    }
    
    internal static class Algorithms
    {

        public static AlgorithmStatistics LDFS(ChessBoard board)//not work
        {
            DateTime time1 = DateTime.Now;
            
            if (board.IsResult())//this part work
            {
                double operTime1 = GetOperationTime(time1);
                AlgorithmStatistics result1 = new AlgorithmStatistics(1, operTime1, board);
                return result1;
            }

            int childrenNum = (board.Size * board.Size) - board.Size;
            TreeNode root = new TreeNode(new ChessBoard(board), childrenNum);
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            List<ChessBoard> chessBoards = new List<ChessBoard>();
            TreeNode tmp = new TreeNode();
            TreeNode tmp2 = new TreeNode();
            int number;
            int counter = 1;
            bool flag = true;

            while (flag)
            {
                counter++;
                tmp = stack.Peek();
                chessBoards = tmp.Board.MakeSuccessorsList();
                Random rand = new Random();
                number = rand.Next(chessBoards.Count);
                tmp2 = tmp.Add(chessBoards[number], number);
                stack.Push(tmp2);
                if (tmp2.Board.IsResult())
                {
                    flag = false;
                    break;
                }
            }
            double operTime = GetOperationTime(time1);
            ChessBoard chessBoard = new ChessBoard(tmp2.Board);
            return new AlgorithmStatistics(counter, operTime, chessBoard);
        }
        
        public static AlgorithmStatistics BFS(ChessBoard board)//not work
        {
            DateTime time1 = DateTime.Now;

            if (board.IsResult())//this part work
            {
                double operTime1 = GetOperationTime(time1);
                AlgorithmStatistics result1 = new AlgorithmStatistics(1, operTime1, board);
                return result1;
            }

            int counter = 1;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int childrenNum = (board.Size * board.Size) - board.Size;
            TreeNode tmp = new TreeNode(new ChessBoard(board), childrenNum);
            queue.Enqueue(tmp);
            bool flag = true;
            TreeNode tmp2 = tmp;
            List<ChessBoard> chessBoards = new List<ChessBoard>();
            ChessBoard chessBoard = null;

            while (flag)
            {
                tmp = queue.Peek();
                queue.Dequeue();
                chessBoards = tmp.Board.MakeSuccessorsList();

                for (int i = 0; i < chessBoards.Count && flag; i++)
                {
                    tmp2 = tmp.Add(chessBoards[i], i);
                    queue.Enqueue(tmp2);
                    if (tmp2.Board.IsResult())
                    {
                        flag = false;
                        chessBoard = new ChessBoard(tmp2.Board);
                    }
                    counter++;
                }
            }

            while(queue.Count > 0)
                queue.Dequeue();

            double operTime = GetOperationTime(time1);            
            return new AlgorithmStatistics(counter, operTime, chessBoard);
        }

        public static AlgorithmStatistics IDS(ChessBoard board/*, int maxDepth*/)//not work
        {
            DateTime time1 = DateTime.Now;

            if (board.IsResult())//this part work
            {
                double operTime1 = GetOperationTime(time1);
                AlgorithmStatistics result1 = new AlgorithmStatistics(1, operTime1, board);
                return result1;
            }

            int maxDepth = 1;
            bool flag = true;
            int counter = 0;
            int childrenNum = (board.Size * board.Size) - board.Size;
            TreeNode root = new TreeNode(new ChessBoard(board), childrenNum);
            AlgorithmStatistics result = null;
            TreeNode tmp = new TreeNode();
            while (flag)
            {
                tmp = DLS(root, maxDepth);
                counter++;
                if (tmp != null)
                {
                    ChessBoard chessBoard = new ChessBoard(tmp.Board);

                    double operTime = GetOperationTime(time1);
                    flag = false;
                    result = new AlgorithmStatistics(counter, operTime, chessBoard);
                }
                maxDepth++;
            }
            return result;

            /*int counter = 0;
            int lastCount = 0;
            int preLastCount = 0;
            int childrenNum = (board.Size * board.Size) - board.Size;
            TreeNode head = new TreeNode(new ChessBoard(board), childrenNum);
            TreeNode tmp = new TreeNode();
            AlgorithmStatistics result = null;
            for (int i = 0; i <= maxDepth && result == null; i++)
            {
                tmp = DLS(head, i);
                if(tmp != null)
                {
                    ChessBoard chessBoard = new ChessBoard(tmp.Board);
                    for (int j = 0; j < head.ChildCount; j++)
                    {
                        lastCount++;
                        
                    }
                    counter += lastCount++;
                    double operTime = GetOperationTime(time1);
                    result = new AlgorithmStatistics(counter, operTime, chessBoard);
                }
                else
                {
                    for (int j = 0; j < head.ChildCount; j++)
                    {
                        preLastCount++;
                    }
                    counter += preLastCount++;
                }
            }
            return result;*/
        }

        private static TreeNode DLS(TreeNode node, int depth)
        {
            if (node.Board.IsResult())
                return node;

            if (depth > 0)
            {
                TreeNode tmp = new TreeNode();
                TreeNode tmp2 = new TreeNode();
                List<ChessBoard> chessBoards = node.Board.MakeSuccessorsList();
                for (int i = 0; i < chessBoards.Count; i++)
                {
                    tmp = node.Add(chessBoards[i], i);
                    tmp2 = DLS(tmp, depth - 1);
                    if (tmp2 != null) return tmp2;
                }
            }
            return null;

            /*TreeNode tmp = new TreeNode();
            TreeNode tmp2 = new TreeNode();
            List<ChessBoard> chessBoards = node.Board.MakeSuccessorsList();

            for (int i = 0; i < chessBoards.Count; i++)
            {
                tmp = node.Add(chessBoards[i], i);
                tmp2 = DLS(tmp, depth - 1);
                if (tmp2 != null) return tmp2;
            }

            return null;*/
        }

        private static double GetOperationTime(DateTime time)
        {
            DateTime time2 = DateTime.Now;
            TimeSpan timeDiff = time2 - time;
            double operTime = timeDiff.TotalMilliseconds;
            return operTime;
        }
    }
}
