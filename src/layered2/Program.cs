using layered2.businesslogiclayer;
using layered2.dataaccesslayer;
using layered2.presentationlayer;

namespace layered2
{
    internal class Program
    {
        public static void Main(string[] args) {
            var dal = new DataacessLayer();
            var bl = new BusinesslogicLayer(dal);
            var pl = new PresentationLayer(bl);

            pl.Show(args);
        }
    }
}