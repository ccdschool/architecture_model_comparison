using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using clean.domain.dependencies;

namespace clean.domain
{
    class Businesslogic : IBusinesslogic
    {
        private readonly IStopwords _dal;
        
        public Businesslogic(IStopwords dal) { _dal = dal; }
        
        
        public (int countTotal, int countDistinct) Count_words(string text) {
            var stopwordsDirectory = _dal.Retrieve();
            
            var candidateWords = text.Split(new[] {' ', '\t', '\n', '\r'}, 
                                            StringSplitOptions.RemoveEmptyEntries);
            var countTotal = 0;
            var countDistinct = 0;
            
            var distinctWords = new HashSet<string>();
            foreach (var wordCandidate in candidateWords) {
                foreach(var m in Regex.Matches(wordCandidate, @"[\w\-]*"))
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

            return (countTotal, countDistinct);
        }
    }
}