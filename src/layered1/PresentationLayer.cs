using System;

namespace layered1
{
    class PresentationLayer
    {
        public static void Show(string[] args) {
            if (args.Length > 0) {
                var (countTotal, countDistinct) = BusinesslogicLayer.Count_words_in_file(args[0]);
                Display_results(countTotal,countDistinct);
            }
            else {
                Console.Write("Text eingeben: ");
                var text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) return;
                
                var (countTotal, countDistinct) = BusinesslogicLayer.Count_words(text);
                Display_results(countTotal,countDistinct);
            }
        }

        static void Display_results(int countTotal, int countDistinct) 
            => Console.WriteLine($"{countTotal} Worte, davon {countDistinct} verschieden");
    }
}