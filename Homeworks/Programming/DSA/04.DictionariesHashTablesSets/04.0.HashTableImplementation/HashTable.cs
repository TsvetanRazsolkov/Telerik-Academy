/*Implement the data structure hash table in a class HashTable<K,T>.
Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[])
with initial capacity of 16.
When the hash table load runs over 75%, perform resizing to 2 times larger capacity.
Implement the following methods and properties:

Add(key, value)
Find(key)->value
Remove(key)
Count
Clear()
this[]
Keys
Try to make the hash table to support iterating over its elements with foreach.

Write unit tests for your class.*/
namespace _04._0.HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>> where K : IComparable
    {
        private const int InitialCapacity = 16;
        private const double ResizeRatio = 0.75;

        private LinkedList<KeyValuePair<K, T>>[] values;

        public HashTable()
        {
            this.values = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var list in this.values)
                {
                    if (list != null)
                    {
                        count += list.Count;
                    }
                }

                return count;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                var keys = new List<K>(this.Count);
                foreach (var list in this.values)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }

                return keys;
            }
        }

        public bool ContainsKey(K key)
        {
            return this.Keys.Any(k => k.CompareTo(key) == 0);
        }

        public void Add(K key, T value)
        {
            this.ResizeAndReadd();

            int position = this.GetPosition(key);

            if (this.ContainsKey(key))
            {
                throw new ArgumentException("An item with the same key has already been added.");
            }

            if (this.values[position] == null)
            {
                this.values[position] = new LinkedList<KeyValuePair<K, T>>();
            }

            var elementToAdd = new KeyValuePair<K, T>(key, value);
            this.values[position].AddLast(elementToAdd);
        }

        public T Find(K key)
        {
            int position = this.GetPosition(key);

            if (this.values[position] != null && this.values[position].Count != 0)
            {
                foreach (var pair in this.values[position])
                {
                    if (pair.Key.CompareTo(key) == 0)
                    {
                        return pair.Value;
                    }
                }
            }

            return default(T);
        }

        public void Remove(K key)
        {
            if (!this.ContainsKey(key))
            {
                throw new ArgumentException("No such item in the hash table.");
            }

            int position = this.GetPosition(key);

            // Little unnecessary, since the existence of the key is already checked, but it doesn't hurt :)
            if (this.values[position] != null && this.values[position].Count != 0)
            {
                var elementToDelete = this.values[position].FirstOrDefault(e => e.Key.CompareTo(key) == 0);

                this.values[position].Remove(elementToDelete);
            }
        }

        public void Clear()
        {
            this.values = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
        }

        public T this[K key]
        {
            get
            {
                if (!this.ContainsKey(key))
                {
                    throw new ArgumentException("Key does not exist in the collection");
                }

                return this.Find(key);
            }
            set
            {
                if (!this.ContainsKey(key))
                {
                    throw new ArgumentException("Key does not exist in the collection");
                }

                this.Remove(key);
                this.Add(key, value);
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.values)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        private void ResizeAndReadd()
        {
            if (this.Count > ResizeRatio * this.values.Length)
            {
                int newCapacity = 2 * this.values.Length;
                var oldValues = (LinkedList<KeyValuePair<K, T>>[])this.values.Clone();
                this.values = new LinkedList<KeyValuePair<K, T>>[newCapacity];

                foreach (var list in oldValues)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            this.Add(pair.Key, pair.Value);
                        }
                    }
                }
            }
        }

        private int GetPosition(K key)
        {
            int position = key.GetHashCode() % this.values.Length;

            if (position < 0)
            {
                position = position * (-1);
            }

            return position;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
