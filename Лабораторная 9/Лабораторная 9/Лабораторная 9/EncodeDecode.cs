using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_9
{
    public class EncodeDecode
    {
        public static string GetEncodeMessage(string input, string[] charsArray, string[] charBitsArray)
        {
            string encodedMessage = "";
            for (int i = 0; i < input.Length; i++)
            {
                string temporaryIndeed = "";

                temporaryIndeed += input[i];

                for (int j = 0; j < charsArray.Length; j++)
                {
                    if (temporaryIndeed == charsArray[j])
                    {
                        encodedMessage += charBitsArray[j];
                        break;
                    }
                }
            }

            return encodedMessage;
        }

        public static string GetDecodedMessage(string encodedMessage, string[] charsArray, string[] charBitsArray)
        {
            int minimal = 2;
            string decodedMessage = "";

            for (int i = 0; i < encodedMessage.Length;)
            {
                string temporaryIndeed = "";

                for (int j = i; j < i + minimal; j++)
                {
                    if (j < encodedMessage.Length)
                    {
                        temporaryIndeed += encodedMessage[j];
                    }

                    else
                    {
                        break;
                    }
                }

                bool booleanIndeed = false;

                for (int k = 0; k < charBitsArray.Length; k++)
                {
                    if (temporaryIndeed == charBitsArray[k])
                    {
                        decodedMessage += charsArray[k];
                        booleanIndeed = true;
                        break;
                    }
                }

                //if (!booleanIndeed)
                //{
                //    minimal--;
                //}

                if (!booleanIndeed)
                {
                    minimal++;
                }

                else
                {
                    i += minimal;
                    minimal = 2;
                }
            }

            return decodedMessage;
        }

        public static string EncodingToBytes(string message)
        {
            var encodeText1251 = Encoding.GetEncoding(1251).GetBytes(message.ToCharArray());

            string binaryIndeed = "";

            foreach (var v in encodeText1251)
            {
                binaryIndeed += Convert.ToString(v, 2);
            }

            return binaryIndeed;
        }
    }
}
