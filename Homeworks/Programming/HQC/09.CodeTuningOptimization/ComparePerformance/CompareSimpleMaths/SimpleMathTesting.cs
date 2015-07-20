namespace CompareSimpleMaths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class SimpleMathTesting
    {
        private const int IntTestValue = 1;
        private const long LongTestValue = 1L;
        private const float FloatTestValue = 1.000001f;
        private const double DoubleTestValue = 1.000001;
        private const decimal DecimalTestValue = 1.000001M;
        private const int OperationsCount = 1000000;
        private const int NumberOfTests = 10;

        private static readonly Stopwatch StopWatch = new Stopwatch();

        public static void Main()
        {
            // No quality code in this assignment. Refactor later.
            string separator = new string('=', 40);
            TestIntOperations();
            Console.WriteLine(separator);
            TestLongOperations();
            Console.WriteLine(separator);
            TestFloatOperations();
            Console.WriteLine(separator);
            TestDoubleOperations();
            Console.WriteLine(separator);
            TestDecimalOperations();
        }

        private static void TestIntOperations()
        {
            Console.WriteLine("Int32 ({0} operations) - average of 10 runs: ", OperationsCount);

            // Addition:
            int testIntValue = IntTestValue;
            var resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testIntValue += IntTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Addition - {0} milliseconds", resultList.Average());

            // Subtraction:
            testIntValue = OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testIntValue -= IntTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Subtraction - {0} milliseconds", resultList.Average());

            // Increment:
            testIntValue = IntTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testIntValue++;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Increment - {0} milliseconds", resultList.Average());

            // Multiply:
            testIntValue = IntTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testIntValue *= IntTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Multiplication - {0} milliseconds", resultList.Average());

            // Divide:
            testIntValue = OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testIntValue /= IntTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Division - {0} milliseconds", resultList.Average());
        }

        private static void TestLongOperations()
        {
            Console.WriteLine("Long ({0} operations) - average of 10 runs: ", OperationsCount);

            // Addition:
            long testValueLong = LongTestValue;
            var resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueLong += LongTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Addition - {0} milliseconds", resultList.Average());

            // Subtraction:
            testValueLong = OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueLong -= LongTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Subtraction - {0} milliseconds", resultList.Average());

            // Increment:
            testValueLong = LongTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueLong++;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Increment - {0} milliseconds", resultList.Average());

            // Multiply:
            testValueLong = LongTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueLong *= LongTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Multiplication - {0} milliseconds", resultList.Average());

            // Divide:
            testValueLong = OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueLong /= LongTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Division - {0} milliseconds", resultList.Average());
        }

        private static void TestFloatOperations()
        {
            Console.WriteLine("Float ({0} operations) - average of 10 runs: ", OperationsCount);

            // Addition:
            float testValueFloat = FloatTestValue;
            var resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueFloat += FloatTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Addition - {0} milliseconds", resultList.Average());

            // Subtraction:
            testValueFloat = (float)OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueFloat -= FloatTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Subtraction - {0} milliseconds", resultList.Average());

            // Increment:
            testValueFloat = FloatTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueFloat++;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Increment - {0} milliseconds", resultList.Average());

            // Multiply:
            testValueFloat = FloatTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueFloat *= FloatTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Multiplication - {0} milliseconds", resultList.Average());

            // Divide:
            testValueFloat = (float)OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueFloat /= FloatTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Division - {0} milliseconds", resultList.Average());
        }

        private static void TestDoubleOperations()
        {
            Console.WriteLine("Double ({0} operations) - average of 10 runs: ", OperationsCount);

            // Addition:
            double testValueDouble = DoubleTestValue;
            var resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDouble += DoubleTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Addition - {0} milliseconds", resultList.Average());

            // Subtraction:
            testValueDouble = (double)OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDouble -= DoubleTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Subtraction - {0} milliseconds", resultList.Average());

            // Increment:
            testValueDouble = DoubleTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDouble++;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Increment - {0} milliseconds", resultList.Average());

            // Multiply:
            testValueDouble = DoubleTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDouble *= DoubleTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Multiplication - {0} milliseconds", resultList.Average());

            // Divide:
            testValueDouble = (double)OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDouble /= DoubleTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Division - {0} milliseconds", resultList.Average());
        }

        private static void TestDecimalOperations()
        {
            Console.WriteLine("Decimal ({0} operations) - average of 10 runs: ", OperationsCount);

            // Addition:
            decimal testValueDecimal = DecimalTestValue;
            var resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDecimal += DecimalTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Addition - {0} milliseconds", resultList.Average());

            // Subtraction:
            testValueDecimal = (decimal)OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDecimal -= DecimalTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Subtraction - {0} milliseconds", resultList.Average());

            // Increment:
            testValueDecimal = DecimalTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDecimal++;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Increment - {0} milliseconds", resultList.Average());

            // Multiply:
            testValueDecimal = DecimalTestValue;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDecimal *= DecimalTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Multiplication - {0} milliseconds", resultList.Average());

            // Divide:
            testValueDecimal = (decimal)OperationsCount;
            resultList = new List<long>();
            for (int i = 0; i < NumberOfTests; i++)
            {
                StopWatch.Start();
                for (int j = 0; j < OperationsCount; j++)
                {
                    testValueDecimal /= DecimalTestValue;
                }

                StopWatch.Stop();
                resultList.Add(StopWatch.ElapsedMilliseconds);
                StopWatch.Reset();
            }

            Console.WriteLine("Division - {0} milliseconds", resultList.Average());
        }
    }
}
