using System;
using System.Runtime.CompilerServices;
using CustomLinkedList;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private DynamicList<int> list;

        [SetUp]
        public void Setup()
        {
            this.list = new DynamicList<int>();
        }

        [Test]
        public void CountMethodReturnsCorrectCount()
        {
            Assert.AreEqual(0, this.list.Count);
        }

        [Test]
        public void TMethodGetterThrowsAnException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Assert.AreEqual(0, this.list[1]));
        }

        [Test]
        public void AddMethodWorksCorrectly()
        {
            this.list.Add(12);

            Assert.AreEqual(12, this.list[0]);
        }

        [Test]
        public void TMethodGetterWorksCorrectly()
        {
            this.list.Add(12);

            Assert.AreEqual(12, this.list[0]);
        }

        [Test]
        public void RemoveAtMethodWorksCorrectly()
        {
            this.list.Add(12);

            Assert.AreEqual(12, this.list.RemoveAt(0));
        }

        [Test]
        public void RemoveAtMethodRemovesCorrectly()
        {
            this.list.Add(12);
            this.list.RemoveAt(0);

            Assert.Throws<ArgumentOutOfRangeException>(() => Assert.AreEqual(0, this.list[0]));
        }

        [Test]
        public void RemoveAtMethodThrowsAnException()
        {
            this.list.Add(12);

            Assert.Throws<ArgumentOutOfRangeException>(() => this.list.RemoveAt(123));
        }

        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            this.list.Add(12);

            Assert.AreEqual(0, this.list.Remove(12));
        }

        [Test]
        public void RemoveMethodRemovesCorrectly()
        {
            this.list.Add(12);
            this.list.Remove(12);

            Assert.Throws<ArgumentOutOfRangeException>(() => Assert.AreEqual(0, this.list[0]));
        }

        [Test]
        public void RemoveMethodDoesntFindAnIndex()
        {
            this.list.Add(12);

            Assert.AreEqual(-1, this.list.Remove(13));
        }

        [Test]
        public void IndexOfMethodWorksCorrectly()
        {
            this.list.Add(12);

            Assert.AreEqual(0, this.list.IndexOf(12));
        }

        [Test]
        public void IndexOfMethodDoesntFindAnIndex()
        {
            this.list.Add(12);

            Assert.AreEqual(-1, this.list.IndexOf(13));
        }

        [Test]
        public void ContainsMethodIsFalse()
        {
            this.list.Add(12);

            Assert.AreEqual(false, this.list.Contains(122));
        }

        [Test]
        public void ContainsMethodIsTrue()
        {
            this.list.Add(12);

            Assert.AreEqual(true, this.list.Contains(12));
        }


    }
}