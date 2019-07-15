using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HideConverting;
using Sort;
using ConvertingStuff;

namespace HideTesting
{
    [TestClass]
    public class HideTesting
    {
        Helper h = new Helper();

        [TestMethod]
        public void CreateIntValue()
        {
            HidingInt hid = new HidingInt();
            hid.Hp = 1234;

            Assert.AreEqual(1234, hid.Hp);
        }

        [TestMethod]
        public void CreateFloatValue()
        {
            float test = 1234.567f;
            HidingFloat hid = new HidingFloat();
            hid.Hp = test;
            Assert.AreEqual(test, hid.Hp);
        }

        [TestMethod]
        public void CreateDecimalValue()
        {
            decimal test = new decimal(1234.5678910d);
            HidingDecimal hid = new HidingDecimal();
            hid.Hp = test;
            Assert.AreEqual(test, hid.Hp);
        }
    }
}
