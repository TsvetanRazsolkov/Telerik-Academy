namespace Matrix
{
    using System;

    class MatrixTest
    {
        private static readonly string separator = new string('-', Console.WindowWidth);

        static void Main()
        {
            // Testing the bool operators true and false:
            Matrix<int> matr = new Matrix<int>(2,2);
            Console.WriteLine("Testing the bool operators true and false:");
            Console.WriteLine(matr);
            if (matr)
            {
                Console.WriteLine("True - there are non-zero elements.");
            }
            else
            {
                Console.WriteLine("False - there are no non-zero elements.");
            }
            Console.WriteLine();

            // Testing matrix arithmetic operators +, -, * :
            Console.WriteLine("Testing arithmetic operators +, -, * :");
            Matrix<int> firstMatrix = new Matrix<int>(2, 2);
            firstMatrix[0, 0] = 3;
            firstMatrix[0, 1] = 3;
            firstMatrix[1, 0] = 3;
            firstMatrix[1, 1] = 4;
            Matrix<int> secondMatrix = new Matrix<int>(2, 2);
            secondMatrix[0, 0] = 3;
            secondMatrix[0, 1] = 3;
            secondMatrix[1, 0] = 3;
            secondMatrix[1, 1] = 4;

            Matrix<int> sumMatrix = firstMatrix + secondMatrix;
            Console.WriteLine(firstMatrix + "+" + Environment.NewLine +
                secondMatrix + "=" + Environment.NewLine +
                sumMatrix);
            Console.WriteLine(separator);

            Matrix<int> subtractedMatrix = firstMatrix - secondMatrix;
            Console.WriteLine(firstMatrix + "-" + Environment.NewLine +
                secondMatrix + "=" + Environment.NewLine +
                subtractedMatrix);
            Console.WriteLine(separator);

            Matrix<int> multipliedMatrix = firstMatrix * secondMatrix;
            Console.WriteLine(firstMatrix + "*" + Environment.NewLine +
                secondMatrix + "=" + Environment.NewLine +
                multipliedMatrix);
        }
    }
}
