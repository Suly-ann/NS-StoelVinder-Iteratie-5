using NS_Stoel_Vinder_Lib.DAL;
using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;

namespace NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext
{
    public class TicketTestContext : ITicketContext
    {
        readonly Ticket ticket = new Ticket(1, "Coen", "van de", "Berg", 15.00, "Beginstation", "Eindstation", DateTime.Today, 2, "C", 24);

        public void DisplayTicket(Ticket ticketinfo)
        {
            _ = ticket.Firstname == ticketinfo.Firstname &&
            ticket.Insertion == ticketinfo.Insertion &&
            ticket.Lastname == ticketinfo.Lastname &&
            ticket.Price == ticketinfo.Price &&
            ticket.Startstation == ticketinfo.Startstation &&
            ticket.Endstation == ticketinfo.Endstation &&
            ticket.Time == ticketinfo.Time &&
            ticket.TrainClass == ticketinfo.TrainClass &&
            ticket.Row == ticketinfo.Row &&
            ticket.SeatID == ticketinfo.SeatID;
        }
    }
}
