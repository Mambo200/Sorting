using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide
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

        public static string[] StringToHex(string _value)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(_value);
            string[] toReturn = new string[bytes.Length];
            int i = 0;
            foreach (var t in bytes)
            {
                toReturn[i++] = t.ToString("X2");
            }
            return toReturn;
        }

        public static string HexToString(string[] _hex)
        {
            string toReturn = "";
            List<byte> b = new List<byte>();

            for (int i = 0; i < _hex.Length; i += 2)
            {

                var bytes = new byte[2];



                bytes[0] = Convert.ToByte(_hex[i].Substring(0, 2), 16);
                bytes[1] = Convert.ToByte(_hex[i+1].Substring(0, 1), 16);

                toReturn += Encoding.Unicode.GetString(bytes);
            }


            return toReturn;
        }

        /// <summary>
        /// Combine two binary formatted strings
        /// </summary>
        /// <param name="_binOne">first binary</param>
        /// <param name="_binTwo">second binary</param>
        /// <param name="_throwWhenOverflow">true: Function throws an Exception if overflow</param>
        /// <exception cref="StringNotBinaryException">String was in the wrong format</exception>
        /// <exception cref="OverflowException">Addition causes an overflow</exception>
        /// <returns></returns>
        public static string Combine(string _binOne, string _binTwo, bool _throwWhenOverflow = false)
        {
            if (!IsBinary(_binOne)) throw new StringNotBinaryException($"\"{_binOne}\" is not binary.");
            if (!IsBinary(_binTwo)) throw new StringNotBinaryException($"\"{_binTwo}\" is not binary.");
            if (_throwWhenOverflow)
                if (_binOne[0] == '1' && _binTwo[0] == '1') throw new OverflowException("binary would overflow");
            string toReturn = "";
            bool addone = false;

            for (int i = 8 - 1; i >= 0; i--)
            {
                char c1 = _binOne[i];
                char c2 = _binTwo[i];

                // check numbers
                if (c1 == '0' && c2 == '0') { toReturn = toReturn.Insert(0, addone ? "1" : "0"); addone = false; }
                else if (c1 == '1' && c2 == '1') { toReturn = toReturn.Insert(0, addone ? "1" : "0"); addone = true; }
                else if (c1 == '1' || c2 == '1') { toReturn = toReturn.Insert(0, addone ? "0" : "1"); }
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
