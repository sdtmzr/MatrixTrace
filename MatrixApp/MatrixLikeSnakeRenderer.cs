using System;
using MatrixLibrary;
using MatrixApp.Resources;

namespace Program
{
    public class MatrixLikeSnakeRenderer
    {
        public void RenderMatrixLikeSnake(Matrix matrix)
        {
            if (CheckRenderCondition(matrix))
            {
                int[] array = new SnakeAlgorithm().GetMatrixBySnakeStyle(matrix);
                string result = String.Join(" ", array);
                Console.WriteLine(Message.SnakeStyle, result);
            }
        }

        internal bool CheckRenderCondition(Matrix matrix)
        {
            return matrix.Length <= (Console.WindowWidth / 3) - 5 ? true : false;
        }
    }
}
