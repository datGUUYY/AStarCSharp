using System;
using System.Collections.Generic;

namespace TilePuzzle
{
    public class Solver
    {
        protected bool solved;
        public Solver()
        {
            int[,] start = { { 1, 5, 2 }, { 6, 3, 8 }, { 0, 7, 4 } };
            int[,] end = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            EightPuzzleStateNode origin = new EightPuzzleStateNode(start, end);
            open = new SortedSet<EightPuzzleStateNode>(new EightPuzzleStateNodeComparer());
            closed = new HashSet<EightPuzzleStateNode>();
            open.Add(origin);
            solved = false;
        }
        public void Solve()
        {
            
            while (open.Count > 0)
            {
                process();
                if (solved) break;
            }
        }
        public void process()
        {
            EightPuzzleStateNode current = open.First();
            open.Remove(current);
            List<EightPuzzleStateNode> temp = new List<EightPuzzleStateNode>();
            current.InsertChildren(temp);
            foreach (EightPuzzleStateNode child in temp)
            {
                if ( child.body.Rank == child.target.Rank &&
           Enumerable.Range(0, child.body.Rank).All(d => child.body.GetLength(d) == child.target.GetLength(d)) &&
           child.body.Cast<int>().SequenceEqual(child.target.Cast<int>())) 
                {   //TODO: make a function for the above line
                    printback(child);
                    solved = true;
                    break;
                }
                checkClosed(child);
            }
        }
        protected void checkClosed(EightPuzzleStateNode checknode)
        {
            foreach (EightPuzzleStateNode against in closed)
            {

                if (against.body.Rank == checknode.body.Rank &&
           Enumerable.Range(0, against.body.Rank).All(d => against.body.GetLength(d) == checknode.body.GetLength(d)) &&
           against.body.Cast<int>().SequenceEqual(checknode.body.Cast<int>()))
                {
                    if (checknode.DVal > against.DVal)
                    {
                        closed.Remove(against);
                        open.Add(checknode);
                    }
                    return;
                }
            }
            open.Add(checknode);
        }
        protected void printback(EightPuzzleStateNode printee)
        {
            Stack<EightPuzzleStateNode> outputStack = new Stack<EightPuzzleStateNode>();
            EightPuzzleStateNode current = printee;
            while (current != null)
            {
                outputStack.Push(current);
                current = current.parent;
            }
            while (outputStack.Count > 5)
            {
                EightPuzzleStateNode[] line = new EightPuzzleStateNode[5];
                for (int i = 0; i < 5; i++)
                    line[i] = outputStack.Pop();
                for (int i = 0; i < line[0].body.GetLength(0); i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        foreach (int x in GetRow(line[j].body,i)) 
                        {
                            Console.Write(x + " ");
                        }
                        Console.Write('\t');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            while (outputStack.Count != 0)
            {
                
                int[,] value = outputStack.Pop().body;
                // foreach (int[] a in value) 
                // {
                    foreach (int b in value)
                        Console.Write(b + " ");
                    Console.WriteLine();
                // }
                Console.WriteLine();
            }
        }
         public static int[] GetRow(int[,] array, int row) //TODO: Implement as top-level function
    {
        int cols = array.GetLength(1);
        int[] result = new int[cols];
        for (int i = 0; i < cols; i++)
        {
            result[i] = array[row, i];
        }
        return result;
    }
        private SortedSet<EightPuzzleStateNode> open;
        private HashSet<EightPuzzleStateNode> closed;
        
    public static void main(String []args)
	{
		Solver solver = new Solver();
		solver.Solve();
	}   
    }

    public class EightPuzzleStateNodeComparer : IComparer<EightPuzzleStateNode>
    {
        public int Compare(EightPuzzleStateNode o1, EightPuzzleStateNode o2)
        {
            return o1.GetValue() - o2.GetValue();
        }
    }



}

// public class EightPuzzleStateNode
// {
//     private int[,] start;
//     private int[,] end;

//     public EightPuzzleStateNode(int[,] start, int[,] end)
//     {
//         this.start = start;
//         this.end = end;
//     }

//     public int GetValue()
//     {
//         // Implementation of the GetValue method
//         return 0;
//     }
// }
