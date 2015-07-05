namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides extension methods for transforming and manipulating
    /// <see cref="System.String"/> values. 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encrypts the string by hashing and returns another string in a hexadecimal format.
        /// </summary>
        /// <param name="input">
        /// The string value you wish to encrypt.
        /// </param>
        /// <returns>
        /// String in hexadecimal format.
        /// </returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts a string value to a boolean value and returns it.
        /// </summary>
        /// <param name="input">
        /// String to convert.
        /// </param>
        /// <returns>
        /// Boolean value.
        /// </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer
        /// equivalent and returns it.
        /// </summary>
        /// <param name="input">
        /// String value to convert.
        /// </param>
        /// <returns>
        /// A 16-bit signed integer representation of the input string 
        /// or the default value 0 if the input parameter is invalid.
        /// </returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer
        /// equivalent and returns it.
        /// </summary>
        /// <param name="input">
        /// String value to convert.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer representation of the input string 
        /// or the default value 0 if the input parameter is invalid.
        /// </returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer
        /// equivalent and returns it.
        /// </summary>
        /// <param name="input">
        /// String value to convert.
        /// </param>
        /// <returns>
        /// A 64-bit signed integer representation of the input string 
        /// or the default value 0 if the input parameter is invalid.
        /// </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string representation of a date to its DateTime equivalent and returns it.
        /// </summary>
        /// <param name="input">
        /// String value to convert.
        /// </param>
        /// <returns>
        /// A DateTime representation of the input string 
        /// or DateTime.MinValue if the input parameter is invalid.
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts the first letter of a string to capital and returns the changed string.
        /// </summary>
        /// <param name="input">
        /// String value to change.
        /// </param>
        /// <returns>
        /// A string with capitalized first letter
        /// or the input parameter if it is null or empty string.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the substring between two specified substrings
        /// or an empty string if some of the method parameters is invalid.
        /// </summary>
        /// <param name="input">
        /// The string from which substring will be extracted.
        /// </param>
        /// <param name="startString">
        /// Substring in the input, located before the target substring.
        /// </param>
        /// <param name="endString">
        /// Substring in the input, located after the target substring.
        /// </param>
        /// <param name="startFrom">
        /// Index of the input string where the search starts from.
        /// </param>
        /// <returns>
        /// A string value or empty string in case of invalid input parameters.
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts any cyrillic letters in a string 
        /// to their latin phonetic transcription representations.
        /// </summary>
        /// <param name="input">
        /// String value.
        /// </param>
        /// <returns>
        /// A string with latin letters representing the phonetic transcription of the input text. 
        /// </returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts any latin letters in a string 
        /// to their cyrillic keyboard input representations.
        /// </summary>
        /// <param name="input">
        /// String value.
        /// </param>
        /// <returns>
        /// A string with cyrillic letters representing the cyrillic keyboard representations of the input text. 
        /// </returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts a string to a valid user name.
        /// </summary>
        /// <param name="input">String value to convert.</param>
        /// <returns>
        /// A string containing only latin letters, digits, underscores or dots.
        /// </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();

            // Replace all symbols that are not alphanumeric, underscore or a dot.
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts a string to a valid file name.
        /// </summary>
        /// <param name="input">String value to convert.</param>
        /// <returns>
        /// A string containing only latin letters, digits, underscores, hyphens or dots.
        /// </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            // Replace all symbols that are not alphanumeric, underscore, hyphen or a dot.
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring with a specified length starting from the beginning of the input string.
        /// </summary>
        /// <param name="input">String from which to extract the first characters.</param>
        /// <param name="charsCount">Count of characters needed.</param>
        /// <returns>
        /// A string containing the specified number of characters from the beginning of the input
        /// or the input string if charsCount parameter is invalid.
        /// </returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension of a specified string input or an empty string
        /// if the input is not a valid file name.
        /// </summary>
        /// <param name="fileName">String file name.</param>
        /// <returns>
        /// A string - the file extension or an empty string if the input is not a valid file name.
        /// </returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type as a string value according to given file extension.
        /// </summary>
        /// <param name="fileExtension">File extension.</param>
        /// <returns>
        /// The content type, according to the given file extension as a string
        /// or "application/octet-stream" if the file extension is unknown.
        /// </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string to the corresponding byte array of its characters
        /// and returns it.
        /// </summary>
        /// <param name="input">Input string to be converted.</param>
        /// <returns>
        /// A byte array that is copied from the bytes in the char array representation
        /// of the input string.
        /// </returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
