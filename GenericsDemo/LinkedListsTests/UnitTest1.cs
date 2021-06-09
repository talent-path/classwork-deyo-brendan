using NUnit.Framework;
using LinkedList;
using System.Linq;

namespace LinkedListsTests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void SetupAllTests()
        {

        }

        [OneTimeSetUp]
        public void SecondSetup()
        {

        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LinkedListAdd (
            [Values("one","",null)]string first,
            [Values("two","",null)]string second)
        {
            DavidLinkedList<string> list = new DavidLinkedList<string>();
            list.Add(first);
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(1, list.Count());
            list.Add(second);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(second, list.Skip(1).First());
        }

        [TestCase("one","two")]
        [TestCase("","")]
        [TestCase(null, "one")]
        public void LinkedListRemove(string first, string second)
        {
            DavidLinkedList<string> list = new DavidLinkedList<string>();
            list.Add(first);
            Assert.AreEqual(second, list.First());
            Assert.AreEqual(1, list.Count());
            list.Add(first);
            list.Remove(first);
            Assert.AreEqual(second, list.First());
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(second, list.Skip(1).First());
        }



    }
}