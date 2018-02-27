using System;
using clean.usecases;
using clean.usecases.dependencies;

namespace clean.adapters
{
    class Presenter : IPresenter
    {
        public void Display_results(int countTotal, int countDistinct) 
            => Console.WriteLine($"{countTotal} Worte, davon {countDistinct} verschieden");
    }
}