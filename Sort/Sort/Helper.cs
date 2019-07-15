﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hide.Converting;

namespace Sort
{
    public class Helper
    {
        public static int arraySize = 10000;
        private static Random r = new Random();

        /// <summary>
        /// Creates a sorted array from _start to _size
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_start">min number of array</param>
        /// <returns>new sorted array</returns>
        public int[] GiveIntArraySorted(int _size, int _start = 0)
        {
            return GiveIntArraySorted(_size, 1, _start);
        }

        /// <summary>
        /// Creates a sorted array from _start to _size with steps
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_step">array[i] = _start + (i * _step)</param>
        /// <param name="_start">min number of array</param>
        /// <returns>new sorted array with steps</returns>
        public int[] GiveIntArraySorted(int _size, int _step, int _start)
        {
            int[] array = new int[_size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _start + (i * _step);
            }
            return array;
        }

        /// <summary>
        /// Creates a sorted array with random numbers from _start to _size (uses bubblesort) (Numbers can appear multiple times)
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_randomStart">random number begin</param>
        /// <param name="_randomEnd">random number end</param>
        /// <param name="_start">min number of array</param>
        /// <returns>new sorted int array</returns>
        public int[] GiveIntArraySorted(int _size, int _randomStart, int _randomEnd, int _start)
        {
            int[] array = new int[_size];
            
            for (int i = 0; i < array.Length; i++)
                array[i] = _start + i + r.Next(_randomStart, _randomEnd);

            SortAlgorithm.SortAlgorithmCSharp.BubbleSort(array);

            return array;

        }

        /// <summary>
        /// Creates a sorted array with random chars (chars can appear multiple times)
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_start">number to start with</param>
        /// <returns>new sorted char array</returns>
        public char[] GiveCharArraySorted(int _size, int _start = 0)
        {
            char[] array = new char[_size];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = GetCharFromInt((short)i);
            }

            return array;
            
        }

