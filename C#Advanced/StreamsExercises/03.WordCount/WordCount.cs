
namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            var wordsByCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(@"words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    word = word.ToLower();

                    if (!wordsByCount.ContainsKey(word))
                    {
                        wordsByCount[word] = 0;
                    }
                }
            }

            using (var reader = new StreamReader(@"..\Files\text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var currentWords = line
                        .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();

                    foreach (var word in currentWords)
                    {
                        if (wordsByCount.ContainsKey(word))
                        {
                            wordsByCount[word]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("result.txt"))
            {
                foreach (var res in wordsByCount.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{res.Key} - {res.Value}");
                }
            }
        }
    }
}
