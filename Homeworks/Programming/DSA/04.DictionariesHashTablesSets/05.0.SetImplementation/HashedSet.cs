/*Implement the data structure set in a class HashedSet<T>
using your class HashTable<K,T> to hold the elements.
Implement all standard set operations like:

Add(T)
Find(T)
Remove(T)
Count
Clear()
union and
intersect
Write unit tests for your class.*/
namespace _05._0.SetImplementation
{
    using System;
    using System.Collections.Generic;

    using _04._0.HashTableImplementation;

    public class HashedSet<T> : IEnumerable<T> where T : IComparable
    {
        private HashTable<int, T> values;

        public HashedSet()
        {
            this.values = new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.values.Count;
            }
        }

        public void Add(T value)
        {
            // When adding existing element here nothing should happen, as in the HashTable we should throw exception
            try
            {
                this.values.Add(value.GetHashCode(), value);
            }
            catch (ArgumentException)
            {
            }
        }

        // Find and return the value, which we give as parameter - don't get this but it's in the spec, so... :)
        public T Find(T value)
        {
            return this.values.Find(value.GetHashCode());
        }

        // The above is bugging me, so here is something more reasonable :)
        public bool Contains(T value)
        {
            return this.values.ContainsKey(value.GetHashCode());
        }

        public void Remove(T value)
        {
            this.values.Remove(value.GetHashCode());
        }

        public void Clear()
        {
            this.values.Clear();
        }

        public HashedSet<T> UnionWith(HashedSet<T> other)
        {
            var unionSet = new HashedSet<T>();

            foreach (var item in this)
            {
                unionSet.Add(item);
            }

            foreach (var item in other)
            {
                unionSet.Add(item);
            }

            return unionSet;
        }

        /// <summary>
        /// Returns new HashedSet<T> with elements formed in the intersection between two HashedSet<T>
        /// </summary>
        /// <param name="other">The HashedSet<T> with which we will intersect the current HashedSet<T></param>
        /// <returns>New HashedSet<T> or null if there are no common elements</returns>
        public HashedSet<T> IntersectWith(HashedSet<T> other)
        {
            var intersectionSet = new HashedSet<T>();

            foreach (var item in this)
            {
                foreach (var anotherItem in other)
                {
                    if (anotherItem.CompareTo(item) == 0)
                    {
                        intersectionSet.Add(item);
                    }
                }
            }

            return intersectionSet.Count == 0 ? null : intersectionSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.values)
            {
                yield return pair.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
