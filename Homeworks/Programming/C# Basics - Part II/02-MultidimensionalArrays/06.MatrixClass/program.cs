using System;

// Write a class Matrix, to hold a matrix of integers. Overload the operators
// for adding, subtracting and multiplying of matrices, indexer for 
// accessing the matrix content and ToString().

class Program
{
    static void Main()
    {
        Matrix firstMatrix = new Matrix(2, 2);
        firstMatrix[0, 0] = 3;
        firstMatrix[0, 1] = 3;
        firstMatrix[1, 0] = 3;
        firstMatrix[1, 1] = 4;
        Matrix secondMatrix = new Matrix(2, 2);
        secondMatrix[0, 0] = 3;
        secondMatrix[0, 1] = 3;
        secondMatrix[1, 0] = 3;
        secondMatrix[1, 1] = 4;

        Matrix sumMatrix = firstMatrix + secondMatrix;
        Console.WriteLine(firstMatrix.ToString() + "+" + Environment.NewLine + 
            secondMatrix.ToString() + "=" + Environment.NewLine +
            sumMatrix.ToString());

        Matrix subtractedMatrix = firstMatrix - secondMatrix;
        Console.WriteLine(firstMatrix.ToString() + "-" + Environment.NewLine +
            secondMatrix.ToString() + "=" + Environment.NewLine +
            subtractedMatrix.ToString());

        Matrix multipliedMatrix = firstMatrix * secondMatrix;
        Console.WriteLine(firstMatrix.ToString() + "*" + Environment.NewLine +
            secondMatrix.ToString() + "=" + Environment.NewLine +
            multipliedMatrix.ToString());
    }
}