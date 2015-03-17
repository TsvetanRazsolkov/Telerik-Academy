namespace InfiniteConvergentSeries
{
    using System;

    public class InfiniteConvergentSeries
    {
        private const double precision = 0.01;

        public static double CalculateConvergentSeries(double precision, Func<double, double> Calculate)
        {
            double result = Calculate(precision);

            return result;
        }

        static void Main()
        {
            Func<double, double> firstDelegate = CalculateFirstSeries;
            double firstSeries = CalculateConvergentSeries(precision, firstDelegate);
            Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + ... = {0:F2}", firstSeries);

            Func<double, double> secondDelegate = CalculateSecondSeries;
            double secondSeries = CalculateConvergentSeries(precision, secondDelegate);
            Console.WriteLine("1 + 1/2! + 1/3! + 1/4! + 1/5! + ... = {0:F2}", secondSeries);

            Func<double, double> thirdDelegate = CalculateThirdSeries;
            double thirdSeries = CalculateConvergentSeries(precision, thirdDelegate);
            Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + ... = {0:F2}", thirdSeries);
        }

        private static double CalculateFirstSeries(double precision)
        {
            double result = 1;
            double previousResult = 0;
            int powerOfTwo = 1;
            while (result - previousResult > precision)
            {
                previousResult = result;
                result += 1.0 / TwoByPower(powerOfTwo);
                powerOfTwo++;
            }
            return result;
        }        

        private static double CalculateSecondSeries(double precision)
        {
            double result = 1;
            double previousResult = 0;
            int denominator = 2;
            while (result - previousResult > precision)
            {
                previousResult = result;
                result += (double)(1 / Factorial(denominator));
                denominator++;
            }
            return result;
        }       

        private static double CalculateThirdSeries(double precision)
        {
            double result = 1;
            double previousResult = 0;
            int powerOfTwo = 1;
            while (Math.Abs(result - previousResult) > precision)
            {
                previousResult = result;
                if (powerOfTwo % 2 == 0)
                {
                    result -= 1.0 / TwoByPower(powerOfTwo);
                }
                else
                {
                    result += 1.0 / TwoByPower(powerOfTwo);
                }                
                powerOfTwo++;
            }
            return result;
        }

        private static long TwoByPower(int powerOfTwo)
        {
            long result = 1;
            for (int i = 0; i < powerOfTwo; i++)
            {
                result *= 2;
            }
            return result;
        }

        private static decimal Factorial(int denominator)
        {
            decimal factorial = 1;
            for (int i = 1; i <= denominator; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
