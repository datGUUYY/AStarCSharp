
using System.Collections.Generic;

namespace TilePuzzle
{
    public interface IStateNode<t>
    {
        int GetValue();
        void SetHVal();
        void SetDVal();
        void InsertChildren(ICollection<t> target);
    }

    public class EightPuzzleStateNode : EightPuzzleCloneable<EightPuzzleStateNode>, IStateNode<EightPuzzleStateNode>
    {
        protected int HVal;
        public int DVal; //TODO: Make this protected, replace with accessor
        public Guid id {get;} = Guid.NewGuid();
        public EightPuzzleStateNode(EightPuzzleStateNode parent) : base(parent)
        {
        }

        public EightPuzzleStateNode(int[,] body, int[,] target) : base(body, target)
        {
        }

        public void SetHVal()
        {
            HVal = manhattan();
        }

        public void SetDVal()
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
                newState.takeMove(move);
                newState.SetDVal();
                newState.SetHVal();
                target.Add(newState);
            }
        }
    }
}


