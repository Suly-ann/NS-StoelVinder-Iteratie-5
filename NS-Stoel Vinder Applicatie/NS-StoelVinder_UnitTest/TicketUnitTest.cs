using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class TicketUnitTest
    {
        private readonly TicketTestContext ticketTestContext = new TicketTestContext();
        private TicketRepo ticketRepro;

       [TestInitialize]
        public void Setup()
        {
            ticketRepro = new TicketRepo(ticketTestContext);
        }

        [TestMethod]
        public void TestValidDisplayTicket()
        {

            //Ticket ticket = new Ticket(1, "Coen", "van de", "Berg", 15.00, "Beginstation", "Eindstation", DateTime.Today, 2, "C", 24);
            //testticket = ticketRepro.DisplayTicket(ticket);
            //Assert.AreEqual(testticket);
        }

        [TestMethod]
        public void TestNotValidDisplayTicket()
        {

            //Ticket ticket = new Ticket(4, "Henk", "", "Smith", 25.00, "Begin", "Eind", DateTime.Now, 1, "A", 10);
            //testticket = ticketRepro.DisplayTicket(ticket);
            //Assert.AreNotEqual(testticket);
        }

    }
}
