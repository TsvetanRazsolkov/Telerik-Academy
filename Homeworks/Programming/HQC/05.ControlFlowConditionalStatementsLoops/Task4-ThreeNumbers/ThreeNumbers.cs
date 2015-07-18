namespace ThreeNumbers
{
    using System;

    public class ThreeNumbers
    {
        public static void Main()
        {
            int firstNumber;
            bool isFirstNumberValid = int.TryParse(Console.ReadLine(), out firstNumber);
            int secondNumber;
            bool isSecondNumberValid = int.TryParse(Console.ReadLine(), out secondNumber);
            int thirdNumber;
            bool isThirdNumberValid = int.TryParse(Console.ReadLine(), out thirdNumber);

            ValidateInput(isFirstNumberValid, isSecondNumberValid, isThirdNumberValid);

            int biggestNumber = FindBiggestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(biggestNumber);

            int smallestNumber = FindSmallestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(smallestNumber);

            double average = FindAverageOfNumbers(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine("{0:F2}", average);
        }

        private static double FindAverageOfNumbers(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Parameter must be a not empty integer array.");
            }

            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            double average = sum / numbers.Length;

            return average;
        }

        private static int FindSmallestNumber(params int[] numbers)
        {
            int smallestNumber = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < smallestNumber)
                {
                    smallestNumber = numbers[i];
                }
            }

            return smallestNumber;
        }

        private static int FindBiggestNumber(params int[] numbers)
        {
            int biggestNumber = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > biggestNumber)
                {
                    biggestNumber = numbers[i];
                }
            }

            return biggestNumber;
        }

        private static void ValidateInput(params bool[] areInputsValid)
        {
            foreach (var isInputValid in areInputsValid)
            {
                if (!isInputValid)
                {
                    throw new ArgumentException("Input values should be 32 bit integers");
                }
            }
        }
    }
}
