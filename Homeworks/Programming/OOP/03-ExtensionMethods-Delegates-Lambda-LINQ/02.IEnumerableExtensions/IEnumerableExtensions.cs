/* Implement a set of extension methods for IEnumerable<T> that implement the following group
functions: sum, product, min, max, average. */
namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            T sum = default(T);
            bool collectionIsEmpty = true;
            foreach (var item in collection)
            {
                collectionIsEmpty = false;
                sum += (dynamic)item;
            }
            if (collectionIsEmpty)
            {
                throw new ArgumentException("Collection cannot be empty.");
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;
            bool collectionIsEmpty = true;
            foreach (var item in collection)
            {
                collectionIsEmpty = false;
                product *= item;
            }
            if (collectionIsEmpty)
            {
                throw new ArgumentException("Collection cannot be empty.");
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            enumerator.MoveNext();
            T min = enumerator.Current;

            bool collectionIsEmpty = true;
            foreach (var item in collection)
            {
                collectionIsEmpty = false;
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }
            if (collectionIsEmpty)
            {
                throw new ArgumentException("Collection cannot be empty.");
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            enumerator.MoveNext();
            T max = enumerator.Current;

            bool collectionIsEmpty = true;
            foreach (var item in collection)
            {
                collectionIsEmpty = false;
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
            if (collectionIsEmpty)
            {
                throw new ArgumentException("Collection cannot be empty.");
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            dynamic count = 0;
            bool collectionIsEmpty = true;
            foreach (var item in collection)
            {
                collectionIsEmpty = false;
                sum += item;
                count++;
            }
            if (collectionIsEmpty)
            {
                throw new ArgumentException("Collection cannot be empty.");
            }
            return (T)(sum / count);
        }
    }
}
