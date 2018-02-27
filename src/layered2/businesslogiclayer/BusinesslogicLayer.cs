using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using layered2.dataaccesslayer;

namespace layered2.businesslogiclayer
{
    class BusinesslogicLayer : IBusinesslogicLayer
    {
        private readonly IDataacessLayer _dal;
        
        public BusinesslogicLayer(IDataacessLayer dal) { _dal = dal; }
        
        
        public (int countTotal, int countDistinct) Count_words_in_file(string filename) {
            var text = _dal.Read_text(filename);
            return Count_words(text);
        }
        
        public (int countTotal, int countDistinct) Count_words(string text) {
            var stopwordsDirectory = _dal.Load_stopwords();
            
            var candidateWords = text.Split(new[] {' ', '\t', '\n', '\r'}, 
                                            StringSplitOptions.RemoveEmptyEntries);
            var countTotal = 0;
            var countDistinct = 0;
            
            var distinctWords = new HashSet<string>();
            foreach (var wordCandidate in candidateWords) {
                foreach(var m in Regex.Matches(wordCandidate, @"[\w\-]*"))
                    if (!string.IsNullOrWhiteSpace(m.ToString())) {
                        var word = m.ToString().ToLower();

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