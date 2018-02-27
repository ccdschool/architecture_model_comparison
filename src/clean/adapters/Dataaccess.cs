using System.Collections.Generic;
using System.IO;
using clean.domain;
using clean.domain.dependencies;
using clean.usecases.dependencies;

namespace clean.adapters
{
    class Dataaccess : ITexts, IStopwords
    {
        string ITexts.Retrieve(string filename) => File.ReadAllText(filename);

        
        HashSet<string> IStopwords.Retrieve() {
            const string STOPWORDS_FILENAME = "stopwords.txt";
            
            var stopwords = new string[0];
            if (File.Exists(STOPWORDS_FILENAME))
                stopwords = File.ReadAllLines(STOPWORDS_FILENAME);
            return new HashSet<string>(stopwords);
        }
    }
}