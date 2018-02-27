using System.Collections.Generic;

namespace clean.domain.dependencies
{
    internal interface IStopwords
    {
        HashSet<string> Retrieve();
    }
}