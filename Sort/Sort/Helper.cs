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
        /// Creates a sorted array from 0 to _size
        /// </summary>
        /// <param name="_size">size of array</param>
        /// <returns>new sorted array</returns>
        public int[] GiveIntArraySorted(int _size)
        {
            int[] array = new int[_size];

            for (int i = 0; i < array.Length; i++)
                array[i] = i;

            return array;
        }

        /// <summary>
        /// Randomly shuffles int array
        /// </summary>
        /// <param name="_array">int array to shuffle</param>
        /// <returns>shuffeled int array</returns>
        public int[] GiveIntArrayShuffle(int[] _array)
        {
            GiveIntArrayShuffle(_array, _array.Length);
            return _array;
        }

        /// <summary>
        /// Randomly shuffles int array
        /// </summary>
        /// <param name="_array">array to shuffle</param>
        /// <param name="_shuffelTimes">how many times shall array be shuffled</param>
        /// <returns>shuffled array</returns>
        public int[] GiveIntArrayShuffle(int[] _array, int _shuffelTimes)
        {
            for (int i = 0; i < _shuffelTimes; i++)
            {
                _array = (int[])SortAlgorithm.SortAlgorithmCSharp.SwapArrayPlace(
                    _array, 
                    r.Next(_array.Length), 
                    r.Next(_array.Length)
                    );
            }
            return _array;
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
                equal = _array1.GetValue(i) == _array2.GetValue(i);

                if (equal == false)
                    break;
            }

            return equal;
        }
    }
}
