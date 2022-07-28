using System;
namespace ParsingOfNumbers.lib
{
    public class TextNormalization
    {
        private static readonly Dictionary<string, long> numberTable = new()
        {
            { "minus", -1 },
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            { "ten", 10 },
            { "eleven", 11 },
            { "twelve", 12 },
            { "thirteen", 13 },
            { "fourteen", 14 },
            { "fifteen", 15 },
            { "sixteen", 16 },
            { "seventeen", 17 },
            { "eighteen", 18 },
            { "nineteen", 19 },
            { "twenty", 20 },
            { "thirty", 30 },
            { "forty", 40 },
            { "fifty", 50 },
            { "sixty", 60 },
            { "seventy", 70 },
            { "eighty", 80 },
            { "ninety", 90 },
            { "hundred", 100 },
            { "thousand", 1000 },
            { "lakh", 100000 },
            { "million", 1000000 },
            { "billion", 1000000000 },
            { "trillion", 1000000000000 },
            { "quadrillion", 1000000000000000 },
            { "quintillion", 1000000000000000000 }
        };

        private static bool isEndsWithMark(string text)
        {
            if (text.EndsWith('.') || text.EndsWith('!') || text.EndsWith('?'))
                return true;
            return false;
        }

        private static List<string> SplitString(string text)
        {
            List<string> words = text.Split(' ').ToList();

            // check if the last char is one of '.', '!', '?'
            string lastWord = "";
            bool flag = false;
            if (isEndsWithMark(text))
            {
                lastWord = text.Substring(text.LastIndexOf(' ') + 1, text.Length - text.LastIndexOf(' ') - 2);
                flag = true;
            }
            else lastWord = text.Substring(text.LastIndexOf(' ') + 1, text.Length - text.LastIndexOf(' ') - 1);

            words.RemoveAt(words.Count - 1);
            words.Add(lastWord);
            if (flag) words.Add(text.ElementAt(text.Length - 1).ToString());

            return words;
        }

        private static long ConvertSequenceToNumber(List<string> words)
        {
            long acc = 0, total = 0L;
            foreach (string word in words)
            {
                long n = numberTable.GetValueOrDefault(word);
                if (n == -1) continue;
                if (n >= 1000)
                {
                    total += acc * n;
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (words.First().StartsWith("minus",
                    StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }

        private static string ParseText(string text)
        {
            List<string> words = SplitString(text);
            List<string> temp = new();
            List<string> res = new();

            
            int wordCounter = 0;
            for (int i = 0; i < words.Count; i++)
            {
                bool found = false;
                if (numberTable.ContainsKey(words.ElementAt(i)))
                {
                    found = true;

                    wordCounter++;
                    temp.Add(words.ElementAt(i));
                }

                if (!found || i == words.Count - (isEndsWithMark(text)? 2: 1))
                {
                    if (temp.Count > 0)
                    {
                        long number = ConvertSequenceToNumber(temp);
                        temp.Clear();
                        res.Add(number.ToString());
                    }
                    else res.Add(words.ElementAt(i));
                }
            }

            string final = "";
            for (int i = 0; i < res.Count; i++)
            {
                if (isEndsWithMark(text))
                    if (i != res.Count - 2) final += res.ElementAt(i) + " ";
                    else final += res.ElementAt(i);
                else
                    if (i != res.Count - 1) final += res.ElementAt(i) + " ";
                    else final += res.ElementAt(i);
            }

            return final;

        }

        public static string NormalizeText(string text)
        {
            return ParseText(text);
        }
    }
}

