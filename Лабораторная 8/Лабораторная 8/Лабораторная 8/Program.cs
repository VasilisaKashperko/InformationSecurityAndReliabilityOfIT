using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Лабораторная_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t\tЗадание 2\n");

            string input3Letters = "сем";
            byte[] bytes = Encoding.GetEncoding(1251).GetBytes(input3Letters);
            string output3Letters = "";

            for (int i = 0; i < bytes.Length; i++)
            {
                output3Letters += Convert.ToString(bytes[0], 2);
            }
            Console.WriteLine("Строка в ASCII: " + output3Letters);
            // https://snipp.ru/handbk/table-ascii - таблица ASCII

            Console.WriteLine("\t\t\t\tЗадание 1\n");

            string[] input = new string[] {"101010", "КАШПЕРКО", "МУЛЬТИМИЛЛИОНЕР", output3Letters};

            foreach (string words in input)
            {
                Stopwatch ticksEncode = new Stopwatch();
                ticksEncode.Start();

                Console.WriteLine("\t\t\tСообщение: " + words);
                Console.WriteLine("\nКодирование\n");

                string[] w1 = Functionality.CreateMatrix(words);
                Console.WriteLine("Матрица W1 - сдвиг строк");
                Functionality.PrintMatrix(w1);
                string[] w2 = Functionality.SortedMatrix(w1);
                Console.WriteLine("Матрица W2 - отсортированные строки");
                Functionality.PrintMatrix(w2);

                string inputEncode = Functionality.GetTheLastColumnFromMatrix(w2) + Functionality.GetRowNumberFromMatrix(words, w2);
                string gettedMessage = inputEncode.Substring(0, inputEncode.Length - (inputEncode.Length - words.Length));
                ticksEncode.Stop();
                Console.WriteLine("Закодированное сообщение: " + gettedMessage);
                Console.WriteLine("Номер строки содержащей корректное сообщение: " + Functionality.GetRowNumberFromMatrix(words, w2) + "\n");

                Console.WriteLine("\nДекодирование\n");
                Stopwatch ticksDecode = new Stopwatch();
                ticksDecode.Start();
                string[] w2ForDecode = Functionality.GetDecodingMatrix(gettedMessage);
                Console.WriteLine("Восстановленная матрица W2 - отсортировали");
                Functionality.PrintMatrix(w2ForDecode);

                int numberOfInitialMessage = Int32.Parse((inputEncode.Substring(words.Length, (inputEncode.Length - words.Length))));
                ticksDecode.Stop();
                Console.WriteLine("Декодированное сообщение: " + w2ForDecode[numberOfInitialMessage]);
                
                string output = w2ForDecode[numberOfInitialMessage];

                if (String.Compare(output, words) == 0)
                {
                    Console.WriteLine("Успешно!");
                }
                else
                {
                    Console.WriteLine("Ничего не получилось...");
                }
                
                Console.WriteLine("Время кодирования: " + ticksEncode.Elapsed);
                Console.WriteLine("Время декодирования: " + ticksDecode.Elapsed + "\n");
            }
        }
    }
}
