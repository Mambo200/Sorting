using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Helper
    {
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
        /// <param name="_step">array[i] = _start + (i * _step))</param>
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
        public int[] GiveIntArraySorted(int _size, int _randomStart, int _randomEnd, int _start = 0)
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
                _array = SortAlgorithm.SortAlgorithmCSharp.SwapArrayPlace(
                    _array, 
                    r.Next(_array.Length), 
                    r.Next(_array.Length)
                    );
            }
        }

        /// <summary>
        /// Array Equal (only first dimension)
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
                    break;
            }

            return equal;
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
