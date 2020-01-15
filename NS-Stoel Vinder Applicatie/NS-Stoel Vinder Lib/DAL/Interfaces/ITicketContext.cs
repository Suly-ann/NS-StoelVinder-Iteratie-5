using StoelVinder.lib.DAL.Models;
using System;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface ITicketContext
    {
        void DisplayTicket(string firstname, string insertion, string lastname, string startstation, string endstation, DateTime time, int trainclass);

        Account GetByName(string name);

    }
}
