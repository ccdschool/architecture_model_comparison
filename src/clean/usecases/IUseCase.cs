namespace clean.usecases
{
    public interface IUseCase
    {
        void Count_words_in_file(string filename);
        void Count_words(string text);
    }
}