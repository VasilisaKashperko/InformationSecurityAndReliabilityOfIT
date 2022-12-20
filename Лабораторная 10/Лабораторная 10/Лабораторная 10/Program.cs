using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Лабораторная_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = "kashperkovasilisasergeevna"; // 26

                Console.WriteLine("Сообщение: " + input + "\n");

                int dictionaryBuffer = 0;
                int slidingWindowDataBuffer = 0;

                while (dictionaryBuffer == 0)
                {
                    Console.Write("Размер словаря будет равен: ");

                    dictionaryBuffer = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                }

                while (slidingWindowDataBuffer == 0)
                {
                    Console.Write("Размер буфера: ");

                    slidingWindowDataBuffer = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                }

                string mainDictionary = new string('0', dictionaryBuffer);

                string slidingWindowMessage = input.Substring(0, slidingWindowDataBuffer);

                string afterSlidingWindowMessage = input.Substring(slidingWindowDataBuffer, input.Length - slidingWindowDataBuffer);

                Console.WriteLine("\t\t\t\tСжатие\n");

                string encodedInput = string.Empty;
                char theNextSymbolWithoutRepeating;

                int indexStartExtention = 0;
                int extentionLength = 0;

                Stopwatch encodeTimer = new Stopwatch();

                encodeTimer.Start();

                while (slidingWindowMessage != string.Empty)
                {
                    Functionality.ToSearchSymbols(mainDictionary, slidingWindowMessage, out indexStartExtention, out extentionLength, out theNextSymbolWithoutRepeating);

                    //Functionality.ToAddSymbols(extentionLength, ref dictionary, ref slidingWindowMessage);
                    Functionality.ToAddSymbols(extentionLength + 1, ref mainDictionary, ref slidingWindowMessage);

                    Functionality.toCheckBufferSize(dictionaryBuffer, ref mainDictionary);

                    Functionality.ToAddSymbols(extentionLength + 1, ref slidingWindowMessage, ref afterSlidingWindowMessage);

                    Functionality.toCheckBufferSize(slidingWindowDataBuffer, ref slidingWindowMessage);

                    Console.Write(mainDictionary + "\t\t|\t");

                    Console.Write(slidingWindowMessage + "\t\t|\t");

                    Console.Write(indexStartExtention + "" + extentionLength + "" + theNextSymbolWithoutRepeating + "\n\n");

                    encodedInput += indexStartExtention.ToString() + extentionLength.ToString() + theNextSymbolWithoutRepeating.ToString();
                }

                encodeTimer.Stop();

                Console.WriteLine("\nСжатое сообщение: " + encodedInput + "\n");

                Console.WriteLine("\t\t\t\tРаспаковка\n");

                Stopwatch decodeTimer = new Stopwatch();
                decodeTimer.Start();

                string UnwrapedMessage = string.Empty;
                string tempStr = string.Empty;
                mainDictionary = new string('0', dictionaryBuffer);

                for (int i = 0; i <encodedInput.Length/3; i++)
                {
                    indexStartExtention = int.Parse(encodedInput[3*i].ToString());

                    //extentionLength = int.Parse(encodedInput[3*i + 1]);
                    extentionLength = int.Parse(encodedInput[3*i+1].ToString());

                    theNextSymbolWithoutRepeating = encodedInput[3*i+2];

                    if (extentionLength == 0 && indexStartExtention == 0)
                    {
                        UnwrapedMessage += theNextSymbolWithoutRepeating;
                        mainDictionary += theNextSymbolWithoutRepeating;
                    }

                    else
                    {
                        tempStr = mainDictionary.Substring((indexStartExtention - 1), extentionLength) + theNextSymbolWithoutRepeating;
                        UnwrapedMessage += tempStr;
                        mainDictionary += tempStr;
                    }

                    Functionality.toCheckBufferSize(dictionaryBuffer, ref mainDictionary);

                    Console.Write(indexStartExtention + "" + extentionLength + "" + theNextSymbolWithoutRepeating + "" + "\t\t|\t");
                    Console.Write(mainDictionary + "\t\t|\t");
                    Console.Write(UnwrapedMessage + "\n\n");
                }

                decodeTimer.Stop();

                Console.WriteLine("\nВремя кодирования:" + encodeTimer.ElapsedMilliseconds);
                Console.WriteLine("Время декодирования:" + decodeTimer.ElapsedMilliseconds);

                Console.WriteLine("\nВходящее сообщение: " + input.Length + " символов");
                Console.WriteLine("Сжатое сообщение: " + encodedInput.Length + " символов");

                Console.WriteLine("\t\t\t\tЭффективность сжатия\n");

                double r = (Convert.ToDouble(encodedInput.Length) / Convert.ToDouble(input.Length))*100;
                Console.WriteLine(r);
            }

            catch
            {
                Console.WriteLine("Ошибка при выполнении программы. Попробуйте ввести другие значения для буфера.");
            }
        }
    }
}
