namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private readonly MultiDictionary<K1, V> firstDictionary;
        private readonly MultiDictionary<K2, V> secondDictionary;
        private readonly MultiDictionary<Tuple<K1, K2>, V> dualKeyDictionary;

        public BiDictionary()
        {
            firstDictionary = new MultiDictionary<K1, V>(true);
            secondDictionary = new MultiDictionary<K2, V>(true);
            dualKeyDictionary = new MultiDictionary<Tuple<K1, K2>, V>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, V value)
        {
            this.firstDictionary.Add(firstKey, value);
            this.secondDictionary.Add(secondKey, value);

            var complexKey = new Tuple<K1, K2>(firstKey, secondKey);
            this.dualKeyDictionary.Add(complexKey, value);
        }

        public ICollection<V> FindByFirstKey(K1 key)
        {
            return this.firstDictionary[key];
        }

        public ICollection<V> FindBySecondKey(K2 key)
        {
            return this.secondDictionary[key];
        }

        public ICollection<V> FindByTwoKeys(K1 firstKey, K2 secondKey)
        {
            var complexKey = new Tuple<K1, K2>(firstKey, secondKey);

            return this.dualKeyDictionary[complexKey];
        }
    }
}
