using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_8
{
    public class Functionality
    {
        public static void PrintMatrix(string[] matrix)
        {
            foreach (var rows in matrix)
            {
                Console.WriteLine(rows);
            }
            Console.WriteLine();
        }

        public static string[] SortedMatrix(string[] matrix)
        {
            return (matrix.OrderBy(x => x).ToArray());
        }

        public static string[] CreateMatrix(string input)
        {
            string[] matrix = new string[input.Count()];
            for (int i = 0; i < input.Count(); i++)
            {
                matrix[i] = input;
                input = input.Substring(1) + input[0];
            }
            return matrix;
        }

        public static string GetTheLastColumnFromMatrix(string[] matrix)
        {
            string theLastColumn = "";
            foreach (var rows in matrix)
            {
                theLastColumn += rows[rows.Length - 1];
            }
            return theLastColumn;
        }

        public static int GetRowNumberFromMatrix(string input, string[] matrix)
        {
            int correctWordInRows = -1;
            for (int i = 0; i < matrix.Count(); i++)
            {
                if (matrix[i] == input)
                {
                    return i;
                }
            }
            return correctWordInRows;
        }

        public static string[] AddDecodingMatrixRows(string input, string[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = input[i] + matrix[i];
            }
            return matrix;
        }

        public static string[] GetDecodingMatrix(string message)
        {
            string[] messageMatrix = new string[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                messageMatrix = AddDecodingMatrixRows(message, messageMatrix);
                PrintMatrix(messageMatrix);
                messageMatrix = SortedMatrix(messageMatrix);
            }
            return messageMatrix;
        }
    }
}
