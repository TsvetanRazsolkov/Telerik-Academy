namespace EnigmaCat
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class EnigmaCat
    {
        private const int FromBase = 17;
        private const int ToBase = 26;
        private const char FirstDigitInBase17NumSystem = 'a';
        private const char FirstDigitInBase26NumSystem = 'a';

        public static void Main()
        {
            string input = Console.ReadLine();

            string[] numbers = input.Split(' ');

            List<string> resultList = ConvertFromBaseToBase(numbers, FromBase, ToBase);
            Console.WriteLine(string.Join(" ", resultList));
        }

        private static List<string> ConvertFromBaseToBase(string[] numbers, int fromBase, int toBase)
        {
            var resultList = new List<string>();
            string currentNumber = string.Empty;
            string result = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentNumber = numbers[i];
                BigInteger decNumber = ConvertToDecimal(currentNumber, fromBase);
                result = ConvertFromDecimal(decNumber, toBase);
                resultList.Add(result);
            }

            return resultList;
        }

        private static string ConvertFromDecimal(BigInteger decNumber, int targetBase)
        {
            if (decNumber == 0)
            {
                return FirstDigitInBase26NumSystem.ToString();
            }

            string result = string.Empty;
            BigInteger numberInDecimal = decNumber;
            while (numberInDecimal > 0)
            {
                int remainder = (int)(numberInDecimal % targetBase);
                char currentDigitInTargetBase = (char)(remainder + FirstDigitInBase26NumSystem);
                result = currentDigitInTargetBase + result;

                numberInDecimal /= targetBase;
            }

            return result;
        }

        private static BigInteger ConvertToDecimal(string number, int originalBase)
        {
            BigInteger decNumber = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int digitPosition = number.Length - 1 - i;
                char currentDigit = number[i];
                int charCodeOfCurrentDigit = currentDigit - FirstDigitInBase26NumSystem;
                decNumber += charCodeOfCurrentDigit * BaseByPower(originalBase, digitPosition);
            }

            return decNumber;
        }

        private static BigInteger BaseByPower(int numberBase, int power)
        {
            BigInteger result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= numberBase;
            }

            return result;
        }
    }
}
