namespace CompareAdvancedMaths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class AdvancedMathTesting
    {
        private const float FloatTestValue = 42.0f;
        private const double DoubleTestValue = 42.0;
        private const decimal DecimalTestValue = 42.0M;
        private const int OperationsCount = 1000000;
        private const int NumberOfTests = 10;

        private static readonly Stopwatch StopWatch = new Stopwatch();
        
        public static void Main()
        {
            string separator = new string('=', 40);

            TestFloatOperations();
            Console.WriteLine(separator);
            TestDoubleOperations();
            Console.WriteLine(separator);
            TestDecimalOperations();
        }

        private static void TestFloatOperations()
        {
            Console.WriteLine("Float ({0} operations) - average of {1} runs:", OperationsCount, NumberOfTests);

            // Math.Sqrt():
            float testValue = 0.0f;
            var resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = (float)Math.Sqrt(FloatTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Sqrt() - {0} milliseconds", resultsList.Average());

            // Math.Log():
            resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = (float)Math.Log(FloatTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Log() - {0} milliseconds", resultsList.Average());

            // Math.Sin():
            resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = (float)Math.Sin(FloatTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Sin() - {0} milliseconds", resultsList.Average());
        }

        private static void TestDoubleOperations()
        {
            Console.WriteLine("Double ({0} operations) - average of {1} runs:", OperationsCount, NumberOfTests);

            // Math.Sqrt():
            double testValue = 0.0;
            var resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = Math.Sqrt(DoubleTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Sqrt() - {0} milliseconds", resultsList.Average());

            // Math.Log():
            resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = Math.Log(DoubleTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Log() - {0} milliseconds", resultsList.Average());

            // Math.Sin():
            resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = Math.Sin(DoubleTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Sin() - {0} milliseconds", resultsList.Average());
        }

        private static void TestDecimalOperations()
        {
            Console.WriteLine("Decimal ({0} operations) - average of {1} runs:", OperationsCount, NumberOfTests);

            // Math.Sqrt():
            decimal testValue = 0.0M;
            var resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = (decimal)Math.Sqrt((double)DecimalTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Sqrt() - {0} milliseconds", resultsList.Average());

            // Math.Log():
            resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = (decimal)Math.Log((double)DecimalTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Log() - {0} milliseconds", resultsList.Average());

            // Math.Sin():
            resultsList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValue = (decimal)Math.Sin((double)DecimalTestValue);
                }

                StopWatch.Stop();
                resultsList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Math.Sin() - {0} milliseconds", resultsList.Average());
        }
    }
}
