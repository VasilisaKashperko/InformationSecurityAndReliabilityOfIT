using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    class Strings
    {
        static public string ConvertToBinary(string str)
        {
            return string.Join("", str.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
        }

        static public string xorOperation(string a, string b)
        {
            string first = a;
            string second = b;

            if (first.Length < second.Length)
            {
                first = first.PadLeft(second.Length, '0');
            }
            else if (second.Length < first.Length)
            {
                second = second.PadLeft(first.Length, '0');
            }

            StringBuilder resultOfXOR = new StringBuilder("");

            for (int i = 0; i < first.Length; i++)
            {
                if ((first[i] == '0' && second[i] == '0') || (first[i] == '1' && second[i] == '1'))
                {
                    resultOfXOR.Append('0');
                }
                else
                {
                    resultOfXOR.Append('1');
                }
            }

            return resultOfXOR.ToString();
        }

        static public string ApplyError(string informationWord, int errorAmount)
        {
            int applyError = 0;
            char[] informationWordWithError = new char[informationWord.Length];
            informationWordWithError = informationWord.ToArray<char>();
            while (applyError != errorAmount)
            {
                Random random = new Random();
                int position = random.Next(0, informationWord.Length);

                informationWordWithError[position] = char.Parse(xorOperation(informationWordWithError[position].ToString(), '1'.ToString()));

                Thread.Sleep(100);
                applyError++;
            }
            return new string(informationWordWithError);
        }
    }
}
