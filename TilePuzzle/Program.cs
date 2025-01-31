

namespace TilePuzzle
{
      public class Program : Solver //TODO: rename?
    {
        //TODO: Move default constructor and other methods from base class to this class.
        public Program() : base()
        {
        }
        public static void Main(String [] args)
        {
            Program solver = new Program();
            solver.Solve();
        }
    }
}