using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.BLL
{
    public class HistoryRepo
    {
        private readonly IHistoryContext context;

        public HistoryRepo(IHistoryContext context)
        {
            this.context = context;
        }
        internal void DisplayHistory(HistoryModel history)
        {
            context.DisplayHistory(history.Firstname, history.Insertion, history.Lastname, history.Startstation, history.Endstation, history.Time, history.TrainClass);
        }
    }
}
