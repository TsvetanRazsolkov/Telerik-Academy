namespace Decoding
{
    using System;

    public class Decoding
    {
        private const int LetterEncryptionConstant = 1000;
        private const int DigitEncryptionConstant = 500;
        private const int EncodedTextCharTransformator = 100;

        public static void Main()
        {
            int cryptoSalt;
            bool isSaltValidInteger = int.TryParse(Console.ReadLine(), out cryptoSalt);
            if (!isSaltValidInteger)
            {
                throw new ArgumentException("Crypto salt input should be valid 32 bit integer number");
            }            

            string input = Console.ReadLine();
            ValidateTextInput(input);        
            char[] text = input.ToCharArray();

            double[] encodedText = EncodeText(text, cryptoSalt);
            PrintEncodedText(encodedText);
        }

        private static void ValidateTextInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Text cannot be null or empty string");
            }

            if (input.IndexOf("@") == -1 || input.IndexOf("@") == 0)
            {
                throw new ArgumentException("Invalid text input.");
            }
        }

        private static void PrintEncodedText(double[] encodedText)
        {
            double encodedSymbol = 0.0;
            for (int j = 0; j < encodedText.Length; j++)
            {
                encodedSymbol = encodedText[j];
                if (j % 2 == 0)
                {
                    encodedSymbol /= EncodedTextCharTransformator;
                    Console.WriteLine("{0:F2}", encodedSymbol);
                }
                else if (j % 2 != 0)
                {
                    encodedSymbol *= EncodedTextCharTransformator;
                    Console.WriteLine("{0:0}", encodedSymbol);
                }
            }
        }

        private static double[] EncodeText(char[] text, int cryptoSalt)
        {
            double[] encodedText = new double[text.Length - 1];

            int indexInText = 0;
            while (text[indexInText] != '@')
            {
                if (char.IsLetter(text[indexInText]))
                {
                    encodedText[indexInText] = (text[indexInText] * cryptoSalt) + LetterEncryptionConstant;
                }
                else if (char.IsDigit(text[indexInText]))
                {
                    encodedText[indexInText] = text[indexInText] + cryptoSalt + DigitEncryptionConstant;
                }
                else if (!char.IsLetterOrDigit(text[indexInText]))
                {
                    encodedText[indexInText] = text[indexInText] - cryptoSalt;
                }

                indexInText++;
            }

            return encodedText;
        }
    }
}
