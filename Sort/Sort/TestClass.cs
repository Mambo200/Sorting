﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgorithm;
namespace Sort
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void ArrayTest()
        {
            // set first array
            int[] a1 = new int[3];
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = i;
            }

            // set second array
            int[] a2 = new int[3];
            a2[0] = 2;
            a2[1] = 1;
            a2[2] = 0;

            // swap array
            a1 = (int[])SortAlgorithmCSharp.SwapArrayPlace(a1, 0, 2);

            // test
            for (int i = 0; i < a2.GetLength(0); i++)
            {
                Assert.AreEqual(a2[i], a1[i]);
            }

            a1 = (int[])SortAlgorithmCSharp.SwapArrayPlace(a1, -1, 5);

            Assert.AreEqual(null, a1);
        }
        [TestMethod]
        public void BubbleSort()
        {
            int[] a1 = new int[5];
            int[] a2 = new int[5];
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = i;
                a2[i] = a1.Length - i - 1;
            }



            a2 = SortAlgorithmCSharp.BubbleSortInt(a2);

            for (int i = 0; i < a1.Length; i++)
            {
                Assert.AreEqual(a1[i], a2[i]);
            }
        }

        [TestMethod]
        public void BubbleSortExtreme()
        {
            int arraySize = 10000;
            int[] a1 = new int[arraySize];
            int[] a2 = new int[arraySize];

            // set arrays
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = i;
                a2[i] = i;
            }

            

            // shuffle array
            a2 = ShuffleArray(a1, arraySize);

            // sort array
            a2 = SortAlgorithmCSharp.BubbleSortInt(a2);

            // check array
            for (int i = 0; i < a1.Length; i++)
            {
                Assert.AreEqual(a1[i], a2[i]);
            }

        }

        private int[] ShuffleArray(int[] _array, int _shuffle = 1000)
        {
            Random r = new Random();
            int shuffle = _shuffle;
            int[] vs = new int[_array.Length];
            Array.Copy(_array, vs, vs.Length);
            

            while (shuffle != 0)
            {
                vs = (int[])SortAlgorithmCSharp.SwapArrayPlace(vs, r.Next(vs.Length), r.Next(vs.Length));
                shuffle--;
            }

            return vs;
        }
        
    }
}
