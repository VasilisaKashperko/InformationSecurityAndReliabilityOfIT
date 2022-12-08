using System;

namespace Лабораторная_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string Xk = "";
            string Xr = "";

            int k = Xk.Length; int n = 38; int r = 6;

            int error;

            int[] arrayXk = new int[k];

            Operations.StringInArray(arrayXk, Xk);

            int[] arrayXr = new int[Xr.Length];

            Operations.StringInArray(arrayXr, Xr);

            Console.WriteLine("\t\tВходная строка xk: " + Xk);

            Console.WriteLine("\t\tПорождающий полином xr в двоичном виде: " + Xr);

            Console.WriteLine("\t\t\t k = {0}, r = {1}, n = {2}", k, r, n);
            Console.WriteLine("--------------------------------------------------------------------------------");

            int[,] genMatrix = new int[k, n];
            Operations.CreateGenerationMatrix(genMatrix, arrayXr, k, n);

            Console.WriteLine("\n\t\t\t\tПорождающая матрица\n");
            Operations.PrintMatrix(genMatrix, k, n);

            Operations.CreateMatrixCanon(genMatrix, k, n);
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\n\t\t\t\tКаноническая матрица\n");
            Operations.PrintMatrix(genMatrix, k, n);

            int[,] checkMatrix = new int[n, r];

            Operations.CreateMatrixForCheck(checkMatrix, genMatrix, k, n);
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\n\t\t\t\tПроверочная матрица\n");
            Operations.PrintMatrix(checkMatrix, n, r);

            int[] masXn = new int[n];

            Operations.ShiftR(masXn, arrayXk, r);

            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\n\t\t\t\t\tДеление\n");
            Operations.SearchRes(masXn, arrayXr);

            Console.WriteLine("Остаток:");
            Operations.PrintArray(masXn);

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\n\t\t\t\tИтоговая строка\n");
            Operations.ShiftR(masXn, arrayXk, r);

            Operations.PrintArray(masXn);

            Console.WriteLine("--------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Введите место первой ошибки");
                error = Convert.ToInt32(Console.ReadLine()) - 1;

                if (masXn[error] == 1)
                {
                    masXn[error] = 0;
                }
                else
                {
                    masXn[error] = 1;
                }
            }
            catch { }

            Console.WriteLine("Ошибочная строка:");
            Operations.PrintArray(masXn);

            Operations.SearchingMistake(masXn, arrayXr, checkMatrix, r);

            Console.WriteLine("--------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Место первой ошибки: ");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (masXn[error] == 1)
                {
                    masXn[error] = 0;
                }
                else
                {
                    masXn[error] = 1;
                }

                Console.WriteLine("Место второй ошибки: ");
                error = Convert.ToInt32(Console.ReadLine()) - 1;
                if (masXn[error] == 1)
                {
                    masXn[error] = 0;
                }
                else
                {
                    masXn[error] = 1;
                }
            }
            catch { }

            Console.WriteLine("Ошибочная строка:");

            Operations.PrintArray(masXn);

            Operations.SearchingMistake(masXn, arrayXr, checkMatrix, r);
        }
    }
}
