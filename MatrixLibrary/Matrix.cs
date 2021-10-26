using System;

namespace MatrixLibrary
{
    public class Matrix
    {
        private const int MinimalMatrixDimension = 1;
        private const int MaximumMatrixDimension = 2146435071;
        private const double MaximumMatrixLength = 4000000000;

        public int Rows { get; }
        public int Columns { get; }
        public int Length { get; }
        public int this[int row, int column]
        {
            set
            {
                _matrix[row, column] = value;
            }
            get
            {
                return _matrix[row, column];
            }
        }
        private int[,] _matrix;

        public Matrix (int rows, int columns)
        {
            CheckRange(rows, "rows");
            CheckRange(columns, "columns");
            if ((double)rows * columns > MaximumMatrixLength)
            {
                throw new ArgumentOutOfRangeException($"Matrix length is {(long)rows * columns}", $"Total number of matrix cells must be less than {MaximumMatrixLength}");
            }
            _matrix = new int[rows, columns];
            Rows = rows;
            Columns = columns;
            Length = rows * columns;
        }

        public int GetTrace()
        {
            int result = 0;
            for (int i = 0; i < Math.Min(Rows, Columns); i++)
            {
                result += _matrix[i, i];
            }
            return result;
        }

        internal void CheckRange(int number, string type)
        {
            if (number < MinimalMatrixDimension || number > MaximumMatrixDimension)
            {
                throw new ArgumentOutOfRangeException(type, number.ToString(), $"Unacceptabel value. Minimal of each dimensions of matrix is {MinimalMatrixDimension} and maximum is {MaximumMatrixDimension}");
            }
        }
    }
}
