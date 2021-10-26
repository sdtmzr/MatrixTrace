using System;
using Xunit;
using MatrixLibrary;

namespace MatrixLibraryTests
{
    public class MatrixTest
    {
        [Theory]
        [InlineData(5, 5, 65)]
        [InlineData(10, 3, 15)]
        [InlineData(3, 10, 36)]
        [InlineData(5, 1, 1)]
        [InlineData(1, 5, 1)]
        public void TraceOfMatrix(int rows, int columns, int result)
        {
            Matrix matrix = new MatrixFiller().FillMatrixByGradualNumbers(new Matrix(rows, columns));

            var trace = matrix.GetTrace();

            Assert.Equal(result, trace);
        }

        [Theory]
        [InlineData(-5, 5)]
        [InlineData(0, 3)]
        [InlineData(2146435072, 1)]
        public void InputDataRowOutOfRange(int rows, int columns)
        {
            ArgumentOutOfRangeException exception = new ArgumentOutOfRangeException("rows", rows.ToString(), "Unacceptabel value. Minimal of each dimensions of matrix is 1 and maximum is 2146435071");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Matrix(rows, columns));

            Assert.Equal(ex.Message, exception.Message);
        }

        [Theory]
        [InlineData(5, -5)]
        [InlineData(3, 0)]
        [InlineData(1, 2146435072)]
        public void InputDataColumnOutOfRange(int rows, int columns)
        {
            ArgumentOutOfRangeException exception = new ArgumentOutOfRangeException("columns", columns.ToString(), "Unacceptabel value. Minimal of each dimensions of matrix is 1 and maximum is 2146435071");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Matrix(rows, columns));

            Assert.Equal(ex.Message, exception.Message);
        }

        [Fact]
        public void LengthOfMatrixIsTooMuch()
        {
            int rows = 2;
            int columns = 2146435071;
            ArgumentOutOfRangeException exception = new ArgumentOutOfRangeException($"Matrix length is {(long)rows * columns}", "Total number of matrix cells must be less than 4000000000");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Matrix(rows, columns));

            Assert.Equal(ex.Message, exception.Message);
        }
    }
}
