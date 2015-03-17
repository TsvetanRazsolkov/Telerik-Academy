/* Implement an extension method Substring(int index, int length) for the class StringBuilder
that returns new StringBuilder and has the same functionality as Substring in the class String. */
namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    public static class StringBuilderExtension
    {        
        public static StringBuilder Substring(this StringBuilder builder, int index, int length)
        {
            var result = new StringBuilder();
            if (index + length > builder.Length || index < 0 || length <= 0 || index >= builder.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < index + length; i++)
            {
                result.Append(builder[i]);
            }

            return result;
        }
    }
}
