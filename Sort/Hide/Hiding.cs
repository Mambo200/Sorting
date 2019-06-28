using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide
{
    public class HidingInt
    {
        private static Random r = new Random();
        private string[] hp = Converting.StringToBinary("0");
        public int Hp
        {
            get
            {
                string s = "";

                for (int i = 0; i < hp.Length; i++)
                {

                    if (i % 2 != 0) continue;
                    s += Converting.BinaryToChar(hp[i]);
                }
                return int.Parse(s);
            }
            set
            {
                string[] temp = Converting.StringToBinary(Convert.ToString(value));

                string[] temp2 = new string[temp.Length * 2];
                hp = new string[temp2.Length];

                for (int i = 0; i < temp2.Length; i++)
                {
                    if (i % 2 == 0) hp[i] = temp[i / 2];
                    else hp[i] = Converting.CharToBinary(Convert.ToString(r.Next(10))[0]);

                }
            }
        }
    }

    public class HidingFloat
    {
        private static Random r = new Random();
        private string[] hp = Converting.StringToBinary("0");
        public float Hp
        {
            get
            {
                string temp = Converting.BinaryToString(hp);
                return float.Parse(temp);
            }
            set
            {
                hp = Converting.StringToBinary(Convert.ToString(value));
            }
        }
    }

    public class HidingDecimal
    {
        private static Random r = new Random();
        private string[] hp = Converting.StringToBinary("0");
        public decimal Hp
        {
            get
            {
                string temp = Converting.BinaryToString(hp);
                return decimal.Parse(temp);
            }
            set
            {
                hp = Converting.StringToBinary(Convert.ToString(value));
            }
        }

    }
}
