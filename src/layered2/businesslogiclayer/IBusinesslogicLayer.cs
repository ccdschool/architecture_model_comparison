namespace layered2.businesslogiclayer
{
    internal interface IBusinesslogicLayer
    {
        (int countTotal, int countDistinct) Count_words_in_file(string filename);
        (int countTotal, int countDistinct) Count_words(string text);
    }
}