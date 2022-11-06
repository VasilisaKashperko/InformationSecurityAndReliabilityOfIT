using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Calculation
    {
        static public string FindRedundantCharacters(string Xk, char[,] checkMatrix, int r, int k)
        {
            StringBuilder Xr = new StringBuilder("");
            int numberOfPairsOfUnits = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (checkMatrix[i, j] == '1' && Xk[j] == '1')
                        numberOfPairsOfUnits++;
                }

                if (numberOfPairsOfUnits % 2 == 0)
                    Xr.Append('0');
                else
                    Xr.Append('1');

                numberOfPairsOfUnits = 0;
            }

            return Xr.ToString();

        }
        static public int Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        static public int NewtonBinomial(int wt, int r)
        {
            return Factorial(r) / (Factorial(wt) * Factorial(r - wt));
        }

        static public char[,] GetLeftPartCheckMatrix(int r, int k)
        {
            int countOfColomn = 0;
            int wt = 2;

            char[,] leftPartCheckMatrix = new char[r, k];
            while(true)
            {
                int amountAllCombination = NewtonBinomial(wt, r);
                int rightCombination = 0;
                int number = 3;

                while (rightCombination != amountAllCombination && countOfColomn != k)
                {

                    string binaryNumber = Convert.ToString(number, 2);
                    int binaryNumberLength = binaryNumber.Length;

                    //Счетчик единиц в бинарной строке
                    int unitCounter = 0;

                    for (int i = 0; i < binaryNumberLength; i++)
                    {
                        if (binaryNumber[i] == '1')
                            unitCounter++;
                    }

                    if (unitCounter == wt)
                    {
                        countOfColomn++;

                        if (binaryNumberLength < r)
                        {
                            for (int j = 0; j < (r - binaryNumberLength); j++)
                            {
                                binaryNumber = "0" + binaryNumber;
                            }
                        }

                        for(int i1 = 0; i1 < r; i1++)
                        {
                            leftPartCheckMatrix[i1, countOfColomn - 1] = binaryNumber[i1];
                        }

                        rightCombination++;
                    }

                    number++;
                }

                if (countOfColomn != k)
                    wt++;
                else
                    break;
            }

            return leftPartCheckMatrix;
        }

        static public char[,] GetRightPartCheckMatrix(int r)
        {
            char[,] rightPartCheckMatrix = new char[r, r];

            int k = 0;
            for(int i = k; i < r; i++)
            {
                for(int j = 0; j < r; j++)
                {
                    if (j == i - k)
                        rightPartCheckMatrix[i, j] = '1';
                    else
                        rightPartCheckMatrix[i, j] = '0';
                }
            }

            return rightPartCheckMatrix;
        }

        static public char[,] GetCheckMatrix(int r, int k)
        {
            char[,] fullCheckMatrix = new char[r, r + k];

            char[,] leftPart = GetLeftPartCheckMatrix(r, k);
            char[,] rightPart = GetRightPartCheckMatrix(r);

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    fullCheckMatrix[j, i] = leftPart[j, i];
                }
            }

            int i1 = 1;
            for (int i = k; i < (k+r); i++)
            {
                for (int j = 0; j < r; j++)
                {
                    fullCheckMatrix[j, i] = rightPart[j, i1 - 1];
                }
                i1++;
            }

            return fullCheckMatrix;
        }

        static public string GetErrorVector(int errorPosition, int n)
        {
            StringBuilder errorVector = new StringBuilder("");
            for(int i = 0; i < n; i++)
            {
                if (i != errorPosition)
                    errorVector.Append('0');
                else
                    errorVector.Append('1');
            }

            return errorVector.ToString();
        }

        static public char[,] AddColumnAndRow(char[,] originalCheckMatrix, int r, int k)
        {
            char[,] modifyMatrix = new char[r, k + r];

            for (int i = 0; i < r - 1; i++)
            {
                for (int j = 0; j < (k + r - 1); j++)
                {
                    modifyMatrix[i, j] = originalCheckMatrix[i, j];
                }
            }

            for (int i = 0; i < (k + r); i++)
            {
                modifyMatrix[r - 1, i] = '1';
            }

            for (int i = 0; i < r - 1; i++)
            {
                modifyMatrix[i, k + r - 1] = '0';
            }

            return modifyMatrix;
        }

        static public char[,] ModifyMatrix(char[,] originalCheckMatrix, int r, int k)
        {
            char[,] modifyMatrix = AddColumnAndRow(originalCheckMatrix, r, k);

            int amountOfUnit = 0;
            for (int i = 0; i < (k + r); i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (modifyMatrix[j, i] == '1')
                        amountOfUnit++;
                }

                if (amountOfUnit % 2 == 0)
                    modifyMatrix[r - 1, i] = '0';
                else
                    modifyMatrix[r - 1, i] = '1';

                amountOfUnit = 0;
            }

            return modifyMatrix;
           
        }

        static public void PrintMatrix(char[,] matrix, int r, int k)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < (k + r); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static public int GetErrorPosition(char[,] checkMatrix, string syndrom, int r, int k)
        {
            int amountCoincidences = 0;
            for(int i = 0; i < k; i++)
            {
                for(int j = 0; j < r; j++)
                {
                    if (checkMatrix[j, i] == syndrom[j])
                        amountCoincidences++;
                }

                if (amountCoincidences == r)
                    return i;
                else
                    amountCoincidences = 0;
            }

            return -1;
        }
    }
}
