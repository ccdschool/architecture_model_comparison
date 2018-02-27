using System;
using clean.usecases;

namespace clean.adapters
{
    public class Controller
    {
        private readonly IUseCase _uc;
        
        public Controller(IUseCase uc) { _uc = uc; }
        
        
        public void Show(string[] args) {
            if (args.Length > 0)
                _uc.Count_words_in_file(args[0]);
            else {
                Console.Write("Text eingeben: ");
                var text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) return;
                
                _uc.Count_words(text);
            }
        }
    }
}