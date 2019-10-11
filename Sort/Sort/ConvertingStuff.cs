using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HideConverting;

using Hide.Converting;
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
                string s = Binary.CharToBinary(c);
                Assert.AreEqual(s, "01000000");
            }

            {
                char c = 'E';
                string binary = Binary.CharToBinary(c);
                char s = Binary.BinaryToChar(binary);
                Assert.AreEqual(c, s);
            }

            {
                string s = "HhAaLlLlOo! WwAaSs GgEeHhTt?";
                string[] binary = Binary.StringToBinary(s);
                string back = Binary.BinaryToString(binary);
                Assert.AreEqual(s, back);
            }

            {
                string s = h.GetRandomString(10);
                string[] binary = Binary.StringToBinary(s);
                string aCon = Binary.BinaryToString(binary);
                Assert.AreEqual(s, aCon);
            }
        }

        [TestMethod]
        public void ByteToChar()
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

                string convert = Binary.BinaryToString(bytes);

                Assert.AreEqual("monika did this.", convert);


            }
        }

        [TestMethod]
        public void CharToByteException()
        {
            //char c = Converting.BinaryToChar(h.GetRandomChar());
            //string binary = Converting.CharToBinary(c);

            string binary = "000010000";
            char c;
            bool ex = h.ThrowException(() => c = Binary.BinaryToChar(binary), new StringNotBinaryException(), out Exception actual);

            Assert.AreEqual(true, ex);
        }

        [TestMethod]
        public void ByteAddition()
        {
            string b1 = "00000001";
            string b2 = "00000010";
            string b3 = Binary.Combine(b1, b2);

            Assert.AreEqual("00000011", b3);

            b3 = Binary.Combine(b3, b1);

            Assert.AreEqual("00000100", b3);


        }


        [TestMethod]
        public void ByteAdditionOverflowNoCrash()
        {
            string b1 = "01000000";
            string b2 = "11000001";
            string b3 = Binary.Combine(b1, b2);

            Assert.AreEqual("00000001", b3);

            b1 = "11111111";
            b2 = "11111111";

            b3 = Binary.Combine(b1, b2);

            Assert.AreEqual("11111110", b3);


        }

        [TestMethod]
        public void ByteAdditionOverflowCrash()
        {
            string b1 = "11111111";
            string b2 = "11111111";
            string b3 = "";

            bool ex = h.ThrowException(() => b3 = Binary.Combine(b1, b2, true), new OverflowException(), out Exception receivedException);

            Assert.AreEqual(true, ex);

        }
    }

    [TestClass]
    public class HexStringByte
    {
        private static Helper h = new Helper();
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

                string convert = Binary.BinaryToString(bytes);
            }

            {
                string text = "Hallo Welt";
                string[] hex = Hexadecimal.StringToHex(text);
                string con = Hexadecimal.HexToString(hex);
                Assert.AreEqual(text, con);
            }

            {
                string[] hex = new string[]
                {
                    "4C",
                    "C3",
                    "B6",
                    "73",
                    "63",
                    "68",
                    "65",
                    "20",
                    "53",
                    "79",
                    "73",
                    "74",
                    "65",
                    "6D",
                    "33",
                    "32",
                    "20",
                    "75",
                    "6D",
                    "20",
                    "7A",
                    "75",
                    "20",
                    "67",
                    "65",
                    "77",
                    "69",
                    "6E",
                    "6E",
                    "65",
                    "6E",
                };

                string con = Hexadecimal.HexToString(hex);
                Assert.AreEqual("LÃ¶sche System32 um zu gewinnen", con);

                hex = new string[] { "4C", "65", "65", "72", "65" };
                con = Hexadecimal.HexToString(hex);
                Assert.AreEqual("Leere", con);
            }
        }

        [TestMethod]
        public void WrongFormat()
        {
            string[] hex;
            string con = "";
            {
                hex = new string[] { "33", "55", "GF" };
                bool ex = h.ThrowException(() => con = Hexadecimal.HexToString(hex), out Exception receivedException);

                Assert.AreEqual(true, ex);
            }

            {
                hex = new string[] { "4C", "65", "65", "72", "65" };
                bool ex = h.ThrowException(() => con = Hexadecimal.HexToString(hex), out Exception receivedException);

                Assert.AreEqual(false, ex);
                Assert.AreEqual("Leere", con);

            }
        }

        [TestMethod]
        public void HexAddition()
        {
            string[] hex1;
            string[] hex2;
            string[] combine;
            string[] expected;

            {
                hex1 = new string[]
                {
                    "11",
                    "A3"
                };
                hex2 = new string[]
                {
                    "22",
                    "44"
                };
                combine = Hexadecimal.Combine(hex1, hex2);

                expected = new string[]
                {
                    "33",
                    "E7"
                };
                Assert.AreEqual(true, h.CheckArray(expected, combine));
            }

            {
                hex1 = new string[]
                {
                    "0F",
                    "FF"
                };
                hex2 = new string[]
                {
                    "00",
                    "02"
                };

                combine = Hexadecimal.Combine(hex1, hex2);

                expected = new string[]
                {
                    "10",
                    "01"
                };
                Assert.AreEqual(true, h.CheckArray(hex1, hex2));
            }
        }
    }
}
