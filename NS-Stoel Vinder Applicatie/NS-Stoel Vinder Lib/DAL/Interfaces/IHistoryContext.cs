using System;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface IHistoryContext
    {
        void DisplayHistory(string firstname, string insertion, string lastname, string startstation, string endstation, DateTime time, int trainclass);
    }
}
