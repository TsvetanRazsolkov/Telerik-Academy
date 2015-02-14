using System;
using System.Text;

class Matrix
{
    // Privete field for the Matrix class:
    private int[,] matrix;

    // Constructor for the Matrix class:
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }
    // Public properties for the Matrix class:
    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }
    public int Cols
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }
    // Indexer for accessing the matrix content:
    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }
    // Operator for adding matrices:
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {        
        Matrix resultMatrix = new Matrix(matrix1.Rows, matrix1.Cols);
        if (matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols)
        {
            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Cols; col++)
                {
                    resultMatrix[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }
            return resultMatrix;
        }
        else
        {
            throw new ArgumentException("Invalid dimensions for adding matrices!");
        }        
    }
    // Operator for subtracting matrices:
    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        Matrix resultMatrix = new Matrix(matrix1.Rows, matrix1.Cols);
        if (matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols)
        {            
            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Cols; col++)
                {
                    resultMatrix[row, col] = matrix1[row, col] - matrix2[row, col];
                }
            }
            return resultMatrix;
        }
        else
        {
            throw new ArgumentException("Invalid dimensions for subtracting matrices!");
        }        
    }
    // Operator for multiplying matrices:
    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {        
        Matrix resultMatrix = new Matrix(matrix1.Rows, matrix2.Cols);
        if (matrix1.Rows == matrix2.Cols && matrix1.Cols == matrix2.Rows)
        {
            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix2.Cols; col++)
                {
                    resultMatrix[row, col] = 0;
                    for (int i = 0; i < matrix1.Cols; i++)
                    {
                        resultMatrix[row, col] += matrix1[row, i] * matrix2[i, col];
                    }
                }
            }
            return resultMatrix;
        }
        else
        {
            throw new ArgumentException("Invalid dimensions for multiplying matrices!");
        }        
    }
    // Override of the ToString() method:
    public override string ToString()
    {
        string result;
        StringBuilder builder = new StringBuilder();
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Cols; col++)
            {
                builder.Append(matrix[row, col]);
                builder.Append("  ");
            }
            builder.Append(Environment.NewLine);
        }
        result = builder.ToString();
        return result;
    }
}