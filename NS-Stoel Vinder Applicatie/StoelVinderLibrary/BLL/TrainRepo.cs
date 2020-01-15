using StoelVinder.lib.DAL.Interfaces;

namespace StoelVinder.lib.BLL
{
    public class TrainRepo
    {
        private readonly ITrainContext context;
        public TrainRepo(ITrainContext context)
        {
            this.context = context;
        }
    }
}
