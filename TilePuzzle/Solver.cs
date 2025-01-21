using System;
using System.Collections.Generic;

namespace TilePuzzle
{
    public class Solver
    {
        public bool Solved { get; protected set; }

        public Solver()
        {
            int[,] start = { { 1, 5, 2 }, { 6, 3, 8 }, { 0, 7, 4 } };
            int[,] end = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            EightPuzzleStateNode origin = new EightPuzzleStateNode(start, end);
            open = new SortedSet<EightPuzzleStateNode>(new EightPuzzleStateNodeComparer());
            closed = new HashSet<EightPuzzleStateNode>();
            open.Add(origin);
            Solved = false;
        }
        public void Solve()
        {
            while (open.Count > 0)
            {
                process();
                if (Solved) break;
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
                if (child.body.Rank == child.target.Rank &&
           Enumerable.Range(0, child.body.Rank).All(d => child.body.GetLength(d) == child.target.GetLength(d)) &&
           child.body.Cast<int>().SequenceEqual(child.target.Cast<int>()))
                {   //TODO: make a function for the above line
                    printback(child);
                    Solved = true;
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
                        foreach (int x in GetRow(line[j].body, i))
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

                foreach (int b in value)
                    Console.Write(b + " ");
                Console.WriteLine();
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
        //TODO: Friend assembly for testing
        public SortedSet<EightPuzzleStateNode> open {get; protected set;}
        public HashSet<EightPuzzleStateNode> closed {get; protected set;}


        //TODO: Separate into a different class that extends Solver
        public static void Main(String[] args)
        {
            Solver solver = new Solver();
            solver.Solve();
        }
    }

    public class EightPuzzleStateNodeComparer : IComparer<EightPuzzleStateNode>
    {
        public int Compare(EightPuzzleStateNode o1, EightPuzzleStateNode o2)
        {
            int value = o1.GetValue() - o2.GetValue();
            if(value == 0)
            {
                return o1.id.CompareTo(o2.id);
            }
            return value;
        }
    }



}