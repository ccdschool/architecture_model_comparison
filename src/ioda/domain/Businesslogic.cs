using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ioda.data;

namespace ioda.domain
{
    class Businesslogic {
        public static WordCountResult Count_words(string text, HashSet<string> stopwordsDirectory) {
            var t = Shred(text);
            return new WordCountResult {
                CountTotal = Filter(t.Words, stopwordsDirectory).ToArray().Length,
                CountDistinct = Filter(t.UniqueWords, stopwordsDirectory).ToArray().Length
            };
        }

        private static ShredderedText Shred(string text) {
            var wordCandidates = text.Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            return new ShredderedText(wordCandidates.SelectMany(Normalize));

            IEnumerable<string> Normalize(string wordCandidate) {
                foreach(var m in Regex.Matches(wordCandidate, @"[\w\-]*"))
                    if (!string.IsNullOrWhiteSpace(m.ToString()))
                        yield return m.ToString();
            }
        }

        private static IEnumerable<string> Filter(IEnumerable<string> words, HashSet<string> stopwordsDirectory)
            => words.Where(w => !stopwordsDirectory.Contains(w));
        
        
        class ShredderedText {
            private readonly IEnumerable<string>  _words;
            
            public ShredderedText(IEnumerable<string> words) { _words = words; }

            public string[] Words => _words.ToArray();
            public string[] UniqueWords => _words.Distinct().ToArray();
        }
    }
}