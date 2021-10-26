using System;
using MatrixLibrary;

namespace Program
{
    public class MatrixRenderer
    {
        public ConsoleColor foregroundColor;

        public ConsoleColor HighlightColor { get; set; } = ConsoleColor.Green;

        public void RenderMatrix(Matrix matrix)
        {
            if (CheckRenderCondition(matrix))
            {
                foregroundColor = Console.ForegroundColor;
                for (int i = 0; i < matrix.Rows; i++)
                {
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        Console.ForegroundColor = i == j ? HighlightColor : foregroundColor;
                        Console.Write($"{matrix[i, j]}\t");
                        Console.ForegroundColor = foregroundColor;
                    }
                    Console.WriteLine();
                }
            }
        }

        internal bool CheckRenderCondition (Matrix matrix)
        {
            return matrix.Columns <= Console.WindowWidth / 8 && matrix.Rows <= Console.WindowHeight - 10 ? true : false;
        }
    }
}
