using System;

namespace MatrixLibrary
{
    public class SnakeAlgorithm
    {
        public int[] GetMatrixBySnakeStyle(Matrix matrix)
        {
            const int LengthCorrector = 1;
            const bool NeedReverse = true;
            const bool NoReverse = false;
            int cycle = 0;
            int counter = 0;
            int startCutter = 1;
            int endCutter = 0;
            int[] array = new int[matrix.Length];
            AddRow(matrix, 0, 0, 0, counter, NoReverse, array);
            counter += matrix.Columns;
            do
            {
                counter = (AddColumn(matrix, matrix.Columns - cycle - LengthCorrector, startCutter, endCutter, counter, NoReverse, array));
                counter = (AddRow(matrix, matrix.Rows - cycle - LengthCorrector, startCutter, endCutter, counter, NeedReverse, array));
                endCutter++;
                counter = (AddColumn(matrix, cycle, startCutter, endCutter, counter, NeedReverse, array));
                cycle++;
                counter = (AddRow(matrix, cycle, startCutter, endCutter, counter, NoReverse, array));
                startCutter++;
            } while (counter < matrix.Length);
            return array;
        }

        internal int AddRow(Matrix matrix, int rowNumber, int startCutter, int endCutter, int counter, bool reverseFlag, int[] resultRow)
        {
            if (counter < matrix.Length)
            {
                int[] row = new int[matrix.Columns];
                for (int i = 0; i < matrix.Columns; i++)
                {
                    row[i] = matrix[rowNumber, i];
                }
                if (reverseFlag)
                {
                    Array.Reverse(row);
                }
                Array.Copy(row, startCutter, resultRow, counter, row.Length - startCutter - endCutter);
                return counter += row.Length - startCutter - endCutter;
            }
            return counter;
        }

        internal int AddColumn(Matrix matrix, int columnNumber, int startCutter, int endCutter, int counter, bool reverseFlag, int[] resultColumn)
        {
            if (counter < matrix.Length)
            {
                int[] column = new int[matrix.Rows];
                for (int i = 0; i < matrix.Rows; i++)
                {
                    column[i] = matrix[i, columnNumber];
                }
                if (reverseFlag)
                {
                    Array.Reverse(column);
                }
                Array.Copy(column, startCutter, resultColumn, counter, column.Length - startCutter - endCutter);
                return counter += column.Length - startCutter - endCutter;
            }
            return counter;
        }
    }
}
