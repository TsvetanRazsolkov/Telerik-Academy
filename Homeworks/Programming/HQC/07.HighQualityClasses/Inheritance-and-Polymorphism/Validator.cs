namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    internal static class Validator
    {
        private const string InvalidStringParameterMessage = "{0} cannot be null or empty string.";
        private const string NullParameterMessage = "{0} cannot be null.";

        internal static void ValidateIfStringIsNullOrEmpty(string input, string parameterName)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(string.Format(InvalidStringParameterMessage, parameterName));
            }
        }

        internal static void ValidateIfNull(IEnumerable<string> students, string parameterName)
        {
            if (students == null)
            {
                throw new ArgumentNullException(parameterName, string.Format(NullParameterMessage, parameterName));
            }
        }
    }
}
