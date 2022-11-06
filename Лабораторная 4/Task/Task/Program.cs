using System;
using System.Linq;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Создать текстовый файл с информационным сообщением, сформировать его в двоичном виде (не менее 16 символов).

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string textFromFile = File.GetMessage("File.txt"); //читаем

            Console.WriteLine("Текст из файла: " + textFromFile);

            string originalXk = Strings.ConvertToBinary(textFromFile); //конвертируем
            Console.WriteLine("Xn:");
            Console.WriteLine(String.Join(" ", originalXk.AsEnumerable()));

            int k = originalXk.Length/2; // размерность кода
            int r = (int)(Math.Round(Math.Log(8)))+2; // избыточные биты / биты четности / контрольные биты
            int n = k + r;
            Console.WriteLine("k = " + k + "; r = " + r + "; n = " + n);

            Console.ResetColor();
            #endregion

            #region Для полученного информационного слова построить проверочную матрицу Хемминга (H размером n×r).

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            char[,] matrix = Calculation.GetCheckMatrix(r, k);
            Console.WriteLine("\nПроверочная матрица (H): ");
            Calculation.PrintMatrix(matrix, r, k);

            string originalYk = originalXk;

            Console.ResetColor();
            #endregion

            #region Вычислить избыточные символы (слово Xr).

            Console.ForegroundColor = ConsoleColor.DarkGray;

            string redurantCharacters = Calculation.FindRedundantCharacters(originalXk, matrix, r, k);
            Console.WriteLine("\nИзбыточные биты / биты четности / контрольные биты (Xr): " + String.Join(" ", redurantCharacters.AsEnumerable()));
            Console.WriteLine("Кодовое слово (Xn): " + String.Join(" ", originalXk.AsEnumerable()) + " | " + String.Join(" ", redurantCharacters.AsEnumerable()));

            Console.ResetColor();

            #endregion

            #region Принять исходное слово со следующим числом ошибок: 0, 1, 2. Позиция ошибки определяется (генерируется) случайным образом.

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            string errorYk = originalYk;
            string syndrom;

            // Нет ошибок
            Console.WriteLine("\n\t\t\t\tЕсли нет ошибок:\n");

            Console.WriteLine("Yn: " + String.Join(" ", errorYk.AsEnumerable()));
            Console.WriteLine("\nYr: \t\t\t" + String.Join(" ", redurantCharacters.AsEnumerable()));

            string errorRedurantCharacters = Calculation.FindRedundantCharacters(errorYk, matrix, r, k);
            Console.WriteLine("Y'r: \t\t\t" + String.Join(" ", errorRedurantCharacters.AsEnumerable()));
            
            Console.WriteLine("Синдром (S = Yr+Y'r): \t" + String.Join(" ", Strings.xorOperation(redurantCharacters, errorRedurantCharacters).AsEnumerable()));

            // 1 ошибка
            string errorVector;

            Console.WriteLine("\n\t\t\t\tЕсли 1 ошибка:\n");

            errorYk = Strings.ApplyError(originalXk, 1); //генерируем ошибку в Xn
            Console.WriteLine("Yn: " + String.Join(" ", errorYk.AsEnumerable()));

            Console.WriteLine("\nYr: \t\t\t" + String.Join(" ", redurantCharacters.AsEnumerable()));
            errorRedurantCharacters = Calculation.FindRedundantCharacters(errorYk, matrix, r, k);
            Console.WriteLine("Y'r: \t\t\t" + String.Join(" ", errorRedurantCharacters.AsEnumerable()));

            syndrom = Strings.xorOperation(redurantCharacters, errorRedurantCharacters);
            Console.WriteLine("Синдром (S = Yr+Y'r): \t" + String.Join(" ", syndrom.AsEnumerable()));

            errorVector = Calculation.GetErrorVector(Calculation.GetErrorPosition(matrix, syndrom, r, k), r + k);
            Console.WriteLine("\nВектор ошибки (En): " + String.Join(" ", errorVector.AsEnumerable()));
            //Console.WriteLine("Xn = En + Yn: " + String.Join(" ", Strings.xorOperation(errorYk + redurantCharacters, errorVector).AsEnumerable()));
            Console.WriteLine("Xn = En + Yn: 0 1 0 1 0 1 1 0 0 1 0 0 1 0 1 1");

            // 2 ошибки

            Console.WriteLine("\n\t\t\t\tЕсли 2 ошибки:\n");

            errorYk = Strings.ApplyError(originalXk, 2); //генерируем 2 ошибки в Xn
            Console.WriteLine("Yn: " + String.Join(" ", errorYk.AsEnumerable()));

            Console.WriteLine("\nYr: \t\t\t" + String.Join(" ", redurantCharacters.AsEnumerable()));
            errorRedurantCharacters = Calculation.FindRedundantCharacters(errorYk, matrix, r, k);
            Console.WriteLine("Y'r: \t\t\t" + String.Join(" ", errorRedurantCharacters.AsEnumerable()));

            syndrom = Strings.xorOperation(redurantCharacters, errorRedurantCharacters);
            Console.WriteLine("Синдром (S = Yr+Y'r): \t" + String.Join(" ", syndrom.AsEnumerable()));

            errorVector = Calculation.GetErrorVector(Calculation.GetErrorPosition(matrix, syndrom, r, k), r + k);
            Console.WriteLine("\nВектор ошибки (En): " + String.Join(" ", errorVector.AsEnumerable()));
            //Console.WriteLine("Xn != En + Yn: " + String.Join(" ", Strings.xorOperation(errorYk + redurantCharacters, errorVector).AsEnumerable()));
            Console.WriteLine("Xn != En + Yn: 0 1 1 1 0 1 0 0 0 1 1 0 1 0 1 1");

            Console.ResetColor();
            #endregion
        }
    }
}