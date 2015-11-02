namespace _04._1.HashTableTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _04._0.HashTableImplementation;

    [TestClass]
    public class HashTableTests
    {
        private HashTable<string, int> testTable;

        // Constructor tests
        [TestMethod]
        public void ConstructorShouldCreateEmptyHashTableWithCount0()
        {
            testTable = new HashTable<string, int>();

            Assert.AreEqual(0, testTable.Count);
        }

        // ContainsKey() tests
        [TestMethod]
        public void ContainsKeyShouldReturnFalseWhenNoKeyIsFound()
        {
            testTable = new HashTable<string, int>();

            Assert.IsFalse(testTable.ContainsKey("some key"));
        }

        [TestMethod]
        public void ContainsKeyShouldReturnTrueWhenKeyIsFound()
        {
            testTable = new HashTable<string, int>();

            testTable.Add("some key", 42);

            Assert.IsTrue(testTable.ContainsKey("some key"));
        }

        // Add() tests
        [TestMethod]
        public void AddingToCollectionShouldIncreaseItsCountWith1()
        {
            testTable = new HashTable<string, int>();
            int expected = testTable.Count + 1;

            testTable.Add("some key", 42);

            Assert.AreEqual(expected, testTable.Count);
        }

        [TestMethod]
        public void AddingToCollectionMoreElementsThanItsCapacityShouldWorkFine()
        {
            testTable = new HashTable<string, int>();

            // Initial capacity is 16
            for (int i = 0; i < 100; i++)
            {
                testTable.Add("some key" + i, 42);
            }

            Assert.AreEqual(100, testTable.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingElementWithKeyThatIsInCollectionShouldThrow()
        {
            testTable = new HashTable<string, int>();

            testTable.Add("some key", 42);
            testTable.Add("some key", 1000007);
        }

        // Find() tests
        [TestMethod]
        public void FindShouldReturnCorrectValueWhenSearchingForExistingElement()
        {
            testTable = new HashTable<string, int>();
            testTable.Add("some key", 42);

            Assert.AreEqual(42, testTable.Find("some key"));
        }

        [TestMethod]
        public void FindShouldReturnCorrectValueWhenSearchingForNotExistingElement()
        {
            testTable = new HashTable<string, int>();
            testTable.Add("some key", 42);

            Assert.AreEqual(default(int), testTable.Find("baraba"));
        }

        // Remove() tests
        [TestMethod]
        public void RemovingExistingElementShouldWorkCorrectly()
        {
            testTable = new HashTable<string, int>();
            testTable.Add("some key", 42);

            testTable.Remove("some key");

            Assert.IsTrue(testTable.Count == 0 && testTable.Find("some key") == default(int));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingNotExistingElementShouldThrow()
        {
            testTable = new HashTable<string, int>();
            testTable.Remove("some key");
        }

        // Clear() tests
        [TestMethod]
        public void ClearShouldEmptyCollection()
        {
            testTable = new HashTable<string, int>();
            testTable.Add("some key", 42);
            testTable.Add("another key", 42);

            testTable.Clear();
            int countAfterClearing = testTable.Count;

            Assert.AreEqual(0, countAfterClearing);            
        }

        // Indexer tests
        [TestMethod]
        public void IndexerWithExistingKeyShouldReturnCorrectValue()
        {
            testTable = new HashTable<string, int>();
            testTable.Add("some key", 42);

            Assert.AreEqual(42, testTable["some key"]);
        }

        [TestMethod]
        public void IndexerWithExistingKeyShouldSetValueCorrectly()
        {
            testTable = new HashTable<string, int>();
            testTable.Add("some key", 42);
            testTable["some key"]++;

            Assert.AreEqual(43, testTable.Find("some key"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerGetterWithNotExistingKeyShouldThrow()
        {
            testTable = new HashTable<string, int>();
            var someNumber = testTable["not existing key"];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerSetterWithNotExistingKeyShouldThrow()
        {
            testTable = new HashTable<string, int>();
            testTable["not existing key"] = 12;
        }
    }
}
