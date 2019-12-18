// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CryptoSolver;

namespace KSU.CIS300.CryptoSolver.Tests
{
    [TestFixture]
    public class TrieTests
    {
        //tests are commented out for now -- remove the comment tags once you are ready to test

        [Test, Timeout(1000)]
        public void TrieTest_Empty()
        {
            ITrie trie = new TrieWithNoChildren();
            Assert.That(trie.WildcardSearch("?"), Is.False);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddOneWild()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("a");
            Assert.That(trie.WildcardSearch("?"), Is.True);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddOneTwoWild()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("a");
            Assert.That(trie.WildcardSearch("??"), Is.False);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddTwoOneWild()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("an");
            Assert.That(trie.WildcardSearch("?"), Is.False);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddSeveralFindWild1()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("bat");
            trie = trie.Add("ball");
            Assert.That(trie.WildcardSearch("b?t"), Is.True);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddSeveralFindWild2()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("bat");
            trie = trie.Add("ball");
            Assert.That(trie.WildcardSearch("b?t?"), Is.False);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddSeveralFindWild3()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("bat");
            trie = trie.Add("ball");
            trie = trie.Add("sale");
            Assert.That(trie.WildcardSearch("?a?e"), Is.True);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddSeveralFindWild4()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("banana");
            trie = trie.Add("balloon");
            trie = trie.Add("banter");
            Assert.That(trie.WildcardSearch("b?n?n?"), Is.True);
        }

        [Test, Timeout(1000)]
        public void TrieTest_LookupEmpty()
        {
            ITrie trie = new TrieWithNoChildren();
            Assert.That(trie.WildcardSearch(""), Is.False);
        }

        [Test, Timeout(1000)]
        public void TrieTest_AddSeveralFindWild5()
        {
            ITrie trie = new TrieWithNoChildren();
            trie = trie.Add("banana");
            trie = trie.Add("balloon");
            trie = trie.Add("banter");
            Assert.That(trie.WildcardSearch("b?n?ns"), Is.False);
        }
    }
}
