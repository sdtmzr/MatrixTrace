using System;

namespace MatrixLibrary
{
    public class MatrixFiller
    {
        public Matrix FillMatrixByRandomNumbers(Matrix matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i,j] = rand.Next(1, 101);
                }
            }
            return matrix;
        }

        public Matrix FillMatrixByGradualNumbers(Matrix matrix)
        {
            int n = 1;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = n++;
                }
            }
            return matrix;
        }
    }
}
