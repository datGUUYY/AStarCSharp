
using System.Collections.Generic;

namespace TilePuzzleBusinessLogic
{
    public interface IStateNode<t>
    {
        int GetValue();
        void CalcHeuristicValue();
        void CalcDepthValue();
        void InsertChildren(ICollection<t> target);
    }

    public class EightPuzzleStateNode : EightPuzzleCloneable<EightPuzzleStateNode>, IStateNode<EightPuzzleStateNode>
    {
        public int HVal { get; protected set; }
        public int DVal; //TODO: Make this protected, replace with accessor
        public Guid id {get;} = Guid.NewGuid();
        public EightPuzzleStateNode(EightPuzzleStateNode parent) : base(parent)
        {
        }

        public EightPuzzleStateNode(int[,] body, int[,] target) : base(body, target)
        {
        }

        public void CalcHeuristicValue()
        {
            HVal = manhattan();
        }

        public void CalcDepthValue()
        {
            DVal = (parent != null) ? parent.DVal + 1 : 0;
        }

        public int GetValue()
        {
            return HVal + DVal;
        }



        public void InsertChildren(ICollection<EightPuzzleStateNode> target)
        {
            // Takes a given state of the eight puzzle and generates a new state for all possible moves from that state.
        
            List<int> moves = new List<int>();
            insertMoves(moves);
            foreach (int move in moves)
            {
                EightPuzzleStateNode newState = new EightPuzzleStateNode(this);
                newState.TakeMove(move);
                newState.CalcDepthValue();
                newState.CalcHeuristicValue();
                target.Add(newState);
            }
        }
    }
}


