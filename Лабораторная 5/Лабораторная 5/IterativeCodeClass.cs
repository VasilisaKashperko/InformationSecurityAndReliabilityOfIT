using System;
using System.Linq;

namespace Лабораторная_5
{
    public class IterativeCodeClass
    {
        public static byte[] ActionsForTwoDimensialMatrix(byte[] thisWord, byte[,] thisMatrix)
        {
            Console.WriteLine("Заполняем матрицу словом");
            byte[,] matrix = DoMatrixWithNumbers(thisMatrix, thisWord);
            GetMatrix(matrix);

            Console.WriteLine("Получаем горизонтальный паритет");
            byte[] theFirstParity = GetTheFirstParity(matrix);
            GetHorizontal(theFirstParity);

            Console.WriteLine("Получаем вертикальный паритет");
            byte[] theSecondParity = GetTheSecondParity(matrix);
            GetWord(theSecondParity);

            Console.WriteLine("Получаем диагональный паритет");
            byte[] theFirstDiagonalParity = GetTheFirstDiagonalParity(matrix);
            GetWord(theFirstDiagonalParity);

            Console.WriteLine("Получаем второй диагональный паритет");
            byte[] theSecondDiagonalParity = GetTheSecondDiagonalParity(matrix);
            GetWord(theSecondDiagonalParity);

            Console.WriteLine("Формирование кодового слова Xn по 2 направлениям (Xk Yh Yv):");
            byte[] wordWithTwo = CreateFullWordTheSecond(thisWord, theFirstParity, theSecondParity);
            GetWord(wordWithTwo);

            Console.WriteLine("Формирование кодового слова Xn по 3 направлениям (Xk Yh Yv Yd):");
            byte[] wordWithThree = CreateFullWordTheThird(thisWord, theFirstParity, theSecondParity, theFirstDiagonalParity);
            GetWord(wordWithThree);

            Console.WriteLine("Формирование кодового слова Xn по 4 направлениям (Xk Yh Yv Yd Yd):");
            byte[] wordWithFour = CreateFullWordTheFourth(thisWord, theFirstParity, theSecondParity, theFirstDiagonalParity, theSecondDiagonalParity);
            GetWord(wordWithFour);

            return wordWithThree;
        }

        public static Random random = new Random();
        public static void GetWord(byte[] word)
        {
            foreach (var i in word)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public static void GetHorizontal(byte[] word)
        {
            foreach (var i in word)
            {
                Console.Write(i+"\n");
            }
            Console.WriteLine();
        }
        public static void GetWordCor(byte[] word, int mistake)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (i == mistake)
                {
                    if (word[i] == 1)
                        word[i] = 0;
                    else
                        word[i] = 1;
                    Console.Write(word[i] + " ");
                }
                else
                    Console.Write(word[i] + " ");
            }
            Console.WriteLine();
        }

        public static byte[,] CreateMatrix(int k1, int k2)
        {
            return new byte[k1, k2];
        }

