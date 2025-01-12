using System;

namespace TilePuzzle
{
    public class EightPuzzleCloneable<T> : EightPuzzle where T : EightPuzzleCloneable<T>
    {
        public int[,] target = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        public T parent = null; //TODO: Make this protected

        public EightPuzzleCloneable(int[,] body, int[,] target) : base(body)
        {
            this.target = target;
        }

        public EightPuzzleCloneable(T parent)
        {
            this.body = new int[parent.body.GetLength(0), parent.body.GetLength(1)];
            for (int i = 0; i < parent.body.GetLength(0); i++)
            {
                for (int j = 0; j < parent.body.GetLength(1); j++)
                {
                    this.body[i, j] = parent.body[i, j];
                }
            }

            this.target = new int[parent.target.GetLength(0), parent.target.GetLength(1)];
            for (int i = 0; i < parent.target.GetLength(0); i++)
            {
                for (int j = 0; j < parent.target.GetLength(1); j++)
                {
                    this.target[i, j] = parent.target[i, j];
                }
            }
            this.parent = parent;
        }
        protected int manhattan()
	{
		int value = 0;
		for(int i = 0; i < target.GetLength(0); i++)
		{
			for(int j = 0; j < target.GetLength(1); j++)
			{
				int targetValue = target[i,j];
				for(int x = 0, y = 0; y < target.GetLength(0); x++)
				{
					y = (x >= target.GetLength(0)) ? y + 1: y;
					x = (x >= target.GetLength(0)) ? x % target.GetLength(0) : x;
					if(body[x,y] == targetValue)
					{
						value += Math.Abs(x - i) + Math.Abs(y - j);
						break;
					}
				}
					
			}
		}
		return value;
	}
    }
}