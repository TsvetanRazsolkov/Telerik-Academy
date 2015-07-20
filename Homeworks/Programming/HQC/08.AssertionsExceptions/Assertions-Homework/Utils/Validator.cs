namespace Assertions_Homework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Validator
    {
        public static bool IsIntegerInRange(int valueToCheck, int minValue, int maxValue)
        {
            bool isInRange = true;
            if (valueToCheck < minValue || maxValue < valueToCheck)
            {
                isInRange = false;
            }

            return isInRange;
        }

        public static bool IsCollectionSortedAscending<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            using (var enumerator = collection.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var previous = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        if (previous.CompareTo(current) > 0)
                        {
                            return false;
                        }

                        previous = current;
                    }
                }
            }

            return true;
        }
    }
}
