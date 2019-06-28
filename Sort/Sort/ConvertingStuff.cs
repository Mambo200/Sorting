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
}
