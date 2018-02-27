namespace clean.domain
{
    internal interface IBusinesslogic
    {
        (int countTotal, int countDistinct) Count_words(string text);
    }
}