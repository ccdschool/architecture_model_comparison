using System.Collections.Generic;
using layered2.dataaccesslayer;
using NUnit.Framework;
using Moq;

namespace layered2.businesslogiclayer
{
    [TestFixture]
    public class BusinesslogicLayer_tests
    {
        [Test]
        public void Count_words()
        {
            var dal = new Mock<IDataacessLayer>();
            dal.Setup(x => x.Load_stopwords()).Returns(new HashSet<string>(new[] {"es"}));
            var sut = new BusinesslogicLayer(dal.Object);

            var (countTotal, countDistinct) = sut.Count_words("Es blaut die Nacht, die Sternlein blinken");
            
            Assert.AreEqual(6, countTotal);
            Assert.AreEqual(5, countDistinct);
        }
    }
}