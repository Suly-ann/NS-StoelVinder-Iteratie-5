using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class TrainUnitTest
    {
        private readonly TrainTestContext trainTestContext = new TrainTestContext();
        private TrainRepo trainRepro;

       [TestInitialize]
        public void Setup()
        {
            trainRepro = new TrainRepo(trainTestContext);
        }
        [TestMethod]
        public void TestValidGetAll()
        {
            List<Train> Train = new List<Train>();
            Train = trainRepro.GetAll();
            Assert.AreEqual(2, Train.Count);
        }

        [TestMethod]
        public void TestNotValidGetAll()
        {
            List<Train> Train = new List<Train>();
            Train = trainRepro.GetAll();
            Assert.AreNotEqual(4, Train.Count);
        }

        [TestMethod]
        public void TestValidGetAllTrains()
        {
            Train train = new Train(1, 5462, 2018);
            bool testtrain = trainRepro.GetAllTrains(train);
            Assert.IsTrue(testtrain);
        }

        [TestMethod]
        public void TestNotValidGetAllTrains()
        {
            Train train = new Train(3, 7845, 1990);
            bool testtrain = trainRepro.GetAllTrains(train);
            Assert.IsFalse(testtrain);
        }

        [TestMethod]
        public void TestValidGetTrainNumbers()
        {
            Train train = new Train(1, 5462, 2018);
            bool testtrain = trainRepro.GetTrainNumbers(train);
            Assert.IsTrue(testtrain);
        }

        [TestMethod]
        public void TestNotValidGetTrainNumbers()
        {
            Train train = new Train(3, 7845, 1990);
            bool testtrain = trainRepro.GetAllTrains(train);
            Assert.IsFalse(testtrain);
        }

    }
}
