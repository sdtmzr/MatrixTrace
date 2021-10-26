using Xunit;
using MatrixLibrary;

namespace MatrixLibraryTests
{
    public class SnakeAlgorithmTest
    {
        [Fact]
        public void SnakeStyleAlgorithmTest()
        {
            Matrix matrix = new MatrixFiller().FillMatrixByGradualNumbers(new Matrix(5, 5));
            int[] expected = { 1, 2, 3, 4, 5, 10, 15, 20, 25, 24, 23, 22, 21, 16, 11, 6, 7, 8, 9, 14, 19, 18, 17, 12, 13 };

            int[] result = new SnakeAlgorithm().GetMatrixBySnakeStyle(matrix);

            Assert.Equal(expected, result);
        }
    }
}
