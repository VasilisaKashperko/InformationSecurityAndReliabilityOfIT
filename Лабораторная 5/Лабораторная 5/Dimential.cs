using System;
using System.Collections.Generic;
using System.Linq;

namespace Лабораторная_5
{
    class Dimential
    {
        public static byte[] SequenceOfTasksWithMatrix(byte[] baseWord, byte[,,] baseMatrix)
        {
            Console.WriteLine("Заполняем матрицу:");
            byte[,,] newMatrix = FillMatrixWithLine(baseMatrix, baseWord);

            Console.WriteLine("Горизонтальный паритет:");
            byte[,] theFirstParity = GetTheFirstParity(newMatrix);
            IterativeCodeClass.GetMatrix(theFirstParity);

            Console.WriteLine("Вертикальный паритет:");
            byte[,] theSecondParity = GetTheSecondParity(newMatrix);
            IterativeCodeClass.GetMatrix(theSecondParity);

            Console.WriteLine("Глубинный паритет:");
            byte[,] theThirdParity = GetTheThirdParity(newMatrix);
            IterativeCodeClass.GetMatrix(theThirdParity);

            Console.WriteLine("Диагональный паритет:");
            byte[,] theFirstDiagonalParity = GetTheFirstDiagonalParity(newMatrix);
            IterativeCodeClass.GetMatrix(theFirstDiagonalParity);


            Console.WriteLine("Получаем второй диагональный паритет:");
            byte[,] theSecondDiagParity = GetTheSecondDiagonalParity(newMatrix);
            IterativeCodeClass.GetMatrix(theSecondDiagParity);


            Console.WriteLine("Формирование финального варианта кодового слова Xn:");
            byte[] fullWord = LongWord(baseWord, theFirstParity, theSecondParity, theThirdParity, theFirstDiagonalParity, theSecondDiagParity);
            IterativeCodeClass.GetWord(fullWord);

            return fullWord;
        }

        public static byte[,,] CreateMatrix(int k1, int k2, int z)
        {
            return new byte[k1, k2, z];
        }

