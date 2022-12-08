using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_7
{
    public class Operations
    {
        public static void OutputMatrix(int[,] matrix, int k, int n)
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void OutputCheckMatrix(int[,] matrix, int k, int n)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }

        public static int[] SearchError(int[] arr, int[,] varifMatrix, int k)
        {

            int r = GetAmountOfCheckChars(k);
            int n = r + k;

            int[] beforeSyndrom = new int[r];

            for (int i = k; i < n; i++)
            {
                beforeSyndrom[i - k] = arr[i];
            }

            arr = GetSyndrom(varifMatrix, arr, k);

            for (int i = k, j = 0; i < n; i++)
            {
                if (beforeSyndrom[i - k].Equals(arr[i]))
                {
                    arr[i] = 0;

                    j++;
                    if (j == r)
                    {
                        for (int l = k; l < n; l++)
                        {
                            arr[l] = beforeSyndrom[l - k];
                        }
                        return arr;
                    }
                }
                else
                {
                    arr[i] = 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int l = 0;
                for (int j = 0; j < r; j++)
                {
                    if (varifMatrix[i, j].Equals(arr[j + k])) l++;
                }
                if (l == r)
                {
                    arr[i] = (arr[i] + 1) % 2;
                }
            }
            arr = GetSyndrom(varifMatrix, arr, k);

            return arr;
        }

        public static int[] Interleaver(int[] arrN, int k)
        {
            int r = GetAmountOfCheckChars(k);
            int n = 6;

            int[,] matrix = new int[k, n];

            for (int i = 0, m = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++, m++)
                {
                    matrix[i, j] = arrN[m];
                }
            }
            Console.WriteLine("\nМатрица перемежения:");
            OutputMatrix(matrix, k, n);

            for (int i = 0, m = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++, m++)
                {
                    arrN[m] = matrix[j, i];
                }
            }

            return arrN;
        }

        public static int[] Deinterleaver(int[] arrN, int k)
        {
            int r = GetAmountOfCheckChars(k);
            int n = k + r;

            int[,] matrix = new int[k, n];

            for (int j = 0, m = 0; j < n; j++)
            {
                for (int i = 0; i < k; i++, m++)
                {
                    matrix[i, j] = arrN[m];
                }
            }
            Console.WriteLine("\n\nПолученая матрица");
            OutputMatrix(matrix, k, n);

            for (int j = 0, m = 0; j < k; j++)  
            {
                for (int i = 0; i < n; i++, m++)
                {
                    arrN[m] = matrix[j, i];
                }
            }

            return arrN;
        }

        public static int[] BitsForCheck(int[] arrK, int[] arrN, int[,] verifMatrix)
        {
            int infoFLow = arrK.Length;
            int k = (int)(Math.Sqrt(infoFLow));
            int r = GetAmountOfCheckChars(k);
            int n = k + r;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < k; j++)
                {
                    temp[j] = arrK[(k * i) + j];
                }

                GetSyndrom(verifMatrix, temp, k);     

                for (int j = 0; j < n; j++)
                {
                    arrN[i * n + j] = temp[j];
                }
            }
            return arrN;
        }

        public static int[] SearchErrors(int[] arrN, int[,] verifMatrix, int k)
        {
            int r = GetAmountOfCheckChars(k);
            int n = r + k;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    temp[j] = arrN[(n * i) + j];
                }

                SearchError(temp, verifMatrix, k);

                for (int j = 0; j < n; j++)
                {
                    arrN[i * n + j] = temp[j];
                }
            }

            return arrN;
        }
        public static int[] DeleteBitsForCheck(int[] arrK, int[] arrN, int[,] checkMatrix)
        {
            int infoFLow = arrK.Length;
            int k = (int)(Math.Sqrt(infoFLow));
            int r = GetAmountOfCheckChars(k);
            int n = k + r;

            for (int i = 0; i < k; i++)
            {
                int[] temp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    temp[j] = arrN[(n * i) + j];
                }

                for (int j = 0; j < k; j++)
                {
                    arrK[i * k + j] = temp[j];
                }
            }
            return arrK;
        }

        public static int GetAmountOfCheckChars(int k)
        {
            int r = (int)(Math.Log(k, 2) + 1.99f);
            return r;
        }

        public static int[,] GetCheckMatrix(int k)
        {
            int r = GetAmountOfCheckChars(k);
            int n = r + k;
            double rDouble = r - 1;
            int rPow = (int)(Math.Pow(2, rDouble));

            int[,] arr = new int[n, r];

            int[,] combinations = new int[rPow, r];

            for (int i = 0; i < rPow; i++)
                for (int j = 0; j < r; j++)
                    combinations[i, j] = 0;

            for (int segmentLenght = 0; segmentLenght < r - 2; segmentLenght++)
            {
                if (segmentLenght * r > k) break;

                for (int i = 0; i < segmentLenght + 2; i++)
                {
                    combinations[segmentLenght * r, i] = 1;
                }

                for (int segmentPositin = 1; segmentPositin < r; segmentPositin++)
                {
                    for (int i = 0; i < r - 1; i++)
                    {
                        combinations[segmentLenght * r + segmentPositin, i + 1] = combinations[segmentLenght * r + segmentPositin - 1, i];
                    }
                    combinations[segmentLenght * r + segmentPositin, 0] = combinations[segmentLenght * r + segmentPositin - 1, r - 1];
                }

                if (segmentLenght == r - 3)
                {
                    for (int i = 0; i < r; i++)
                    {
                        combinations[rPow - 1, i] = 1;
                    }
                }
            }

            for (int i = 0; i < k; i++)
                for (int j = 0; j < r; j++)
                    arr[i, j] = combinations[i, j];

            for (int i = 0; i < r; i++)
                arr[i + k, i] = 1;

            return arr;
        }

        public static int[] GetSyndrom(int[,] VerifMatrix, int[] arr, int k)
        {
            int r = GetAmountOfCheckChars(k);
            int n = r + k;
            int[] syndrom = new int[r];

            for (int i = 0, l = 0; i < r; i++, l = 0)
            {
                for (int j = 0; j < k; j++)
                {
                    if (VerifMatrix[j, i] == 1 && arr[j] == 1) l++;
                    else syndrom[i] = 0;
                }
                if (l % 2 == 1) syndrom[i] = 1;
                else syndrom[i] = 0;
            }

            for (int i = 0; i < r; i++)
            {
                arr[i + k] = syndrom[i];
            }

            return arr;
        }
    }
}
