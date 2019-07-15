using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HideConverting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hide.Converting;

namespace HelpTesting
{
    [TestClass]
    public class HelperTesting
    {
        Sort.Helper h = new Sort.Helper();
        [TestMethod]
        public void TestTryCatch1()
        {
            string b1 = "11111111";
            string b2 = "11111111";
            string b3 = "";

            Action a = new Action(() => b3 = Binary.Combine(b1, b2, true));
            bool ex = h.ThrowException(a, new OverflowException(), out Exception exception);

            Assert.AreEqual(true, ex);



            b1 = "00000000";
            ex = h.ThrowException(a, new OverflowException(), out exception);

            Assert.AreEqual(false, ex);
        }

        [TestMethod]
        public void TestTryCatch2()
        {
            string b1 = "11111110";
            string b2 = "11111111";
            string b3 = "";

            Action a = new Action(() => b3 = Binary.Combine(b1, b2, true));
            bool ex = h.ThrowException(a, out Exception exception);

            Assert.AreEqual(true, ex);



            b2 = "00000001";
            ex = h.ThrowException(a, out exception);

            Assert.AreEqual(false, ex);
            Assert.AreEqual(b3, "11111111");
        }
    }
}
