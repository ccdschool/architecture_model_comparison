using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace dirty
{
    internal class Program
    {
        public static void Main(string[] args) {
            var stopwords = new string[0];
            if (File.Exists("stopwords.txt"))
                stopwords = File.ReadAllLines("stopwords.txt");
            
            var text = "";
            if (args.Length > 0)
                text = File.ReadAllText(args[0]);
            else {
                Console.Write("Text eingeben: ");
                text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) return;
            }

            var candidateWords = text.Split(new[] {' ', '\t', '\n', '\r'}, 
                                            StringSplitOptions.RemoveEmptyEntries);
            var countTotal = 0;
            var countDistinct = 0;
            var stopwordsDirectory = new HashSet<string>(stopwords);
            var distinctWords = new HashSet<string>();
            foreach (var wortkandidat in candidateWords) {
                foreach(var m in Regex.Matches(wortkandidat, @"[\w\-]*"))
                    if (!string.IsNullOrWhiteSpace(m.ToString())) {
                        var word = m.ToString();

                        if (!stopwordsDirectory.Contains(word)) {
                            countTotal++;

                            if (!distinctWords.Contains(word)) {
                                distinctWords.Add(word);
                                countDistinct++;
                            }
                        }
                    }
            }
            
            Console.WriteLine($"{countTotal} Worte, davon {countDistinct} verschieden");
        }
    }
}