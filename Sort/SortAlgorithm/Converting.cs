using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public static class Converting
    {
        /// <summary>
        /// Convert character to binary
        /// </summary>
        /// <param name="_char">char to convert</param>
        /// <returns>binary as string</returns>
        public static string CharToBinary(char _char)
        {
            return Convert.ToString(Convert.ToByte(_char), 2).PadLeft(8, '0');
        }

        /// <summary>
        /// Convert character to binary
        /// </summary>
        /// <param name="_char">char to convert</param>
        /// <returns>binary as string</returns>
        /// /// <exception cref="ArgumentNullException">Thrown when char is null.</exception>
        public static string CharToBinary(char? _char)
        {
            // return if null
            if (_char == null) throw new ArgumentNullException($"Character is NULL.");

            // return string
            return CharToBinary((char)_char);
        }

        /// <summary>
        /// Convert string to binary
        /// </summary>
        /// <param name="_chars">chars to convert</param>
        /// <returns>binary as string array</returns>
        /// <exception cref="ArgumentNullException">Thorwn when array is null</exception>
        public static string[] StringToBinary(params char[] _chars)
        {
            // return if null
            if (_chars == null) throw new ArgumentNullException($"Array is NULL.");

            // create string array
            string[] toReturn = new string[_chars.Length];

            // loop
            for (int i = 0; i < _chars.Length; i++)
            {
                toReturn[i] = CharToBinary(_chars[i]);
            }

            // return string
            return toReturn;
        }

        /// <summary>
        /// Convert string to binary
        /// </summary>
        /// <param name="_string">chars to convert</param>
        /// <returns>binary as string array</returns>
        /// <exception cref="ArgumentNullException">Thorwn when array is null</exception>
        public static string[] StringToBinary(string _string)
        {
            if (_string == null) throw new ArgumentNullException("string is null");

            return StringToBinary(_string.ToCharArray());
        }

        /// <summary>
        /// Convert string to binary
        /// </summary>
        /// <param name="_chars">chars to convert</param>
        /// <returns>binary as string array</returns>
        /// <exception cref="ArgumentNullException">Thorwn when array is null</exception>
        public static string[] StringToBinary(params char?[] _chars)
        {
            // return if null
            if (_chars == null) throw new ArgumentNullException($"Array was NULL.");

            // create string array
            string[] toReturn = new string[_chars.Length];

            // loop
            for (int i = 0; i < _chars.Length; i++)
            {
                toReturn[i] = CharToBinary(_chars[i]);
            }

            // return string
            return toReturn;
        }

        /// <summary>
        /// Convert binary to char
        /// </summary>
        /// <param name="_binary">binary as string</param>
        /// <returns>converted string</returns>
        /// <exception cref="StringNotBinaryException">Thorwn when binary string is not binary</exception>
        public static char BinaryToChar(string _binary)
        {
            if (!IsBinary(_binary)) throw new StringNotBinaryException($"\"{_binary}\" is not binary");

            byte[] byteArray = new byte[1];

            byteArray[0] = (Convert.ToByte(_binary.Substring(0, 8), 2));

            return Encoding.ASCII.GetString(byteArray)[0];
        }

        /// <summary>
        /// Convert binary to string. 
        /// </summary>
        /// <param name="_binary">binary as string array</param>
        /// <returns>converted string</returns>
        /// <exception cref="StringNotBinaryException">Thorwn when binary string is not binary</exception>
        public static string BinaryToString(string[] _binary)
        {
            string toReturn = "";
            foreach (string s in _binary)
            {
                if (!IsBinary(s)) throw new StringNotBinaryException($"\"{_binary}\" is not binary");

                byte[] byteArray = new byte[1];

                byteArray[0] = (Convert.ToByte(s.Substring(0, 8), 2));

                toReturn += Encoding.ASCII.GetString(byteArray);
            }
            return toReturn;
        }

        private static bool IsBinary(string _binaryString)
        {
            if (_binaryString.Length != 8) return false;

            foreach (char c in _binaryString)
            {
                if (c != '0' &&
                    c != '1') return false;
            }

            return true;
        }
    }
}
