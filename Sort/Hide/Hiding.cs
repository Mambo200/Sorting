﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HideConverting
{
    public class HidingInt
    {
        private static Random r = new Random();
        private string[] hp = Hide.Converting.Binary.StringToBinary("0");
        public int Hp
        {
            get
            {
                string s = "";

                for (int i = 0; i < hp.Length; i++)
                {

                    if (i % 2 != 0) continue;
                    s += Hide.Converting.Binary.BinaryToChar(hp[i]);
                }
                return int.Parse(s);
            }
            set
            {
                string[] temp = Hide.Converting.Binary.StringToBinary(Convert.ToString(value));

                string[] temp2 = new string[temp.Length * 2];
                hp = new string[temp2.Length];

                for (int i = 0; i < temp2.Length; i++)
                {
                    if (i % 2 == 0) hp[i] = temp[i / 2];
                    else hp[i] = Hide.Converting.Binary.CharToBinary(Convert.ToString(r.Next(10))[0]);

                }
            }
        }
    }

    public class HidingFloat
    {
        private static Random r = new Random();
        private string[] hp = Hide.Converting.Binary.StringToBinary("0");
        public float Hp
        {
            get
            {
                string temp = Hide.Converting.Binary.BinaryToString(hp);
                return float.Parse(temp);
            }
            set
            {
                hp = Hide.Converting.Binary.StringToBinary(Convert.ToString(value));
            }
        }
    }

    public class HidingDecimal
    {
        private static Random r = new Random();
        private string[] hp = Hide.Converting.Binary.StringToBinary("0");
        public decimal Hp
        {
            get
            {
                string temp = Hide.Converting.Binary.BinaryToString(hp);
                return decimal.Parse(temp);
            }
            set
            {
                hp = Hide.Converting.Binary.StringToBinary(Convert.ToString(value));
            }
        }

    }

    public class HidingString
    {
        BinaryFormatter bf = new BinaryFormatter();
        private MemoryStream mValue;
        private byte[] buffer;

        private HidingString() { }
        public HidingString(string _value)
        {
            SetValue(_value);
        }

        public string Value
        {
            get
            {
                string toReturn = "";
                MemoryStream ms = new MemoryStream(buffer);
                toReturn = (string)bf.Deserialize(ms);
                ms.Close();
                ms.Dispose();
                return toReturn;
            }
            set
            {
                mValue.Close();
                mValue.Dispose();

                SetValue(value);
            }
        }

        private void SetValue(string _value)
        {
            mValue = new MemoryStream();
            bf.Serialize(mValue, _value);
            buffer = new byte[mValue.Length];
            mValue.Position = 0;
            mValue.Read(buffer, 0, (int)mValue.Length);

        }

        ~HidingString()
        {
            mValue.Close();
            mValue.Dispose();
            mValue = null;
        }
    }
}
