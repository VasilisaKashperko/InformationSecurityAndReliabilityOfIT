using System;

namespace Лабораторная_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region The first task

            Console.WriteLine("Entropy of alphabets");
            Console.WriteLine("Cyrillic: " + AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Cyrillic));
            Console.WriteLine("Latin: " + AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Latin));

            #endregion

            #region The second task

            Console.WriteLine("Binary: " + AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Binary));
            Console.WriteLine();

            #endregion

            #region The third task

            Console.WriteLine("I в ФИО (Latin): " + (AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Latin) * "Kashperko Vasilisa Sergeevna".Length));
            Console.WriteLine("I в ФИО (ASCII): " + (AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Binary) * System.Text.Encoding.Unicode.GetBytes("Kashperko Vasilisa Sergeevna").Length));

            #endregion

            #region The fourth task

            Console.WriteLine("I в ФИО (ASCII, error probability 0.1): " + (AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Binary, 0.1f) * System.Text.Encoding.Unicode.GetBytes("Kashperko Vasilisa Sergeevna").Length));
            Console.WriteLine("I в ФИО(ASCII, error probability 0.5): " + (Double.IsNaN(AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Binary, 1f)) ? 0 : AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Binary, 1f) * System.Text.Encoding.Unicode.GetBytes("Kashperko Vasilisa Sergeevna").Length));
            Console.WriteLine("I в ФИО (ASCII, error probability 1): " + (AlphabetsTask.AlphabetEntropy(AlphabetsTask.Alphabets.Binary) * System.Text.Encoding.Unicode.GetBytes("Kashperko Vasilisa Sergeevna").Length));

            #endregion
        }
    }
}
