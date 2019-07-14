using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hide;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace ConvertingStuff
{
    [TestClass]
    public class CharStringByte
    {
        Helper h = new Helper();

        [TestMethod]
        public void CharToByte()
        {
            Sort.Helper h = new Sort.Helper();
            {
                char c = '@';
                string s = Converting.CharToBinary(c);
                Assert.AreEqual(s, "01000000");
            }

            {
                char c = 'E';
                string binary = Converting.CharToBinary(c);
                char s = Converting.BinaryToChar(binary);
                Assert.AreEqual(c, s);
            }

            {
                string s = "HhAaLlLlOo! WwAaSs GgEeHhTt?";
                string[] binary = Converting.StringToBinary(s);
                string back = Converting.BinaryToString(binary);
                Assert.AreEqual(s, back);
            }

            {
                string s = h.GetRandomString(10);
                string[] binary = Converting.StringToBinary(s);
                string aCon = Converting.BinaryToString(binary);
                Assert.AreEqual(s, aCon);
            }


        }

        [TestMethod]
        public void CharToByteException()
        {
            //char c = Converting.BinaryToChar(h.GetRandomChar());
            //string binary = Converting.CharToBinary(c);

            string binary = "000010000";
            char c;
            bool ex = h.ThrowException(() => c = Converting.BinaryToChar(binary), new StringNotBinaryException(), out Exception actual);

            Assert.AreEqual(true, ex);
        }

        [TestMethod]
        public void ByteAddition()
        {
            string b1 = "00000001";
            string b2 = "00000010";
            string b3 = Converting.Combine(b1, b2);

            Assert.AreEqual("00000011", b3);

            b3 = Converting.Combine(b3, b1);

            Assert.AreEqual("00000100", b3);


        }


        [TestMethod]
        public void ByteAdditionOverflowNoCrash()
        {
            string b1 = "01000000";
            string b2 = "11000001";
            string b3 = Converting.Combine(b1, b2);

            Assert.AreEqual("00000001", b3);

            b1 = "11111111";
            b2 = "11111111";

            b3 = Converting.Combine(b1, b2);

            Assert.AreEqual("11111110", b3);


        }

        [TestMethod]
        public void ByteAdditionOverflowCrash()
        {
            string b1 = "11111111";
            string b2 = "11111111";
            string b3 = "";

            bool ex = h.ThrowException(() => b3 = Converting.Combine(b1, b2, true), new OverflowException(), out Exception receivedException);

            Assert.AreEqual(true, ex);

        }
    }

    [TestClass]
    public class HexStringByte
    {
        [TestMethod]
        public void HexToString()
        {
            {
                string[] bytes = new string[]
                {
                    "01101101",
                    "01101111",
                    "01101110",
                    "01101001",
                    "01101011",
                    "01100001",
                    "00100000",
                    "01100100",

                    "01101001",
                    "01100100",
                    "00100000",
                    "01110100",
                    "01101000",
                    "01101001",
                    "01110011",
                    "00101110"
                };

                string convert = Converting.BinaryToString(bytes);
            }

            {
                string text = "Hallo Welt";
                string[] hex = Converting.StringToHex(text);
                string con = Converting.HexToString(hex);
                Assert.AreEqual(text, con);
            }

            {
                string[] hex = new string[]
                {
                    "4C",
                    "0",
                    "C3",
                    "0",
                    "B6",
                    "0",
                    "73",
                    "0",
                    "63",
                    "0",
                    "68",
                    "0",
                    "65",
                    "0",
                    "20",
                    "0",
                    "53",
                    "0",
                    "79",
                    "0",
                    "73",
                    "0",
                    "74",
                    "0",
                    "65",
                    "0",
                    "6D",
                    "0",
                    "33",
                    "0",
                    "32",
                    "0",
                    "20",
                    "0",
                    "75",
                    "0",
                    "6D",
                    "0",
                    "20",
                    "0",
                    "7A",
                    "0",
                    "75",
                    "0",
                    "20",
                    "0",
                    "67",
                    "0",
                    "65",
                    "0",
                    "77",
                    "0",
                    "69",
                    "0",
                    "6E",
                    "0",
                    "6E",
                    "0",
                    "65",
                    "0",
                    "6E",
                    "0",

                };

                string con = Converting.HexToString(hex);

                Assert.AreEqual(/*"LÃ¶sche System32 um zu gewinnen"*/ "Lösche System32 um zu gewinnen", con);
                hex = new string[] { "4C", "65", "65", "72", "65" };

                Assert.AreEqual("Leere", con);
            }
        }
    }
}
