using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.BLL
{
    public class TicketRepo
    {
        private readonly ITicketContext context;
        public TicketRepo(ITicketContext context)
        {
            this.context = context;
        }
        public void DisplayTicket(Ticket ticket)
        {
            context.DisplayTicket(ticket);
        }

    }
}
