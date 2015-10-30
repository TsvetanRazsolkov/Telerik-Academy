## Data Structures, Algorithms and Complexity Homework

1. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the array's size is `n`.

  ```cs
  long Compute(int[] arr)
  {
      long count = 0;
      for (int i=0; i<arr.Length; i++)
      {
          int start = 0, end = arr.Length-1;
          while (start < end)
              if (arr[start] < arr[end])
                  { start++; count++; }
              else 
                  end--;
      }
      return count;
  }
  ```
  O(n <sup>2</sup>) - the outer loop will run through all the elements of the array, and for each one the inner will run again through all the elements of the array.

2. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcCount(int[,] matrix)
  {
      long count = 0;
      for (int row=0; row<matrix.GetLength(0); row++)
          if (matrix[row, 0] % 2 == 0)
              for (int col=0; col<matrix.GetLength(1); col++)
                  if (matrix[row,col] > 0)
                      count++;
      return count;
  }
  ```
  n*m - the outer loop will be executed n-times. For each row if the element at column 0 is even the inner loop will be executed m-times. Worst-case scenario - n*m. Bes-case scenario which is rarely relevant - O(n) - linear complexity, we discard that one. Average-case - n*m/2, in which case we can neglect the constant, so the number of operations of the code above can be said to be n*m (O(n <sup>2</sup>));

3. **(*) What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcSum(int[,] matrix, int row)
  {
      long sum = 0;
      for (int col = 0; col < matrix.GetLength(0); col++) 
          sum += matrix[row, col];
      if (row + 1 < matrix.GetLength(1)) 
          sum += CalcSum(matrix, row + 1);
      return sum;
  }
  
  Console.WriteLine(CalcSum(matrix, 0));
  ```
  n*m - with the remark, that the code above is valid only when n = m и  raw <= m-1. If not an IndexOutOfRangeException will be thrown. The cicle will be executed n-times, and the method itself will be called recursively m-times, so n*m  - O(n <sup>2</sup>) complexity.
