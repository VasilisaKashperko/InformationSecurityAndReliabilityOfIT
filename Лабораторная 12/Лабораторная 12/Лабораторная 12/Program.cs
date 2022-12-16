using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int z = 1;

            while (z != 2 || z != 3)
            {
                    Console.Write("Выберите, для скольки чисел будет вычисляться наибольший общий делитель (НОД)? 2 или 3?: ");
                    z = Convert.ToInt32(Console.ReadLine());

                if (z == 2 || z == 3)
                {
                    switch (z)
                    {
                        case 2:
                            Console.WriteLine("\nАлгоритм Евклида для двух чисел");

                            Console.Write("Первое число: ");
                            var a = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Второе число: ");
                            var b = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Наибольший общий делитель чисел {0} и {1} равен {2}", a, b, GreatestCommonDivisor.GetGreatestCommonDivisor(a, b));

                            if (GreatestCommonDivisor.GetGreatestCommonDivisor(a, b) == 1)
                            {
                                Console.WriteLine("Числа взаимно простые!");
                            }

                            break;

                        case 3:
                            Console.WriteLine("\nАлгоритм Евклида для трёх чисел");

                            Console.Write("Первое число: ");
                            var c = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Второе число: ");
                            var d = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Третье число: ");
                            var e = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Наибольший общий делитель чисел {0}, {1} и {2} равен {3}", c, d, e, GreatestCommonDivisor.GetGreatestCommonDivisor(GreatestCommonDivisor.GetGreatestCommonDivisor(c, d), e));

                            if (GreatestCommonDivisor.GetGreatestCommonDivisor(GreatestCommonDivisor.GetGreatestCommonDivisor(c, d), e) == 1)
                            {
                                Console.WriteLine("Все три числа взаимно простые!");
                            }

                            break;

                        default:
                            Console.WriteLine("Попробуйте выбрать из чисел 2 и 3.");
                            break;
                    }

                    Console.Write("\nДо какого числа выполняем поиск простых чисел? До ");
                    var n = Convert.ToInt32(Console.ReadLine());
                    var primeNumbers = PrimeNumbers.EratosthenesSieve(n);

                    Console.WriteLine("Простые числа от 2 до {0}:", n);
                    Console.WriteLine(string.Join(", ", primeNumbers));

                    Console.WriteLine("Количество простых чисел в интервале: " + primeNumbers.Count);
                    Console.WriteLine(primeNumbers.Count / Math.Log(primeNumbers.Count));

                    Console.WriteLine("\nЯвляется ли число, состоящее из конкантенации двух простым?");

                    string f = "42";
                    string g = "45";

                    Console.WriteLine("Первое число: {0}", f);

                    Console.WriteLine("Второе число: {0}", g);

                    var concated = f + g;
                    Console.WriteLine("\n" + concated.ToString());

                    var primeNumbersHugeGap = PrimeNumbers.EratosthenesSieve(10000);
                    bool isPrimeNumber = primeNumbersHugeGap.Contains(Convert.ToInt32(concated.ToString()));

                    if (isPrimeNumber == true)
                    {
                        Console.WriteLine($"{concated} является простым числом!");
                    }

                    else
                    {
                        Console.WriteLine($"{concated} НЕ является простым числом!");
                    }

                    Console.WriteLine();

                    return;
                }
            }
        }
    }
}
