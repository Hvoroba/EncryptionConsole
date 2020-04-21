using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionLab2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLab2020.Tests
{
    [TestClass()]
    public class AtbashTests
    {
        [TestMethod()]
        public void DecodeTestRus()
        {
            string text = "ЯЮЭЬЫЪЩШЧЦХФУТСРПОНМЛКЙИЗЖЕДГВБА";
            string expected = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            ICipher cipher = new Atbash();
            string actual = cipher.Decode(text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecodeTestEng()
        {
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string expected = "ZYXWVUTSRQPONMLKJIHGFEDCBA";

            ICipher cipher = new Atbash();
            string actual = cipher.Decode(text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecodeTestMixed()
        {
            string text = "ABCxyzжЖж";
            string expected = "ZYXcbaщЩщ";

            ICipher cipher = new Atbash();
            string actual = cipher.Decode(text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncodeTestMixed()
        {
            string text = "ZYX123cbaщЩщ";
            string expected = "ABC123xyzжЖж";           

            ICipher cipher = new Atbash();
            string actual = cipher.Encode(text);
            Assert.AreEqual(expected, actual);
        }
    }
}