        public static byte[,,] FillMatrixWithLine(byte[,,] matrix, byte[] word)
        {
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    for (int a = 0; a < matrix.GetLongLength(2); a++)
                    {
                        matrix[i, j, a] = (byte)word[i * matrix.GetLongLength(1) + j * matrix.GetLongLength(2) + a];
                    }
                }
            }
            return matrix;
        }

        public static byte[,] GetTheFirstParity(byte[,,] matrix)
        {
            byte[,] theFirstParity = new byte[matrix.GetLongLength(0), matrix.GetLongLength(1)];
            byte sum;
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    sum = (byte)0;
                    for (int a = 0; a < matrix.GetLongLength(2); a++)
                    {
                        sum += (byte)(matrix[i, j, a]);
                    }
                    theFirstParity[i, j] = (byte)(sum % 2);
                }
            }
            return theFirstParity;
        }

        public static byte[,] GetTheSecondParity(byte[,,] matrix)
        {
            byte[,] secondParity = new byte[matrix.GetLongLength(1), matrix.GetLongLength(2)];
            byte sum;

            for (int j = 0; j < matrix.GetLongLength(1); j++)
            {
                sum = (byte)0;
                for (int b = 0; b < matrix.GetLongLength(2); b++)
                {
                    for (int i = 0; i < matrix.GetLongLength(0); i++)
                    {
                        sum += (byte)(matrix[i, j, b]);
                    }
                    secondParity[j, b] = (byte)(sum % 2);
                }
            }
            return secondParity;
        }

        public static byte[,] GetTheThirdParity(byte[,,] matrix)
        {
            byte[,] thirdParity = new byte[matrix.GetLongLength(2), matrix.GetLongLength(0)];
            byte sum;
            for (int a = 0; a < matrix.GetLongLength(2); a++)
            {
                for (int i = 0; i < matrix.GetLongLength(0); i++)
                {
                    sum = (byte)0;
                    for (int j = 0; j < matrix.GetLongLength(1); j++)
                    {
                        sum += (byte)(matrix[i, j, a]);
                    }
                    thirdParity[a, i] = (byte)(sum % 2);
                }
            }
            return thirdParity;
        }

        public static byte[,] GetTheFirstDiagonalParity(byte[,,] matrix)
        {
            byte[,] theFirstDiagonalParity = new byte[matrix.GetLongLength(0), matrix.GetLongLength(0)];
            byte summary;
            for (int g = 0; g < matrix.GetLongLength(2); g++)
            {
                for (int i = 0; i < matrix.GetLongLength(0); i++)
                {
                    summary = (byte)0;
                    for (int j = 0; j < matrix.GetLongLength(1); j++)
                    {
                        Console.Write(matrix[(i + j) % matrix.GetLongLength(0), j % matrix.GetLongLength(1), g] + " ");
                        summary += (byte)(matrix[(i + j) % matrix.GetLongLength(0), j % matrix.GetLongLength(1), g]);
                    }
                    Console.WriteLine(summary);
                    theFirstDiagonalParity[g, i] = (byte)(summary % 2);
                }
                Console.WriteLine();
            }
            return theFirstDiagonalParity;
        }

        public static byte[,] GetTheSecondDiagonalParity(byte[,,] matrix)
        {
            byte[,] theSecondDiagonalParity = new byte[matrix.GetLongLength(0), matrix.GetLongLength(0)];
            byte summary;
            for (int g = 0; g < matrix.GetLongLength(2); g++)
            {
                for (int i = 0; i < matrix.GetLongLength(0); i++)
                {
                    summary = (byte)0;
                    for (int j = 0; j < matrix.GetLongLength(1); j++)
                    {
                        Console.Write(matrix[(matrix.GetLongLength(0) - 1) - ((i + j) % matrix.GetLongLength(0)), j % matrix.GetLongLength(1), g] + " ");
                        summary += (byte)(matrix[(matrix.GetLongLength(0) - 1) - ((i + j) % matrix.GetLongLength(0)), j % matrix.GetLongLength(1), g]);
                    }
                    Console.WriteLine(summary);
                    theSecondDiagonalParity[g, i] = (byte)(summary % 2);
                }
                Console.WriteLine();
            }
            return theSecondDiagonalParity;
        }

        public static byte[] ConvertionTheMatrixToString(byte[,] matrix)
        {
            byte[] str = new byte[matrix.GetLongLength(0) * matrix.GetLongLength(1)];
            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    str[i * matrix.GetLongLength(1) + j] = matrix[i, j];
                }
            }
            return str;
        }

        public static byte[] LongWord(byte[] word, byte[,] firstParityMatrix, byte[,] secondParityMatrix, byte[,] thirdParityMatrix, byte[,] firstDiagParityMatrix, byte[,] secondDiagParityMatrix)
        {
            byte[] thisFirstParity = new byte[firstParityMatrix.GetLongLength(0) * firstParityMatrix.GetLongLength(1)];
            byte[] secondParity = new byte[secondParityMatrix.GetLongLength(0) * secondParityMatrix.GetLongLength(1)];
            byte[] thirdParity = new byte[thirdParityMatrix.GetLongLength(0) * thirdParityMatrix.GetLongLength(1)];
            byte[] firstDiagParity = new byte[firstDiagParityMatrix.GetLongLength(0) * firstDiagParityMatrix.GetLongLength(1)];
            byte[] secondDiagParity = new byte[secondDiagParityMatrix.GetLongLength(0) * secondDiagParityMatrix.GetLongLength(1)];


            thisFirstParity = ConvertionTheMatrixToString(firstParityMatrix);
            secondParity = ConvertionTheMatrixToString(secondParityMatrix);
            thirdParity = ConvertionTheMatrixToString(thirdParityMatrix);
            firstDiagParity = ConvertionTheMatrixToString(firstDiagParityMatrix);
            secondDiagParity = ConvertionTheMatrixToString(secondDiagParityMatrix);

            return (((word.Concat(thisFirstParity).ToArray()).Concat(secondParity).ToArray()).Concat(thirdParity).ToArray()).Concat(firstDiagParity).ToArray().Concat(secondDiagParity).ToArray();
        }

        public static void GetMistakesTwoParities(int k1, int k2, int k3, byte[] paritiesWithMistakes, byte[] newParities)
        {
            Console.WriteLine("Сравним наши паритеты");
            IterativeCodeClass.GetWord(paritiesWithMistakes);

            IterativeCodeClass.GetWord(newParities);

            Console.WriteLine("Получим синдром");
            byte[] syndrom = IterativeCodeClass.GetSyndrom(paritiesWithMistakes, newParities);

            IterativeCodeClass.GetWord(syndrom);

            byte[] theFirstParitySyndrom = new byte[k1 * k2];
            Array.Copy(syndrom, 0, theFirstParitySyndrom, 0, k1 * k2);

            byte[] theSecondParitySyndrom = new byte[k2 * k3];
            Array.Copy(syndrom, k1 * k2, theSecondParitySyndrom, 0, k2 * k3);

            IterativeCodeClass.GetWord(theFirstParitySyndrom);
            IterativeCodeClass.GetWord(theSecondParitySyndrom);

            byte[,] theFirstParitySyndromMatrix = new byte[k1, k2];
            for (int i = 0; i < k1; i++)
            {
                for (int j = 0; j < k2; j++)
                {
                    theFirstParitySyndromMatrix[i, j] = syndrom[i * k2 + j];
                }
            }
            byte[,] theSecondParitySyndromMatrix = new byte[k2, k3];
            for (int i = 0; i < k2; i++)
            {
                for (int j = 0; j < k3; j++)
                {
                    theSecondParitySyndromMatrix[i, j] = syndrom[(k1 * k2) + i * k3 + j];
                }
            }
            Console.WriteLine("Первый синдром");
            IterativeCodeClass.GetMatrix(theFirstParitySyndromMatrix);

            Console.WriteLine("Второй синдром");
            IterativeCodeClass.GetMatrix(theSecondParitySyndromMatrix);

            List<int> errorPositions = new List<int>();
            for (int fp0 = 0; fp0 < theFirstParitySyndromMatrix.GetLongLength(0); fp0++)
            {
                for (int fp1 = 0; fp1 < theFirstParitySyndromMatrix.GetLongLength(1); fp1++)
                {
                    if (theFirstParitySyndromMatrix[fp0, fp1] == (byte)1)
                    {
                        for (int sp0 = 0; sp0 < theSecondParitySyndromMatrix.GetLongLength(0); sp0++)
                        {
                            for (int sp1 = 0; sp1 < theSecondParitySyndromMatrix.GetLongLength(1); sp1++)
                            {
                                if (theSecondParitySyndromMatrix[sp0, sp1] == (byte)1)
                                {
                                    errorPositions.Add((int)(fp0 * theFirstParitySyndromMatrix.GetLongLength(0)
                                                        + fp1
                                                        + sp0 * theSecondParitySyndromMatrix.GetLongLength(0)
                                                        + sp1));
                                }
                            }
                        }
                    }
                }
            }
            errorPositions = errorPositions.Distinct().ToList();
            errorPositions = errorPositions.OrderBy(x => x).ToList();
            foreach (var item in errorPositions)
            {
                Console.WriteLine("Ошибка в бите под номером" + item);
            }
        }

        public static void GetMistakesThreeParities(int k1, int k2, int k3, byte[] parityMistakes, byte[] newParities)
        {
            Console.WriteLine("Сравним наши паритеты");

            IterativeCodeClass.GetWord(parityMistakes);
            IterativeCodeClass.GetWord(newParities);

            Console.WriteLine("Получим синдром");
            byte[] syndromWithThree = IterativeCodeClass.GetSyndrom(parityMistakes, newParities);
            IterativeCodeClass.GetWord(syndromWithThree);

            byte[,] theFirstParitySyndrom = new byte[k1, k2];

            for (int i = 0; i < k1; i++)
            {
                for (int j = 0; j < k2; j++)
                {
                    theFirstParitySyndrom[i, j] = syndromWithThree[i * k2 + j];
                }
            }

            byte[,] theSecondParitySyndrom = new byte[k2, k3];
            for (int i = 0; i < k2; i++)
            {
                for (int j = 0; j < k3; j++)
                {
                    theSecondParitySyndrom[i, j] = syndromWithThree[(k1 * k2) + i * k3 + j];
                }
            }

            byte[,] theThirdParitySyndrom = new byte[k3, k1];
            for (int i = 0; i < k3; i++)
            {
                for (int j = 0; j < k1; j++)
                {
                    theThirdParitySyndrom[i, j] = syndromWithThree[(k3 * k1) + (k1 * k2) + i * k1 + j];
                }
            }

            Console.WriteLine("Первый синдром");
            IterativeCodeClass.GetMatrix(theFirstParitySyndrom);

            Console.WriteLine("Второй синдром");
            IterativeCodeClass.GetMatrix(theSecondParitySyndrom);

            Console.WriteLine("Третий синдром");
            IterativeCodeClass.GetMatrix(theThirdParitySyndrom);

            List<int> errorsPositions = new List<int>();
            for (int tf = 0; tf < theFirstParitySyndrom.GetLongLength(0); tf++)
            {
                for (int tfp = 0; tfp < theFirstParitySyndrom.GetLongLength(1); tfp++)
                {
                    if (theFirstParitySyndrom[tf, tfp] == (byte)1)
                    {
                        for (int ts = 0; ts < theSecondParitySyndrom.GetLongLength(0); ts++)
                        {
                            for (int tsp = 0; tsp < theSecondParitySyndrom.GetLongLength(1); tsp++)
                            {
                                if (theSecondParitySyndrom[ts, tsp] == (byte)1)
                                {
                                    for (int ttp = 0; ttp < theThirdParitySyndrom.GetLongLength(0); ttp++)
                                    {
                                        for (int tthp = 0; tthp < theThirdParitySyndrom.GetLongLength(1); tthp++)
                                        {
                                            if (theThirdParitySyndrom[ttp, tthp] == (byte)1)
                                            {
                                                errorsPositions.Add((int)
                                                        (tf * theFirstParitySyndrom.GetLongLength(1) + (tfp + 1) - 1 + ts * theThirdParitySyndrom.GetLongLength(1)
                                                        + (tsp + 1) - 1 + ttp * theThirdParitySyndrom.GetLongLength(1) + (tthp + 1) - 1));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            errorsPositions = errorsPositions.Distinct().ToList();
            errorsPositions = errorsPositions.OrderBy(x => x).ToList();

            foreach (var i in errorsPositions)
            {
                Console.WriteLine("Ошибка в бите под номером" + i);
            }

        }

        public static void FindMistakesWithFourParitiesThree(int w, int q, int e, byte[] paritiesWithMistakes, byte[] newParities)
        {
            Console.WriteLine("Сравним паритеты");
            IterativeCodeClass.GetWord(paritiesWithMistakes);
            IterativeCodeClass.GetWord(newParities);

            Console.WriteLine("Получим синдром");
            byte[] syndrom = IterativeCodeClass.GetSyndrom(paritiesWithMistakes, newParities);
            IterativeCodeClass.GetWord(syndrom);

            byte[,] firstParitySyndrom = new byte[w, q];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    firstParitySyndrom[i, j] = syndrom[i * q + j];
                }
            }

            byte[,] secondParitySyndrom = new byte[q, e];
            for (int i = 0; i < q; i++)
            {
                for (int j = 0; j < e; j++)
                {
                    secondParitySyndrom[i, j] = syndrom[(w * q) + i * e + j];
                }
            }

            byte[,] thirdParitySyndrom = new byte[e, w];
            for (int i = 0; i < e; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    thirdParitySyndrom[i, j] = syndrom[(e * w) + (w * q) + i * w + j];
                }
            }

            byte[,] fourParitySyndrom = new byte[w, e];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < e; j++)
                {
                    fourParitySyndrom[i, j] = syndrom[(e * w) + (w * q) + (w * e) + i * e + j];
                }
            }

            byte[,,] syndromMatrixThreeDimensial = new byte[w, q, e];
            Console.WriteLine("Первый синдром");
            IterativeCodeClass.GetMatrix(firstParitySyndrom);
            Console.WriteLine("Второй синдром");
            IterativeCodeClass.GetMatrix(secondParitySyndrom);
            Console.WriteLine("Третий синдром");
            IterativeCodeClass.GetMatrix(thirdParitySyndrom);
            Console.WriteLine("Четвёртый синдром");
            IterativeCodeClass.GetMatrix(fourParitySyndrom);

            for (int fp0 = 0; fp0 < w; fp0++)
            {
                for (int fp1 = 0; fp1 < q; fp1++)
                {
                    for (int i = 0; i < e; i++)
                    {
                        syndromMatrixThreeDimensial[fp0, fp1, i] = firstParitySyndrom[fp0, fp1];
                    }
                }
            }
            for (int sp0 = 0; sp0 < q; sp0++)
            {
                for (int sp1 = 0; sp1 < e; sp1++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        if (syndromMatrixThreeDimensial[i, sp0, sp1] == (byte)1)
                            syndromMatrixThreeDimensial[i, sp0, sp1] = secondParitySyndrom[sp0, sp1];
                    }
                }
            }
            for (int thp0 = 0; thp0 < e; thp0++)
            {
                for (int thp1 = 0; thp1 < w; thp1++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        if (syndromMatrixThreeDimensial[thp1, i, thp0] == (byte)1)
                            syndromMatrixThreeDimensial[thp1, i, thp0] = thirdParitySyndrom[thp0, thp1];
                    }
                }
            }
            for (int i = 0; i < e; i++)
            {
                for (int fd0 = 0; fd0 < w; fd0++)
                {
                    for (int fd1 = 0; fd1 < q; fd1++)
                    {
                        if (syndromMatrixThreeDimensial[(fd0 + fd1) % w, (fd1) % q, i] == (byte)1)
                            syndromMatrixThreeDimensial[(fd0 + fd1) % w, (fd1) % q, i] = fourParitySyndrom[i, fd0];
                    }
                }
            }

            List<int> errorPositions = new List<int>();
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    for (int g = 0; g < e; g++)
                    {
                        if (syndromMatrixThreeDimensial[i, j, g] == (byte)1)
                        {
                            errorPositions.Add((int) i * q + j * e + g );
                        }
                    }
                }
            }
            errorPositions = errorPositions.Distinct().ToList();
            errorPositions = errorPositions.OrderBy(x => x).ToList();
            foreach (var item in errorPositions)
            {
                Console.WriteLine("Ошибка в бите под номером " + item);
            }

        }
    }
}
