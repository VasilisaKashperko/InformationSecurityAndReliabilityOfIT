using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_12
{
    public class PrimeNumbers
    {
        public static List<int> EratosthenesSieve(int n)
        {
            var primeNumbers = new List<int>();

            // заполняем список числами от 2 до n
            for (var i = 2; i <= n; i++)
            {
                primeNumbers.Add(i);
            }

            for (var i = 0; i < primeNumbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    // и удаляем кратные числа из списка
                    primeNumbers.Remove(primeNumbers[i] * j);
                }
            }

            return primeNumbers;
        }
    }
}
