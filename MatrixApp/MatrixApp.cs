using System;
using MatrixLibrary;
using MatrixApp.Resources;

namespace Program
{
    class MatrixApp
    {
        static void Main()
        {
            Console.WriteLine(Message.WelcomeMessage);
            try
            {
                InteractionsWithUser interactionsWithUser = new InteractionsWithUser(3);
                int columns = interactionsWithUser.GetNumberFromUser(Message.InputColumns);
                int rows = interactionsWithUser.GetNumberFromUser(Message.InputRows);

                Matrix matrix = new MatrixFiller().FillMatrixByGradualNumbers(new Matrix(rows, columns));

                MatrixRenderer matrixRenderer = new MatrixRenderer();
                matrixRenderer.RenderMatrix(matrix);

                MatrixLikeSnakeRenderer matrixLikeSnakeRenderer = new MatrixLikeSnakeRenderer();
                matrixLikeSnakeRenderer.RenderMatrixLikeSnake(matrix);

                Console.WriteLine(Message.TraceResult, matrix.GetTrace());
            }
            catch (Exception ex)
            {
                if (ex is AttemptsExhaustedException || ex is ArgumentOutOfRangeException)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    Console.WriteLine("An unexpected error has occurred. Restart the program and try again.");
                }
            }
        }
    }
}
