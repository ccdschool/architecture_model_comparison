using clean.adapters;
using clean.domain;
using clean.usecases;

namespace clean
{
    internal class Program
    {
        public static void Main(string[] args) {
            var da = new Dataaccess();
            var bl = new Businesslogic(da);
            var pre = new Presenter();
            var uc = new UseCase(bl, da, pre);
            var controller = new Controller(uc);
            
            controller.Show(args);
        }
    }
}