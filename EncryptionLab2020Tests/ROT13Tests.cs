using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionLab2020;

namespace EncryptionLab2020.Tests
{
    [TestClass()]
    public class ROT13Tests
    {
        [TestMethod()]
        public void EncodeTestEng()
        {
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string expected = "NOPQRSTUVWXYZABCDEFGHIJKLM";

            ICipher cipher = new ROT13();
            string actual = cipher.Encode(text);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecodeTestEng()
        { 
            string text = "NOPQRSTUVWXYZABCDEFGHIJKLM";
            string expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            ICipher cipher = new ROT13();
            string actual = cipher.Decode(text);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncodeTestMixed()
        {
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZddqqff  ... ! АБВГДоооя";
            string expected = "NOPQRSTUVWXYZABCDEFGHIJKLMqqddss  ... ! НОПРСыыым";

            ICipher cipher = new ROT13();
            string actual = cipher.Encode(text);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecodeTestMixed()
        {
            string text = "NOPQRSTUVWXYZABCDEFGHIJKLMqqddss  ... ! НОПРСъъъм";
            string expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZddqqff  ... ! АБВГДнння";

            ICipher cipher = new ROT13();
            string actual = cipher.Decode(text);

            Assert.AreEqual(expected, actual);
        }

    }
}