using System;
using layered2.businesslogiclayer;

namespace layered2.presentationlayer
{
    class PresentationLayer
    {
        private readonly IBusinesslogicLayer _bl;
        
        public PresentationLayer(IBusinesslogicLayer bl) { _bl = bl; }
        
        
        public void Show(string[] args) {
            if (args.Length > 0) {
                var (countTotal, countDistinct) = _bl.Count_words_in_file(args[0]);
                Display_results(countTotal,countDistinct);
            }
            else {
                Console.Write("Text eingeben: ");
                var text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) return;
                
                var (countTotal, countDistinct) = _bl.Count_words(text);
                Display_results(countTotal,countDistinct);
            }
        }

        static void Display_results(int countTotal, int countDistinct) 
            => Console.WriteLine($"{countTotal} Worte, davon {countDistinct} verschieden");
    }
}