namespace School
{
    using System;
    using System.Collections.Generic;

    internal static class Validator
    {
        internal const string NullOrEmptyStringErrorMessage = "{0} cannot be null or empty string.";
        internal const string NullArgumentMessage = "{0} cannot be null.";
        internal const string ArgumentOutOfRangeMessage = "{0} is out of range.";
        
        internal static void CheckIfNullOrEmptyString(string valueToCheck, string valueToCheckName)
        {
            if (string.IsNullOrEmpty(valueToCheck) || string.IsNullOrWhiteSpace(valueToCheck))
            {
                throw new ArgumentException(string.Format(NullOrEmptyStringErrorMessage, valueToCheckName));
            }
        }

        internal static void CheckIfNull<T>(T value, string valueName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(string.Format(NullArgumentMessage, valueName));
            }
        }

        internal static void CheckIfIntegerInRange(int valueToCheck, int minValue, int maxValue, string valueToCheckName)
        {
            if (valueToCheck < minValue || valueToCheck > maxValue)
            {
                throw new ArgumentOutOfRangeException(string.Format(ArgumentOutOfRangeMessage, valueToCheckName));
            }
        }
    }
}