        public static byte[,] DoMatrixWithNumbers(byte[,] matrix, byte[] word)
        {
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    matrix[i, j] = (byte)word[i * matrix.GetLongLength(1) + j];
                }
            }
            return matrix;
        }

        public static void GetMatrix(byte[,] matrix)
        {
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static byte[] GetTheFirstParity(byte[,] matrix)
        {
            byte[] theFirstParity = new byte[matrix.GetLongLength(0)];
            byte summary;
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                summary = (byte)0;
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    summary += (byte)(matrix[i, j]);
                }
                theFirstParity[i] = (byte)(summary % 2);
            }
            Console.WriteLine("\n");
            return theFirstParity;
        }

        public static byte[] GetTheSecondParity(byte[,] matrix)
        {
            byte[] theSecondParity = new byte[matrix.GetLongLength(1)];
            byte summary;
            for (int i = 0; i < matrix.GetLongLength(1); i++)
            {
                summary = (byte)0;
                for (int j = 0; j < matrix.GetLongLength(0); j++)
                {
                    summary += (byte)(matrix[j, i]);
                }
                theSecondParity[i] = (byte)(summary % 2);
            }
            return theSecondParity;
        }

        public static byte[] GetTheFirstDiagonalParity(byte[,] matrix)
        {
            byte[] theFirstDiagonalParity = new byte[matrix.GetLongLength(0)];
            byte summary;
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                summary = (byte)0;
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    summary += (byte)(matrix[(i + j) % matrix.GetLongLength(0), j % matrix.GetLongLength(1)]);
                }
                theFirstDiagonalParity[i] = (byte)(summary%2);
            }
            return theFirstDiagonalParity;
        }

        public static byte[] GetTheSecondDiagonalParity(byte[,] matrix)
        {
            byte[] theSecondDiagonalParity = new byte[matrix.GetLongLength(0)];
            byte summary;
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                summary = (byte)0;
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    summary += (byte)(matrix[(matrix.GetLongLength(0) - 1) - ((i + j) % matrix.GetLongLength(0)), j % matrix.GetLongLength(1)]);
                }
                theSecondDiagonalParity[i] = (byte)(summary % 2);
            }
            return theSecondDiagonalParity;
        }

        public static byte[] CreateFullWordTheSecond(byte[] word, byte[] theFirstParity, byte[] theSecondParity)
        {
            return (word.Concat(theFirstParity).ToArray()).Concat(theSecondParity).ToArray();
        }

        public static byte[] CreateFullWordTheThird(byte[] word, byte[] theFirstParity, byte[] theSecondParity, byte[] theFirstDiagParity)
        {
            return ((word.Concat(theFirstParity).ToArray()).Concat(theSecondParity).ToArray()).Concat(theFirstDiagParity).ToArray();
        }

        public static byte[] CreateFullWordTheFourth(byte[] word, byte[] firstParity, byte[] secondParity, byte[] firstDiagParity, byte[] secondDiagParity)
        {
            return (((word.Concat(firstParity).ToArray()).Concat(secondParity).ToArray()).Concat(firstDiagParity).ToArray()).Concat(secondDiagParity).ToArray();
        }

        public static byte[] CreateAMistake(byte[] fullWord, int k, int countMistakes)
        {
            for (int i = 0; i < countMistakes; i++)
            {
                int mistakePosition = random.Next(0, k);
                Console.WriteLine("Ошибка в бите под номером " + mistakePosition);
                fullWord[mistakePosition] = (byte)((fullWord[mistakePosition] + 1) % 2);
            }
            return fullWord;
        }

        public static byte[] GetSyndrom(byte[] paritiesWithMistakes, byte[] newParities)
        {
            byte[] syndrom = new byte[paritiesWithMistakes.Length];
            for (int i = 0; i < paritiesWithMistakes.Length; i++)
            {
                syndrom[i] = (byte)((paritiesWithMistakes[i] + newParities[i]) % 2);
            }
            return syndrom;
        }

        public static void GetMistakesWithTheSecondParity(int k1, int k2, byte[] paritiesWithMistakes, byte[] newParities)
        {
            Console.WriteLine("Сравнение паритетов:");
            GetWord(paritiesWithMistakes);
            GetWord(newParities);

            Console.WriteLine("Получаем синдром:");
            byte[] syndrom = GetSyndrom(paritiesWithMistakes, newParities);
            GetWord(syndrom);

            byte[] theFirstParitySyndrom = new byte[k1];
            byte[] theSecondParitySyndrom = new byte[k2];

            Array.Copy(syndrom, 0, theFirstParitySyndrom, 0, k1);
            Array.Copy(syndrom, k1, theSecondParitySyndrom, 0, k2);

            GetWord(theFirstParitySyndrom);
            GetWord(theSecondParitySyndrom);

            Console.WriteLine();
            for (int i = 0; i < theFirstParitySyndrom.Length; i++)
            {
                if (theFirstParitySyndrom[i] == (byte)1)
                {
                    for (int j = 0; j < theSecondParitySyndrom.Length; j++)
                    {
                        if (theSecondParitySyndrom[j] == (byte)1)
                        {
                            int mistake = (i * theSecondParitySyndrom.Length) + (j + 1) - 1;
                            Console.WriteLine("Ошибка в бите под номером " + mistake);
                        }
                    }
                }
            }
        }

        public static int GetMistakesPositionWithTheSecondParity(int k1, int k2, byte[] paritiesWithMistakes, byte[] newParities)
        {
            int mistakPosition = 0;
            byte[] syndrom = GetSyndrom(paritiesWithMistakes, newParities);
            byte[] firstParitySyndrom = new byte[k1];
            byte[] secondParitySyndrom = new byte[k2];

            Array.Copy(syndrom, 0, firstParitySyndrom, 0, k1);
            Array.Copy(syndrom, k1, secondParitySyndrom, 0, k2);

            for (int i = 0; i < firstParitySyndrom.Length; i++)
            {
                if (firstParitySyndrom[i] == (byte)1)
                {
                    for (int j = 0; j < secondParitySyndrom.Length; j++)
                    {
                        if (secondParitySyndrom[j] == (byte)1)
                            mistakPosition = (i * secondParitySyndrom.Length) + (j + 1) - 1;
                    }
                }
            }
            return mistakPosition;
        }

        public static void GetMistakesWithTheThirdParity(int k1, int k2, int k3, byte[] paritiesWithMistakes, byte[] newParities)
        {
            Console.WriteLine("Сравним паритеты");
            GetWord(paritiesWithMistakes);
            GetWord(newParities);

            Console.WriteLine("Получим синдром");
            byte[] syndrom = GetSyndrom(paritiesWithMistakes, newParities);
            GetWord(syndrom);

            Console.WriteLine("Парс синдром паритетов");
            byte[] theFirstParitySyndrom = new byte[k1];
            byte[] theSecondParitySyndrom = new byte[k2];
            byte[] theFirstDiagonalParitySyndrom = new byte[k3];

            Array.Copy(syndrom, 0, theFirstParitySyndrom, 0, k1);
            Array.Copy(syndrom, k1, theSecondParitySyndrom, 0, k2);
            Array.Copy(syndrom, k1 + k2, theFirstDiagonalParitySyndrom, 0, k3);

            GetWord(theFirstParitySyndrom);
            GetWord(theSecondParitySyndrom);
            GetWord(theFirstDiagonalParitySyndrom);

            Console.WriteLine();

            for (int i = 0; i < theFirstParitySyndrom.Length; i++)
            {
                if (theFirstParitySyndrom[i] == (byte)1)
                {
                    for (int j = 0; j < theSecondParitySyndrom.Length; j++)
                    {
                        if (theSecondParitySyndrom[j] == (byte)1)
                        {
                            for (int a = 0; a < theFirstDiagonalParitySyndrom.Length; a++)
                            {
                                if (theFirstDiagonalParitySyndrom[a] == (byte)1)
                                {
                                    for (int I = a, J = 0; J < theSecondParitySyndrom.Length; I++, J++)
                                    {
                                        int mistake = (i * theSecondParitySyndrom.Length) + (j + 1) - 1;
                                        if ((i == I % theFirstParitySyndrom.Length) && (j == J))
                                            Console.WriteLine("Ошибка в бите под номером" + mistake);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static int GetMistakesPositionWithThreeParities(int k1, int k2, int k3, byte[] paritiesWithMistakes, byte[] newParities)
        {
            int mistakePosition = 0;

            byte[] syndrom = GetSyndrom(paritiesWithMistakes, newParities);
            byte[] firstParitySyndrom = new byte[k1];
            byte[] theSecondParitySyndrom = new byte[k2];
            byte[] firstDiagParitySyndrom = new byte[k3];

            Array.Copy(syndrom, 0, firstParitySyndrom, 0, k1);
            Array.Copy(syndrom, k1, theSecondParitySyndrom, 0, k2);
            Array.Copy(syndrom, k1 + k2, firstDiagParitySyndrom, 0, k3);

            Console.WriteLine();
            for (int i = 0; i < firstParitySyndrom.Length; i++)
            {
                if (firstParitySyndrom[i] == (byte)1)
                {
                    for (int j = 0; j < theSecondParitySyndrom.Length; j++)
                    {
                        if (theSecondParitySyndrom[j] == (byte)1)
                        {
                            for (int a = 0; a < firstDiagParitySyndrom.Length; a++)
                            {
                                if (firstDiagParitySyndrom[a] == (byte)1)
                                {
                                    for (int I = a, J = 0; J < theSecondParitySyndrom.Length; I++, J++)
                                    {
                                        mistakePosition = (i * theSecondParitySyndrom.Length) + (j + 1) - 1;
                                        if ((i == I % firstParitySyndrom.Length) && (j == J))
                                            Console.WriteLine("Ошибка в бите №" + mistakePosition);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return mistakePosition;
        }
    }
}
