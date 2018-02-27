using System.Collections.Generic;
using System.IO;

namespace layered2.dataaccesslayer
{
    class DataacessLayer : IDataacessLayer
    {
        public string Read_text(string filename) => File.ReadAllText(filename);

        
        public HashSet<string> Load_stopwords() {
            const string STOPWORDS_FILENAME = "stopwords.txt";
            
            var stopwords = new string[0];
            if (File.Exists(STOPWORDS_FILENAME))
                stopwords = File.ReadAllLines(STOPWORDS_FILENAME);
            return new HashSet<string>(stopwords);
        }
    }
}