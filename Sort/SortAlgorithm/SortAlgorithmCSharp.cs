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
        /// Sort int list (Bubble Sort Algorithm)
        /// </summary>
        /// <param name="_list">list to sort (uses array variety)</param>
        /// <returns>sorted list</returns>
        public static List<int> BubbleSort(List<int> _list)
        {
            // convert to array
            int[] vs = new int[_list.Count];
            Array.Copy(_list.ToArray(), vs, _list.Count);

            return BubbleSort(vs).ToList();
        }

        /// <summary>
        /// Sort int array (Bubble Sort Algorithm)
        /// </summary>
        /// <param name="_array">array to sort</param>
        /// <returns>sorted array</returns>
        public static int[] BubbleSort(int[] _array)
        {
            int highestArrayToCheck = _array.Length;
            int temp = highestArrayToCheck;

            bool swapped = true;

            while (swapped)
            {
                // reset swapped bool and set highest position swapped
                swapped = false;
                highestArrayToCheck = temp;

                // check array sort
                for (int i = 0; i < highestArrayToCheck - 1; i++)
                {
                    // check int of arrays
                    if (_array[i] > _array[i + 1])
                    {
                        // swap array locations
                        _array = (int[])SwapArrayPlace(_array, i, i + 1);
                        swapped = true;
                        temp = i + 1;
                    }

                }

            }

            return _array;
        }

        /// <summary>
        /// Sort string array (Bubble Sort Algorithm)
        /// </summary>
        /// <param name="_array">array to sort</param>
        /// <returns>sorted array</returns>
        public static string[] BubbleSort(string[] _array)
        {
            int highestArrayToCheck = _array.Length;
            int temp = highestArrayToCheck;

            bool swapped = true;

            while (swapped)
            {
                // reset swapped bool and set highest position swapped
                swapped = false;
                highestArrayToCheck = temp;

                // check array sort
                for (int i = 0; i < highestArrayToCheck - 1; i++)
                {
                    char[] a1 = _array[i].ToCharArray();
                    char[] a2 = _array[i + 1].ToCharArray();
                    // check int of arrays
                    for (int n = 0; n < a1.GetLength(0); n++)
                    {
                        // check if array contains chat
                        if (a2.GetLength(0) == 0)
                        {
                            if (a1.GetLength(0) != 0)
                            {
                                _array = (string[])SwapArrayPlace(_array, i, i + 1);
                                swapped = true;
                                temp = i + 1;
                                break;
                            }
                        }
                        if (a1[n] > a2[n])
                        {
                            _array = (string[])SwapArrayPlace(_array, i, i + 1);
                            swapped = true;
                            temp = i + 1;
                            break;
                        }
                        else if (a1[n] < a2[n])
                        {
                            break;
                        }
                    }
                }

            }

            return _array;
        }


        /// <summary>
        /// Sorting int values (Limitations: every value must be different!)
        /// </summary>
        /// <param name="_array">array to sort</param>
        /// <returns>sorted array. if failed, return int[0]</returns>
        public static int[] FailSortInt(int[] _array)
        {
            int highestNumber = int.MinValue;
            int lowestNumber = 0;

            // get highest and lowest number of array
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                if (_array[i] < lowestNumber)
                    lowestNumber = _array[i];
                else if (_array[i] > highestNumber)
                    highestNumber = _array[i];
            }

            try
            {
                int test = (Math.Abs(lowestNumber) + Math.Abs(highestNumber)) + _array.GetLength(0);
            }
            catch (Exception)
            {
                return new int[0];
                throw;
            }

            // create new array
            string[] newArray = new string[Math.Abs(lowestNumber) + Math.Abs(highestNumber) + _array.GetLength(0)];

            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                newArray[i] = "nothing";
            }

            // paste values
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                int position = _array[i] + Math.Abs(lowestNumber);
                int number = _array[i];
                newArray[position] = _array[i].ToString();
            }

            int positionToPaste = 0;
            int[] arrayToReturn = new int[_array.GetLength(0)];
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                if (newArray[i] != "nothing")
                {
                    arrayToReturn[positionToPaste] = Convert.ToInt32(newArray[i]);
                    positionToPaste++;
                }
            }
            return arrayToReturn;
        }

        /// <summary>
        /// Sorting int values and takes the lowest and highest value and puts it in a new array
        /// </summary>
        /// <param name="_array">array to sort</param>
        /// <returns>new sorted array</returns>
        public static int[] LowestHighestSortInt(int[] _array)
        {
            int[] arrayToReturn = new int[_array.GetLength(0)];
            List<int> listToSort = _array.ToList();
            int place = 0;
            while (listToSort.Count != 0)
            {
                int valHighest = int.MinValue;
                int valLowest = int.MaxValue;

                foreach (int number in listToSort)
                {
                    // check highest and lowest number
                    if (listToSort.Count == 1)
                    {
                        arrayToReturn[place] = number;
                    }
                    else
                    {
                        if (number > valHighest)
                            valHighest = number;
                        if (number < valLowest)
                            valLowest = number;
                    }

                }
                // add lowest and highest value to array
                arrayToReturn[place] = valLowest;
                arrayToReturn[arrayToReturn.GetLength(0) - (place + 1)] = valHighest;

                // remove values from list
                listToSort.Remove(valLowest);
                listToSort.Remove(valHighest);
                place++;
            }

            return arrayToReturn;
        }

        /// <summary>
        /// Sorting int values, takes the lowest value and swap it with the first item, then second and so on.
        /// </summary>
        /// <param name="_array">array to sort</param>
        /// <returns>new sorted array</returns>
        public static int[] SelectionSortInt(int[] _array)
        {
            int[] arrayToRetun = new int[_array.GetLength(0)];
            Array.Copy(_array, arrayToRetun, arrayToRetun.GetLength(0));

            for (int i = 0; i < arrayToRetun.GetLength(0); i++)
            {
                int lowest = int.MaxValue;
                int positionToSwap = -1;
                for (int y = i; y < arrayToRetun.GetLength(0); y++)
                {
                    // get lowest number and array position
                    if (arrayToRetun[y] < lowest)
                    {
                        lowest = arrayToRetun[y];
                        positionToSwap = y;
                    }

                }

                // swap array places
                if (positionToSwap >= 0)
                {
                    arrayToRetun = (int[])SwapArrayPlace(arrayToRetun, i, positionToSwap);
                }
            }

            return arrayToRetun;
        }

        public static int[] CocktailSort(int[] _array)
        {
            int[] arrayToReturn = new int[_array.GetLength(0)];
            Array.Copy(_array, arrayToReturn, _array.GetLength(0));
            bool swapped = false;

            for (int i = 0; i < _array.GetLength(0); i++)
            {
                // reset flag
                swapped = false;

                // from low to high
                for (int y = 0; y < _array.GetLength(0) - (i + 1); y++)
                {
                    if (arrayToReturn[y] > arrayToReturn[y + 1])
                    {
                        SwapArrayPlace(arrayToReturn, y, y + 1);
                        swapped = true;
                    }
                }

                // from high to low
                for (int y = _array.GetLength(0) - (i + 1); y >= i + 1; y--)
                {
                    if (arrayToReturn[y - 1] > arrayToReturn[y])
                    {
                        SwapArrayPlace(arrayToReturn, y - 1, y);
                        swapped = true;
                    }
                }

                // check if something was changed
                if (swapped == false)
                {
                    break;
                }
            }

            return arrayToReturn;
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

    }
}
