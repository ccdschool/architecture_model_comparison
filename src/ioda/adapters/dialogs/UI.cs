using System;

namespace ioda.adapters.dialogs
{
    class UI
    {
        public void Ask_user_for_text(Action<string> onText) {
            Console.Write("Text eingeben: ");
            var text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text)) return;

            onText(text);
        }
        
        
        public void Display_results(int countTotal, int countDistinct) 
            => Console.WriteLine($"{countTotal} Worte, davon {countDistinct} verschieden");
    }
}