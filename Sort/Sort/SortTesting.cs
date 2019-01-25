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
    public class BubbleSorting
    {
        int arraySize = Helper.arraySize;
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
            int size = 5;
            int[] a1;
            int[] a2;
            h.GiveTwoArrays(size, 0, out a1, out a2);

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
            int size = 10;
            string[] a1 = h.GiveStringArraySorted(size);
            string[] a2 = new string[a1.GetLength(0)];

            Array.Copy(a1, a2, a1.GetLength(0));

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void BubbleSortStringExtreme()
        {
            int size = arraySize;

            string[] a1 = h.GiveStringArraySorted(size);
            string[] a2 = new string[a1.GetLength(0)];

            Array.Copy(a1, a2, a2.GetLength(0));

            h.ArrayShuffle(a2);

            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void BubbleSortExtreme()
        {
            int size = arraySize;
            int[] a1;
            int[] a2;

            h.GiveTwoArrays(size, 0, out a1, out a2);

            // sort array
            a2 = SortAlgorithmCSharp.BubbleSort(a2);

            // check array
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
    }

    [TestClass]
    public class FailSorting
    {
        int arraySize = Helper.arraySize;
        Helper h = new Helper();

        [TestMethod]
        public void FailSort()
        {
            int size = 10;

            int[] a1;
            int[] a2;

            // test 1
            h.GiveTwoArrays(size, 5, 0, out a1, out a2);

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
            int size = arraySize;
            int[] a1;
            int[] a2;

            h.GiveTwoArrays(size, size, out a1, out a2);

            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void EasySortExtreme()
        {
            int size = arraySize;

            // get array
            int[] a1;
            int[] a2;


            h.GiveTwoArrays(size, 435, 213, out a1, out a2);
            Array.Copy(a1, a2, a1.GetLength(0));

            // sort array
            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            // check array
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
    }

    [TestClass]
    public class LowestHighestSorting
    {
        int arraySize = Helper.arraySize;
        Helper h = new Helper();

        [TestMethod]
        public void LowestHighestSortInt()
        {
            int size = 10;

            int[] a1;
            int[] a2;

            h.GiveTwoArrays(size, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void LowestHighestSortIntExtreme()
        {
            int size = 10000;
            int[] a1;
            int[] a2;

            h.GiveTwoArrays(size, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }
    }

    [TestClass]
    public class SelectionSorting
    {
        int arraySize = Helper.arraySize;
        Helper h = new Helper();

        [TestMethod]
        public void SelectionSort()
        {
            int size = 20;

            int[] a1;
            int[] a2;

            h.GiveTwoArrays(size, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.SelectionSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void SelectionSortExtreme()
        {
            int size = arraySize;
            int[] a1;
            int[] a2;

            h.GiveTwoArrays(size, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.SelectionSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

            h.GiveTwoArrays(size, 0, 10, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.SelectionSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
    }

    [TestClass]
    public class CocktailSorting
    {
        int arraySize = Helper.arraySize;
        Helper h = new Helper();

        [TestMethod]
        public void CocktailSort()
        {
            int size = 20;
            int[] a1;
            int[] a2;
            h.GiveTwoArrays(size, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.CocktailSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void CocktailSortExtreme()
        {
            int size = arraySize;

            int[] a1;
            int[] a2;
            h.GiveTwoArrays(size, 0, out a1, out a2);

            a2 = SortAlgorithmCSharp.CocktailSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }
    }
}
