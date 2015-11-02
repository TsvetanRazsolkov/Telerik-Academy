namespace _05._1.SetTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _05._0.SetImplementation;

    [TestClass]
    public class HashedSetTests
    {
        private HashedSet<string> testSet;

        // Constructor tests
        [TestMethod]
        public void ConstructorShouldCreateEmptyHashedSetWithCount0()
        {
            testSet = new HashedSet<string>();

            Assert.AreEqual(0, testSet.Count);
        }

        // Add() tests
        [TestMethod]
        public void AddingToCollectionShouldIncreaseItsCountWith1()
        {
            testSet = new HashedSet<string>();
            int expected = testSet.Count + 1;

            testSet.Add("Pesho");

            Assert.AreEqual(expected, testSet.Count);
        }

        [TestMethod]
        public void AddingToCollectionMoreElementsThanItsCapacityShouldWorkFine()
        {
            testSet = new HashedSet<string>();

            // Initial capacity is 16
            for (int i = 0; i < 100; i++)
            {
                testSet.Add("Pesho" + i);
            }

            Assert.AreEqual(100, testSet.Count);
        }

        [TestMethod]
        public void AddingExistingElementShouldDoNothing()
        {
            testSet = new HashedSet<string>();

            testSet.Add("Pesho");
            testSet.Add("Pesho");
            testSet.Add("Pesho");
            testSet.Add("Pesho");

            Assert.AreEqual(1, testSet.Count);
        }

        // Contains() tests
        [TestMethod]
        public void ContainsShouldReturnFalseWhenNoElementIsFound()
        {
            testSet = new HashedSet<string>();

            Assert.IsFalse(testSet.Contains("Gosho"));
        }

        [TestMethod]
        public void ContainsShouldReturnTrueWhenElementIsFound()
        {
            testSet = new HashedSet<string>();

            testSet.Add("Genadi");

            Assert.IsTrue(testSet.Contains("Genadi"));
        }

        // Find() tests
        [TestMethod]
        public void FindShouldReturnCorrectValueWhenSearchingForExistingElement()
        {
            testSet = new HashedSet<string>();
            testSet.Add("Pesho");

            Assert.AreEqual("Pesho", testSet.Find("Pesho"));
        }

        [TestMethod]
        public void FindShouldReturnCorrectValueWhenSearchingForNotExistingElement()
        {
            testSet = new HashedSet<string>();

            Assert.IsNull(testSet.Find("Vankata"));
        }

        // Remove() tests
        [TestMethod]
        public void RemovingExistingElementShouldWorkCorrectly()
        {
            testSet = new HashedSet<string>();
            testSet.Add("Pesho");

            testSet.Remove("Pesho");

            Assert.IsTrue(testSet.Count == 0 && testSet.Find("Pesho") == null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingNotExistingElementShouldThrow()
        {
            testSet = new HashedSet<string>();
            testSet.Remove("Stamat");
        }

        // Clear() tests
        [TestMethod]
        public void ClearShouldEmptyCollection()
        {
            testSet = new HashedSet<string>();
            testSet.Add("Pesho");
            testSet.Add("Gosho");

            testSet.Clear();
            int countAfterClearing = testSet.Count;

            Assert.AreEqual(0, countAfterClearing);
        }

        // UnionWith() tests
        [TestMethod]
        public void UnionShouldWorkCorrectly()
        {
            testSet = new HashedSet<string>();
            testSet.Add("Pesho");
            testSet.Add("Gosho");

            var anotherTestSet = new HashedSet<string>();
            anotherTestSet.Add("Kiro");
            anotherTestSet.Add("Joro");

            var union = testSet.UnionWith(anotherTestSet);

            Assert.IsTrue(
                union.Contains("Pesho")
                && union.Contains("Gosho")
                && union.Contains("Kiro")
                && union.Contains("Joro")
                && 4 == union.Count);
        }

        // IntersectWith() tests
        [TestMethod]
        public void IntersectWithCollectionsWithCommonElementsShouldReturnTheirIntersection()
        {
            testSet = new HashedSet<string>();
            testSet.Add("Pesho");
            testSet.Add("Gosho");
            testSet.Add("Kiro");

            var anotherTestSet = new HashedSet<string>();
            anotherTestSet.Add("Kiro");
            anotherTestSet.Add("Joro");
            anotherTestSet.Add("Pesho");

            var intersection = testSet.IntersectWith(anotherTestSet);

            Assert.IsTrue(
                intersection.Contains("Pesho")
                && intersection.Contains("Kiro")
                && 2 == intersection.Count);
        }

        [TestMethod]
        public void IntersectWithCollectionsWithNoCommonElementsShouldReturnNull()
        {
            testSet = new HashedSet<string>();
            testSet.Add("Pesho");
            testSet.Add("Gosho");

            var anotherTestSet = new HashedSet<string>();
            anotherTestSet.Add("Kiro");
            anotherTestSet.Add("Joro");

            var intersection = testSet.IntersectWith(anotherTestSet);

            Assert.IsNull(intersection);
        }
    }
}
