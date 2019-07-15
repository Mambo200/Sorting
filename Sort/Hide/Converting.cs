using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide.Converting
{
    public static class Binary
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
            if (!IsBinary(_binary)) throw new HideConverting.StringNotBinaryException($"\"{_binary}\" is not binary");

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
                if (!IsBinary(s)) throw new HideConverting.StringNotBinaryException($"\"{_binary}\" is not binary");

                byte[] byteArray = new byte[1];

                byteArray[0] = (Convert.ToByte(s.Substring(0, 8), 2));

                toReturn += Encoding.ASCII.GetString(byteArray);
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
            if (!IsBinary(_binOne)) throw new HideConverting.StringNotBinaryException($"\"{_binOne}\" is not binary.");
            if (!IsBinary(_binTwo)) throw new HideConverting.StringNotBinaryException($"\"{_binTwo}\" is not binary.");
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

    public static class Hexadecimal
    {
        /// <summary>
        /// Convert Strings to hexadecimal.
        /// </summary>
        /// <param name="_value">the string which shall be converted</param>
        /// <returns>converted string</returns>
        public static string[] StringToHex(string _value)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(_value);
            string[] temp = new string[bytes.Length];
            string[] toReturn = new string[temp.Length / 2];
            int i = 0;
            foreach (var t in bytes)
            {
                temp[i++] = t.ToString("X2");
            }

            for (int y = 0; y < temp.Length; y += 2)
            {
                toReturn[y / 2] = temp[y];
            }

            return toReturn;
        }

        public static string[] Combine(string[] _left, string[] _right)
        {
            if (_left == null || _right == null) throw new NullReferenceException("One array is null.");
            #region ERROR
            if (!IsHexadecimal(_left, _right)) throw new FormatException("String was not in the Hexadecimal format.");
            #endregion
            if (_left.Length != _right.Length) throw new IndexOutOfRangeException("Arrays do not have the same lengh.");
            if (_left.Length == 0) return new string[0];

            List<string> toReturn = new List<string>();
            int overload = 0;
            int outOverload = 0;
            for (int i = _left.Length - 1; i >= 0; i--)
            {
                toReturn.Insert(0, (Combine(_left[i], _right[i], overload, out outOverload)));
            }

            return toReturn.ToArray();
        }

        private static string Combine(string _left, string _right, int _overload, out int overload)
        {
            overload = _overload;
            string temp = "";
            for (int i = 2 - 1; i >= 0; i--)
            {
                short s1 = HexOriginalToHexNumber(_left[i]);
                short s2 = HexOriginalToHexNumber(_right[i]);

                short newValue = (short)(s1 + s2 + overload);
                overload = 0;
                while (newValue > 15)
                {
                    overload++;
                    newValue -= 15;
                }

                temp += HexNumberToHexOriginal(newValue);
            }
            overload = _overload;

            string toReturn = "" + temp[1] +temp[0];
            return toReturn;
        }

        private static string HexNumberToHexOriginal(short _number)
        {
            switch (_number)
            {
                case 0:
                    return "0";
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                case 5:
                    return "5";
                case 6:
                    return "6";
                case 7:
                    return "7";
                case 8:
                    return "8";
                case 9:
                    return "9";
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    throw new FormatException("Wrong Format. only accept numbers from 0 to 15");
            }
        }
        private static short HexOriginalToHexNumber(char _char)
        {
            string temp = "" + _char;
            temp = temp.ToUpper();
            char toLook = temp[0];
            switch (toLook)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    throw new FormatException(toLook + " is an invalid Hex Char");
            }
        }
        public static string HexToString(string[] _hex)
        {
            if (IsHexadecimal(_hex)) throw new FormatException("at least one string was in the wrong Format");

            string toReturn = "";

            for (int i = 0; i < _hex.Length; i++)
            {

                var bytes = new byte[2];



                bytes[0] = Convert.ToByte(_hex[i].Substring(0, 2), 16);
                bytes[1] = Convert.ToByte("00".Substring(0, 2), 16);

                toReturn += Encoding.Unicode.GetString(bytes);
            }


            return toReturn;
        }

        private static bool IsHexadecimal(string _hexString)
        {
            if (_hexString.Length > 2 || _hexString.Length < 0) return false;

            foreach (char c in _hexString)
            {
                if (c != '0' || c != '1' || c != '2' || c != '3' || c != '4' || c != '5' || c != '6' || c != '7' || c != '8' || c != '9' ||
                    c != 'A' || c != 'B' || c != 'C' || c != 'D' || c != 'E' || c != 'F') return false;
            }

            return true;
        }

        private static bool IsHexadecimal(string[] _hexString)
        {
            for (int i = 0; i < _hexString.Length; i++)
            {
                if (!IsHexadecimal(_hexString[i])) return false;
            }

            return true;
        }

        private static bool IsHexadecimal(string[] _left, string[] _right)
        {
            if (!IsHexadecimal(_left) || !IsHexadecimal(_right)) return false;
            else return true;
        }
    }
}
