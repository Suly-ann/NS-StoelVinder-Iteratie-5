using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.DAL.Models;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class WagonUnitTest
    {
        private readonly WagonTestContext wagonTestContext = new WagonTestContext();

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void TestValidTravelplan()
        {
            Wagon wagon = new Wagon(9, 4, 1, false);
            bool testwagon = wagonTestContext.WagonContext(wagon.Wagonnumber, wagon.TrainClass, wagon.Toilet);
            Assert.IsTrue(testwagon);
        }

        [TestMethod]
        public void TestNotValidTravelplan()
        {
            Wagon wagon = new Wagon(5, 5, 2, true);
            bool testwagon = wagonTestContext.WagonContext(wagon.Wagonnumber, wagon.TrainClass, wagon.Toilet);
            Assert.IsFalse(testwagon);

        }
    }
}
