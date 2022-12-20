using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_11
{
    public class Functionality
    {
        public char SymbolFromMessage { get; set; }
        public int AmountOfSymbol { get; set; }
        public double ProbalilityOfSymbol { get; set; }
        public string CodeOfSymbol { get; set; }
        public double IntervalStart { get; set; }
        public double IntervalEnd { get; set; }

        public static void GetSymbolsRepeat(List<Functionality> symbolsWithTheirCodes)
        {
            foreach (var symbolWithItsCode in symbolsWithTheirCodes)
            {
                Console.WriteLine(symbolWithItsCode.SymbolFromMessage + " | " + symbolWithItsCode.AmountOfSymbol);
            }
        }

        public static void GetSymbolsWithTheirCharacteristics(List<Functionality> symbolsWithTheirCodes)
        {
            foreach (var symbolWithItsCode in symbolsWithTheirCodes)
            {
                Console.WriteLine(symbolWithItsCode.SymbolFromMessage + " | " + symbolWithItsCode.AmountOfSymbol + " | " + symbolWithItsCode.ProbalilityOfSymbol);
            }
        }

        public static void GetSymbolsWithTheirIntervals(List<Functionality> symbolsWithTheirCodes)
        {
            foreach (var symbolWithItsCode in symbolsWithTheirCodes)
            {
                Console.WriteLine(symbolWithItsCode.SymbolFromMessage + " | " + symbolWithItsCode.AmountOfSymbol + " | " + symbolWithItsCode.ProbalilityOfSymbol + " | [" + symbolWithItsCode.IntervalStart + " ; " + symbolWithItsCode.IntervalEnd + "]");
            }
        }

        public static List<Functionality> ToAddSymbols(List<Functionality> symbolsWithTheirCodes, string output)
        {
            foreach (var symbol in output)
            {
                if (symbolsWithTheirCodes.Find(x => x.SymbolFromMessage == symbol) != null)
                {
                    symbolsWithTheirCodes.Where(x => x.SymbolFromMessage == symbol).ToList().ForEach(x => x.AmountOfSymbol++);
                }

                else
                {
                    symbolsWithTheirCodes.Add(new Functionality(symbol, 1, 0, ""));
                }
            }
            return symbolsWithTheirCodes;
        }

        public Functionality(char symbol, int amount, double probability, string code)
        {
            this.IntervalStart = 0;
            this.IntervalEnd = 0;
            this.SymbolFromMessage = symbol;
            this.AmountOfSymbol = amount;
            this.ProbalilityOfSymbol = probability;
            this.CodeOfSymbol = code;
        }
    }
}
