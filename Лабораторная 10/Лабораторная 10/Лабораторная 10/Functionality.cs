using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_10
{
    public class Functionality
    {
        public static void ToAddSymbols(int symbolAmount, ref string buffer, ref string slidingWindow)
        {
            if(symbolAmount > slidingWindow.Length)
            {
                symbolAmount = slidingWindow.Length;
            }

            if (symbolAmount > 0)
            {
                buffer += slidingWindow.Substring(0, symbolAmount);
                slidingWindow = slidingWindow.Substring(symbolAmount, slidingWindow.Length - symbolAmount);
            }
        }

        public static void toCheckBufferSize(int size, ref string bufferAfterShift)
        {
            if (bufferAfterShift.Length > size)
            {
                bufferAfterShift = bufferAfterShift.Substring(bufferAfterShift.Length - size, bufferAfterShift.Length - (bufferAfterShift.Length - size));
            }
        }

        public static void ToSearchSymbols(string buffer, string slidingWindow, out int indeedSet, out int coincideLength, out char theNextSymbol)
        {
            coincideLength = 0;

            theNextSymbol = slidingWindow[0];

            indeedSet = 0;

            // while (buffer.Contains(slidingWindow.Substring(0, (coincideLength))))

            while (buffer.Contains(slidingWindow.Substring(0, (coincideLength + 1))))
            {
                //indeedSet = buffer.IndexOf(slidingWindow.Substring(0, (coincideLength))) + 1;

                indeedSet = buffer.IndexOf(slidingWindow.Substring(0, (coincideLength + 1))) + 1;

                coincideLength++;

                if (slidingWindow.Length == coincideLength)
                {
                    theNextSymbol = ' ';
                    break;
                }

                else
                {
                    theNextSymbol = slidingWindow[coincideLength];
                }
            }
        }
    }
}
