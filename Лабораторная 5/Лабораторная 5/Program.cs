using System;
using System.Text;

namespace Лабораторная_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите 1 для выполнения первого задания, 2 - для второго");
            string line = Console.ReadLine();

            if (Convert.ToInt32(line) == 1)
            {
                Console.WriteLine("Задание 1");
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("Произвольное бинарное представление информационного слова:");

                int k = 9;
                byte[] thisWord = new byte[k];
                for (int i = 0; i < k; i++)
                {
                    thisWord[i] = (byte)(IterativeCodeClass.random.Next(0, 2));
                }
                IterativeCodeClass.GetWord(thisWord);

                int k1 = 3;
                int k2 = 3;
                byte[,] thisMatrix = IterativeCodeClass.CreateMatrix(k1, k2);

                byte[] fullWord = IterativeCodeClass.ActionsForTwoDimensialMatrix(thisWord, thisMatrix);

                byte[] fullWordRea = fullWord;

                Console.WriteLine("\nЗадаём ошибки");
                int amountOfMistakes = 1;

                Console.WriteLine($"Количество ошибок: {amountOfMistakes}");
                byte[] fullWordWithMistakes = IterativeCodeClass.CreateAMistake(fullWord, k, amountOfMistakes);

                Console.WriteLine("Yn:");
                IterativeCodeClass.GetWord(fullWordWithMistakes);
                Console.WriteLine();

                Console.WriteLine("\nВычисление проверочных символов для слова с ошибкой:");
                byte[] wordWithMistakes = new byte[k];
                byte[] newfullWord = IterativeCodeClass.ActionsForTwoDimensialMatrix(wordWithMistakes, thisMatrix);
                Array.Copy(fullWordWithMistakes, wordWithMistakes, k);

                Console.WriteLine("\n");
                Console.WriteLine("Ищем ошибки (проверка по двум паритетам):");

                byte[] twoParitiesWithMistakes = new byte[k1 + k2];
                byte[] newTwoParities = new byte[k1 + k2];

                Array.Copy(fullWordWithMistakes, k, twoParitiesWithMistakes, 0, k1 + k2);
                Array.Copy(newfullWord, k, newTwoParities, 0, k1 + k2);

                IterativeCodeClass.GetMistakesWithTheSecondParity(k1, k2, twoParitiesWithMistakes, newTwoParities);
                int mistakesInThisWord = IterativeCodeClass.GetMistakesPositionWithTheSecondParity(k1, k2, twoParitiesWithMistakes, newTwoParities);
                if (amountOfMistakes == 1)
                {
                    Console.WriteLine("Yn':");
                    IterativeCodeClass.GetWordCor(fullWordRea, mistakesInThisWord);
                }
                else if (amountOfMistakes % 2 == 0)
                {
                    Console.WriteLine("Итеративный код позволяет нам исправлять только одну ошибку.");
                }
                else
                {
                    Console.WriteLine("Yn':");
                    IterativeCodeClass.GetWordCor(fullWordRea, mistakesInThisWord);
                }

                Console.WriteLine("\n");
                Console.WriteLine("Ищем ошибки, используя проверку по трем паритетам");
                byte[] threeParitiesMistakes = new byte[k1 + k2 + k1];
                byte[] modThreeParities = new byte[k1 + k2 + k1];

                Array.Copy(fullWordWithMistakes, k, threeParitiesMistakes, 0, k1 + k2 + k1);
                Array.Copy(newfullWord, k, modThreeParities, 0, k1 + k2 + k1);

                IterativeCodeClass.GetMistakesWithTheThirdParity(k1, k2, k1, threeParitiesMistakes, modThreeParities);
                int mistakesInWordThree = IterativeCodeClass.GetMistakesPositionWithTheSecondParity(k1, k2, twoParitiesWithMistakes, newTwoParities);
                if (amountOfMistakes == 1)
                {
                    Console.WriteLine("Yn':");
                    IterativeCodeClass.GetWordCor(fullWordRea, mistakesInWordThree);
                }
                else if (amountOfMistakes%2 == 0)
                {
                    Console.WriteLine("Итеративный код позволяет нам исправлять только одну ошибку.");
                }
                else
                {
                    Console.WriteLine("Yn':");
                    IterativeCodeClass.GetWordCor(fullWordRea, mistakesInWordThree);
                }

                Console.ReadLine();
            }

            if (Convert.ToInt32(line) == 2)
            {
                Console.WriteLine("Задание 2");
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Произвольное бинарное представление информационного слова Хk:");
                int k = 24;
                byte[] thisWord = new byte[k];
                for (int i = 0; i < k; i++)
                {
                    thisWord[i] = (byte)(IterativeCodeClass.random.Next(0, 2));
                }
                IterativeCodeClass.GetWord(thisWord);

                Console.WriteLine("Создаём трёхмерную матрицу:");
                int k1 = 6; int k2 = 2; int k3 = 2;
                Console.WriteLine($"k1 = {k1}\nk2 = {k2}\nz = {k3}");
                byte[,,] thisMatrixDimentional = Dimential.CreateMatrix(k1, k2, k3);

                byte[] fullWord = Dimential.SequenceOfTasksWithMatrix(thisWord, thisMatrixDimentional);

                Console.WriteLine("\n");
                Console.WriteLine("Задаём ошибки");
                int countMistakes = 1;

                Console.WriteLine($"Количество ошибок: {countMistakes}");
                byte[] fullWordWithMistakesThree = IterativeCodeClass.CreateAMistake(fullWord, k, countMistakes);

                Console.WriteLine("Yn:");
                IterativeCodeClass.GetWord(fullWordWithMistakesThree);
                Console.WriteLine();

                Console.WriteLine("\n");
                Console.WriteLine("Повторяем операции вычисления проверочных символов для слова с ошибкой");
                byte[] wordWithMistakesThree = new byte[k];
                Array.Copy(fullWordWithMistakesThree, wordWithMistakesThree, k);
                byte[] newfullWordThree = Dimential.SequenceOfTasksWithMatrix(wordWithMistakesThree, thisMatrixDimentional);

                Console.WriteLine("\n");
                Console.WriteLine("Ищем ошибки, используя проверку по двум паритетам");
                byte[] twoParitiesWithMistakesThree = new byte[(k1 * k2) + (k2 * k3)];
                byte[] newTwoParities = new byte[(k1 * k2) + (k2 * k3)];

                Array.Copy(fullWordWithMistakesThree, k, twoParitiesWithMistakesThree, 0, twoParitiesWithMistakesThree.Length);
                Array.Copy(newfullWordThree, k, newTwoParities, 0, newTwoParities.Length);

                Dimential.GetMistakesTwoParities(k1, k2, k3, twoParitiesWithMistakesThree, newTwoParities);

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Выход из программы...");
            }
        }
    }
}
