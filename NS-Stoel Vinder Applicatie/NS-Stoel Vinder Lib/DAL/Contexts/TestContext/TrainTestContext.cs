using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext
{
    public class TrainTestContext: ITrainContext
    {
        readonly Train train = new Train(1, 5462, 2018);

        public List<Train> GetAll()
        {
            Train trains = new Train();
            List<Train> Trains = new List<Train>();
            Trains.Add(trains);
            Trains.Add(trains);
            return Trains;
        }

        public bool GetAllTrains(Train trains)
        {
            if (train.ID == trains.ID && train.Trainnumber == trains.Trainnumber && train.Constructionyear == trains.Constructionyear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetTrainNumbers(Train trains)
        {

            if (train.Trainnumber == trains.Trainnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