        /// <summary>
        /// Creates a sorted array with random strings (strings can appear multiple times).
        /// Lengh of strings is random
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <returns>new sorted string array</returns>
        public string[] GiveStringArraySorted(int _size)
        {
            string[] array = new string[_size];
            int counter = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int stringLengh = r.Next(1, 11);
                char[] addToArray = new char[stringLengh];
                counter = i;
                for (int u = 0; u < stringLengh; u++)
                {
                    addToArray[u] = GetCharFromInt(counter);
                    counter++;
                }
                array[i] = CharArrayToString(addToArray);
                
            }
            return array;
        }

        /// <summary>
        /// Randomly shuffles array
        /// </summary>
        /// <param name="_array">array to shuffle</param>
        public void ArrayShuffle(Array _array)
        {
            ArrayShuffle(_array, _array.Length);
        }

        /// <summary>
        /// Randomly shuffles array
        /// </summary>
        /// <param name="_array">array to shuffle</param>
        /// <param name="_shuffelTimes">how many times shall array be shuffled</param>
        public void ArrayShuffle(Array _array, int _shuffelTimes)
        {
            for (int i = 0; i < _shuffelTimes; i++)
            {
                SortAlgorithm.SortAlgorithmCSharp.SwapArrayPlace(
                    _array, 
                    r.Next(_array.Length), 
                    r.Next(_array.Length)
                    );
            }
        }

        /// <summary>
        /// Array Equal (only first dimension)
        /// IMPORTANT: Method can only return true or throw an exception!
        /// </summary>
        /// <param name="_array1">first array</param>
        /// <param name="_array2">second array</param>
        /// <returns>true when both arrays are equal</returns>
        public bool CheckArray(Array _array1, Array _array2)
        {
            bool equal = true;
            // check lengt of array
            if (_array1.GetLength(0) != _array2.GetLength(0))
                return false;

            for (int i = 0; i < _array1.GetLength(0); i++)
            {
                string arrayV1 = _array1.GetValue(i).ToString();
                string arrayV2 = _array2.GetValue(i).ToString();
                if (arrayV1 != arrayV2)
                    equal = false;

                if (equal == false)
                    throw new NotEqualException(arrayV1, arrayV2, i);
            }

            return equal;
        }

        /// <summary>
        /// Creates one sorted array and one shuffeled array
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_start">Startnumber of array</param>
        /// <param name="a1">sorted array</param>
        /// <param name="a2">shuffeled array</param>
        public void GiveTwoArrays(int _size, int _start, out int[] a1, out int[] a2)
        {
            a1 = GiveIntArraySorted(_size, _start);
            a2 = GiveIntArraySorted(_size, _start);
            Array.Copy(a1, a2, a2.GetLength(0));

            ArrayShuffle(a2);
        }

        /// <summary>
        /// Creates one sorted array and one shuffeled array
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_start">Startnumber of array</param>
        /// <param name="_shuffleTimes">how many times shall array be shuffeled</param>
        /// <param name="a1">sorted array</param>
        /// <param name="a2">shuffeled array</param>
        public void GiveTwoArraysShuffle(int _size, int _start, int _shuffleTimes, out int[] a1, out int[] a2)
        {
            a1 = GiveIntArraySorted(_size, _start);
            a2 = GiveIntArraySorted(_size, _start);
            Array.Copy(a1, a2, a2.GetLength(0));

            ArrayShuffle(a2, _shuffleTimes);
        }

        /// <summary>
        /// Creates one sorted array and one shuffeled array
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_step">array[i] = _start + (i * _step)</param>
        /// <param name="_start">Startnumber of array</param>
        /// <param name="a1">sorted array</param>
        /// <param name="a2">shuffeled array</param>
        public void GiveTwoArrays(int _size, int _step, int _start, out int[] a1, out int[] a2)
        {
            a1 = GiveIntArraySorted(_size, _step, _start);
            a2 = GiveIntArraySorted(_size, _step, _start);
            Array.Copy(a1, a2, a2.GetLength(0));

            ArrayShuffle(a2);
        }

        /// <summary>
        /// Creates one sorted array and one shuffeled array
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_step">array[i] = _start + (i * _step)</param>
        /// <param name="_start">Startnumber of array</param>
        /// <param name="_shuffleTimes">how many times shall array be shuffeled</param>
        /// <param name="a1">sorted array</param>
        /// <param name="a2">shuffeled array</param>
        public void GiveTwoArraysShuffle(int _size, int _step, int _start, int _shuffleTimes, out int[] a1, out int[] a2)
        {
            a1 = GiveIntArraySorted(_size, _step, _start);
            a2 = GiveIntArraySorted(_size, _step, _start);
            Array.Copy(a1, a2, a2.GetLength(0));

            ArrayShuffle(a2, _shuffleTimes);

        }

        /// <summary>
        /// Creates one sorted array and one shuffeled array
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_randomStart">random number begin</param>
        /// <param name="_randomEnd">random number end</param>
        /// <param name="_start">Startnumber of array</param>
        /// <param name="a1">sorted array</param>
        /// <param name="a2">shuffeled array</param>
        public void GiveTwoArrays(int _size, int _randomStart, int _randomEnd, int _start, out int[] a1, out int[] a2)
        {
            a1 = GiveIntArraySorted(_size, _randomStart, _randomEnd, _start);
            a2 = GiveIntArraySorted(_size, _randomStart, _randomEnd, _start);
            Array.Copy(a1, a2, a2.GetLength(0));

            ArrayShuffle(a2);
        }

        /// <summary>
        /// Creates one sorted array and one shuffeled array
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <param name="_randomStart">random number begin</param>
        /// <param name="_randomEnd">random number end</param>
        /// <param name="_start">Startnumber of array</param>
        /// <param name="_shuffleTimes">how many times shall array be shuffeled</param>
        /// <param name="a1">sorted array</param>
        /// <param name="a2">shuffeled array</param>
        public void GiveTwoArraysShuffle(int _size, int _randomStart, int _randomEnd, int _start, int _shuffleTimes, out int[] a1, out int[] a2)
        {
            a1 = GiveIntArraySorted(_size, _randomStart, _randomEnd, _start);
            a2 = GiveIntArraySorted(_size, _randomStart, _randomEnd, _start);
            Array.Copy(a1, a2, a2.GetLength(0));

            ArrayShuffle(a2);

            ArrayShuffle(a2, _shuffleTimes);
        }

        /// <summary>
        /// creates a random string. 
        /// Using the Method <see cref="SortAlgorithm.Converting.BinaryToChar(string)"/>
        /// </summary>
        /// <param name="_length">length of the string</param>
        /// <returns>random string</returns>
        public string GetRandomString(int _length)
        {
            string toReturn = "";
            for (int i = 0; i < _length; i++)
            {
                string binary = "";
                for (int y = 0; y < 8; y++)
                {
                    binary += r.Next(2);
                }

                toReturn += Binary.BinaryToChar(binary);
            }

            return toReturn;
        }


        public string GetRandomChar()
        {
            string toReturn = "";
            for (int i = 0; i < 8; i++)
            {
                int b = r.Next(2);
                toReturn += b;
            }
            return toReturn;
        }

        /// <summary>
        /// Check if given Function throws an exception
        /// </summary>
        /// <param name="_action">Function to check</param>
        /// <param name="_actually">Actuall thrown Exception (null when no exception was thrown)</param>
        /// <returns>true: Function called an Exception | false: Function did not call an exception</returns>
        public bool ThrowException(Action _action, out Exception _actually)
        {
            _actually = null;

            try
            {
                Task t = new Task(_action);
                t.Start();
                t.Wait();
            }
            catch (Exception e)
            {
                _actually = e.InnerException;
            }

            return _actually == null ? false : true;

        }

        /// <summary>
        /// Check if given Function throws an exception and is equal with an expected exception
        /// </summary>
        /// <param name="_action">Function to check</param>
        /// <param name="_expected">Expected Exception</param>
        /// <param name="_actually">Actuall thrown Exception (null when no exception was thrown)</param>
        /// <returns>true: Function called an Exception and is equal with expected Exception | 
        /// false: Function did not call an exception or is not equal with expected Exception</returns>
        public bool ThrowException (Action _action, Exception _expected, out Exception _actually)
        {
            bool toReturn = false;
            _actually = null;

            try
            {
                Task t = new Task(_action);
                t.Start();
                t.Wait();
            }
            catch (Exception e)
            {
                Type e1 = e.InnerException.GetType();
                Type e2 = _expected.GetType();
                if (e1 == e2) toReturn = true;
                _actually = e.InnerException;
            }

            return toReturn;
        }

        /// <summary>
        /// convert a number to char
        /// </summary>
        /// <param name="_number">number</param>
        /// <returns>char</returns>
        private char GetCharFromInt(int _number)
        {
            if(_number > short.MaxValue)
                throw new System.OverflowException("The given integer was too high to convert to a short");
            

            return GetCharFromInt((short)_number);
        }

        /// <summary>
        /// convert a number to char
        /// </summary>
        /// <param name="_number">number</param>
        /// <returns>char</returns>
        private char GetCharFromInt(short _number)
        {
            char c = Convert.ToChar(_number);
            return c;
        }


        /// <summary>
        /// convert a number array to char array
        /// </summary>
        /// <param name="_number">number array</param>
        /// <returns>char array</returns>
        private char[] GetCharFromInt(short[] _number)
        {
            char[] c = new char[_number.GetLength(0)];

            for (int i = 0; i < c.GetLength(0); i++)
            {
                c[i] = GetCharFromInt(_number[i]);
            }

            return c;
        }

        /// <summary>
        /// convert a number array to char array
        /// </summary>
        /// <param name="_number">number array</param>
        /// <returns>char array</returns>
        private char[] GetCharFromInt(int[] _number)
        {
            char[] c = new char[_number.GetLength(0)];

            for (int i = 0; i < c.GetLength(0); i++)
            {
                c[i] = GetCharFromInt(_number[i]);
            }

            return c;
        }

        /// <summary>
        /// convert char array to string
        /// </summary>
        /// <param name="_array">char array</param>
        /// <returns>string</returns>
        private string CharArrayToString(char[] _array)
        {
            string s = "";
            foreach (char c in _array)
            {
                s += c;
            }
            return s;
        }

        
    }
}
