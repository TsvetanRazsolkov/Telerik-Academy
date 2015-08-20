namespace RotatingWalkInMatrix
{
    internal static class Validator
    {
        private const int MinMatrixSize = 1;
        private const int MaxMatrixSize = 100;

        internal static bool NumberIsInRange(int number)
        {
            var inRange = MinMatrixSize <= number && number <= MaxMatrixSize;

            return inRange;
        }
    }
}
