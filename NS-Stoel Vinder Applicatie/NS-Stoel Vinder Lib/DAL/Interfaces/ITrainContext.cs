using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface ITrainContext
    {
        bool GetAllTrains(Train train);
        List<Train> GetAll();
        bool GetTrainNumbers(Train train);
    }
}
