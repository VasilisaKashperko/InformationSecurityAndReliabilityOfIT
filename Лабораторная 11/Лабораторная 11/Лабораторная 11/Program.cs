using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = { "мультимиллионер", "мультимиллионерсеменохранилище" };

                Console.WriteLine("Сообщение первое: " + input[0]);
                Console.WriteLine("Сообщение второе: " + input[1] + "\n");

                Console.WriteLine("\t\t\tСжатие\n");

                Stopwatch encodeTimer = new Stopwatch();
                encodeTimer.Start();

                foreach (var i in input)
                {
                    List<Functionality> inputSymbolsList = new List<Functionality>();

                    inputSymbolsList = Functionality.ToAddSymbols(inputSymbolsList, i);

                    Functionality.GetSymbolsRepeat(inputSymbolsList);
                    Console.WriteLine();

                    double summaryIndeed = inputSymbolsList.Sum(x => x.AmountOfSymbol);

                    for (int k = 0; k < inputSymbolsList.Count; k++)
                    {
                        inputSymbolsList[k].ProbalilityOfSymbol = inputSymbolsList[k].AmountOfSymbol/summaryIndeed;
                    }

                    //inputSymbolsList = inputSymbolsList.OrderBy(x => x.ProbalilityOfSymbol).ToArray();
                    inputSymbolsList = inputSymbolsList.OrderBy(x => x.ProbalilityOfSymbol).ToList();
                    Functionality.GetSymbolsWithTheirCharacteristics(inputSymbolsList);
                    Console.WriteLine();

                    double doubleIndeedForIntervals = 0;

                    for (int k = 0; k < inputSymbolsList.Count; k++)
                    {
                        inputSymbolsList[k].IntervalStart = doubleIndeedForIntervals;

                        doubleIndeedForIntervals += inputSymbolsList[k].ProbalilityOfSymbol;

                        inputSymbolsList[k].IntervalEnd = doubleIndeedForIntervals;
                    }

                    Functionality.GetSymbolsWithTheirIntervals(inputSymbolsList);
                    Console.WriteLine();

                    double LowerBorder = inputSymbolsList.Find(x => x.SymbolFromMessage == i[0]).IntervalStart;

                    double HigherBorder = inputSymbolsList.Find(x => x.SymbolFromMessage == i[0]).IntervalEnd;

                    double LowerBorderForTheNext = 0;
                    double HigherBorderForTheNext = 0;

                    double intervalStart;
                    double intervalEnd;

                    Console.WriteLine("\nLn = Ln-1 + (Hn-1 - Ln-1) * меньшее значение для буквы в первых постронных отрезках");
                    Console.WriteLine("Hn = Ln-1 + (Hn-1 - Ln-1) * большее значение для буквы в первых постронных отрезках\n");


                    for (int k = 1; k < i.Length; k++)
                    {
                        intervalStart = inputSymbolsList.Find(x => x.SymbolFromMessage == i[k]).IntervalStart;
                        intervalEnd = inputSymbolsList.Find(x => x.SymbolFromMessage == i[k]).IntervalEnd;

                        LowerBorderForTheNext = LowerBorder+(HigherBorder-LowerBorder) * intervalStart;
                        HigherBorderForTheNext = LowerBorder+(HigherBorder-LowerBorder) * intervalEnd;

                        Console.WriteLine(LowerBorderForTheNext + " - " + HigherBorderForTheNext);

                        LowerBorder = LowerBorderForTheNext;
                        HigherBorder = HigherBorderForTheNext;
                    }

                    encodeTimer.Stop();

                    Console.WriteLine("\nСжатое сообщение: " + LowerBorderForTheNext);

                    Console.WriteLine("\n\t\t\tРаспаковка\n");

                    string output = string.Empty;
                    Functionality outputDecodedSymbol;

                    Stopwatch decodeTimer = new Stopwatch();
                    decodeTimer.Start();

                    for (int k = 0; k < i.Length; k++)
                    {
                        outputDecodedSymbol = inputSymbolsList.Find(x => (LowerBorderForTheNext <= x.IntervalEnd) && (LowerBorderForTheNext >= x.IntervalStart));

                        intervalStart = outputDecodedSymbol.IntervalStart;
                        intervalEnd = outputDecodedSymbol.IntervalEnd;

                        output += outputDecodedSymbol.SymbolFromMessage;

                        Console.WriteLine(outputDecodedSymbol.SymbolFromMessage + " | " +intervalStart + " - " + intervalEnd);

                        LowerBorderForTheNext = (LowerBorderForTheNext - intervalStart) / (intervalEnd - intervalStart);
                    }

                    decodeTimer.Stop();

                    Console.WriteLine("\nРаспакованное сообщение: " + output);

                    Console.WriteLine("\nВремя кодирования:" + encodeTimer.ElapsedMilliseconds);
                    Console.WriteLine("Время декодирования:" + decodeTimer.ElapsedMilliseconds);

                    Console.WriteLine("\n-------------------------------------------------------------------\n");
                }
            }

            catch
            {
                Console.WriteLine("Ошибка при выполнении программы!");
            }
        }
    }
}
