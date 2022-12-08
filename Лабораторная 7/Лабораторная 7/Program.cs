using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Длина сообщения - 16\n");
            int messageLength = 16;

            Console.WriteLine("Длина информационного слова - 4\n");
            int k = 4;
            int r = Operations.GetAmountOfCheckChars(k);

            int n = k + r;
            int codeMessageLength = messageLength + (r * k);

            int[] message = new int[16] { 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 };

            Console.WriteLine("Сообщение: ");
            Operations.PrintArray(message);

            int[] changedMessage = new int[messageLength];

            int[] codeWithCheckCombination = new int[messageLength + (r * k)];

            int[,] HammingsCheckingMatrix = new int[n, r];

            HammingsCheckingMatrix = Operations.GetCheckMatrix(k);

            Operations.BitsForCheck(message, codeWithCheckCombination, HammingsCheckingMatrix);

            Console.WriteLine("\nСообщение с проверочными битами:");
            Operations.PrintArray(codeWithCheckCombination);

            Operations.Interleaver(codeWithCheckCombination, k);

            Console.WriteLine("Cообщение после перемежения: ");
            Operations.PrintArray(codeWithCheckCombination);

            Console.WriteLine("\nПозиция для начала ошибок:");
            int error = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Укажите длину пакета ошибок 3, 4 или 5 (4 вариант):");
            int errorLenght = Convert.ToInt32(Console.ReadLine());
            for (int i = error; i < (error + errorLenght); i++)
            {
                codeWithCheckCombination[i] = (codeWithCheckCombination[i] + 1) % 2;
            }

            Console.WriteLine("Сообщение с ошибками:");
            Operations.PrintArray(codeWithCheckCombination);
            Operations.Deinterleaver(codeWithCheckCombination, k);

            Console.WriteLine("\nСобщение с переставленными ошибками:");
            Operations.PrintArray(codeWithCheckCombination);
            Operations.SearchErrors(codeWithCheckCombination, HammingsCheckingMatrix, k);

            Console.WriteLine("\nСообщение после исправления ошибок кодом Хемминга:");
            Operations.PrintArray(codeWithCheckCombination);
            Operations.DeleteBitsForCheck(changedMessage, codeWithCheckCombination, HammingsCheckingMatrix);

            Console.WriteLine("\nИсправленное сообщение без проверочных символов:");
            Operations.PrintArray(changedMessage);

            Console.WriteLine("\nПервоначальное сообщение:");
            Operations.PrintArray(message);
            Console.WriteLine("\n");
        }
    }
}
