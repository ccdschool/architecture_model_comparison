using System.Collections.Generic;

namespace layered2.dataaccesslayer
{
    internal interface IDataacessLayer
    {
        string Read_text(string filename);
        HashSet<string> Load_stopwords();
    }
}