using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_9
{
    public class Functionality
    {
        public static void GetProbabylityAndFrequency(string inputMessage, List<string> chars, List<int> frequencies, List<double> probabilities)
        {
            string outputMessage = "";

            for (int i = 0; i < inputMessage.Length; i++)
            {
                int count = 0;
                bool charRepeats = false;
                bool isCharRepeating = false;

                if (!isCharRepeating)
                {

                    for (int j = 0; j < inputMessage.Length; j++)
                    {
                        if (inputMessage[i] == inputMessage[j])
                        {
                            charRepeats = true;
                            count++;
                        }
                    }
                }

                else
                {
                    continue;
                }

                for (int k = 0; k < outputMessage.Length; k++)
                {
                    if (inputMessage[i] == outputMessage[k])
                    {
                        isCharRepeating = true;
                        break;
                    }
                }

                if (charRepeats)
                {
                    outputMessage = outputMessage + inputMessage[i];
                }

                if (!isCharRepeating)
                {
                    string temporaryBuffer = "";
                    temporaryBuffer = $"{temporaryBuffer}{inputMessage[i]}";

                    chars.Add(temporaryBuffer);
                    frequencies.Add(count);
                    probabilities.Add((double)count/(double)inputMessage.Length);
                }
            }
        }

        public static void GetArrayFromChars(string[] charsArray, int[] frequenciesArray, double[] probabilitiesArray, List<string> chars, List<int> frequencies, List<double> probabilities)
        {
            for (int i = 0; i < charsArray.Length; i++)
            {
                charsArray[i] = chars[i];
                frequenciesArray[i] = frequencies[i];
                probabilitiesArray[i] = probabilities[i];
            }
        }

        public static void PrintResults(string[] charsArray, int[] frequenciesArray, double[] probabilitiesArray)
        {
            Console.WriteLine("----------------+------------------+-------------------------");
            Console.WriteLine("     Символ     |     Частота      |       Вероятность");
            Console.WriteLine("----------------+------------------+-------------------------");

            for (int i = 0; i < charsArray.Length; i++)
            {
                Console.WriteLine($"\t'{charsArray[i]}'\t|\t{frequenciesArray[i]}\t   |\t{probabilitiesArray[i]}");
            }
            Console.WriteLine("----------------+------------------+-------------------------");
        }

        public static void GetSortedArray(string[] charsArray, double[] probabilitiesArray)
        {
            Console.WriteLine("\nСортировка:\n");
            Array.Sort(probabilitiesArray, charsArray);
            Array.Reverse(probabilitiesArray);
            Array.Reverse(charsArray);
            Console.WriteLine("----------------+-----------------------------");
            Console.WriteLine("     Символ     |          Вероятность");
            Console.WriteLine("----------------+-----------------------------");
            for (int i = 0; i < probabilitiesArray.Length; i++)
            {
                Console.Write($"\t'{charsArray[i]}'\t|\t{probabilitiesArray[i]}" + "\n");
            }
            Console.WriteLine("----------------+-----------------------------");
        }

        public static double GetSummaryProbabilities(double[] probabilitiesArray)
        {
            double summaryProbabylity = 0;

            for (int i = 0; i < probabilitiesArray.Length; i++)
            {
                summaryProbabylity += probabilitiesArray[i];
            }

            return summaryProbabylity;
        }

        public static void ShannonFano(int left, int right, double[] probabilitiesArray, string[] charBitsArray)
        {
            int a;

            if (left < right)
            {
                a = ToSplitSequences(left, right, probabilitiesArray);

                for (int i = left; i <= right; i++)
                {
                    if (i <= a)
                    {
                        charBitsArray[i] += Convert.ToByte(1);
                    }
                    else
                    {
                        charBitsArray[i] += Convert.ToByte(0);
                    }
                }

                // и немножко рекурсии
                ShannonFano(left, a, probabilitiesArray, charBitsArray);
                ShannonFano(a + 1, right, probabilitiesArray, charBitsArray);
            }
        }

        public static int ToSplitSequences(int left, int right, double[] probabilitiesArray)
        {
            int a;
            double countFirst = 0;
            double countSecond;

            for (int i = left; i <= right - 1; i++)
            {
                countFirst += probabilitiesArray[i];
            }

            //for (int i = left; i <= right - 1; i++)
            //{
            //    countFirst -= probabilitiesArray[i];
            //}

            countSecond = probabilitiesArray[right];
            a = right;

            while (countFirst >= countSecond)
            {
                a--;
                countFirst -= probabilitiesArray[a];
                countSecond += probabilitiesArray[a];
            }

            return a;
        }
    }
}
