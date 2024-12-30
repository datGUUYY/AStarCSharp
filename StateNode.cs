
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
            // Implementation of InsertChildren method
        }
    }
}


