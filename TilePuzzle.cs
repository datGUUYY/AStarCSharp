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

        public void insertMoves(List<int> target) //TODO test if Collection is a valid type
        {
            //TODO: refactor into generic //didnt need to do?
            
            int empty = GetEmpty();
            if (empty > 2) target.Add(empty - 3);
            if (empty % 3 > 0) target.Add(empty - 1);
            if (empty < 6) target.Add(empty + 3);
            if (empty % 3 < 2) target.Add(empty + 1);
        }

        public int GetEmpty()
        {
            for (int i = 0; i < body.GetLength(0) * body.GetLength(1); i++)
            {
                if (body[i / body.GetLength(1), i % body.GetLength(1)] == 0)
                    return i;
            }
            throw new InvalidOperationException("Empty tile not found.");
        }

        public void takeMove(int i)
        {
            int empty = GetEmpty();
            int inner = body.GetLength(1);
            body[empty / inner, empty % inner] = body[i / inner, i % inner];
            body[i / inner, i % inner] = 0;
        }
    }
}