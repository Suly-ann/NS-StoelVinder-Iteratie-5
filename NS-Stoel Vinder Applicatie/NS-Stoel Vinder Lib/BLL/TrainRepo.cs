using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.BLL
{
    public class TrainRepo
    {
        private readonly ITrainContext context;
        public TrainRepo(ITrainContext context)
        {
            this.context = context;
        }
        public bool GetAllTrains(Train train)
        {
            return context.GetAllTrains(train);
        }

        public List<Train> GetAll()
        {
            return context.GetAll();
        }

        public bool GetTrainNumbers(Train train)
        {
            return context.GetTrainNumbers(train);
        }
    }
}
