// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CryptoSolver;
using System.Text;
using System.IO;

namespace KSU.CIS300.CryptoSolver.Tests
{
    [TestFixture]
    public class CipherTests
    {
        //tests are commented out for now -- remove the comment tags once you are ready to test

        
        [Test, Timeout(1000)]
        public void CipherTest_ReadDictionary()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);
            Assert.That(read, Is.True);
        }

        [Test, Timeout(1000)]
        public void CipherTest_AllWordsTrue()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            cipher.ReadDictionary(fullPath);
            Assert.That(cipher.AllWords("this is a test"), Is.True);
        }

        [Test, Timeout(1000)]
        public void CipherTest_AllWordsFalse()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            cipher.ReadDictionary(fullPath);
            Assert.That(cipher.AllWords("not all wurdz"), Is.False);
        }

        [Test, Timeout(1000)]
        public void CipherTest_EncryptTest()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);
            string result = cipher.Encrypt("abcdefghijklmnopqrstuvwxyz");
            bool[] used = new bool[26];
            foreach (char c in result)
            {
                used[c - 'a'] = true;
            }
            foreach (bool val in used)
            {
                Assert.That(val, Is.True);
            }
        }

        [Test, Timeout(1000)]
        public void CipherTest_ContainsInvalidFalse()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            Assert.That(cipher.ContainsInvalid("these are all valid"), Is.False);
        }

        [Test, Timeout(1000)]
        public void CipherTest_ContainsInvalidTrue()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            Assert.That(cipher.ContainsInvalid("Not all valid!"), Is.True);
        }

        [Test, Timeout(1000)]
        public void CipherTest_SolvedTrue()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);
            StringBuilder[] build = { new StringBuilder("this"), new StringBuilder("is"), new StringBuilder("a"), new StringBuilder("test") };
            Assert.That(cipher.Solved(build), Is.True);
        }

        [Test, Timeout(1000)]
        public void CipherTest_SolvedFalse1()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);
            StringBuilder[] build = { new StringBuilder("this"), new StringBuilder("is"), new StringBuilder("a"), new StringBuilder("t?st") };
            Assert.That(cipher.Solved(build), Is.False);
        }

        [Test, Timeout(1000)]
        public void CipherTest_SolvedFalse2()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);
            StringBuilder[] build = { new StringBuilder("this"), new StringBuilder("iz"), new StringBuilder("a"), new StringBuilder("test") };
            Assert.That(cipher.Solved(build), Is.False);
        }

        [Test, Timeout(1000)]
        public void CipherTest_DecryptFalse()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);

            bool solved;
            cipher.Decrypt("qweqweqwe", out solved);
            Assert.That(solved, Is.False);
        }

        [Test, Timeout(1000)]
        public void CipherTest_DecryptTrue()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);

            bool solved;
            cipher.Decrypt("this is a test", out solved);
            Assert.That(solved, Is.True);
        }

        [Test, Timeout(1000)]
        public void CipherTest_DecryptResult()
        {
            SubstitutionCipher cipher = new SubstitutionCipher();
            string fullPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"testData\dictionary.txt");
            bool read = cipher.ReadDictionary(fullPath);

            bool solved;
            string result = cipher.Decrypt("pjihzkl dipd hkpi dt hriho zm dri jbtvbka zp klgkep gtbozuv htbbihdle mtb ikhr hkpi", out solved).Trim();
            Assert.That(result.Equals("special test case to check if the program is always working correctly for each case"), Is.True);
        }

        
    }
}
