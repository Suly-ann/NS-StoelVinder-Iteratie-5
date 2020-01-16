using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Models;
using System;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class TravelplanUnitTest
    {
        private readonly TravelplanTestContext travelplanTestContext = new TravelplanTestContext();

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void TestValidTravelplan()
        {
            Travelplan travelplan = new Travelplan("Beginstation", "Eindstation");
            bool testtravelplan = travelplanTestContext.TravelplanContext(travelplan.Startstation, travelplan.Endstation);
            Assert.IsTrue(testtravelplan);
        }

        [TestMethod]
        public void TestNotValidTravelplan()
        {
            Travelplan travelplan = new Travelplan("Beginstation", "Beginstation");
            bool testtravelplan = travelplanTestContext.TravelplanContext(travelplan.Startstation, travelplan.Endstation);
            Assert.IsFalse(testtravelplan);

        }

        [TestMethod]
        public void TestValidTime()
        {
            Travelplan travelplan = new Travelplan(DateTime.Today, 11, 5462);
            bool testtravelplan = travelplanTestContext.TimeContext(travelplan.Time, travelplan.Railstation, travelplan.Trainnr);
            Assert.IsTrue(testtravelplan);
        }

        [TestMethod]
        public void TestNotValidRegistration()
        {
            Travelplan travelplan = new Travelplan(DateTime.Now, 5, 7864);
            bool testtravelplan = travelplanTestContext.TimeContext(travelplan.Time, travelplan.Railstation, travelplan.Trainnr);
            Assert.IsFalse(testtravelplan);

        }

    }
}
