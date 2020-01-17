using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class TravelplanUnitTest
    {
        private readonly TravelplanTestContext travelplanTestContext = new TravelplanTestContext();
        private TravelplanRepo travelplanRepro;

       [TestInitialize]
        public void Setup()
        {
            travelplanRepro = new TravelplanRepo(travelplanTestContext);
        }

        [TestMethod]
        public void TestGetAllStations()
        {
            List<Station> Stations = new List<Station>();
            Stations = travelplanRepro.GetStationsOnly();
            Assert.AreEqual(1, Stations.Count);
        }

        [TestMethod]
        public void TestValidGetTravelplans()
        {
            Travelplan travelplan = new Travelplan("Beginstation", "Eindstation");
            List<Travelplan> Stations = travelplanRepro.GetTravelplans(travelplan);
            Assert.AreEqual(1, Stations.Count);
        }

        [TestMethod]
        public void TestNotValidGetTravelplans()
        {
            Travelplan travelplan = new Travelplan("Eind", "Begin");
            List<Travelplan> Stations = travelplanRepro.GetTravelplans(travelplan);
            Assert.AreNotEqual(1, Stations.Count);
        }

    }
}
