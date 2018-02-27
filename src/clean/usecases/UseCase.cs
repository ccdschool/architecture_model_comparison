using clean.domain;
using clean.usecases.dependencies;

namespace clean.usecases
{
    class UseCase : IUseCase
    {
        private readonly IBusinesslogic _bl;
        private readonly ITexts _txt;
        private readonly IPresenter _ui;

        public UseCase(IBusinesslogic bl, ITexts txt, IPresenter ui) {
            _bl = bl;
            _txt = txt;
            _ui = ui;
        }
        

        public void Count_words_in_file(string filename) {
            var text = _txt.Retrieve(filename);
            Count_words(text);
        }

        public void Count_words(string text) {
            var (countTotal, countDistinct) = _bl.Count_words(text);
            _ui.Display_results(countTotal, countDistinct);
        }
    }
}