namespace Matrix
{
    using System;
    using System.Text;

    class Matrix<T> where T : struct, IComparable
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[this.Rows, this.Cols];
        }

        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Either size of the matrix cannot be less than 1");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Either size of the matrix cannot be less than 1");
                }
                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                CheckIndices(row, col);
                return this.matrix[row, col];
            }
            set
            {
                CheckIndices(row, col);
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            if (matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols)
            {
                for (int row = 0; row < matrix1.Rows; row++)
                {
                    for (int col = 0; col < matrix1.Cols; col++)
                    {
                        resultMatrix[row, col] = (dynamic)matrix1[row, col] + matrix2[row, col];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new InvalidOperationException("Invalid dimensions for adding matrices!");
            }
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            if (matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols)
            {
                for (int row = 0; row < matrix1.Rows; row++)
                {
                    for (int col = 0; col < matrix1.Cols; col++)
                    {
                        resultMatrix[row, col] = (dynamic)matrix1[row, col] - matrix2[row, col];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new InvalidOperationException("Invalid dimensions for subtracting matrices!");
            }
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> resultMatrix = new Matrix<T>(matrix1.Rows, matrix2.Cols);

            if (matrix1.Rows == matrix2.Cols && matrix1.Cols == matrix2.Rows)
            {
                for (int row = 0; row < matrix1.Rows; row++)
                {
                    for (int col = 0; col < matrix2.Cols; col++)
                    {
                        resultMatrix[row, col] = default(T);
                        for (int i = 0; i < matrix1.Cols; i++)
                        {
                            resultMatrix[row, col] += (dynamic)matrix1[row, i] * matrix2[i, col];
                        }
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new InvalidOperationException("Invalid dimensions for multiplying matrices!");
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0) // Check for non-zero elements;
                    {
                        return true;
                    }                    
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0) // Check for non-zero elements;
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            string result;
            StringBuilder builder = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    builder.AppendFormat("{0, -5}", matrix[row, col]);
                }
                builder.Append(Environment.NewLine);
            }
            result = builder.ToString();
            return result;
        }

        private void CheckIndices(int row, int col)
        {
            if (row >= this.matrix.GetLength(0) || row < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (col >= this.matrix.GetLength(1) || col < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
