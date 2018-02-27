using ioda.adapters.dialogs;
using ioda.adapters.providers;
using ioda.domain;

namespace ioda
{
    internal class Controller
    {
        public static void Main(string[] args) {
            var cmd = new Commandline(args);
            var da = new Dataaccess();
            var ui = new UI();
            var app = new Controller(cmd, ui, da);
            
            app.Run(args);
        }
        
        #region Ctor
        private readonly Commandline _cmd;
        private readonly UI _ui;
        private readonly Dataaccess _da;

        Controller(Commandline cmd, UI ui, Dataaccess da) {
            _cmd = cmd;
            _ui = ui;
            _da = da;
        }
        #endregion
        
        void Run(string[] args) {
            _cmd.Determine_text_source(
                onFile: Count_words_in_file,
                onUser: Count_words_in_user_entered_text);
        }

        void Count_words_in_file(string filename) {
            var text = _da.Load_text(filename);
            Count_words(text);
        }

        void Count_words_in_user_entered_text() {
            _ui.Ask_user_for_text(
                Count_words);
        }

        void Count_words(string text) {
            var stopwords = _da.Load_stopwords();
            var result = Businesslogic.Count_words(text, stopwords);
            _ui.Display_results(result.CountTotal, result.CountDistinct);
        }
    }
}