using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class SeatUnitTest
    {
        private readonly SeatTestContext seatTestContext = new SeatTestContext();
        private SeatRepo seatRepo;

        [TestInitialize]
        public void Setup()
        {
            seatRepo = new SeatRepo(seatTestContext);
        }

        //[TestMethod]
        //public void TestValidGetAllSeat1steKlasse()
        //{
        //    List<Seat> Seat = new List<Seat>();
        //    Seat = seatRepo.GetAllSeat1steKlasse();
        //    Assert.AreEqual(4, Seat.Count);
        //}

        //[TestMethod]
        //public void TestValidGetAllSeat2deKlasse()
        //{
        //    List<Seat> Seat = new List<Seat>();
        //    Seat = seatRepo.GetAllSeat2deKlasse();
        //    Assert.AreEqual(2, Seat.Count);
        //}

        [TestMethod]
        public void TestValidIsReserved()
        {
            Seat seat = new Seat(4, "A", false);
            bool testseat = seatRepo.IsReserved(seat);
            Assert.IsTrue(testseat);
        }
    }
}
