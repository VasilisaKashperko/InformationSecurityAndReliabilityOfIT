﻿using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Лабораторная_2
{
    public static class AlphabetsTask
    {
        public static double AlphabetEntropy(Alphabets Alphabet, float errorProbability = 0)
        {
            string alphabet = "";
            string path = "";

            if (Alphabet == Alphabets.Latin)
            {
                alphabet = "qwertyuiopasdfghjklñzxcvbnm"; // испанский язык
                path = "latin.txt";
            }

            else if (Alphabet == Alphabets.Cyrillic)
            {
                path = "cyrillic.txt";
                alphabet = "љњертзуиопшђжасдфгхјклчћѕџцвбнм"; // сербский язык
            }

            else if (Alphabet == Alphabets.Binary)
            {
                path = "binary.bin";
                alphabet = "01";
            }

            Dictionary<char, int> numberOfOccurrences = new Dictionary<char, int>();
            foreach (var ch in alphabet)
                numberOfOccurrences.Add(ch, 0);

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                text = text.ToLower();
                foreach (var ch in text.Select((value, i) => new { i, value }))
                {
                    if (alphabet.Contains(ch.value))
                        numberOfOccurrences[ch.value]++;
                    else
                        text.Remove(ch.i);
                }

                double answer = 0;
                foreach (var ch in alphabet)
                {
                    if (numberOfOccurrences[ch] != 0)
                    {
                        double P = (double)numberOfOccurrences[ch] / (double)text.Length * (1 - errorProbability);
                        answer += P * Math.Log2(P);
                    }
                }

                return -answer;
            }
        }
        public enum Alphabets
        {
            Latin,
            Cyrillic,
            Binary
        }
    }
}