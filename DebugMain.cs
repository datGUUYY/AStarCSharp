namespace TilePuzzle
{
    public class DebugSolver : Solver
    {
        private int count = 0;
        private List<int[,]> checkTemp;


        public DebugSolver() : base()
        {
            checkTemp = new List<int[,]>();
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 8 }, { 0, 7, 4 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 8 }, { 7, 0, 4 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 8 }, { 7, 4, 0 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 0 }, { 7, 4, 8 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 0, 3 }, { 7, 4, 8 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 4, 3 }, { 7, 0, 8 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 4, 3 }, { 7, 8, 0 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 8 }, { 7, 4, 0 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 4, 3 }, { 7, 0, 8 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 4, 3 }, { 7, 8, 0 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 0, 6, 3 }, { 7, 4, 8 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 0 }, { 7, 4, 8 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 8 }, { 7, 0, 4 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 3, 8 }, { 7, 4, 0 } });

            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 4, 0 }, { 7, 8, 3 } });
            checkTemp.Add(new int[,] { { 1, 5, 2 }, { 6, 4, 3 }, { 7, 8, 0 } });
        }

        public void process()
        {
            EightPuzzleStateNode current = open.First();
            checkAgainstJava(current.body);
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
                    solved = true;
                    break;
                }
                checkClosed(child);
            }
        }
        public static void Main(string[] args)
        {
            DebugSolver solver = new DebugSolver();
            solver.Solve();
        }

           public void Solve()
        {

            while (open.Count > 0)
            {
                process();
                if (solved) break;
            }
        }

        private void checkAgainstJava(int[,] current)
        {
            //Compare to the temp list in the currently working java implementation
            int[,] checkCurrent = checkTemp[count];
            if (current.Rank != checkCurrent.Rank || Enumerable.Range(0, current.Rank).All(d => current.GetLength(d) != checkCurrent.GetLength(d)) || !current.Cast<int>().SequenceEqual(checkCurrent.Cast<int>()))
            {
                Console.WriteLine("Error: " + count);
            }
            count++;
        }
    }

}