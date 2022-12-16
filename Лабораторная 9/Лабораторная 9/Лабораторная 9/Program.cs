using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Лабораторная_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Василиса Кашперко";
            Console.WriteLine("Сообщение: " + input + "\n");

            List<string> chars = new List<string>();
            List<int> frequency = new List<int>();
            List<double> probability = new List<double>();

            Console.WriteLine("Рассчет вероятностей появления символов в сообщении:\n");
            Functionality.GetProbabylityAndFrequency(input, chars, frequency, probability);

            string[] lettersArray = new string[chars.Count];

            int[] frequenciesArray = new int[chars.Count];

            double[] probabilitiesArray = new double[chars.Count];

            string[] letterBitsArray = new string[chars.Count];

            Functionality.GetArrayFromChars(lettersArray, frequenciesArray, probabilitiesArray, chars, frequency, probability);
            Functionality.PrintResults(lettersArray, frequenciesArray, probabilitiesArray);

            Functionality.GetSortedArray(lettersArray, probabilitiesArray);

            double sumOfProbabilities = Functionality.GetSummaryProbabilities(probabilitiesArray);
            Console.WriteLine("\nСумма вероятностей = " + sumOfProbabilities);

            Console.WriteLine("\n\t\t\tМетод сжатия Шеннона-Фано:");
            Functionality.ShannonFano(0, lettersArray.Length - 1, probabilitiesArray, letterBitsArray);

            Console.WriteLine("\n----------------+------------------");
            Console.WriteLine("     Символы    |       Биты       ");
            Console.WriteLine("----------------+------------------");

            for (int i = 0; i < letterBitsArray.Length; i++)
            {
                Console.WriteLine($"\t{lettersArray[i]}\t|\t{letterBitsArray[i]}");
            }
            Console.WriteLine("----------------+------------------");

            string encodedMessage = EncodeDecode.GetEncodeMessage(input, lettersArray, letterBitsArray);
            string decodedMessage = EncodeDecode.GetDecodedMessage(encodedMessage, lettersArray, letterBitsArray);
            Console.WriteLine("\nЗакондированное сообщение: " + encodedMessage);
            Console.WriteLine("Декодированное сообщение: "+ decodedMessage);

            Console.WriteLine("\n\t\t\tВ ASCII:\n");
            string asciiEncoded = EncodeDecode.EncodingToBytes(input);
            Console.WriteLine("Закондированное сообщение: "+ asciiEncoded);
            Console.WriteLine("Сообщение: " + input);

            Console.WriteLine("\n\t\t\tСимволов после сжатия:\n");

            Console.WriteLine($"методом Шеннона-Фано: " + encodedMessage.Length);
            Console.WriteLine($"в ASCII: " + asciiEncoded.Length);

            Console.WriteLine("\n\t\t\tЭффективность сжатия:");
            double times = (double)(asciiEncoded.Length)/(double)(encodedMessage.Length);
            Console.WriteLine("\nМетодом метода Шеннона-Фано мы уменьшили общий размер данных в " + times + " раз");
            Console.WriteLine("по сравнению с кодом, полученным преобразованием в коды ASCII\n");
        }
    }
}
