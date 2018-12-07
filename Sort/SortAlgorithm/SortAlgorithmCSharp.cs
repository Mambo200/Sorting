using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public static class SortAlgorithmCSharp
    {
        /// <summary>
        /// Sort int array (Bubble Sort Algorithm)
        /// </summary>
        /// <param name="_list">list to sort (uses array variety)</param>
        /// <returns>sorted list</returns>
        public static List<int> BubbleSortInt(List<int> _list)
        {
            // convert to array
            int[] vs = new int[_list.Count];
            Array.Copy(_list.ToArray(), vs, _list.Count);

            return BubbleSortInt(vs).ToList();
        }

        /// <summary>
        /// Sort int array (Bubble Sort Algorithm)
        /// </summary>
        /// <param name="_array">array to sort</param>
        /// <returns>sorted array</returns>
        public static int[] BubbleSortInt(int[] _array)
        {
            int[] vs = new int[_array.Length];
            Array.Copy(_array, vs, _array.Length);
            int highestArrayToCheck = _array.Length;
            int temp = highestArrayToCheck;

            bool swapped = true;

            while (swapped)
            {
                // reset swapped bool
                swapped = false;
                highestArrayToCheck = temp;

                // check array sort
                for (int i = 0; i < highestArrayToCheck - 1; i++)
                {
                    // check int of arrays
                    if (vs[i] > vs[i + 1])
                    {
                        // swap array locations
                        vs = (int[])SwapArrayPlace(vs, i, i + 1);
                        swapped = true;
                        temp = i + 1;
                    }

                }

            }

            return vs;
        }

        /// <summary>
        /// Swap two positions from an array
        /// </summary>
        /// <param name="_array">array to swap</param>
        /// <param name="_firstArrayLocation">first position to swap</param>
        /// <param name="_secondArrayLocation">second position to swap</param>
        /// <returns>new swapped array. returns null array when swap didnt work (Out of Range Exception)</returns>
        public static Array SwapArrayPlace(Array _array, int _firstArrayLocation, int _secondArrayLocation)
        {
            try
            {
            var p1 = _array.GetValue(_firstArrayLocation);
            var p2 = _array.GetValue(_secondArrayLocation);

                _array.SetValue(p2, _firstArrayLocation);
                _array.SetValue(p1, _secondArrayLocation);
            }
            catch (IndexOutOfRangeException)
            {
                _array = null;
            }
            
            return _array;
        }

        /// <summary>
        /// Swap two positions from an array
        /// </summary>
        /// <param name="_array">array to swap</param>
        /// <param name="_firstArrayLocation">first position to swap</param>
        /// <param name="_secondArrayLocation">second position to swap</param>
        /// <returns>new swapped array. returns null array when swap didnt work</returns>
        //public static int[] SwapArrayPlace(int[] _array, int _firstArrayLocation, int _secondArrayLocation)
        //{
        //    int[] newArray = new int[_array.GetLength(0)];
        //    Array.Copy(_array, newArray, _array.Length);
        //
        //    try
        //    {
        //        newArray.SetValue(_array.GetValue(_firstArrayLocation), _secondArrayLocation);
        //        newArray.SetValue(_array.GetValue(_secondArrayLocation), _firstArrayLocation);
        //    }
        //    catch (IndexOutOfRangeException)
        //    {
        //        newArray = null;
        //    }
        //
        //    return newArray;
        //
        //}
    }
}
