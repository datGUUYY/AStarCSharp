using System;

namespace TilePuzzle
{
    public class EightPuzzle
    {
        public int[,] body = new int[3, 3]; 
        //I have no idea how the java version of this code worked.

        public EightPuzzle()
        {
            for (int i = 1; i < 9; i++)
            {
                body[i / 3, i % 3] = i;
            }
            body[2, 2] = 0;
        }

        public EightPuzzle(int[,] body)
        {
            this.body = new int[body.GetLength(0), body.GetLength(1)];
            for (int i = 0; i < body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    this.body[i, j] = body[i, j];
                }
            }
        }
    }
}