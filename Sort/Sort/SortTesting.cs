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
        int ArraySize { get { return Helper.arraySize; } }
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

            SortAlgorithmCSharp.SwapArrayPlace(a2, 0, 2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void BubbleSortInt()
        {
            int size = 5;
       
            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.BubbleSort(a2);

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

            SortAlgorithmCSharp.BubbleSort(a2);

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

            SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void BubbleSortStringExtreme()
        {
            int size = ArraySize;

            string[] a1 = h.GiveStringArraySorted(size);
            string[] a2 = new string[a1.GetLength(0)];

            Array.Copy(a1, a2, a2.GetLength(0));

            h.ArrayShuffle(a2);

            SortAlgorithmCSharp.BubbleSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void BubbleSortExtreme()
        {
            int size = ArraySize;

            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            // sort array
            SortAlgorithmCSharp.BubbleSort(a2);

            // check array
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
    }

    [TestClass]
    public class FailSorting
    {
        int ArraySize { get { return Helper.arraySize; } }
        Helper h = new Helper();

        [TestMethod]
        public void FailSort()
        {
            int size = 10;

            // test 1
            h.GiveTwoArrays(size, 5, 0, out int[] a1, out int[] a2);

            a2 = a2 = SortAlgorithmCSharp.FailSortInt(a2);

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
            int size = ArraySize;

            h.GiveTwoArrays(size, size, out int[] a1, out int[] a2);

            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void EasySortExtreme()
        {
            int size = ArraySize;

            // get array
            h.GiveTwoArrays(size, 435, 213, out int[] a1, out int[] a2);

            // sort array
            a2 = SortAlgorithmCSharp.FailSortInt(a2);

            // check array
            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
    }

    [TestClass]
    public class LowestHighestSorting
    {
        int ArraySize { get { return Helper.arraySize; } }
        Helper h = new Helper();

        [TestMethod]
        public void LowestHighestSortInt()
        {
            int size = 10;

            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void LowestHighestSortInt2()
        {
            int[] a1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] a2 = new int[] { 0, 8, 4, 6, 3, 1, 7, 2, 9, 5 };
          //int[] a2 = new int[] { 0, 5, 2, 3, 6, 4, 7, 8, 1, 9 };
            

            a2 = a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void LowestHighestSortIntExtreme()
        {
            int size = 10000;

            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            a2 = SortAlgorithmCSharp.LowestHighestSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }
    }

    [TestClass]
    public class SelectionSorting
    {
        int ArraySize { get { return Helper.arraySize; } }
        Helper h = new Helper();

        [TestMethod]
        public void SelectionSort()
        {
            int size = 20;
            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.SelectionSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }

        [TestMethod]
        public void SelectionSortExtreme()
        {
            int size = ArraySize;
            
            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.SelectionSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

            h.GiveTwoArrays(size, 0, 10, 0, out a1, out a2);

            SortAlgorithmCSharp.SelectionSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));

        }
    }

    [TestClass]
    public class CocktailSorting
    {
        int ArraySize { get { return Helper.arraySize; } }
        Helper h = new Helper();

        [TestMethod]
        public void CocktailSort()
        {
            int size = 20;
            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.CocktailSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void CocktailSortRandom()
        {
            int size = 20;
            h.GiveTwoArrays(size, 0, 20, 0, out int[] a1, out int[] a2);
            SortAlgorithmCSharp.CocktailSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
            
        }

        [TestMethod]
        public void CocktailSortExtreme()
        {
            int size = ArraySize;

            h.GiveTwoArrays(size, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.CocktailSort(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }
    }

    [TestClass]
    public class ShellSorting
    {
        int ArraySize { get { return Helper.arraySize; } }
        Helper h = new Helper();

        [TestMethod]
        public void ShellSortInt()
        {

            h.GiveTwoArrays(100, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.ShellSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }

        [TestMethod]
        public void ShellSortIntExtreme()
        {
            h.GiveTwoArrays(ArraySize, 0, out int[] a1, out int[] a2);

            SortAlgorithmCSharp.ShellSortInt(a2);

            Assert.AreEqual(true, h.CheckArray(a1, a2));
        }
    }
}


namespace ConvertingStuff
{
    [TestClass]
    public class CharStringByte
    {
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
    }
}
