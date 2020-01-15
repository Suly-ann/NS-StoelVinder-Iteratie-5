namespace StoelVinder.lib.DAL.Models
{
    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Station()
        {

        }

        public Station(string name)
        {
            Name = name;
        }
    }

    
}
