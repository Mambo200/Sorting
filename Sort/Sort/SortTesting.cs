using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgorithm;

namespace Sort
{
    [TestClass]
    public class SortTesting
    {
        int arraySize = 10000;
        Helper h = new Helper();

        [TestMethod]
        public void ArrayTest()
        {

            // set first array
            int[] a1 = h.GiveIntArraySorted(3);

            // set second array
            int[] a2 = h.GiveIntArraySorted(3);
            a2[0] = 2;
            a2[1] = 1;
            a2[2] = 0;

            Assert.AreEqual(false, h.CheckArray(a1, a2));

            // swap array
            a1 = (int[])SortAlgorithmCSharp.SwapArrayPlace(a1, 0, 2);

            // test
            Assert.AreEqual(true, h.CheckArray(a1, a2));
            

            a1 = (int[])SortAlgorithmCSharp.SwapArrayPlace(a1, -1, 5);

            Assert.AreEqual(null, a1);
        }

        [TestMethod]
        public void BubbleSortInt()
        {
            int[] a1 = h.GiveIntArraySorted(5);
            int[] a2 = h.GiveIntArraySorted(5);
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = i;
                a2[i] = a1.Length - i - 1;
            }



            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void BubbleSortString1()
        {
            string[] a1 = new string[] { "", "AA", "BB", "CC", "DD", "EE", "FF", "GG",
                "HH", "II", "JJ", "KK", "LL", "MM", "NN", "OO", "PP",
                "QQ", "RR", "SS", "TT", "UU", "VV", "WW", "XX", "YY", "ZZ" };

            string[] a2 = new string[a1.GetLength(0)];

            // copy array
            Array.Copy(a1, a2, a1.GetLength(0));

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void BubbleSortString2()
        {
            string[] a1 = h.GiveStringArraySorted(10);
            string[] a2 = new string[a1.GetLength(0)];

            Array.Copy(a1, a2, a1.GetLength(0));

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void BubbleSortStringExtreme()
        {
            string[] a1 = h.GiveStringArraySorted(arraySize);
            string[] a2 = new string[a1.GetLength(0)];

            Array.Copy(a1, a2, a2.GetLength(0));

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void BubbleSortExtreme()
        {
            int[] a1 = new int[arraySize];
            int[] a2 = new int[arraySize];

            // set arrays
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = i;
                a2[i] = i;
            }

            

            // shuffle array
            h.ArrayShuffle(a2);

            // sort array
            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            // check array
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void FailSort()
        {
            // set first array
            int[] a1 = h.GiveIntArraySorted(10, 5, 10);

            // set second array
            int[] a2 = h.GiveIntArraySorted(10, 5, 10);

            // test 1
            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

            // test 2
            a1[0] = -4324634;
            a1[1] = -43242;
            a1[2] = -3123;
            a1[3] = 0;
            a1[4] = 1;
            a1[5] = 5;
            a1[6] = 33;
            a1[7] = 41234;
            a1[8] = 3482309;
            a1[9] = 22432253;
            
            Array.Copy(a1, a2, a1.GetLength(0));
            h.ArrayShuffle(a2);
            
            a2 = SortAlgorithmCSharp.FailSortInt(a2);
            Assert.AreEqual(true, h.CheckArray(a1, a2));

            // test 3
            a1[0] = int.MinValue;
            a1[9] = int.MaxValue;
            Array.Copy(a1, a2, a1.GetLength(0));
            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.FailSortInt(a2);
            Assert.AreEqual(false, h.CheckArray(a1, a2));
            
            // test 4
            a1[0] = -5;
            a1[1] = 0;
            a1[2] = 3;
            a1[3] = 6;
            a1[4] = 10;
            a1[5] = 33;
            a1[6] = 323;
            a1[7] = 555;
            a1[8] = 1000;
            a1[9] = 9000;

            a2 = new int[10];
            Array.Copy(a1, a2, a1.GetLength(0));
            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.FailSortInt(a2);
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void FailSort2()
        {
            int[] a1 = new int[3];
            int[] a2 = new int[a1.GetLength(0)];

            a1[0] = 22432200;
            a1[1] = 22432220;
            a1[2] = 22432253;

            Array.Copy(a1, a2, a1.GetLength(0));

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void FailSortExtreme()
        {
            int[] a1 = h.GiveIntArraySorted(arraySize, arraySize);
            int[] a2 = new int[a1.GetLength(0)];

            Array.Copy(a1, a2, a1.GetLength(0));

            h.ArrayShuffle(a2);
            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
        [TestMethod]
        public void EasySortExtreme()
        {
            // get array
            int[] a1 = h.GiveIntArraySorted(arraySize, 435, 213);
            int[] a2 = new int[a1.GetLength(0)];
            Array.Copy(a1, a2, a1.GetLength(0));

            // shuffle array
            h.ArrayShuffle(a2);

            // sort array
            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            // check array
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void LowestHighestSortInt()
        {
            int[] a1 = h.GiveIntArraySorted(10);
            int[] a2 = h.GiveIntArraySorted(10);

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void LoewstHighestSortIntExtreme()
        {
            int size = 10000;
            int[] a1 = h.GiveIntArraySorted(size);
            int[] a2 = h.GiveIntArraySorted(size);

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }
    }
}
